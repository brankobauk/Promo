$(document).ready(function () {
    $('.date').prop('readOnly', true);
    $('.date').datepicker({
        dateFormat: 'dd.mm.yy',
        minDate: '1.1.2010',
    });
});