using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flight.Models;

namespace Flight.Controllers
{
    public class VECHUYENBAYsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: VECHUYENBAYs
        public ActionResult Index()
        {
            var vECHUYENBAYs = db.VECHUYENBAYs.Include(v => v.CHUYENBAY).Include(v => v.DONGIA).Include(v => v.HANGVE).Include(v => v.KHACHHANG);
            return View(vECHUYENBAYs.ToList());
        }

        // GET: VECHUYENBAYs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VECHUYENBAY vECHUYENBAY = db.VECHUYENBAYs.Find(id);
            if (vECHUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(vECHUYENBAY);
        }

        // GET: VECHUYENBAYs/Create
        public ActionResult Create()
        {
            ViewBag.MaChuyenBay = new SelectList(db.CHUYENBAYs, "MaChuyenBay", "MaChiTietChuyenBay");
            ViewBag.MaDonGia = new SelectList(db.DONGIAs, "MaDonGia", "MaDonGia");
            ViewBag.MaHangVe = new SelectList(db.HANGVEs, "MaHangVe", "TenHangVe");
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang");
            return View();
        }

        // POST: VECHUYENBAYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVeChuyenBay,TinhTrangVe,MaDonGia,MaHangVe,MaChuyenBay,CMND")] VECHUYENBAY vECHUYENBAY)
        {
            if (ModelState.IsValid)
            {
                db.VECHUYENBAYs.Add(vECHUYENBAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChuyenBay = new SelectList(db.CHUYENBAYs, "MaChuyenBay", "MaChiTietChuyenBay", vECHUYENBAY.MaChuyenBay);
            ViewBag.MaDonGia = new SelectList(db.DONGIAs, "MaDonGia", "MaDonGia", vECHUYENBAY.MaDonGia);
            ViewBag.MaHangVe = new SelectList(db.HANGVEs, "MaHangVe", "TenHangVe", vECHUYENBAY.MaHangVe);
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang", vECHUYENBAY.CMND);
            return View(vECHUYENBAY);
        }

        // GET: VECHUYENBAYs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VECHUYENBAY vECHUYENBAY = db.VECHUYENBAYs.Find(id);
            if (vECHUYENBAY == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChuyenBay = new SelectList(db.CHUYENBAYs, "MaChuyenBay", "MaChiTietChuyenBay", vECHUYENBAY.MaChuyenBay);
            ViewBag.MaDonGia = new SelectList(db.DONGIAs, "MaDonGia", "MaDonGia", vECHUYENBAY.MaDonGia);
            ViewBag.MaHangVe = new SelectList(db.HANGVEs, "MaHangVe", "TenHangVe", vECHUYENBAY.MaHangVe);
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang", vECHUYENBAY.CMND);
            return View(vECHUYENBAY);
        }

        // POST: VECHUYENBAYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVeChuyenBay,TinhTrangVe,MaDonGia,MaHangVe,MaChuyenBay,CMND")] VECHUYENBAY vECHUYENBAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vECHUYENBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChuyenBay = new SelectList(db.CHUYENBAYs, "MaChuyenBay", "MaChiTietChuyenBay", vECHUYENBAY.MaChuyenBay);
            ViewBag.MaDonGia = new SelectList(db.DONGIAs, "MaDonGia", "MaDonGia", vECHUYENBAY.MaDonGia);
            ViewBag.MaHangVe = new SelectList(db.HANGVEs, "MaHangVe", "TenHangVe", vECHUYENBAY.MaHangVe);
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang", vECHUYENBAY.CMND);
            return View(vECHUYENBAY);
        }

        // GET: VECHUYENBAYs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VECHUYENBAY vECHUYENBAY = db.VECHUYENBAYs.Find(id);
            if (vECHUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(vECHUYENBAY);
        }

        // POST: VECHUYENBAYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VECHUYENBAY vECHUYENBAY = db.VECHUYENBAYs.Find(id);
            db.VECHUYENBAYs.Remove(vECHUYENBAY);
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
