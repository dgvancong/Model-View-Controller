
var list = document.getElementsByClassName("slide-img");
var index = 0;

function Init() {
    if (list && list.length > 0) {
        for (let x of list) {
            x.style.display = 'none';
        }
        list[index].style.display = 'block';
        list[index].style.animation = 'fadeIn 1s ease-in-out'
    }
}

function showL() {
    if (list && list.length > 0) {
        for (let x of list) {
            x.style.display = 'none';
        }

        if (index < list.length - 1)
            index = index + 1;
        else index = 0;
        list[index].style.display = 'block';
        list[index].style.animation = 'fadeIn 1s ease-in-out'

    }
}

function showR() {
    if (list && list.length > 0) {
        for (let x of list) {
            x.style.display = 'none';
        }

        if (index > 0)
            index = index - 1;
        else index = list.length - 1;
        list[index].style.display = 'block';
        list[index].style.animation = 'fadeIn 1s ease-in-out'

    }
}
Init();
setTimeout(showL, 6000);