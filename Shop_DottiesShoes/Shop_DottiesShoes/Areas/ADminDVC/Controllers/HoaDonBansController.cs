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
    public class HoaDonBansController : Controller
    {
        private ShopDottiesShoesEntities1 db = new ShopDottiesShoesEntities1();

        // GET: ADminDVC/HoaDonBans
        public ActionResult Index()
        {
            var hoaDonBans = db.HoaDonBans.Include(h => h.KhachHang);
            return View(hoaDonBans.ToList());
        }

        // GET: ADminDVC/HoaDonBans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonBan hoaDonBan = db.HoaDonBans.Find(id);
            if (hoaDonBan == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonBan);
        }

        // GET: ADminDVC/HoaDonBans/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.KhachHangs, "Username", "DiaChi");
            return View();
        }

        // POST: ADminDVC/HoaDonBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHDB,Username,NgayDat,SDT,DiaChi,TrangThai,GhiChu")] HoaDonBan hoaDonBan)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonBans.Add(hoaDonBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.KhachHangs, "Username", "DiaChi", hoaDonBan.Username);
            return View(hoaDonBan);
        }

        // GET: ADminDVC/HoaDonBans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonBan hoaDonBan = db.HoaDonBans.Find(id);
            if (hoaDonBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.KhachHangs, "Username", "DiaChi", hoaDonBan.Username);
            return View(hoaDonBan);
        }

        // POST: ADminDVC/HoaDonBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHDB,Username,NgayDat,SDT,DiaChi,TrangThai,GhiChu")] HoaDonBan hoaDonBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.KhachHangs, "Username", "DiaChi", hoaDonBan.Username);
            return View(hoaDonBan);
        }

        // GET: ADminDVC/HoaDonBans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonBan hoaDonBan = db.HoaDonBans.Find(id);
            db.HoaDonBans.Remove(hoaDonBan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ADminDVC/HoaDonBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonBan hoaDonBan = db.HoaDonBans.Find(id);
            db.HoaDonBans.Remove(hoaDonBan);
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
