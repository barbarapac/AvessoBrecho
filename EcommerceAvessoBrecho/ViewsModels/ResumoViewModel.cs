using EcommerceAvessoBrecho.Models;

namespace EcommerceAvessoBrecho.ViewsModels
{
    public class ResumoViewModel
    {
        public ResumoViewModel(Pedido _pedido)
        {
            pedido = _pedido;
        }

        public Pedido pedido { get; }

    }
}
