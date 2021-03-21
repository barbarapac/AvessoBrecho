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

        public BuscaProdutosViewModel(Produto produto)
        {
            Produto = produto;
        }

        public IList<Produto> Produtos { get; }
        public Produto Produto { get; set;  }
        public string Pesquisa { get; set; }
    }
}
