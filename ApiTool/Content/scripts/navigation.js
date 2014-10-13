window.OTAPITOOL = window.OTAPITOOL || {};

window.OTAPITOOL.Navigation = function () {
    "use strict";

    var selected = null;

    var setSelectedClass = function () {
        var link = $('a:contains("' + selected + '")');
        link.addClass("current");
    };

    return {
        init: function (args) {
            args = args || {};
            selected = args.Selected;

            $(document).ready(function () {
                setSelectedClass();
            });
        }
    };
}();
