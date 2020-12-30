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
    public class CHITIETCHUYENBAYsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: CHITIETCHUYENBAYs
        public ActionResult Index()
        {
            var cHITIETCHUYENBAYs = db.CHITIETCHUYENBAYs.Include(c => c.CHUYENBAY);
            return View(cHITIETCHUYENBAYs.ToList());
        }

        // GET: CHITIETCHUYENBAYs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETCHUYENBAY cHITIETCHUYENBAY = db.CHITIETCHUYENBAYs.Find(id);
            if (cHITIETCHUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETCHUYENBAY);
        }

        // GET: CHITIETCHUYENBAYs/Create
        public ActionResult Create()
        {
            ViewBag.MaChiTietChuyenBay = new SelectList(db.CHUYENBAYs, "MaChuyenBay", "MaChiTietChuyenBay");
            return View();
        }

        // POST: CHITIETCHUYENBAYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChiTietChuyenBay,MaChuyenBay,SanBayTrungGian,ThoiGianDung,GhiChu")] CHITIETCHUYENBAY cHITIETCHUYENBAY)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETCHUYENBAYs.Add(cHITIETCHUYENBAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChiTietChuyenBay = new SelectList(db.CHUYENBAYs, "MaChuyenBay", "MaChiTietChuyenBay", cHITIETCHUYENBAY.MaChiTietChuyenBay);
            return View(cHITIETCHUYENBAY);
        }

        // GET: CHITIETCHUYENBAYs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETCHUYENBAY cHITIETCHUYENBAY = db.CHITIETCHUYENBAYs.Find(id);
            if (cHITIETCHUYENBAY == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChiTietChuyenBay = new SelectList(db.CHUYENBAYs, "MaChuyenBay", "MaChiTietChuyenBay", cHITIETCHUYENBAY.MaChiTietChuyenBay);
            return View(cHITIETCHUYENBAY);
        }

        // POST: CHITIETCHUYENBAYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChiTietChuyenBay,MaChuyenBay,SanBayTrungGian,ThoiGianDung,GhiChu")] CHITIETCHUYENBAY cHITIETCHUYENBAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETCHUYENBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChiTietChuyenBay = new SelectList(db.CHUYENBAYs, "MaChuyenBay", "MaChiTietChuyenBay", cHITIETCHUYENBAY.MaChiTietChuyenBay);
            return View(cHITIETCHUYENBAY);
        }

        // GET: CHITIETCHUYENBAYs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETCHUYENBAY cHITIETCHUYENBAY = db.CHITIETCHUYENBAYs.Find(id);
            if (cHITIETCHUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETCHUYENBAY);
        }

        // POST: CHITIETCHUYENBAYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHITIETCHUYENBAY cHITIETCHUYENBAY = db.CHITIETCHUYENBAYs.Find(id);
            db.CHITIETCHUYENBAYs.Remove(cHITIETCHUYENBAY);
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
