var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#UpdateCart').off('click').on('click', function () {
            var listProduct = $('.ds-input');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    SanPham: {
                        MaSP: $(item).data('id')
                    }
                });
            })
            $.ajax({
                url: '/Home/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Home/viewCart"
                    }
                }
            })
        });
        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Home/DeleteAll',
                dataType: 'json',
                type: 'POST',
                sucsses: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Home/viewCart"
                    }
                }
            });
        });
        $('.delete-product').off('click').on('click', function (e) {
            e.preventDefault;
            $.ajax({
                url: '/Home/Delete',
                data: { id: $(this).data('id') },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Home/viewCart"
                    }
                }
            })
        });
    }
}
cart.init()

var listTotal = $('.product-subtotal > .amount');
console.log(listTotal)
var Total = 0;
for (let i = 0; i < listTotal.length; i++) {
    Total += parseFloat(listTotal[i].innerHTML);
}
$('#Cart-total-span').text(Total.toString());