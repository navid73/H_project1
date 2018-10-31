(function ($) {
    $(document).ready(function () {
        $('#nav-dropdown').click(function(){
            const $html = $('html');
            if($html.hasClass('nav-open')) {
                $html.removeClass('nav-open');
            } else {
                $html.addClass('nav-open');
            }
        });
    });
})(jQuery);
