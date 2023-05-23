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
    let message = "Tem certeza que deseja excluir este registro?"

    if (isClient) {
        message = "Tem certeza que deseja excluir este registro? Os registros de venda vinculados este cliente também serão perdidos!";
    } else if(isProduct) {
        message = "Tem certeza que deseja excluir este registro? Os registros de venda vinculados este produto também serão perdidos!";
    } 

    confirm(message);
}

$("#inserirCliente").click(function() {
    var modalItem = {
        objectId: $(".inputIdCliente").val(),
        objectInputText1: $(".inputTextNome").val(),
        objectInputText2: $(".inputTextCidade").val()
    }

    if (!isCamposInvalidos(modalItem)) {
        console.log('Tudo certo');
    } else {
        alertarCampoObrigatrio();
    }
}); 

$("#inserirProduto").click(function () {
    var modalItem = {
        objectId: $(".inputIdProduto").val(),
        objectInputText1: $(".inputTextDesc").val(),
        objectInputText2: $(".inputTextVlr").val()
    }

    if (!isCamposInvalidos(modalItem)) {
        console.log('Tudo certo');
    } else {
        alertarCampoObrigatrio();
    }
}); 

function isCamposInvalidos(modalItem) {
    return modalItem.objectInputText1 == '' || modalItem.objectInputText2 == undefined;
}

function alertarCampoObrigatrio() {
    alert("Todos os campos são de preenchimento obrigatório!");
}
