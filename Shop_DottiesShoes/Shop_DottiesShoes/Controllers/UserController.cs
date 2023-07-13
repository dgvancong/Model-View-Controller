﻿using Shop_DottiesShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_DottiesShoes.Common;

namespace Shop_DottiesShoes.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/Home/Index");
        }


        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return Redirect("/Home/Index");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    if (dao.CheckEmail(model.Email))
                    {
                        ModelState.AddModelError("", "Email đã tồn tại");
                    }
                    else
                    {
                        var user = new KhachHang();
                        user.Username = model.UserName;
                        user.MatKhau = Encryptor.MD5Hash(model.Password);
                        user.SoDT = model.Phone;
                        user.Email = model.Email;
                        user.DiaChi = model.Address;
                        user.PostCode = model.PostCode;
                        user.GroupID = Shop_DottiesShoes.Common.CommonConstants.MEMBER_GROUP;
                        var result = dao.Insert(user);
                        if (result != "")
                        {
                            ViewBag.Success = "Đăng ký thành công";
                            model = new RegisterModel();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Đăng ký không thành công");
                        }
                    }
                }
            }
            return View(model);

        }
    }
}