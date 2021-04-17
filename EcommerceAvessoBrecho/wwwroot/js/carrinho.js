class Carrinho {

    clickRemoveItemCarrinho(button){
        let data = this.getData(button);
        this.postQuantidade(data);
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
            url: '/pedido/removequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data.itemPedidoId)
        }).done(function (response) {
            location.reload();
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}



