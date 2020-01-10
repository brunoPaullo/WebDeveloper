(function (supplier) {
    supplier.success = successReload;
    supplier.pages = 1;
    supplier.rowSize = 10;

    //Atributos para el manejo del Hub
    supplier.hub = {};
    supplier.ids = [];
    supplier.recordInUse = false;
    supplier.addSupplier = addSupplierId;
    supplier.removeHubSupplier = removeSupplierId;
    supplier.validate = validate;
    $(function () {
        connectToHub();
        init(1);
    })

    //getCustomers();

    supplier.reloadData = reload;
    return supplier;

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
        $.get('/Suppliers/Count/?rows=' + supplier.rowSize,
            function (data) {
                supplier.pages = data;
                $('.pagination').bootpag({
                    total: supplier.pages,
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
                    getSuppliers(num);
                });
                getSuppliers(numPage);
            });
    }

    function getSuppliers(cantPages) {
        var url = '/Suppliers/List/' + cantPages + '/' + supplier.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

    function addSupplierId(id) {
        supplier.hub.server.addSupplierId(id);
    }

    function removeSupplierId(id) {
        supplier.hub.server.removeSupplierId(id);
    }

    function connectToHub() {
        supplier.hub = $.connection.supplierHub;
        supplier.hub.client.supplierStatus = supplierStatus;

        //Metodos en el cliente
        //customer.hub.client.method = method;
    }

    function supplierStatus(supplierIds) {
        console.log(supplierIds);
        supplier.ids = supplierIds;
    }

    function validate(id) {
        supplier.recordInUse = (supplier.ids.indexOf(id) > -1);
        if (supplier.recordInUse) {
            $('#inUse').removeClass('hidden');
            $('#btn-save').html("");
        }
    }
})(window.supplier = window.supplier || {});