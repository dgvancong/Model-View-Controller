function search() {
    var inp = document.querySelector(".input-search");
    var prd = document.querySelectorAll(".Content_Center_Product");
    for (var i = 0; i < prd.length; i++) {
        prd[i].style.display = 'block';
        console.log(prd[i].textContent.toLowerCase());
        if (prd[i].textContent.toLowerCase().includes(inp.value.toLowerCase()) == false) {
            prd[i].style.display = 'none';
        }
    }
}