using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using EcommerceAvessoBrecho.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {

        private readonly IHttpContextAccessor contextAccessor;
        private readonly IHttpHelper httpHelper;
        private readonly IClienteRepository clienteRepository;
        private readonly ISendEmailRepository sendEmailRepository;

        public PedidoRepository(IConfiguration configuration, AppDbContext contexto,
               IHttpContextAccessor contextAccessor, IHttpHelper sessionHelper,
               IClienteRepository clienteRepository, ISendEmailRepository sendEmailRepository) : base(configuration, contexto)
        {
            this.contextAccessor = contextAccessor;
            this.httpHelper = sessionHelper;
            this.clienteRepository = clienteRepository;
            this.sendEmailRepository = sendEmailRepository;
        }

        public async Task AddItemAsync(string codigo)
        {
            var produto = await
                           context.Set<Produto>()
                           .Where(p => p.Codigo.Equals(codigo.PadLeft(3, '0')))
                           .SingleOrDefaultAsync();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = await GetPedidoAsync();

            var itemPedido = await
                                context.Set<ItemPedido>()
                                .Where(i => i.Produto.Codigo == codigo.PadLeft(3, '0')
                                        && i.Pedido.Id == pedido.Id)
                                .SingleOrDefaultAsync();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Promocao ? produto.PrecoPromocional : produto.Preco);
                await
                    context.Set<ItemPedido>()
                    .AddAsync(itemPedido);

                await context.SaveChangesAsync();
            }

            if (pedido != null)
            {
                pedido.VlTotalPedido += itemPedido.PrecoUnitario;
                context.Set<Pedido>().Update(pedido);
                await context.SaveChangesAsync();
            }

            if (pedido.VlDesconto > 0) await AplicaCupomDescontoAsync(true);
        }

        public async Task<ItemPedido> GetItemPedidoAsync(int itemPedidoId)
        {
            return await context
                    .Set<ItemPedido>()
                    .Where(ip => ip.Id == itemPedidoId)
                    .SingleOrDefaultAsync();
        }

        public async Task<Pedido> GetPedidoAsync()
        {
            var pedidoId = httpHelper.GetPedidoId();
            var pedido = await dbSet
                .Include(p => p.ItensPedido)
                .ThenInclude(i => i.Produto)
                .ThenInclude(prod => prod.Categoria)
                .Include(p => p.Cliente)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefaultAsync();

            if (pedido == null)
            {
                pedido = new Pedido(httpHelper.GetCadastro());
                await dbSet.AddAsync(pedido);
                await context.SaveChangesAsync();
                httpHelper.SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        public async Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(int id)
        {
            var itemPedidoDB = await GetItemPedidoAsync(id);

            if (itemPedidoDB != null)
            {
                await RemoveItemPedidoAsync(itemPedidoDB.Id);
                await context.SaveChangesAsync();

                var pedido = await GetPedidoAsync();

                if (pedido.VlDesconto > 0) 
                    await AplicaCupomDescontoAsync(true);
                
                var carrinhoViewModel = new CarrinhoViewModel(pedido.ItensPedido, pedido.ItensPedido.Count > 0 
                                                                                  ? pedido.VlDesconto 
                                                                                  : 0);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        public async Task<Pedido> UpdateClienteAsync(Cliente cliente)
        {
            var pedido = await GetPedidoAsync();
            await clienteRepository.UpdateAsync(pedido.Cliente.Id, cliente);
            httpHelper.SetCliente(pedido.Cliente);
            return pedido;
        }

        private async Task RemoveItemPedidoAsync(int itemPedidoId)
        {
            context.Set<ItemPedido>()
                .Remove(await GetItemPedidoAsync(itemPedidoId));
        }

        public async Task AplicaCupomDescontoAsync(bool aplicaCupom = false)
        {
            var pedido = await GetPedidoAsync();

            if (pedido.VlTotalPedido > 0)
            {
                var totPedido = pedido.ItensPedido.Sum(i => i.Quantidade * i.PrecoUnitario);
                if (aplicaCupom) pedido.VlDesconto = (totPedido * (decimal)0.10);
                pedido.VlTotalPedido = totPedido - pedido.VlDesconto;
                context.Set<Pedido>().Update(pedido);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Pedido> FinalizaPedidoAsync(bool aplicaCupom = false)
        {
            var pedido = await GetPedidoAsync();
            sendEmailRepository.EnviarEmailPedido(pedido);
            httpHelper.ResetPedidoId();
            httpHelper.ResetClienteId();
            return pedido;
        }
        

        //private void EnviaEmailTeste(string email, string nome)
        //{

        //    MailMessage mail = new MailMessage();

        //    mail.From = new MailAddress("avesso.brecho.fake@gmail.com");
        //    mail.To.Add(email); // para
        //    mail.Subject = "Teste"; // assunto
        //    mail.Body = "Testando mensagem de e-mail"; // mensagem

        //    using (var smtp = new SmtpClient("smtp.gmail.com"))
        //    {
        //        try
        //        {
        //            smtp.EnableSsl = true; // GMail requer SSL
        //            smtp.Port = 587;       // porta para SSL
        //            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
        //            smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

        //            // seu usuário e senha para autenticação
        //            smtp.Credentials = new NetworkCredential("avesso.brecho.fake@gmail.com", "avessofake1");

        //            // envia o e-mail
        //            smtp.Send(mail);
        //        }
        //        catch (Exception ex)
        //        {

        //            //null;
        //        }
        //    }

    }
}
