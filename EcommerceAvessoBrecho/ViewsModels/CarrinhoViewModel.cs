using EcommerceAvessoBrecho.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceAvessoBrecho.ViewsModels
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(IList<ItemPedido> itens, decimal vlDesconto)
        {
            Itens = itens;
            VlDesconto = vlDesconto;
        }

        public decimal VlDesconto { get; }
        public IList<ItemPedido> Itens { get; }
        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);

    }
}
