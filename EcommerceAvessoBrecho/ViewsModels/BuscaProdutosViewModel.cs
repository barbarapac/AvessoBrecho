using EcommerceAvessoBrecho.Models;
using System.Collections.Generic;

namespace EcommerceAvessoBrecho.ViewsModels
{
    public class BuscaProdutosViewModel
    {
        public BuscaProdutosViewModel(IList<Produto> produtos, string pesquisa)
        {
            Produtos = produtos;
            Pesquisa = pesquisa;
        }

        public IList<Produto> Produtos { get; }
        public string Pesquisa { get; set; }
    }
}
