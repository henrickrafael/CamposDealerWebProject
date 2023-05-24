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

    var result = confirm(message);

    return result;
}

$("#inserirCliente").click(function() {
    var modalItem = {
        objectId: $(".inputIdCliente").val(),
        objectInputText1: $(".inputTextNome").val(),
        objectInputText2: $(".inputTextCidade").val()
    }

    if (!isCamposInvalidos(modalItem)) {
        InserirClienteAsync(modalItem);
    } else {
        alertarCampoObrigatrio();
    }
}); 

function limparModal(modalItem) {
    modalItem.objectInputText1.val('');
    modalItem.objectInputText2.val('');
}

$("#inserirProduto").click(function () {
    var modalItem = {
        objectId: $(".inputIdCliente").val(),
        objectInputText1: $(".inputTextDesc").val(),
        objectInputText2: $(".inputTextVlr").val()
    }

    if (!isCamposInvalidos(modalItem)) {
        InserirProdutoAsync(modalItem);
    } else {
        alertarCampoObrigatrio();
    }
}); 

function isCamposInvalidos(modalItem) {
    return (modalItem.objectInputText1 == '' || modalItem.objectInputText1 == undefined) || (modalItem.objectInputText2 == '' || modalItem.objectInputText2 == undefined);
}

function alertarCampoObrigatrio() {
    alert("Todos os campos são de preenchimento obrigatório!");
}

function InserirClienteAsync(modalItem) {
    var cliente = {
        IdCliente: modalItem.objectId,
        NmCliente: modalItem.objectInputText1,
        Cidade: modalItem.objectInputText2
    }

    console.log(cliente.IdCliente);

    if (parseInt(cliente.IdCliente) > 0) {
        AtualizarClienteAsync(cliente);
    }

    $.ajax({
        url: "Home/AddCliente",
        method: 'POST',
        data: {
            cliente: cliente
        },
        success: function () {
            alert("Cliente inserido com sucesso!");
            location.reload();
        }
    })
}

function AtualizarClienteAsync(cliente) {

    $.ajax({
        url: "Home/UpdateCliente",
        method: 'POST',
        data: {
            cliente: cliente
        },
        success: function () {
            alert("Cliente atualizado com sucesso!");
            location.reload();
        }
    })

}

function RemoverClienteAsync(confirmDelete, idCliente) {
    if (!confirmDelete) {
        return;
    }

    $.ajax({
        url: "Home/DeleteCliente",
        method: 'POST',
        data: {
            idCliente: idCliente
        },
        success: function () {
            alert("Cliente removido com sucesso!");
            location.reload();
        }
    });
    
}

function mostrarModal(nomeId) {
    new bootstrap.Modal($(nomeId), {}).show();
}

function GetClienteByIdAsync(idCliente) {
    $.ajax({
        url: "Home/GetClienteById",
        method: 'GET',
        data: {
            idCliente: idCliente
        },
        success: function (cliente) { 
            mostrarModal("#crudModalClient"); 
            $(".inputIdCliente").val(cliente.idCliente);
            $(".inputTextNome").val(cliente.nmCliente);
            $(".inputTextCidade").val(cliente.cidade);
        }
    });
}

