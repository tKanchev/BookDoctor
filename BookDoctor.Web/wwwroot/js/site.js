jQuery(document).ready(function () {
    $('.doctorInputs').hide();

    $('input:radio[name="IsDoctor"]').change(function () {
        if ($(this).val() == 'True') {
            $('.doctorInputs').show();
        }
        else {
            $('.doctorInputs').hide();
        }
    });
    $('.alert').fadeOut(6000);
});