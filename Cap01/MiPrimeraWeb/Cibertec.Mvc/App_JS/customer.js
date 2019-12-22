(function (customer) {
    customer.success = successReload;
    customer.pages = 1;
    customer.rowSize = 10;
    init(1);
    //getCustomers();

    customer.reloadData = reload;
    return customer;

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

    function reload(elementId ,url) {
        $.get(url, function (data) {
            $('#' + elementId).html(data);
        })
    }

    function init(numPage) {
        $.get('/Customers/Count/?rows=' + customer.rowSize,
            function (data) {
                customer.pages = data;
                $('.pagination').bootpag({
                    total: customer.pages,
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
                    getCustomers(num);
                });
                getCustomers(numPage);
            });
    }

    function getCustomers(cantPages) {
        var url = '/Customers/List/' + cantPages + '/' + customer.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

})(window.customer = window.customer || {});