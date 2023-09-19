$(document).ready(function () {
    $("#nav-client-view").load("/Clientes");
    $("#nav-product-view").load("/Produtos");
    $("#nav-sales-view").load("/Vendas");
});    


$("#inserirCliente").click(function () {
    alterarTituloModal("clientModalOperationLabel");
})

$("#clientModalOperation").on("hidden.bs.modal", function () {
    $(".reset-fields").click();
})

$("#inserirClientModal").click(function () {
    
    var clientId = $('#client-id').val();
    console.log(clientId);

    var cliente = {
        nmCliente: $('#client-name').val(),
        cidade: $('#city-name').val()
    };

    if (clientId == null || clientId == 0 || clientId == undefined) {
        salvarDadosCliente(cliente);
    } else if (clientId == null && clientId > 0) {
        cliente.idCliente = clientId;
        //Método para atualizar os dados do cliente.
    }

});


function getClientData(id) {

    alterarTituloModal("clientModalOperationLabel");

    $.ajax({
        url: `Clientes/GetClientById/${id}`,
        dataType: "json",
        timeout: 1000,
        success: function (data) {
            setModalData(data);
        }
    });    
}

function setModalData(clientData) {    
    $("#client-id").val(clientData.idCliente);
    $('#client-name').val(clientData.nmCliente);
    $('#city-name').val(clientData.cidade);    
}

$("#inserirProdutoModal").click(function () {

    var productId = $('#product-id').val();

    var produto = {
        dscProduto: $('#product-name').val(),
        vlrUnitario: $('#price-value').val()
    };

    if (productId == null || productId == 0 || productId == undefined) {
        salvarDadosProduto(produto);
    } else if (productId == null && productId > 0) {
        produto.idProduto = productId;
        //Método para atualizar os dados do produto.
    }

});

$(".fechar").click(function () {
    $(".reset-fields").click();
});

function alterarTituloModal(id) {
    let tituloModal = $(`#${id}`);    
    let novoTitulo;

    if (tituloModal.text().includes("Inserir")) {
        novoTitulo = tituloModal.text().replace("Inserir", "Atualizar");        
        tituloModal.text(novoTitulo);
    } else {
        novoTitulo = tituloModal.text().replace("Atualizar", "Inserir");
        tituloModal.text(novoTitulo);
    }
}

function salvarDadosProduto(dadosProduto) {
    $.ajax({
        url: "Produtos/AddProduct",
        method: "POST",
        data: {
            produto: dadosProduto
        },
        success: function () {
            $("#nav-product-view").load("/Produtos");
        }
    });

    esconderModal();
    $(".reset-fields").click();
}

function salvarDadosCliente(dadosCliente) {
    $.ajax({
        url: "Clientes/AddClient",
        method: "POST",
        data: {
            cliente: dadosCliente
        },
        success: function () {            
            $("#nav-client-view").load("/Clientes");            
        }
    });

    esconderModal();    
    $(".reset-fields").click();
}   

function esconderModal() {
    $(".modal").modal('hide');
}

