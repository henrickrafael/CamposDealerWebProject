$("#inserirClientModal").click(function () {

    var clientId = $('#client-id').val();    

    var cliente = {             
        nmCliente:  $('#client-name').val(),
        cidade: $('#city-name').val()
    };

    if (clientId == null || clientId == 0 || clientId == undefined) {
        salvarDadosCliente(cliente);
    } else if (clientId == null && clientId > 0) {
        cliente.idCliente = clientId;
        //Método para atualizar os dados do cliente.
    }

})

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

})

$(".fechar").click(function () {
    $(".reset-fields").click();
})

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

