//Paliativo, devido ao prazo. 
//Para poder mudar a lógica de carregamento da página, forcei a seleção da aba após o refresh da página.

var path = window.location.pathname;    
if (path.includes("SearchProduct")) {
    $(document).ready(function () {
        $("#nav-client-tab").removeClass("active");
        $("#nav-client").removeClass("active");
        $("#nav-client").removeClass("show");
        $("#nav-product-tab").addClass("active");
        $("#nav-product").addClass("active show");        
    });
}

if (path.includes("SearchSale")) {
    $(document).ready(function () {
        $("#nav-client-tab").removeClass("active");
        $("#nav-client").removeClass("active");
        $("#nav-client").removeClass("show");
        $("#nav-sales-tab").addClass("active");
        $("#nav-sales").addClass("active show");        
    });
}

function confirmDelete(isClient, isProduct) {
    var message = "";
    if (isClient) {
        message = "Tem certeza que deseja excluir este registro? Os registros de venda vinculados este cliente também serão perdidos!";
    } else if(isProduct) {
        message = "Tem certeza que deseja excluir este registro? Os registros de venda vinculados este produto também serão perdidos!";
    } else { 
        message = "Tem certeza que deseja excluir este registro?";
    }

    confirm(message);
}

$("#fecharModal").click(function () {    
    $(".clienteNome").val('');
    $(".cidadeNome").val('');
    $(".cidadeNome").removeClass('is-invalid');
    $(".erroCidadeCliente").text('');
    $(".erroCidadeCliente").addClass('d-none');
    $(".clienteNome").removeClass('is-invalid');
    $(".erroNomeCliente").text('');
    $(".erroNomeCliente").addClass('d-none');
});

$("#inserirCliente").click(function() {
    var cliente = {
        clienteId: $(".clienteId").val(),
        clienteNome: $(".clienteNome").val(),
        cidadeNome: $(".cidadeNome").val()
    }

    if (isCamposValidos(cliente)) {
        console.log('tudo certo');
    } else {
        console.log('campos invalidos');
    }
}); 

function isCamposValidos(cliente) {
    let isNomeValido = ValidarNome(cliente.clienteNome);
    let isCidadeValida = ValidarCidade(cliente.cidadeNome);

    return isNomeValido && isCidadeValida;
}

function ValidarNome(nome) {
    if (nome == '' || nome == undefined) {
        $(".clienteNome").addClass('is-invalid');
        $(".erroNomeCliente").text('Campo obrigatório!');
        $(".erroNomeCliente").removeClass('d-none');

        return false;
    }

    return true;
}

function ValidarCidade(nome) {
    if (nome == '' || nome == undefined) {
        $(".cidadeNome").addClass('is-invalid');
        $(".erroCidadeCliente").text('Campo obrigatório!');
        $(".erroCidadeCliente").removeClass('d-none');
        return false;
    }

    return true;
}