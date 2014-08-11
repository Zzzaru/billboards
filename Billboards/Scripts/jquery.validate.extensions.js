$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:,\d{3})+)?(?:(\.|\,)\d+)?$/.test(value);
};

$.validator.methods.range = function (value, element, param) {
    var globalizedValue = value.replace(",", ".");
    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
};

$.validator.methods.date = function (value, element) {
    var dateVsTime = value.split(' ');
    var dateParts = dateVsTime[0].split('.');
    var date;
    if (dateParts[0] && dateParts[1] && dateParts[2]) {
        if (dateVsTime[1]) {
            var timeParts = dateVsTime[1].split(':');
            date = new Date(dateParts[2], dateParts[1], dateParts[0], timeParts[0], timeParts[1]);
        } else {
            date = new Date(dateParts[2], dateParts[1], dateParts[0]);
        }
        return this.optional(element) || !/Invalid|NaN/.test(date.toString());
    }
    return false;
};