using EcommerceAvessoBrecho.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository; 
        }

        public async Task<IActionResult> ListarProdutosTelaInicial()
        {
            return View(await produtoRepository.GetProdutosAsync());
        }
        
        public async Task<IActionResult> ListarProdutosEmPromocao()
        {
            return View(await produtoRepository.GetProdutosPromocaoAsync());
        }

        public async Task<IActionResult> PesquisaProduto(string pesquisa)
        {
            return View(await produtoRepository.GetProdutosAsync(pesquisa));
        }

        public async Task<IActionResult> DetalheProduto(int id)
        {
            var produto = await produtoRepository.GetProdutoById(id);

            return View(produto);
        }

    }
}
