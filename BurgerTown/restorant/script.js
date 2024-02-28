let saveTotalPrice = [];
let inputsF = [];
bgTable()

function adjustFontSize() {
    const cgyItems = document.querySelectorAll('.cgy-item');
    cgyItems.forEach(item => {
        const maxHeight = 60; // Maksimum yükseklik
        const textHeight = item.scrollHeight; // Metnin yüksekliği

        const currentFontSize = parseFloat(window.getComputedStyle(item, null).getPropertyValue('font-size'));

        // Yüksekliği kontrol et, gerekirse font boyutunu ayarla
        if (textHeight > maxHeight) {
        const newFontSize = (maxHeight / textHeight) * currentFontSize;
        item.style.fontSize = newFontSize + 'px';
        }
    });
}
window.addEventListener('load', adjustFontSize);
window.addEventListener('resize', adjustFontSize);

const fullscreenButton = document.getElementById('fullscreenButton');
fullscreenButton.addEventListener('click', toggleFullscreen);

function toggleFullscreen() {
    if (document.fullscreenElement) {
        document.exitFullscreen();
    } else {
        document.documentElement.requestFullscreen();
    }
}

$(document).ready(function () {
    setCarts("sect")
    $('.menu-owl').owlCarousel({
        nav:true,
        dots:false,
        items:6,
        navText: ["<i class='fa-solid fa-chevron-left'></i>", "<i class='fa-solid fa-chevron-right'></i>"],
        margin:8,
        touchDrag:false,
        mouseDrag:false,
        responsive: {
            550: {
                items: 2
            },
            750: {
                items: 3
            },
            950: {
                items: 4
            },
            1250: {
                items: 5
            },
            1400: {
                items: 6
            }
        }
    });
    
    $("#menusUp").on("click", function() {
        scrollProducts(-250);
    });
    $("#menusDown").on("click", function() {
        scrollProducts(250);
    });
    $("#addedUp").on("click", function() {
        scrollAdded(-250);
    });
    $("#addedDown").on("click", function() {
        scrollAdded(250);
    });

    function scrollProducts(amount) {
        var productsArea = $("#productsArea");
        productsArea.scrollTop(productsArea.scrollTop() + amount);
    }
    function scrollAdded(amount){
        var addedProduct = $("#tableAreaAside");
        addedProduct.scrollTop(addedProduct.scrollTop() + amount);
    }
    
});

var popupContents = document.querySelectorAll('.popup-content');

popupContents.forEach(function (popupContent) {
    var scrollUpButton = popupContent.nextElementSibling.querySelector('.fa-chevron-up');
    var scrollDownButton = popupContent.nextElementSibling.querySelector('.fa-chevron-down');

    scrollUpButton.addEventListener('click', function() {
        scrollPopup(popupContent, -250);
    });

    scrollDownButton.addEventListener('click', function() {
        scrollPopup(popupContent, 250);
    });
});

function scrollPopup(popupContent, amount) {
    popupContent.scrollTop += amount;
}

function setCarts(category) {
    const productsArea = document.querySelectorAll("#productsArea section");
    productsArea.forEach(section => {
        section.classList.remove("animated", "active");
        setTimeout(() => {
            if (section.classList.contains(category)) {
                section.classList.add("animated", "active");
            }
        }, 100);
    });
}

$(document).ready(function () {
    const categories = $(".cgy-item");
    categories.on("click", function () {
        categories.removeClass("activeCgl");
        $(this).addClass("activeCgl");
        const selectedCategory = $(this).data("category");
        setCarts(selectedCategory);
    });
});

const categories = ["hamburgerPop","drinkPop", "hamburgersPop", "dessertPop"]

categories.forEach(category => {
    let selector = `.${category} .product`;
    let getsCirclePlusIcons = document.querySelectorAll(selector);
    for(let circle of getsCirclePlusIcons){
        circle.addEventListener("click", () => {
            getPopup(`${category}`);
        });
    }
});

function getPopup(catPop) {
    let popup = document.getElementById("popup");
    let popupContents = document.querySelectorAll("#popup .pop");
    popup.classList.add("activePopup");
    popupContents.forEach(selcdPop => {
        selcdPop.style.display = "none";
    });
    
    let selectedPop = document.getElementById(catPop);
    let popupInputs = selectedPop.querySelectorAll("input[type='checkbox']");
    
    
    
    if (selectedPop) {
        popupInputs.forEach(function(popupInput) {
            popupInput.checked = false;
        });

        selectedPop.style.display = "block";
        selectedPop.children[1].scrollTop = 0;

        let priceValue = selectedPop.querySelector('.popup-price-content b').textContent;
        let totalPopPrice = selectedPop.querySelector('.totalPopPrice');
        totalPopPrice.textContent = priceValue;
    }
}


const exitPopups = document.querySelectorAll("#popup .title");
for(let i of exitPopups){
    i.addEventListener("click", exitPopup)
}
function exitPopup(){
    let popup = document.getElementById("popup");
    popup.classList.remove("activePopup");
}

