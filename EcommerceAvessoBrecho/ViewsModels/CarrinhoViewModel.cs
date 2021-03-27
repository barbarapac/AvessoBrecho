using EcommerceAvessoBrecho.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceAvessoBrecho.ViewsModels
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(IList<ItemPedido> itens)
        {
            Itens = itens;
        }

        public IList<ItemPedido> Itens { get; }

        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);

    }
}
