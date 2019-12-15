(function (cibertec) {
    cibertec.getModal = getModalContent;
    cibertec.closeModal = closeModal;
    return cibertec;

    function getModalContent(url) {
        $.get(url, function (data) {
            $('.modal-body').html(data);
        })
    }

    function closeModal(option) {
        $("button[data-dismiss='modal']").click();
        $('.modal-body').html("");
        modifyAlertClasses(option);
    }

    function modifyAlertClasses(option) {
        $('#successMessage').addClass('hidden')
        $('#deleteMessage').addClass('hidden')
        $('#editMessage').addClass('hidden')

        if (option == 'Create') {
            $('#successMessage').removeClass('hidden')
        } else if (option == 'Delete') {
            $('#deleteMessage').removeClass('hidden')
        } else if (option == 'Edit') {
            $('#editMessage').removeClass('hidden')
        }
    }
})(window.cibertec = window.cibertec || {});