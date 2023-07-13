function myFunction() {
    document.getElementById("demo").innerHTML = "Paragraph changed.";
}


function ShowGiay2(url) {
    document.getElementById('Main-Content-Adidas').src = url;
}
    function ShowGiay2(e) {
        let list = document.getElementsByClassName('img-item');
        for(let x of list) {
            x.style.opacity  = 0.5;
        }
        document.getElementById('Main-Content-Adidas').src=e.src;
        e.style.opacity  = 1;
    }


//-----------------------------------------------//













const baoquan = document.querySelector(".baoquan")
const chitiet = document.querySelector(".chitiet")
if (chitiet) {
    chitiet.addEventListener("click", function () {
        document.querySelector(".product-content-right-bottom-content-chitiet").style.display = "block"
        document.querySelector("product-content-right-bottom-content-baoquan").style.display = "none"
    })
}

if (baoquan) {
    baoquan.addEventListener("click", function () {
        document.querySelector(".product-content-right-bottom-content-chitiet").style.display = "none"
        document.querySelector("product-content-right-bottom-content-baoquan").style.display = "block"

    })
}



const butTon = document.querySelector("product-content-right-bottom-top")
if (butTon) {
    butTon.addEventListener("click", function () {
        document.querySelector("product-content-right-bottom-big").classList.toggle("activeB")
    } )
}