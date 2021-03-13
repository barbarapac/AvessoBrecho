using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.ViewsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Repositories.IRepository
{
    public interface IProdutoRepository
    {
        Task SaveProdutosAsync(List<Roupa> roupas);
        Task<IList<Produto>> GetProdutosAsync();
        Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa);
    }
}
