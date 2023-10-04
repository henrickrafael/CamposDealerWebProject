$("#inserirCliente").click(function () {
    resetTituloModal("clientModalOperationLabel");
});

$("#inserirProduto").click(function () {
    resetTituloModal("productModalOperationLabel");
});

$("#inserirVenda").click(function () {
    resetTituloModal("saleModalOperationLabel");
});

$("#clientModalOperation").on("hidden.bs.modal", function () {
    $(".reset-fields").click();
});

$("#productModalOperation").on("hidden.bs.modal", function () {
    $(".reset-fields").click();
});

$("#saleModalOperation").on("hidden.bs.modal", function () {
    $(".reset-fields").click();
});

function resetAll() {
    $(".reset-fields").click();
}

function getSaleData(id) {    

    alterarTituloModal("saleModalOperationLabel");

    $.ajax({
        url: `Vendas/GetVendaById/${id}`,
        dataType: "JSON",
        timeout: 1000,
        success: function (data) {
            setModalDataVenda(data)
        }

    });
}

function setModalDataVenda(dataVenda) {
    $('#sale-id').val(dataVenda.idVenda);
    $('#sale-qtd').val(dataVenda.qtdVenda);
    $('#total-value').val(dataVenda.vlrTotalVenda);
    $('#product-id').val(dataVenda.produtoId);
    $('#client-id').val(dataVenda.clienteId);
    $('#unity-value').val(dataVenda.produto.vlrUnitario);

    $(`#product-id option[value="${dataVenda.produtoId}"]`).prop('selected', true);
    $(`#client-id option[value="${dataVenda.clienteId}"]`).prop('selected', true);
}

function now() {
    const date = new Date();

    let ano = date.getFullYear();
    let mes = String(date.getMonth() + 1).padStart(2, "0");
    let dia = String(date.getDate()).padStart(2, "0");
    let hora = date.getHours();
    let minutos = date.getMinutes();
    let segundos = date.getSeconds();

    return `${ano}-${mes}-${dia} ${hora}:${minutos}:${segundos}`
}

function setOnlyNumbers(event, valueInput, useDot) {
    
    var asciiCode = (event.which) ? event.which : event.keyCode

    if (useDot) { 
        if (asciiCode == 46) {
            if (valueInput.value.indexOf('.') === -1) {
                return true;
            }
            return false;
        }
    }

    if (asciiCode > 31 && (asciiCode < 48 || asciiCode > 57)) {
        return false;
    }

    return true;
}

function setDefaultValue(prop) {
    prop.value = 0;
}

function setDropDownValue(element) {
    $(`#${element.id}`).val(element.value);   
}

$("#inserirVendaModal").click(function () {
    var saleId = $('#sale-id').val();

    var venda = {
        qtdVenda: $('#sale-qtd').val(),
        dthVenda: now(),
        vlrTotalVenda: $('#total-value').val(),
        produtoId: $('#product-id').val(),
        clienteId: $('#client-id').val()
    }

    if (saleId == null || saleId == 0 || saleId == undefined) {
        salvarDadosVenda(venda);
    } else if (saleId != null && saleId > 0) {
        venda.idVenda = saleId;
        atualizarDadosVenda(venda);
    }
});

function atualizarDadosVenda(dadosVenda) {
    $.ajax({
        url: "Vendas/UpdateSaleById",
        method: "POST",
        data: {
            venda: dadosVenda
        },
        success: () => {
            $("#nav-sale-view").load("/Vendas");
            getUpdatedViewModel();

            alert("Venda atualizada com sucesso!");
        }
    });
}


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
            getUpdatedViewModel();

            alert("Cliente atualizado com sucesso!");
        }

    });

    esconderModal();
    resetAll();
}

function removerCliente(id) {
    var confirmarExclusao = confirm("Tem certeza que deseja remover este cliente?")

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

function removerProduto(id) {
    var confirmarExclusao = confirm("Tem certeza que deseja remover este produto?")

    if (confirmarExclusao) {
        $.ajax({
            url: `Produtos/DeleteProductById/${id}`,
            method: "DELETE",
            timeout: 1000,
            success: function () {
                $("#nav-product-view").load("/Produtos");
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
        vlrUnitario: $('#price-value').val().replace(".", ",")    
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
            $("#nav-product-view").load("/Produtos");
            getUpdatedViewModel();

            alert("Produto atualizado com sucesso!");            
        }

    });

    esconderModal();
    resetAll();
}

function atualizarViewModelVendas(modelData) {       
    var model = JSON.stringify(modelData);
    var modelEncoded = window.btoa(model); 

    $("#nav-sales-view").load("/Vendas");
    $("#sale-modal-wrapper").load(`/Vendas/GetUpdatedSaleIndex?model=${modelEncoded}`);   
}

function getUpdatedViewModel() {    
    return $.ajax({
        url: "/Home/GetViewModel",
        dataType: "json",
        timeout: 1000,
        success: function (data) {
            atualizarViewModelVendas(data);
        }
    })
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

function salvarDadosVenda(dadosVenda) {
    $.ajax({
        url: "Vendas/AddSale",
        method: "POST",
        data: {
            venda: dadosVenda
        },
        success: function () {
            $("#nav-sales-view").load("/Vendas");
            alert("Venda inserida com sucesso!");
        }
    });

    esconderModal();
    resetAll();
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
    resetAll();
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
    resetAll();
}   

function esconderModal() {
    $(".modal").modal('hide');
}

function setValorUnitario(vlr) {
    $("#unity-value").val(vlr);    

    setTotalValue(vlr, $("sale-qtd").val());
}

function setTotalValue(vlr, qtd) {
    let total = vlr * qtd;
    $("#total-value").val(total.toFixed(2));
}

//TODO: aplicar sweet alert eventualmente