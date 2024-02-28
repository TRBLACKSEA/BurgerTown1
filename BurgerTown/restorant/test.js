let offerCgy = document.getElementById("offers");
let productsArea = document.getElementById("productsArea");
let otherAllCgy = document.querySelectorAll(".cgy-item");
let offer = document.querySelector(".offers");

offerCgy.addEventListener("click", function () {
    offer.classList.add("active", "animated");
    productsArea.style.display = "none";
});

for (let cg of otherAllCgy) {
    cg.addEventListener("click", function () {
        offer.classList.remove("active", "animated");
        productsArea.style.display = "grid";
    });
}
