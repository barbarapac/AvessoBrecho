using EcommerceAvessoBrecho.Models;

namespace EcommerceAvessoBrecho.ViewsModels
{
    public class FinalizaPedidoViewModel
    {
        public FinalizaPedidoViewModel(Pedido _pedido)
        {
            pedido = _pedido;
        }

        public Pedido pedido { get; }
    }
}
