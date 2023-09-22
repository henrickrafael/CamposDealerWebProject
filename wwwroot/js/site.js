$(document).ready(function () {
    $("#nav-client-view").load("/Clientes");
    $("#nav-product-view").load("/Produtos");
    $("#nav-sales-view").load("/Vendas");    
});    


$("#inserirCliente").click(function () {
    resetTituloModal("clientModalOperationLabel");
})

$("#inserirProduto").click(function () {
    resetTituloModal("productModalOperationLabel");
})


$("#clientModalOperation").on("hidden.bs.modal", function () {
    $(".reset-fields").click();
})

$("#inserirClientModal").click(function () {

    var clientId = $('#client-id').val();    

    var cliente = {
        nmCliente: $('#client-name').val(),
        cidade: $('#city-name').val()
    };

    if (clientId == null || clientId == 0 || clientId == undefined) {
        salvarDadosCliente(cliente);
    } else if (clientId != null && clientId > 0) {
        cliente.idCliente = clientId;
        atualizarDadosCliente(cliente);
    }

});

function atualizarDadosCliente(dadosCliente) {
    $.ajax({
        url: `Clientes/UpdateClientById`,
        method: "POST",
        data: {
            cliente: dadosCliente
        },
        success: function () {            
            $("#nav-client-view").load("/Clientes");
            alert("Cliente atualizado com sucesso!");
        }

    });

    esconderModal();
    $(".reset-fields").click();
}

function removerCliente(id) {
    var confirmarExclusao = confirm("Tem certeza que desjea remover este cliente?")

    if (confirmarExclusao) { 
        $.ajax({
            url: `Clientes/DeleteClientById/${id}`,
            method: "DELETE",        
            timeout: 1000,
            success: function () {
                $("#nav-client-view").load("/Clientes");
            }
        });    
    }
}


function getClientData(id) {

    alterarTituloModal("clientModalOperationLabel");

    $.ajax({
        url: `Clientes/GetClientById/${id}`,
        dataType: "json",
        timeout: 1000,
        success: function (data) {
            setModalDataCliente(data);
        }
    });    
}

function getProductData(id) {

    alterarTituloModal("productModalOperationLabel");

    $.ajax({
        url: `Produtos/GetProductById/${id}`,
        dataType: "json",
        timeout: 1000,
        success: function (data) {
            setModalDataProduto(data);
        }
    });
}

function setModalDataCliente(clientData) {
    $("#client-id").val(clientData.idCliente);
    $('#client-name').val(clientData.nmCliente);
    $('#city-name').val(clientData.cidade);
}

function setModalDataProduto(clientData) {    
    $("#product-id").val(clientData.idProduto);
    $('#product-name').val(clientData.dscProduto);
    $('#price-value').val(clientData.vlrUnitario);    
}

$("#inserirProdutoModal").click(function () {

    var productId = $('#product-id').val();

    var produto = {
        dscProduto: $('#product-name').val(),
        vlrUnitario: $('#price-value').val()
    };

    if (productId == null || productId == 0 || productId == undefined) {
        salvarDadosProduto(produto);
    } else if (productId != null && productId > 0) {
        produto.idProduto = productId;
        atualizarDadosProduto(produto);
    }

});

function atualizarDadosProduto(dadosProduto) {
    $.ajax({
        url: `Produtos/UpdateProductById`,
        method: "POST",
        data: {
            produto: dadosProduto
        },
        success: function () {
            $("#nav-client-view").load("/Produtos");
            alert("Produto atualizado com sucesso!");
        }

    });

    esconderModal();
    $(".reset-fields").click();
}

$(".fechar").click(function () {
    $(".reset-fields").click();
});

function alterarTituloModal(id) {
    let tituloModal = $(`#${id}`);    
    let novoTitulo;

    if (tituloModal.text().includes("Inserir")) {
        novoTitulo = tituloModal.text().replace("Inserir", "Atualizar");        
        tituloModal.text(novoTitulo);
    } 
}

function resetTituloModal(id) {
    let tituloModal = $(`#${id}`);
    let novoTitulo = tituloModal.text().replace("Atualizar", "Inserir");
    
    tituloModal.text(novoTitulo);
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

