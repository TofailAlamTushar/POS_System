/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />

$(document).ready(function () {
    $(".List-table").DataTable({
        'paging': true,
        'lengthChange': true,
        'searching': true,
        'ordering': true,
        'info': true,
        'autoWidth': true
    });
});