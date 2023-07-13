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
    public class CT_HoaDonNhapController : Controller
    {
        private ShopDottiesShoesEntities1 db = new ShopDottiesShoesEntities1();

        // GET: ADminDVC/CT_HoaDonNhap
        public ActionResult Index()
        {
            var cT_HoaDonNhap = db.CT_HoaDonNhap.Include(c => c.HoaDonNhap).Include(c => c.SanPham);
            return View(cT_HoaDonNhap.ToList());
        }

        // GET: ADminDVC/CT_HoaDonNhap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDonNhap cT_HoaDonNhap = db.CT_HoaDonNhap.Find(id);
            if (cT_HoaDonNhap == null)
            {
                return HttpNotFound();
            }
            return View(cT_HoaDonNhap);
        }

        // GET: ADminDVC/CT_HoaDonNhap/Create
        public ActionResult Create()
        {
            ViewBag.MaHDN = new SelectList(db.HoaDonNhaps, "MaHDN", "SDT");
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "TenLoai");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "HinhAnh");
            return View();
        }

        // POST: ADminDVC/CT_HoaDonNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHDN,MaHDN,MaSP,SoLuong,DonGia,TongTien,MaLoai")] CT_HoaDonNhap cT_HoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.CT_HoaDonNhap.Add(cT_HoaDonNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHDN = new SelectList(db.HoaDonNhaps, "MaHDN", "SDT", cT_HoaDonNhap.MaHDN);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "HinhAnh", cT_HoaDonNhap.MaSP);
            return View(cT_HoaDonNhap);
        }

        // GET: ADminDVC/CT_HoaDonNhap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDonNhap cT_HoaDonNhap = db.CT_HoaDonNhap.Find(id);
            if (cT_HoaDonNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHDN = new SelectList(db.HoaDonNhaps, "MaHDN", "SDT", cT_HoaDonNhap.MaHDN);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "HinhAnh", cT_HoaDonNhap.MaSP);
            return View(cT_HoaDonNhap);
        }

        // POST: ADminDVC/CT_HoaDonNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHDN,MaHDN,MaSP,SoLuong,DonGia,TongTien,MaLoai")] CT_HoaDonNhap cT_HoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HoaDonNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHDN = new SelectList(db.HoaDonNhaps, "MaHDN", "SDT", cT_HoaDonNhap.MaHDN);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "HinhAnh", cT_HoaDonNhap.MaSP);
            return View(cT_HoaDonNhap);
        }

        // GET: ADminDVC/CT_HoaDonNhap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDonNhap cT_HoaDonNhap = db.CT_HoaDonNhap.Find(id);
            db.CT_HoaDonNhap.Remove(cT_HoaDonNhap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ADminDVC/CT_HoaDonNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_HoaDonNhap cT_HoaDonNhap = db.CT_HoaDonNhap.Find(id);
            db.CT_HoaDonNhap.Remove(cT_HoaDonNhap);
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
