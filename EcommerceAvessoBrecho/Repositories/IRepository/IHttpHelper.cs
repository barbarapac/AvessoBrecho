using EcommerceAvessoBrecho.Models;
using Microsoft.Extensions.Configuration;

namespace EcommerceAvessoBrecho.Repositories.IRepository
{
    public interface IHttpHelper
    {
        IConfiguration Configuration { get; }
        int? GetPedidoId();
        void SetPedidoId(int pedidoId);
        void ResetPedidoId();
        void SetCliente(Cliente cliente);
        Cliente GetCadastro();
    }
}
