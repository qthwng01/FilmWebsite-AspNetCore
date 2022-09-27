// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Lazy loading image

document.addEventListener("DOMContentLoaded", function () {
    var lazyloadImages = document.querySelectorAll("img.lazy");
    var lazyloadThrottleTimeout;

    function lazyload() {
        if (lazyloadThrottleTimeout) {
            clearTimeout(lazyloadThrottleTimeout);
        }

        lazyloadThrottleTimeout = setTimeout(function () {
            var scrollTop = window.pageYOffset;
            lazyloadImages.forEach(function (img) {
                if (img.offsetTop < (window.innerHeight + scrollTop)) {
                    img.src = img.dataset.src;
                    img.classList.remove('lazy');
                }
            });
            if (lazyloadImages.length == 0) {
                document.removeEventListener("scroll", lazyload);
                window.removeEventListener("resize", lazyload);
                window.removeEventListener("orientationChange", lazyload);
            }
        }, 20);
    }

    document.addEventListener("scroll", lazyload);
    window.addEventListener("resize", lazyload);
    window.addEventListener("orientationChange", lazyload);
});

// Get all the buttons into a node list
let buttons = document.querySelectorAll(".round-black-btn");

// Set an event handler on the document so that when
// any element is clicked, the event will bubble up to it
document.addEventListener("click", function (evt) {
    // Check to see if it was a button that was clicked
    if (evt.target.classList.contains("round-black-btn")) {
        // Loop over all the buttons & remove the active class
        buttons.forEach(function (button) {
            button.classList.remove("active");
        });
        // Make the clicked button have the active class
        evt.target.classList.add("active");
    }
});


$(function () {
    jQuery(document).on("click", ".round-black-btn", function (e) {
        e.preventDefault();
        var el = jQuery(this);
        var url = el.attr("data-src");
        $('iframe').attr('src', url);
        $('iframe').load();
        //alert(url);
        //$('source').attr('src', result);
    });
});


$(".round-black-btn").click(function () {
    $('html,body').animate({
        scrollTop: $('iframe').offset().top
    }, 'slow');
});