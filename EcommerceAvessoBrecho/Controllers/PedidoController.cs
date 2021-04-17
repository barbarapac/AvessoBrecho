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

        public async Task<IActionResult> Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                await _pedidoRepository.AddItemAsync(codigo);
            }

            var pedido = await _pedidoRepository.GetPedidoAsync();
            pedido.VlTotalPedido = pedido.ItensPedido.Sum(i => i.Quantidade * i.PrecoUnitario);

            List<ItemPedido> itens = pedido.ItensPedido;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
                     
            return base.View(carrinhoViewModel);
        }

        public async Task<IActionResult> AplicaDesconto(string cupom)
        {
            var pedido = await _pedidoRepository.GetPedidoAsync();

            if (pedido == null)
            {
                return RedirectToAction("BuscaProdutos");
            }

            if (!Equals(cupom, "AVESSO10"))
                base.Unauthorized("Cupom inválido");

            var totPedido = pedido.ItensPedido.Sum(i => i.Quantidade * i.PrecoUnitario);
            pedido.VlTotalPedido = totPedido - (totPedido * (decimal)0.010);

            return base.View();
        }

        public async Task<IActionResult> Cliente(string cupom)
        {
            var pedido = await _pedidoRepository.GetPedidoAsync();

            return View(pedido.Cliente);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveQuantidade([FromBody] string itemPedidoId)
        {
            try
            {
                await _pedidoRepository.RemoveItemPedidoAsync(int.Parse(itemPedidoId));
                return Ok();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

    }
}
