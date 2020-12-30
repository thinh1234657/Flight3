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
    public class PHIEUDATCHOesController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: PHIEUDATCHOes
        public ActionResult Index()
        {
            var pHIEUDATCHOes = db.PHIEUDATCHOes.Include(p => p.KHACHHANG);
            return View(pHIEUDATCHOes.ToList());
        }

        // GET: PHIEUDATCHOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUDATCHO pHIEUDATCHO = db.PHIEUDATCHOes.Find(id);
            if (pHIEUDATCHO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUDATCHO);
        }

        // GET: PHIEUDATCHOes/Create
        public ActionResult Create()
        {
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang");
            return View();
        }

        // POST: PHIEUDATCHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuDatCho,NgayDat,SoGheDat,CMND,MaChuyenBay")] PHIEUDATCHO pHIEUDATCHO)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUDATCHOes.Add(pHIEUDATCHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang", pHIEUDATCHO.CMND);
            return View(pHIEUDATCHO);
        }

        // GET: PHIEUDATCHOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUDATCHO pHIEUDATCHO = db.PHIEUDATCHOes.Find(id);
            if (pHIEUDATCHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang", pHIEUDATCHO.CMND);
            return View(pHIEUDATCHO);
        }

        // POST: PHIEUDATCHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuDatCho,NgayDat,SoGheDat,CMND,MaChuyenBay")] PHIEUDATCHO pHIEUDATCHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUDATCHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang", pHIEUDATCHO.CMND);
            return View(pHIEUDATCHO);
        }

        // GET: PHIEUDATCHOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUDATCHO pHIEUDATCHO = db.PHIEUDATCHOes.Find(id);
            if (pHIEUDATCHO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUDATCHO);
        }

        // POST: PHIEUDATCHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUDATCHO pHIEUDATCHO = db.PHIEUDATCHOes.Find(id);
            db.PHIEUDATCHOes.Remove(pHIEUDATCHO);
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
