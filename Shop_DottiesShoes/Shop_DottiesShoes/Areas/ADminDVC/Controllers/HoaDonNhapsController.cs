using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_DottiesShoes.Models;

namespace Shop_DottiesShoes.Areas.ADminDVC.Controllers
{
    public class HoaDonNhapsController : Controller
    {
        private ShopDottiesShoesEntities1 db = new ShopDottiesShoesEntities1();

        // GET: ADminDVC/HoaDonNhaps
        public ActionResult Index()
        {
            var hoaDonNhaps = db.HoaDonNhaps.Include(h => h.NhaCungCap);
            return View(hoaDonNhaps.ToList());
        }

        // GET: ADminDVC/HoaDonNhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonNhap);
        }

        // GET: ADminDVC/HoaDonNhaps/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            return View();
        }

        // POST: ADminDVC/HoaDonNhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHDN,MaNCC,NgayDat,SDT,DiaChi,TrangThai,GhiChu")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonNhaps.Add(hoaDonNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", hoaDonNhap.MaNCC);
            return View(hoaDonNhap);
        }

        // GET: ADminDVC/HoaDonNhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", hoaDonNhap.MaNCC);
            return View(hoaDonNhap);
        }

        // POST: ADminDVC/HoaDonNhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHDN,MaNCC,NgayDat,SDT,DiaChi,TrangThai,GhiChu")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", hoaDonNhap.MaNCC);
            return View(hoaDonNhap);
        }

        // GET: ADminDVC/HoaDonNhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            db.HoaDonNhaps.Remove(hoaDonNhap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ADminDVC/HoaDonNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            db.HoaDonNhaps.Remove(hoaDonNhap);
            db.SaveChanges();
            return RedirectToAction("Index");
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
