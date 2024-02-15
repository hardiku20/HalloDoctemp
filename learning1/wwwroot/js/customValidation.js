$(document).ready(function () {

    $('#email').on('blur', function () {
        var inputValue = $('#email').val();
        $.get('/Home/PatientCheck', { email: inputValue }, function (response) {
            if (!response.isValid) {
                $('.hidden-pass').show();
            } else {
                $('.hidden-pass').hide();
            }
        });
    });
});