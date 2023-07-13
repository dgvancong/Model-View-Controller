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

namespace Shop_DottiesShoes.Areas.ADminDVC.Controllers
{
    public class CT_HoaDonBanController : Controller
    {
        private ShopDottiesShoesEntities1 db = new ShopDottiesShoesEntities1();

        // GET: ADminDVC/CT_HoaDonBan
        public ActionResult Index()
        {
            var cT_HoaDonBan = db.CT_HoaDonBan.Include(c => c.HoaDonBan).Include(c => c.SanPham);
            return View(cT_HoaDonBan.ToList());
        }

        // GET: ADminDVC/CT_HoaDonBan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDonBan cT_HoaDonBan = db.CT_HoaDonBan.Find(id);
            if (cT_HoaDonBan == null)
            {
                return HttpNotFound();
            }
            return View(cT_HoaDonBan);
        }

        // GET: ADminDVC/CT_HoaDonBan/Create
        public ActionResult Create()
        {
            ViewBag.MaHDB = new SelectList(db.HoaDonBans, "MaHDB", "Username");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "HinhAnh");
            return View();
        }

        // POST: ADminDVC/CT_HoaDonBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHDB,MaHDB,MaSP,SoLuong,DonGia")] CT_HoaDonBan cT_HoaDonBan, HttpPostedFileBase file1)
        {
            string _FileName = "";
            string _path = "";
            try
            {
                if (file1.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(file1.FileName);
                    _path = Path.Combine(Server.MapPath("~/UploadedFiles/files"), _FileName);
                    file1.SaveAs(_path);
                }
            }
            catch { }
            if (ModelState.IsValid)
            {
                cT_HoaDonBan.SanPham.HinhAnh = "/UploadedFiles/files/" + _FileName;
                db.CT_HoaDonBan.Add(cT_HoaDonBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHDB = new SelectList(db.HoaDonBans, "MaHDB", "Username", cT_HoaDonBan.MaHDB);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "HinhAnh", cT_HoaDonBan.MaSP);
            return View(cT_HoaDonBan);
        }

        // GET: ADminDVC/CT_HoaDonBan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDonBan cT_HoaDonBan = db.CT_HoaDonBan.Find(id);
            if (cT_HoaDonBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHDB = new SelectList(db.HoaDonBans, "MaHDB", "Username", cT_HoaDonBan.MaHDB);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "HinhAnh", cT_HoaDonBan.MaSP);
            return View(cT_HoaDonBan);
        }

        // POST: ADminDVC/CT_HoaDonBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHDB,MaHDB,MaSP,SoLuong,DonGia")] CT_HoaDonBan cT_HoaDonBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HoaDonBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHDB = new SelectList(db.HoaDonBans, "MaHDB", "Username", cT_HoaDonBan.MaHDB);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "HinhAnh", cT_HoaDonBan.MaSP);
            return View(cT_HoaDonBan);
        }

        // GET: ADminDVC/CT_HoaDonBan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDonBan cT_HoaDonBan = db.CT_HoaDonBan.Find(id);
            db.CT_HoaDonBan.Remove(cT_HoaDonBan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ADminDVC/CT_HoaDonBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_HoaDonBan cT_HoaDonBan = db.CT_HoaDonBan.Find(id);
            db.CT_HoaDonBan.Remove(cT_HoaDonBan);
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
