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
    public class MAYBAYsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: MAYBAYs
        public ActionResult Index()
        {
            return View(db.MAYBAYs.ToList());
        }

        // GET: MAYBAYs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAYBAY mAYBAY = db.MAYBAYs.Find(id);
            if (mAYBAY == null)
            {
                return HttpNotFound();
            }
            return View(mAYBAY);
        }

        // GET: MAYBAYs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MAYBAYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMayBay,LoaiMayBay")] MAYBAY mAYBAY)
        {
            if (ModelState.IsValid)
            {
                db.MAYBAYs.Add(mAYBAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mAYBAY);
        }

        // GET: MAYBAYs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAYBAY mAYBAY = db.MAYBAYs.Find(id);
            if (mAYBAY == null)
            {
                return HttpNotFound();
            }
            return View(mAYBAY);
        }

        // POST: MAYBAYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMayBay,LoaiMayBay")] MAYBAY mAYBAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAYBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mAYBAY);
        }

        // GET: MAYBAYs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAYBAY mAYBAY = db.MAYBAYs.Find(id);
            if (mAYBAY == null)
            {
                return HttpNotFound();
            }
            return View(mAYBAY);
        }

        // POST: MAYBAYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MAYBAY mAYBAY = db.MAYBAYs.Find(id);
            db.MAYBAYs.Remove(mAYBAY);
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
