using EcommerceAvessoBrecho.Models;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Repositories.IRepository
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetPedidoAsync();
        Task AddItemAsync(string codigo);
        Task<Pedido> UpdateClienteAsync(Cliente cliente);
        Task<ItemPedido> GetItemPedidoAsync(int itemPedidoId);
        Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(int itemPedidoId);
        Task AplicaCupomDescontoAsync(bool aplicaCupom = false);
        Task<Pedido> FinalizaPedidoAsync(bool aplicaCupom = false);
    }
}
