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
    public class SANBAYsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: SANBAYs
        public ActionResult Index()
        {
            return View(db.SANBAYs.ToList());
        }

        // GET: SANBAYs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANBAY sANBAY = db.SANBAYs.Find(id);
            if (sANBAY == null)
            {
                return HttpNotFound();
            }
            return View(sANBAY);
        }

        // GET: SANBAYs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SANBAYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanBay,TenSanBay")] SANBAY sANBAY)
        {
            if (ModelState.IsValid)
            {
                db.SANBAYs.Add(sANBAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sANBAY);
        }

        // GET: SANBAYs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANBAY sANBAY = db.SANBAYs.Find(id);
            if (sANBAY == null)
            {
                return HttpNotFound();
            }
            return View(sANBAY);
        }

        // POST: SANBAYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanBay,TenSanBay")] SANBAY sANBAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sANBAY);
        }

        // GET: SANBAYs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANBAY sANBAY = db.SANBAYs.Find(id);
            if (sANBAY == null)
            {
                return HttpNotFound();
            }
            return View(sANBAY);
        }

        // POST: SANBAYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANBAY sANBAY = db.SANBAYs.Find(id);
            db.SANBAYs.Remove(sANBAY);
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
