jQuery.validator.addMethod("requirediftrue", function(value, element, params) {
    var checkboxID = $(element).attr("data-val-requirediftrue-boolprop");
    var checkboxValue = $("#" + checkboxID).first().is(":checked");

    return !checkboxValue || value;
}, "");

jQuery.validator.unobtrusive.adapters.add("requirediftrue", {}, function(options) {
    options.rules["requirediftrue"] = true;
    options.messages["requirediftrue"] = options.message;
})