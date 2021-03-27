using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using EcommerceAvessoBrecho.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IActionResult> Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                await _pedidoRepository.AddItemAsync(codigo);
            }

            var pedido = await _pedidoRepository.GetPedidoAsync();
            List<ItemPedido> itens = pedido.ItensPedido;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }

        public async Task<IActionResult> Cliente()
        {
            var pedido = await _pedidoRepository.GetPedidoAsync();

            if (pedido == null)
            {
                return RedirectToAction("BuscaProdutos");
            }

            return View(pedido.Cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resumo(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                return View(await _pedidoRepository.UpdateClienteAsync(cliente));
            }
            return RedirectToAction("Cliente");
        }
    }
}
