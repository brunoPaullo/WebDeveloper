(function (customer) {
    customer.success = successReload;
    customer.reloadData = reload;
    return customer;

    function successReload(option) {
        cibertec.closeModal(option);
    }

    function reload(elementId ,url) {
        $.get(url, function (data) {
            $('#' + elementId).html(data);
        })
    }

})(window.customer = window.customer || {});