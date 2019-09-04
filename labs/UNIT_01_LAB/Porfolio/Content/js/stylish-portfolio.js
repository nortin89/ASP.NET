(function($) {
  "use strict"; // Start of use strict

  // Closes the sidebar menu
  $("#menu-close").click(function(e) {
    e.preventDefault();
    $("#sidebar-wrapper").toggleClass("active");
  });

  // Opens the sidebar menu
  $("#menu-toggle").click(function(e) {
    e.preventDefault();
    $("#sidebar-wrapper").toggleClass("active");
  });


  // Activate scrollspy to add active class to navbar items on scroll
  $('body').scrollspy({ target: '#mainNav', offset: 56 });

  // Smooth scrolling using jQuery easing
  $('.js-scroll-trigger').click(function (e) {
    e.preventDefault();
    $('.navbar-collapse').collapse('hide');

    const target = $(this.hash);
    $('html').animate({ scrollTop: target.offset().top - 56 }, 1000, 'swing');

    //const target = document.querySelector(this.hash);
    //$('html').animate({ scrollTop: target.offsetTop - 56 }, 1000, 'swing');
  });

  //#to-top button appears after scrolling
//  var fixed = false;
//  $(document).scroll(function() {
//    if ($(this).scrollTop() > 250) {
//      if (!fixed) {
//        fixed = true;
//        $('#to-top').show("slow", function() {
//          $('#to-top').css({
//            position: 'fixed',
//            display: 'block'
//          });
//        });
//      }
//    } else {
//      if (fixed) {
//        fixed = false;
//        $('#to-top').hide("slow", function() {
//          $('#to-top').css({
//            display: 'none'
//          });
//        });
//      }
//    }
//  });

//})(jQuery); // End of use strict


// Disable Google Maps scrolling
// See http://stackoverflow.com/a/25904582/1607849
// Disable scroll zooming and bind back the click event
var onMapMouseleaveHandler = function(event) {
  var that = $(this);
  that.on('click', onMapClickHandler);
  that.off('mouseleave', onMapMouseleaveHandler);
  that.find('iframe').css("pointer-events", "none");
}
var onMapClickHandler = function(event) {
  var that = $(this);
  // Disable the click handler until the user leaves the map area
  that.off('click', onMapClickHandler);
  // Enable scrolling zoom
  that.find('iframe').css("pointer-events", "auto");
  // Handle the mouse leave event
  that.on('mouseleave', onMapMouseleaveHandler);
}
// Enable map zooming with mouse scroll when the user clicks the map
$('.map').on('click', onMapClickHandler);
