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
    public class CHUYENBAYsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: CHUYENBAYs
        public ActionResult Index()
        {
            var cHUYENBAYs = db.CHUYENBAYs.Include(c => c.CHITIETCHUYENBAY).Include(c => c.MAYBAY).Include(c => c.TUYENBAY);
            return View(cHUYENBAYs.ToList());
        }

        // GET: CHUYENBAYs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENBAY cHUYENBAY = db.CHUYENBAYs.Find(id);
            if (cHUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENBAY);
        }

        // GET: CHUYENBAYs/Create
        public ActionResult Create()
        {
            ViewBag.MaChuyenBay = new SelectList(db.CHITIETCHUYENBAYs, "MaChiTietChuyenBay", "MaChuyenBay");
            ViewBag.MaMayBay = new SelectList(db.MAYBAYs, "MaMayBay", "LoaiMayBay");
            ViewBag.MaTuyenBay = new SelectList(db.TUYENBAYs, "MaTuyenBay", "MaSanBayDi");
            return View();
        }

        // POST: CHUYENBAYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChuyenBay,NgayGio,ThoiGianBay,SoLuongGheHang1,SoLuongGheHang2,MaChiTietChuyenBay,MaTuyenBay,MaMayBay")] CHUYENBAY cHUYENBAY)
        {
            if (ModelState.IsValid)
            {
                db.CHUYENBAYs.Add(cHUYENBAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChuyenBay = new SelectList(db.CHITIETCHUYENBAYs, "MaChiTietChuyenBay", "MaChuyenBay", cHUYENBAY.MaChuyenBay);
            ViewBag.MaMayBay = new SelectList(db.MAYBAYs, "MaMayBay", "LoaiMayBay", cHUYENBAY.MaMayBay);
            ViewBag.MaTuyenBay = new SelectList(db.TUYENBAYs, "MaTuyenBay", "MaSanBayDi", cHUYENBAY.MaTuyenBay);
            return View(cHUYENBAY);
        }

        // GET: CHUYENBAYs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENBAY cHUYENBAY = db.CHUYENBAYs.Find(id);
            if (cHUYENBAY == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChuyenBay = new SelectList(db.CHITIETCHUYENBAYs, "MaChiTietChuyenBay", "MaChuyenBay", cHUYENBAY.MaChuyenBay);
            ViewBag.MaMayBay = new SelectList(db.MAYBAYs, "MaMayBay", "LoaiMayBay", cHUYENBAY.MaMayBay);
            ViewBag.MaTuyenBay = new SelectList(db.TUYENBAYs, "MaTuyenBay", "MaSanBayDi", cHUYENBAY.MaTuyenBay);
            return View(cHUYENBAY);
        }

        // POST: CHUYENBAYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChuyenBay,NgayGio,ThoiGianBay,SoLuongGheHang1,SoLuongGheHang2,MaChiTietChuyenBay,MaTuyenBay,MaMayBay")] CHUYENBAY cHUYENBAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUYENBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChuyenBay = new SelectList(db.CHITIETCHUYENBAYs, "MaChiTietChuyenBay", "MaChuyenBay", cHUYENBAY.MaChuyenBay);
            ViewBag.MaMayBay = new SelectList(db.MAYBAYs, "MaMayBay", "LoaiMayBay", cHUYENBAY.MaMayBay);
            ViewBag.MaTuyenBay = new SelectList(db.TUYENBAYs, "MaTuyenBay", "MaSanBayDi", cHUYENBAY.MaTuyenBay);
            return View(cHUYENBAY);
        }

        // GET: CHUYENBAYs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENBAY cHUYENBAY = db.CHUYENBAYs.Find(id);
            if (cHUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENBAY);
        }

        // POST: CHUYENBAYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHUYENBAY cHUYENBAY = db.CHUYENBAYs.Find(id);
            db.CHUYENBAYs.Remove(cHUYENBAY);
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
