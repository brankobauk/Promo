$(document).ready(function () {
    
jQuery.validator.addMethod(
        'date',
        function (value, element, params) {
            if (this.optional(element)) {
                return true;
            };
            var result = false;
            try {
                $.datepicker.parseDate('dd.mm.yy', value);
                result = true;
            } catch (err) {
                result = false;
            }
            return result;
        },
        ''
    );
$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\,]\d{3})+)(?:[\,]\d+)?$/.test(value);
}
});