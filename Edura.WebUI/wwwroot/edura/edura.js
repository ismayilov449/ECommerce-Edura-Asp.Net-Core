$(document).ready(function() {


    // preloader
    $(window).load(function() {
        $('.preloader-animation').fadeOut(); // fade out the loading animation
        $('#preloader').delay(350).fadeOut('slow'); // fade out the white DIV that covers the website.
        $('body').delay(350).css({'overflow':'visible'});
    })


    // activate wow.js
    new WOW().init();


    // back to top button
    $(window).scroll(function () {
       if ($(this).scrollTop() > 50) {
           $('#back-to-top').fadeIn();
       } else {
           $('#back-to-top').fadeOut();
       }
   });


    // scroll body to 0px on click
    $('#back-to-top').click(function () {
        $('#back-to-top').tooltip('hide');
        $('body,html').animate({
            scrollTop: 0
            }, 800);
        return false;
    });

    $('#back-to-top').tooltip('show');


    // counterup
    $('.counter').counterUp({
        delay: 10,
        time: 1500
    });



    // initialize owl carousels/galleries
    $("#portfolio-carousel").owlCarousel({
        autoPlay: 4000, //Set AutoPlay to 4 seconds
        items : 4,
        navigation : true,
        navigationText: [
          "<i class='fa fa-angle-left'></i>",
          "<i class='fa fa-angle-right'></i>"
        ],
        pagination : false,
    });


    $("#portfolio-carousel-home").owlCarousel({
        autoPlay: 6000, //Set AutoPlay to 4 seconds
        items : 3,
        navigation : true,
        navigationText: [
          "<i class='fa fa-angle-left'></i>",
          "<i class='fa fa-angle-right'></i>"
        ],
        pagination : false,
    });


    $("#portfolio-gallery").owlCarousel({
        autoPlay: 4000, //Set AutoPlay to 4 seconds
        items : 1,
        navigation : true,
        navigationText: [
          "<i class='fa fa-angle-left'></i>",
          "<i class='fa fa-angle-right'></i>"
        ],
        pagination : true,
        singleItem : true,
        transitionStyle : "fadeUp"
    });


    $("#products-carousel").owlCarousel({
        autoPlay: 4000, //Set AutoPlay to 4 seconds
        items : 4,
        navigation : true,
        navigationText: [
          "<i class='fa fa-angle-left'></i>",
          "<i class='fa fa-angle-right'></i>"
        ],
        pagination : false,
    });


    $("#product-gallery").owlCarousel({
        autoPlay: 4000, //Set AutoPlay to 4 seconds
        items : 1,
        navigation : true,
        navigationText: [
          "<i class='fa fa-angle-left'></i>",
          "<i class='fa fa-angle-right'></i>"
        ],
        pagination : true,
        singleItem : true,
        transitionStyle : "fadeUp"
    });


    $("#testimonials-carousel").owlCarousel({
        autoPlay: 4000, //Set AutoPlay to 4 seconds
        items : 2,
        navigation : true,
        navigationText: [
          "<i class='fa fa-angle-left'></i>",
          "<i class='fa fa-angle-right'></i>"
        ],
        pagination : false,
    });


    $("#testimonials-carousel-home").owlCarousel({
        autoPlay: 4000, //Set AutoPlay to 4 seconds
        items : 1,
        navigation : false,
        pagination : true,
        singleItem : true,
        transitionStyle : "backSlide"
    });


    $("#blog-carousel-home").owlCarousel({
        autoPlay: false, //Set AutoPlay to 4 seconds
        items : 1,
        navigation : false,
        pagination : true,
        singleItem : true,
        transitionStyle : "backSlide"
    });


    $("#partners-gallery").owlCarousel({
        autoPlay: 5000, //Set AutoPlay to 5 seconds
        items : 5,
        navigation : false,
        pagination : true,
    });



    // bootstrap carousel (homepage)
    $('.carousel').carousel({
        interval: 5000 //changes the speed
    })



    // code to execute after images are loaded
    $('#wrapper').imagesLoaded( function() {

        // portfolio filters
        if ($('.portfolio-container').length) {

            // initialize filterizr
            $('.portfolio-container').filterizr();

            // portfolio filter controls
            $('.portfolio-controls li').click(function() {
                $('.portfolio-controls li').removeClass('active');
                $(this).addClass('active');
            });
        }

    });


});
