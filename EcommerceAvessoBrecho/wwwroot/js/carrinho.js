class Carrinho {
    
    getData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]');
        var itemId = $(linhaDoItem).attr('item-id');
        var novaQuantidade = $(linhaDoItem).find('input').val();

        return {
            Id: itemId,
            Quantidade: novaQuantidade
        };
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}



