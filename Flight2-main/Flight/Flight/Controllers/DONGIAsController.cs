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
    public class DONGIAsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: DONGIAs
        public ActionResult Index()
        {
            return View(db.DONGIAs.ToList());
        }

        // GET: DONGIAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONGIA dONGIA = db.DONGIAs.Find(id);
            if (dONGIA == null)
            {
                return HttpNotFound();
            }
            return View(dONGIA);
        }

        // GET: DONGIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DONGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonGia,USD,VND")] DONGIA dONGIA)
        {
            if (ModelState.IsValid)
            {
                db.DONGIAs.Add(dONGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dONGIA);
        }

        // GET: DONGIAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONGIA dONGIA = db.DONGIAs.Find(id);
            if (dONGIA == null)
            {
                return HttpNotFound();
            }
            return View(dONGIA);
        }

        // POST: DONGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonGia,USD,VND")] DONGIA dONGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dONGIA);
        }

        // GET: DONGIAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONGIA dONGIA = db.DONGIAs.Find(id);
            if (dONGIA == null)
            {
                return HttpNotFound();
            }
            return View(dONGIA);
        }

        // POST: DONGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DONGIA dONGIA = db.DONGIAs.Find(id);
            db.DONGIAs.Remove(dONGIA);
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
