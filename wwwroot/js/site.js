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