class Cliente {
    changePesquisarCEP() {
        let cep = document.getElementById("cep").value;

        if (cep.length == 8) {
            $.ajax({
                url: '/consultacep/buscacep',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(cep)
            }).done(function (response) {
                var res = response;

                if (res != null) {
                    document.querySelector("[name='endereco']").value = res.logradouro;
                    document.querySelector("[name='municipio']").value = res.localidade;
                    document.querySelector("[name='UF']").value = res.uf;
                    document.querySelector("[name='bairro']").value = res.bairro;
                } else {
                    alert("CEP não encontrado!");
                }                
            });
        }
    }
}

var cliente = new Cliente();