$(function () {
    //Tooltips
    $('[data-toggle="tooltip"]').tooltip();

    //Bind the sticky function
    $("#sticky-menu").sticky({
        topSpacing: 0
    });

    $(".submenu a.scroll").click(function (event) {
        event.preventDefault();
        var t = $(this).attr('href')
        $('html, body').animate({
            scrollTop: $(t).offset().top - 100
        }, 1000);
    });
});