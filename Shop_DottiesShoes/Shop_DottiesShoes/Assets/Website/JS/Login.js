function login(){
    var loi = "";
    var email= document.getElementById("email");
if(email.value==""){
    email.className="loi";
    loi += "Email không được bỏ trống.";
}
else if(email.value.lenght > 30){
    email.className="loi";
    loi += "Email quá dài.";
}
else email.className="txt";

var password= document.getElementById("password");
if(password.value==""){
    password.className="loi";
    loi += " Mật khẩu không được bỏ trống.";
}
else if(password.value.lenght <= 10){
    password.className="loi";
    loi += "Mật khẩu không đúng 10 kí tự.";
}
else password.className="txt";
if(loi!=""){
    document.getElementById('baoloi').innerHTML=loi;
    return false;
}
}