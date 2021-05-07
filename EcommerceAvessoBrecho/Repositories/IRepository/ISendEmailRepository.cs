using EcommerceAvessoBrecho.Models;

namespace EcommerceAvessoBrecho.Repositories.IRepository
{
    public interface ISendEmailRepository
    {
        void EnviarEmailPedido(Pedido pedido);
    }
}
