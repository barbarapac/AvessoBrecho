using System;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using EcommerceAvessoBrecho.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EcommerceAvessoBrecho.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {

        private readonly IHttpContextAccessor contextAccessor;
        private readonly IHttpHelper httpHelper;
        private readonly IClienteRepository clienteRepository;

        public PedidoRepository(IConfiguration configuration, AppDbContext contexto,
               IHttpContextAccessor contextAccessor, IHttpHelper sessionHelper,
               IClienteRepository clienteRepository) : base(configuration, contexto)
        {
            this.contextAccessor = contextAccessor;
            this.httpHelper = sessionHelper;
            this.clienteRepository = clienteRepository;
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
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                await
                    context.Set<ItemPedido>()
                    .AddAsync(itemPedido);

                await context.SaveChangesAsync();
            }
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
                var carrinhoViewModel = new CarrinhoViewModel(pedido.ItensPedido);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }
            
            throw new ArgumentException("ItemPedido não encontrado");
        }

        public async Task<Pedido> UpdateClienteAsync(Cliente cliente)
        {
            var pedido = await GetPedidoAsync();
            await clienteRepository.UpdateAsync(pedido.Cliente.Id, cliente);
            httpHelper.ResetPedidoId();
            httpHelper.SetCliente(pedido.Cliente);
            return pedido;
        }

        private async Task RemoveItemPedidoAsync(int itemPedidoId)
        {
            context.Set<ItemPedido>()
                .Remove(await GetItemPedidoAsync(itemPedidoId));
        }
    }
    
}
