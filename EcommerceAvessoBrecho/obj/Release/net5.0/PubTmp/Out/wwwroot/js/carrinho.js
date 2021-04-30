class Carrinho {

    clickRemoveItemCarrinho(button){
        let data = this.getData(button);
        this.postQuantidade(data);
    }

    clickAddProdPedido(codItem) {
        $.ajax({
            url: '/pedido/additemcarrinho',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(codItem.toString())
        }).done(function (response) {
            window.location.href = "../pedido/carrinho";
        });
    }

    getData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]');
        var itemPedidoId = $(linhaDoItem).attr('item-id');

        return {
            itemPedidoId
        };
    }

    postQuantidade(data) {
        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data.itemPedidoId)
        }).done(function (response) {
            window.location.href = "../pedido/carrinho";
        });
    }       

    clickAddCupomDesconto(desconto) {
        let cupom = document.getElementById("inputCupom").value;

        if (desconto == 0) {
            if (cupom == 'AVESSO10') {
                $.ajax({
                    url: '/pedido/aplicacupomdesconto',
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(cupom),
                    success: function () {
                        window.location.href = "../pedido/carrinho";
                    }
                }).done(function (response) {
                    window.location.href = "../pedido/carrinho";
                });
            } else {
                alert("Cupom Inválido");
            }
        } else {
            alert("Você já possui um cupom aplicado.");
        }
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}