let saveButtons = document.querySelectorAll("#popup .pop .popup-footer button.btn-success")
for(let save of saveButtons){
    save.addEventListener("click", function(){
        let popContent = save.parentElement.parentElement;
        willSavePopupInf(popContent)
        bgTable()
        exitPopup()
        const otherPopupCagirma = document.querySelectorAll("#tableAreaAside tr td .fa-pencil")
        for(let p of otherPopupCagirma){
            p.addEventListener("click", function(){
                getPopup("hamburgerPop")
                // burası table daki kalemlere tıklanıldığında  yapılacak olan işlem burada yazılmalı. şimdilik ssadece hamburpepup ı ççğaırılıyor ilerdedüşünülecek .... !önemli!
            })
        }
    })
}

function willSavePopupInf(informations){
    let saveName = informations.querySelector(".popup-content h3").textContent;
    let savePrice = informations.querySelector(".popup-content .popup-price-content b").textContent.replace(/\$|TL/g, '');
    let saveInputs = informations.querySelectorAll(".popup-content .popupCategories input");
    let saveId = document.querySelectorAll("#tableAreaAside table tr").length;
    let button = informations.querySelector(".btnAddPopup");

    for (var d of saveInputs){
        if (d.checked){
            inputsF.push(d.nextElementSibling.textContent)
        }
    }

    button.disabled = true;
    let forTotalPice = button.querySelector(".totalPopPrice").textContent.replace(/\$|TL/g, '');
    saveTotalPrice += forTotalPice;

    createTrTables(saveName, savePrice, inputsF, saveId, saveTotalPrice);

}

function createTrTables(name, price, inputsF, id, saveTotalPrice) {
    let tr = `
        <tr class="newAddClass" data-id="item${id}">
            <td class="itemName d-grid-1">
                <div class="mainItemName">${name} </div>
                <ul>${inputsF.slice(0, 3).map(p => `<li>${p}</li>`).join('')}</ul>
            </td>
            <td class="itemQuantity">
                <i class="fa-solid fa-circle-plus"></i>
                <span class="itemQty">1</span>
                <i class="fa-solid fa-circle-minus"></i>
            </td>
            <td class="itemLonely"> ${price} TL</td>
            <td class="itemPer"> ${saveTotalPrice} TL</td>
            <td class="itemtTotal"> ${saveTotalPrice} TL</td>
            <td class="d-flex-1">
                <ul class="continueUl">${inputsF.map(p => `<li>${p}</li>`).join('')}</ul>
                <i class="fa-solid fa-trash"></i>
                <i class="fa-solid fa-pencil mx-3"></i>
                <i class="fa-solid fa-ellipsis-vertical" onclick="cagir(event)"></i>
            </td>
        </tr>
    `;
    let table = document.querySelector("#tableAreaAside table tbody");
    table.insertAdjacentHTML('beforeend', tr);
    totalPriceMax()
    resetDizi()
}

function resetDizi(){
    saveTotalPrice = [];
    inputsF = [];
}

function cagir(event){
    let displayIt = event.target.parentElement.children[0];
    if (displayIt.style.display === "block") {
        displayIt.style.display = "none";
    } else {
        displayIt.style.display = "block";
    }
}

function bgTable(){
    let tableTr = document.querySelectorAll("#tableAreaAside tr");
    tableTr.forEach((tr, index) => {
        if (index % 2 === 0) {
            tr.style.backgroundColor = "white";
        } else {
            tr.style.backgroundColor = "lightgray"; 
        }
    });
}

document.getElementById("popup").addEventListener("click", function(event){
    let clickedElement = event.target;
    if (clickedElement.closest('.popupCategories ul li') !== null) {
        let clickedInput = clickedElement.querySelector("input")
        if(clickedInput.checked){
            clickedInput.checked = false;
            if(clickedElement.parentElement.classList.contains("sizing")){
                let sizingContainers = clickedElement.parentElement;
                sizingContainers.classList.remove("absb");
                saveButtonPop(sizingContainers)
            }
            priceUpdateUseInpts(clickedElement)
        }else{
            clickedInput.checked = true;
            priceUpdateUseInpts(clickedElement)
            if(clickedElement.parentElement.classList.contains("sizing")){
                // önemli işlem save buton aktif olması içi
                let sizingContainers = clickedElement.parentElement;
                sizingContainers.classList.add("absb"); //active but for save button
                let sizingCheckboxes = sizingContainers.querySelectorAll('input[type="checkbox"]');
                sizingCheckboxes.forEach(function (otherCheckbox) {
                    if (otherCheckbox !== clickedInput) {
                        otherCheckbox.checked = false;
                    }
                });
                saveButtonPop(sizingContainers)
            }
        }
    }else{
        return
    }

});

