(function (product) {
    product.success = successReload;
    product.pages = 1;
    product.rowSize = 10;

    //Atributos para el manejo del Hub
    product.hub = {};
    product.ids = [];
    product.recordInUse = false;
    product.addProduct = addProductId;
    product.removeHubProduct = removeProductId;
    product.validate = validate;
    $(function () {
        connectToHub();
        init(1);
    })

    //getCustomers();

    product.reloadData = reload;
    return product;

    function successReload(option) {
        cibertec.closeModal(option);
        elements = document.getElementsByClassName('active');
        activePage = elements[1].children;
        //getCustomers(activePage[0].text);

        var rowCount = $('.table >tbody >tr').length;
        console.log(rowCount);
        console.log(option);
        //Paginacion de eliminacion: evaluar/ actualizar paginacion
        if (option === 'Delete' && (rowCount - 1) === 1 && activePage[0].text != 1) {
            init(activePage[0].text - 1);
        } else {
            init(activePage[0].text);
        }
    }

    function reload(elementId, url) {
        $.get(url, function (data) {
            $('#' + elementId).html(data);
        })
    }

    function init(numPage) {
        $.get('/Products/Count/?rows=' + product.rowSize,
            function (data) {
                product.pages = data;
                $('.pagination').bootpag({
                    total: product.pages,
                    page: numPage,
                    maxVisible: 5,
                    leaps: true,
                    firstLastUse: true,
                    first: '← ',
                    last: '→ ',
                    wrapClass: 'pagination',
                    activeClass: 'active',
                    disabledClass: 'disabled',
                    nextClass: 'next',
                    prevClass: 'prev',
                    lastClass: 'last',
                    firstClass: 'first'
                }).on('page', function (event, num) {
                    getProducts(num);
                });
                getProducts(numPage);
            });
    }

    function getProducts(cantPages) {
        var url = '/Products/List/' + cantPages + '/' + product.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

    function addProductId(id) {
        product.hub.server.addProductId(id);
    }

    function removeProductId(id) {
        product.hub.server.removeProductId(id);
    }

    function connectToHub() {
        product.hub = $.connection.productHub;
        product.hub.client.productStatus = productStatus;

        //Metodos en el cliente
        //customer.hub.client.method = method;
    }

    function productStatus(productsIds) {
        console.log(productsIds);
        product.ids = productsIds;
    }

    function validate(id) {
        product.recordInUse = (product.ids.indexOf(id) > -1);
        if (product.recordInUse) {
            $('#inUse').removeClass('hidden');
            $('#btn-save').html("");
        }
    }
})(window.product = window.product || {});