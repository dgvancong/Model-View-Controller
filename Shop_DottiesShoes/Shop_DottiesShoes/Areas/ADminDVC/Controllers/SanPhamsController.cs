using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_DottiesShoes.Models;
using Newtonsoft.Json;

namespace Shop_DottiesShoes.Areas.ADminDVC.Controllers
{
    public class SanPhamsController : BaseController
    {
        private ShopDottiesShoesEntities1 db = new ShopDottiesShoesEntities1();

        // GET: ADminDVC/SanPhams
        public ActionResult Index()
        {
            Session["UserName"] = "admin";
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham);
            return View(sanPhams.ToList());
        }
        public JsonResult GetByID(int id)
        {
            Session["UserName"] = "admin";
            var sp = db.SanPhams.Select(s => new { s.MaSP, s.HinhAnh, s.MaLoai, s.TenSP, s.SoLuong, s.DonGia, s.MauSac, s.KichThuoc, s.GhiChu, s.GiaSale }).FirstOrDefault(s => s.MaSP == id); return Json(sp, JsonRequestBehavior.AllowGet);
        }

        public ContentResult GetTenDM()
        {
            Session["UserName"] = "admin";
            var ds = db.LoaiSanPhams.Select(s => new { s.MaLoai, s.TenLoai, s.GhiChu }).ToList();
            var list = JsonConvert.SerializeObject(ds,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(list, "application/json");
            //return Json(ds, JsonRequestBehavior.AllowGet);

        }
        public ContentResult GetAll()
        {
            Session["UserName"] = "admin";
            var ds = db.SanPhams.Select(s => new { s.MaSP, s.HinhAnh, s.MaLoai, s.TenSP, s.SoLuong, s.DonGia, s.MauSac, s.KichThuoc, s.GhiChu, s.GiaSale }).ToList();
            var list = JsonConvert.SerializeObject(ds,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(list, "application/json");
            //return Json(ds, JsonRequestBehavior.AllowGet);
        }

        // GET: ADminDVC/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: ADminDVC/SanPhams/Create
        public ActionResult Create()
        {
            Session["UserName"] = "admin";
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "TenLoai", "MaLoai");
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham sanpham)
        {
            Session["UserName"] = "admin";
            db.SanPhams.Add(sanpham);
            db.SaveChanges();
            SetAlert("Thêm sản phẩm thành công", "success");
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "TenLoai", sanpham.MaLoai);
            //return Json(true, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }

        // GET: ADminDVC/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // POST: ADminDVC/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(SanPham sanpham)
        {
            db.Entry(sanpham).State = EntityState.Modified;
            db.SaveChanges();
            SetAlert("Sửa sản phẩm thành công", "success");

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: ADminDVC/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ADminDVC/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            SetAlert("Xoá sản phẩm thành công", "success");
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public JsonResult DeleteObj(int id)
        {
            var ncc = db.NhaCungCaps.Where(x => x.MaNCC == id).FirstOrDefault();
            db.NhaCungCaps.Remove(ncc);
            db.SaveChanges();
            SetAlert("Xoá nhà cung cấp thành công", "success");
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
