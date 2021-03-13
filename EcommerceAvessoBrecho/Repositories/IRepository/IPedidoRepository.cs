using EcommerceAvessoBrecho.Models;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Repositories.IRepository
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetPedidoAsync();
        Task AddItemAsync(string codigo);
        Task<Pedido> UpdateCadastroAsync(Cliente cliente);
        //Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido);
    }
}
