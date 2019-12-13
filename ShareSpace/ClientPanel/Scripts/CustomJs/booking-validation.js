(function ($) {
    "use strict";
    /*[ Validate ]*/
    var input2 = $('.validate-input .validate-field');

    $('.validate-form').on('submit', function () {
        var check = true;

        for (var i = 0; i < input2.length; i++) {
            if (validate(input2[i]) == false) {
                showValidate(input2[i]);
                check = false;
            }
        }

        return check;
    });

    $('.validate-form .validate-field').each(function () {
        $(this).focus(function () {
            hideValidate(this);
        });
    });

    function validate(input2) {
        if ($(input2).attr('type') == 'email' || $(input2).attr('name') == 'email') {
            if ($(input2).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if ($(input2).val().trim() == '') {
                return false;
            }
        }
    }

    function showValidate(input2) {
        var thisAlert = $(input2).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input2) {
        var thisAlert = $(input2).parent();

        $(thisAlert).removeClass('alert-validate');
    }

})(jQuery);

(function ($) {
    "use strict";
    /*[ Validate ]*/
    var input2 = $('.validate-big-input .validate-big-field');

    $('.validate-big-form').on('submit', function () {
        var check = true;

        for (var i = 0; i < input2.length; i++) {
            if (validate(input2[i]) == false) {
                showValidate(input2[i]);
                check = false;
            }
        }

        return check;
    });

    $('.validate-big-form .validate-big-field').each(function () {
        $(this).focus(function () {
            hideValidate(this);
        });
    });

    function validate(input2) {
        if ($(input2).attr('type') == 'email' || $(input2).attr('name') == 'email') {
            if ($(input2).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if ($(input2).val().trim() == '') {
                return false;
            }
        }

        if ($(input2).attr('type') == 'phone' || $(input2).attr('name') == 'phone') {
            if ($(input2).val().trim().match(/^\d+$/) == null) {
                return false;
            }
        }
        else {
            if ($(input2).val().trim() == '') {
                return false;
            }
        }
    }

    function showValidate(input2) {
        var thisAlert = $(input2).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input2) {
        var thisAlert = $(input2).parent();

        $(thisAlert).removeClass('alert-validate');
    }

})(jQuery);