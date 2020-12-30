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
    public class TUYENBAYsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: TUYENBAYs
        public ActionResult Index()
        {
            return View(db.TUYENBAYs.ToList());
        }

        // GET: TUYENBAYs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENBAY tUYENBAY = db.TUYENBAYs.Find(id);
            if (tUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(tUYENBAY);
        }

        // GET: TUYENBAYs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TUYENBAYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTuyenBay,MaSanBayDi,MaSanBayDen")] TUYENBAY tUYENBAY)
        {
            if (ModelState.IsValid)
            {
                db.TUYENBAYs.Add(tUYENBAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tUYENBAY);
        }

        // GET: TUYENBAYs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENBAY tUYENBAY = db.TUYENBAYs.Find(id);
            if (tUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(tUYENBAY);
        }

        // POST: TUYENBAYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTuyenBay,MaSanBayDi,MaSanBayDen")] TUYENBAY tUYENBAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tUYENBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tUYENBAY);
        }

        // GET: TUYENBAYs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENBAY tUYENBAY = db.TUYENBAYs.Find(id);
            if (tUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(tUYENBAY);
        }

        // POST: TUYENBAYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TUYENBAY tUYENBAY = db.TUYENBAYs.Find(id);
            db.TUYENBAYs.Remove(tUYENBAY);
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
