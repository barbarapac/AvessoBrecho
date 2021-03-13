using EcommerceAvessoBrecho.Models;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Repositories.IRepository
{
    public interface IClienteRepository
    {
        Task<Cliente> UpdateAsync(int clienteId, Cliente novoCliente);
    }
}
