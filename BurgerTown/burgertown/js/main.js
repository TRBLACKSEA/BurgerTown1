"use strict";
    
$(document).ready(function () {
    $("#small_carousel").owlCarousel({
        items: 1,
        loop: false,
        margin: 10,
        nav: false,
        dots: true,
        autoplay: false,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        mouseDrag: false
    });
    $("#carouselF").owlCarousel({
        items: 1,
        loop: false,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        autoplayHoverPause: true,
        mouseDrag: false,
        nav: false
    });
    $('.owl-carousel').owlCarousel({
        loop: false,
        margin: 10,
        dots:false,
        nav:false,
        autoplay: true,
        responsiveClass: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            },
            1000: {
                items: 3
            }
        }
    });

    // $(window).load(function () {
    //     $("#loading").fadeOut(500);
    // });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 600) {
            $('.scrollup').fadeIn('slow');
        } else {
            $('.scrollup').fadeOut('slow');
        }
    });
    $('.scrollup').click(function () {
        $("html, body").animate({scrollTop: 0}, 1000);
        return false;
    });
});


let toggler = document.querySelector(".navbar-toggler");
toggler.addEventListener("click", function(){
    let menu = document.querySelector("header .container");
    menu.classList.toggle("actived");
})

document.addEventListener('DOMContentLoaded', function () {
    animateTextForClass('sampleClass'); // Class olarak 'sampleClass' yerine h2 elementinin gerçek class'ını kullan
});

function animateTextForClass(className) {
    const elements = document.querySelectorAll('.' + className);
    elements.forEach((element) => {
        const textContent = element.innerText;
        const textContainer = document.createElement(element.tagName.toLowerCase());
        textContainer.className = 'animate';

        textContent.split('').forEach((letter, index) => {
        const span = document.createElement('span');
        span.innerHTML = letter;
        span.style.animationDelay = `${index * 0.1}s`;
        textContainer.appendChild(span);
        });

        element.parentNode.replaceChild(textContainer, element);
    });
}

function openPopup(title, content, imagePath) {
    document.getElementById('popupTitle').innerText = title;
    document.getElementById('popupContent').innerText = content;
    document.getElementById('popupImage').src = imagePath;
    document.querySelector('.popup-content').classList.add('animate__fadeInUp');
    document.querySelector('.popup-image').classList.add('animate__zoomIn');
    document.querySelector('.popup-title').classList.add('animate__fadeInDown');
    document.querySelector('.popup-content-text').classList.add('animate__fadeIn');
    document.getElementById('popupOverlay').style.display = 'flex';
}

// Function to close the popup with animation
function closePopup() {
    document.querySelector('.popup-content').classList.remove('animate__fadeInUp');
    document.querySelector('.popup-content').classList.add('animate__fadeOutDown');
    setTimeout(function () {
        document.getElementById('popupOverlay').style.display = 'none';
        document.querySelector('.popup-content').classList.remove('animate__fadeOutDown');
    }, 500);
}

// Adding click event listeners to each card
document.querySelectorAll('.tmt_card').forEach(function(card) {
    card.addEventListener('click', function() {
        var title = card.getAttribute('data-title');
        var content = card.getAttribute('data-content');
        var imagePath = card.getAttribute('data-image');
        openPopup(title, content, imagePath);
    });
});
