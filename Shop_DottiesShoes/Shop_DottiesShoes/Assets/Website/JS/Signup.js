
var list = JSON.parse(localStorage.getItem('Customer')) || [];

function DangKy() {
    var lastname = document.getElementById("lastname").value;
    var username = document.getElementById("username").value;
    var male = document.getElementById("male").value;
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var atposition = email.indexOf("@");
    var dotposition = email.lastIndexOf(".");

    if (lastname == null || lastname == "") {
        alert("Họ  người dùng không được để trống! Vui lòng nhập lại!");
        return false;
    }

    if (username == null || username == "") {
        alert("Tên người dùng không được để trống! Vui lòng nhập lại!");
        return false;
    }
    else if (email != "" && email != null && (atposition < 1 || dotposition < (atposition + 2) || (dotposition + 2) >= email.length)) {
        alert("Email khách hàng không hợp lệ! Vui lòng nhập lại!");
        return false;
    }
    else if (password == null || password == "") {
        alert("Mật khẩu khách hàng không được để trống! Vui lòng nhập lại!");
        return false;
    }

    console.log("AddCustomer");
    if (list == null) list = [];
    var customer = {
        "username": username,
        "email": email,
        "password": password
    };
    list.push(customer);
    localStorage.setItem("Customer", JSON.stringify(list));
    alert("Đăng ký thành công!");
    location.reload();
}