$(document).ready(function(){
    var nav = $('#nav'); // Use the correct selector for your navigation element
    var header = $('#cards');
    var navHeight = nav.outerHeight(); // Use outerHeight to include padding and border

    if (nav.length) { // Check if the navigation element exists
        $(window).scroll(function () {
            var scrollPos = $(window).scrollTop();

            if (scrollPos > navHeight) {
                nav.addClass('nav-fixed');
                header.addClass('header-shrink');
            } else {
                nav.removeClass('nav-fixed');
                header.removeClass('header-shrink');
            }
        });
    }

    
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

    
})

document.addEventListener("DOMContentLoaded", function () {
    const navItems = document.querySelectorAll(".navMenu-item");

    navItems.forEach(function (item) {
        item.addEventListener("click", function () {
            const targetId = item.getAttribute("data-target");
            const targetSection = document.getElementById(targetId);

            if (targetSection) {
                targetSection.scrollIntoView({
                    behavior: "smooth"
                });
            }
        });
    });
});

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

window.addEventListener("click", function(event){
    if((event.target === this.document.querySelector(".popup-overlay"))){
        closePopup()
    }
})

function closePopup() {
    document.querySelector('.popup-content').classList.remove('animate__fadeInUp');
    document.querySelector('.popup-content').classList.add('animate__fadeOutDown');
    setTimeout(function () {
        document.getElementById('popupOverlay').style.display = 'none';
        document.querySelector('.popup-content').classList.remove('animate__fadeOutDown');
    }, 500);
}

document.querySelectorAll('.tmt_card').forEach(function(card) {
    card.addEventListener('click', function() {
        var title = card.getAttribute('data-title');
        var content = card.getAttribute('data-content');
        var imagePath = card.getAttribute('data-image');
        openPopup(title, content, imagePath);

    });
});

function toggleMenu() {
    var menu = document.getElementById("menu");
    menu.style.display = (menu.style.display === "block") ? "none" : "block";
}

function changeButtonText(newText) {
    var button = document.getElementById("myButton");
    button.innerHTML = newText;
    toggleMenu(); // Menüyü kapat
}

document.querySelector("#seenBtn").addEventListener("click", function(){
    document.querySelector("#hiddenBtn").classList.toggle("langActive");
});

document.querySelector("#hiddenBtn").addEventListener("click", function() {
    let willSelected = this.querySelector("#giveText").innerText;
    if(willSelected == "English"){
        document.querySelector("#langText").innerText= "English";
        document.querySelector("#giveText").innerText="Türkçe"
        document.querySelector("#hiddenBtn").classList.remove("langActive");
    }else{
        document.querySelector("#langText").innerText= "Türkçe";
        document.querySelector("#giveText").innerText="English"
        document.querySelector("#hiddenBtn").classList.remove("langActive");
    };
});

const owl = $('.nav-menu-owl-rest').owlCarousel({
    margin: 10,
    nav: false,
    dots: false,
    responsive: {
        0: { items: 2 },
        600: { items: 3 },
        1000: { items: 5 },
        1200: { items: 6 },
        1300: { items: 7 }
    }
});
let currentActiveSection = null;

const observer = new IntersectionObserver((entries) => {
    entries.forEach((entry) => {
        if (entry.isIntersecting) {
            const sectionId = entry.target.id;

            if (currentActiveSection !== sectionId) {
                // Navbar elemanları üzerinde dolaşarak uyumlu olanı seç
                const navLink = $(`#mainNav a[href="#${sectionId}"]`);
                $('#mainNav a').removeClass('activedClass');
                navLink.addClass('activedClass');

                // Owl Carousel'ı section'ın ortasına kaydır
                const index = $(`.owl-item a[href="#${sectionId}"]`).closest('.owl-item').index();
                owl.trigger('to.owl.carousel', [index, 300]);

                // AltNav'ı güncelle
                $('.altNav .nav-category').hide();
                $(`.altNav .nav-category.${sectionId}`).css('display', 'flex');

                currentActiveSection = sectionId;
            }
        }
    });
}, { threshold: 0.5 });

const sections = document.querySelectorAll('section');
sections.forEach((section) => {
    observer.observe(section);
});
