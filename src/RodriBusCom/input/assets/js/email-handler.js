$(function () {
    setEmailHover();
    setDisplayEmailWhenVisible();
});

var email = 'mailto:';
for (var i = 0; i < charArr.length; i++) {
    email += String.fromCharCode(charArr[i]);
}

function setEmailHover() {
    $('.mail-link').hover(
        function () {
            //In
            $(this).attr('href', email);
        },
        function () {
            //Out
            $(this).removeAttr('href');
        }
    );
}

function setDisplayEmailWhenVisible() {
    var emails = $('.mail-full');
    $.each(emails, function (i, el) {
        handleEmailDisplay($(el));
    });

    //Display email on footer when visible
    $(window).scroll(function () { // bind window scroll event
        $.each(emails, function (i, el) {
            handleEmailDisplay($(el));
        });
    });
}

function handleEmailDisplay(element) {
    if (element.isOnScreen()) { // if target element is visible on screen after DOM loaded
        element.text(email.substring(7, email.length));
    } else {
        element.text('');
    }
}