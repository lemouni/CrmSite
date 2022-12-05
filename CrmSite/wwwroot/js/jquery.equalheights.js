$(window).bind("resize",height_handler).bind("load",height_handler);


function height_handler(){
	//if (window.matchMedia("screen and (min-width: 768px)").matches) {

	if( $(window).width()>=752 ){
		$(".minheight1").css("height","auto").equalHeights();
        $(".minheight2").css("height","auto").equalHeights();
        $(".minheight3").css("height","auto").equalHeights();
	}else{
		$(".minheight1").css({'height':'auto'});
        $(".minheight2").css({'height':'auto'});
        $(".minheight3").css({'height':'auto'});
	}


}

/*!
 * Simple jQuery Equal Heights
 *
 * Copyright (c) 2013 Matt Banks
 * Dual licensed under the MIT and GPL licenses.
 * Uses the same license as jQuery, see:
 * http://docs.jquery.com/License
 *
 * @version 1.5.1
 */
(function($) {

    $.fn.equalHeights = function() {
        var maxHeight = 0,
            $this = $(this);

        $this.each( function() {
            var height = $(this).innerHeight();

            if ( height > maxHeight ) { maxHeight = height; }
        });

        return $this.css('height', maxHeight);
    };

    // auto-initialize plugin
    $('[data-equal]').each(function(){
        var $this = $(this),
            target = $this.data('equal');
        $this.find(target).equalHeights();
    });

})(jQuery);