using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using EcommerceAvessoBrecho.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resumo(Cliente cliente)
        {
            if (!ModelState.IsValid) 
                return View("Cliente");

            await _pedidoRepository.UpdateClienteAsync(cliente);
            var pedido = await _pedidoRepository.GetPedidoAsync();
            ResumoViewModel resumoViewModel = new ResumoViewModel(pedido);
            return base.View(resumoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdditemCarrinho([FromBody]string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                await _pedidoRepository.AddItemAsync(codigo);
            }

            return Ok();
        }

        public async Task<IActionResult> Carrinho()
        {
            var pedido = await _pedidoRepository.GetPedidoAsync();
            await _pedidoRepository.AplicaCupomDescontoAsync();

            List<ItemPedido> itens = pedido.ItensPedido;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens, itens.Count > 0 ? pedido.VlDesconto : 0);

            return base.View(carrinhoViewModel);
        }

        public async Task<IActionResult> Cliente(string cupom)
        {
            var pedido = await _pedidoRepository.GetPedidoAsync();

            return View(pedido.Cliente);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantidade([FromBody] string itemPedidoId)
        {
            await _pedidoRepository.UpdateQuantidadeAsync(int.Parse(itemPedidoId));
            return RedirectToAction("carrinho");
        }

        [HttpPost]
        public async Task<IActionResult> AplicaCupomDesconto([FromBody] string cupom)
        {
            await _pedidoRepository.AplicaCupomDescontoAsync(true);
            return RedirectToAction("carrinho");
        }

        public async Task<IActionResult> FinalizaPedido()
        {
            var pedido = await _pedidoRepository.FinalizaPedidoAsync();
            FinalizaPedidoViewModel finalizaPedidoViewModel = new FinalizaPedidoViewModel(pedido);
            return base.View(finalizaPedidoViewModel);
        }
    }
}
