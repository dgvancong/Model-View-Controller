using Newtonsoft.Json;
using Shop_DottiesShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shop_DottiesShoes.Controllers
{
    public class HomeController : Controller
    {
        ShopDottiesShoesEntities1 db = new ShopDottiesShoesEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductInterface(int id)
        {
            var ds = db.SanPhams.FirstOrDefault(s => s.MaSP == id);
            return View(ds);
        }
        public ActionResult CartInterface()
        {
            List<CT_HoaDonBan> ds = (List<CT_HoaDonBan>)Session["cart"];
            return View(ds);
        }
        public ActionResult viewCart()
        {
            List<CT_HoaDonBan> ds = (List<CT_HoaDonBan>)Session["cart"] ?? new List<CT_HoaDonBan>();
            List<CT_HoaDonBan> ds1 = new List<CT_HoaDonBan>();
            foreach (var d in ds)
            {
                ds1.Add(d);
            }
            return View(ds);
        }
        public ActionResult AddCart(int id)
        {
            var spt = db.SanPhams.FirstOrDefault(s => s.MaSP == id);
            if (Session["cart"] != null)
            {
                List<CT_HoaDonBan> cart = (List<CT_HoaDonBan>)Session["cart"] ?? new List<CT_HoaDonBan>();
                var kt = cart.FirstOrDefault(s => s.SanPham.MaSP == id);
                if (kt == null)
                {
                    CT_HoaDonBan sp = new CT_HoaDonBan() { MaCTHDB = id, SoLuong = 1, SanPham = spt };

                    cart.Add(sp);

                }
                else
                {
                    kt.SoLuong += 1;
                }
                Session["cart"] = cart;
            }
            else
            {
                List<CT_HoaDonBan> cart = new List<CT_HoaDonBan>();
                CT_HoaDonBan sp = new CT_HoaDonBan() { MaCTHDB = id, SoLuong = 1, SanPham = spt };
                cart.Add(sp);
                Session["cart"] = cart;

            }
            return RedirectToAction("Index");
        }
        public ActionResult LoginInterface()
        {
            return View();
        }
        public ActionResult SignupInterface()
        {
            return View();
        }
        public ContentResult GetProduct()
        {
            var ds = db.SanPhams.Select(s => new { s.MaSP, s.MaLoai, s.MauSac, s.TenSP, s.HinhAnh, s.GiaSale, s.DonGia, s.KichThuoc, s.SoLuong, s.GhiChu }).ToList();
            var list = JsonConvert.SerializeObject(ds,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(list, "application/json");
        }
        public ActionResult NikeInterface()
        {
            List<SanPham> list = db.SanPhams.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult PaymentInterface()
        {
            List<CT_HoaDonBan> ds = (List<CT_HoaDonBan>)Session["cart"];
            ViewBag.cart = ds;
            return View();
        }
        [HttpPost]
        public ActionResult PaymentInterface(string DeliveryAddress, string note, string phone, string recipient)
        {
            var session = (Shop_DottiesShoes.Common.UserLogin)Session[Shop_DottiesShoes.Common.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return Redirect("/User/Login");
            }
            var order = new HoaDonBan();
            order.NgayDat = DateTime.Now;
            order.DiaChi = DeliveryAddress;
            order.SDT = phone;
            order.TrangThai = "Đang giao";
            order.GhiChu = note;
            order.Username = session.UserName;
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CT_HoaDonBan>)Session["cart"];
                var detailDao = new OrderDetailsDao();
                foreach (var item in cart)
                {
                    var orderDetail = new CT_HoaDonBan();
                    orderDetail.MaHDB = id;
                    orderDetail.MaSP = item.SanPham.MaSP;
                    orderDetail.SoLuong = item.SoLuong;
                    orderDetail.DonGia = item.SanPham.DonGia;
                    detailDao.Insert(orderDetail);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("LoiThanhToan", "Home");
            }
            return RedirectToAction("Success", "Home");
        }
        public ActionResult Success()
        {
            Session["cart"] = null;
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CT_HoaDonBan>)Session["cart"];
            sessionCart.RemoveAll(x => x.SanPham.MaSP == id);
            Session["cart"] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session["cart"] = null;
            return Json(new
            {
                status = true
            });
        }
        // Cập nhật giỏ hàng
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CT_HoaDonBan>>(cartModel);
            var sessionCart = (List<CT_HoaDonBan>)Session["cart"];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.MaSP == item.SanPham.MaSP);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session["cart"] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
    }
}