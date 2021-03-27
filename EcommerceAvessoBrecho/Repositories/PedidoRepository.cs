using System;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
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
                           .Where(p => p.Codigo == codigo)
                           .SingleOrDefaultAsync();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = await GetPedidoAsync();

            var itemPedido = await
                                context.Set<ItemPedido>()
                                .Where(i => i.Produto.Codigo == codigo
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

        public async Task RemoveItemPedidoAsync(int itemPedidoId)
        {
            context.Set<ItemPedido>()
                .Remove(await GetItemPedidoAsync(itemPedidoId));
        }

        public async Task<Pedido> UpdateClienteAsync(Cliente cliente)
        {
            var pedido = await GetPedidoAsync();
            await clienteRepository.UpdateAsync(pedido.Cliente.Id, cliente);
            httpHelper.ResetPedidoId();
            httpHelper.SetCliente(pedido.Cliente);
            return pedido;
        }
    }
}