function saveButtonPop(sizingContainers) {
    let totalSizingElementsContainer = sizingContainers.parentElement.parentElement;
    let totalSizingElements = totalSizingElementsContainer.querySelectorAll(".sizing");
    let button = totalSizingElementsContainer.parentElement.querySelector(".btnAddPopup");
    const allElementsHaveAbsbClass = Array.from(totalSizingElements).every(element => element.classList.contains('absb'));
    if(allElementsHaveAbsbClass){
        button.disabled=false;
    } else {
        button.disabled=true;
    }

}

function priceUpdateUseInpts(clickedElement){
    var popElement = clickedElement.closest('.pop');
    var priceElement = popElement.querySelector('.popup-price-content b').textContent;
    let totalPrice = parseFloat(priceElement)
    var contentElements = popElement.querySelectorAll('.popupCategories input[type="checkbox"]');
    setTimeout(() => {
        contentElements.forEach(function (size) {
            var sizePrice = size.nextElementSibling.nextElementSibling.textContent;
            if (sizePrice.trim().toLowerCase() === 'ücretsiz') {
                toplanacaklar.push(0); // Ücretsizse 0 olarak ekle
            } else {
                var cleanedContent = sizePrice.replace(/\$|TL/g, '');
                let addWillPrice = parseFloat(cleanedContent)
                if (size.checked) {
                    toplanacaklar.push(addWillPrice * 1);
                }
            }
        });
    }, 100);
    let toplanacaklar = [];
    setTimeout(() => {
        let total = 0;
        for (var i = 0; i < toplanacaklar.length; i++) {
            if (typeof toplanacaklar[i] === 'number') {
                total += toplanacaklar[i];
            }
        }
        let saveWill = popElement.querySelector('.btnAddPopup .totalPopPrice');
        let applySavedButton = totalPrice += total;
        let floorAplySavedButton =applySavedButton.toFixed(2)
        saveWill.innerHTML = floorAplySavedButton + " TL";
    }, 200);
}

function restartInputs(){
    var sizingContainers = document.querySelectorAll('.sizing');
    sizingContainers.forEach(function (container) {
        var sizingCheckboxes = container.querySelectorAll('input[type="checkbox"]');

        sizingCheckboxes.forEach(function (checkbox) {
            checkbox.addEventListener('change', function () {
                if (this.checked) {
                    sizingCheckboxes.forEach(function (otherCheckbox) {
                        if (otherCheckbox !== checkbox) {
                            otherCheckbox.checked = false;
                        }
                    });
                }
            });
        });
    });
}

document.querySelector('#tableAreaAside table tbody').addEventListener('click', function (event) {
    const target = event.target;
    if (target.classList.contains('fa-circle-plus')) {
        // console.log(target.closest('tr'))
        changeQuantity(target.closest('tr').dataset.id, 'plus');
    } else if (target.classList.contains('fa-circle-minus')) {
        changeQuantity(target.closest('tr').dataset.id, 'minus');
    } else if (target.classList.contains('fa-trash')) {
        removeItem(target.closest('tr').dataset.id);
        bgTable()
        resetDataId()
    }
});

function changeQuantity(itemId, action) {
    var quantityElement = document.querySelector('[data-id="' + itemId + '"] .itemQty');
    var currentQuantity = parseInt(quantityElement.textContent); 
    var pricePerItem = parseFloat(document.querySelector('[data-id="' + itemId + '"] .itemPer').textContent);

    if (action === 'plus') {
        currentQuantity += 1;
    } else if (action === 'minus' && currentQuantity > 1) {
        currentQuantity -= 1;
    }

    quantityElement.textContent = currentQuantity;

    var totalElement = document.querySelector('[data-id="' + itemId + '"] .itemtTotal');
    var newTotal = (currentQuantity * pricePerItem).toFixed(2);
    totalElement.textContent = newTotal + ' TL';
}

function removeItem(itemId) {
    var itemRow = document.querySelector('[data-id="' + itemId + '"]');
    itemRow.parentNode.removeChild(itemRow);
    totalPriceMax()
}

function resetDataId() {
    var rows = document.querySelectorAll('#tableAreaAside table tbody tr.newAddClass');
    rows.forEach((row, index) => {
        var currentId = row.dataset.id;
        var newId = 'item' + (index + 1);
        row.dataset.id = newId;
        if (row.dataset.other) {
            var otherAttribute = row.dataset.other;
            row.dataset.other = otherAttribute.replace(new RegExp(currentId, 'g'), newId);
        }
    });
}

function totalPriceMax(){
    let everyTrsPriceContainer = document.querySelectorAll("#tableAreaAside tbody tr .itemtTotal");
    let totalPriceArray = [];
    let toplam = 0;
    for(let price of everyTrsPriceContainer){
        totalPriceArray.push(parseFloat(price.textContent))
    }
    for(let arrayPrice of totalPriceArray){
        toplam += arrayPrice; 
    }
    document.getElementById("toplamFiyat").textContent = toplam.toFixed(2) + " " + "TL";
}

