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
    public class HANGVEsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: HANGVEs
        public ActionResult Index()
        {
            return View(db.HANGVEs.ToList());
        }

        // GET: HANGVEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANGVE hANGVE = db.HANGVEs.Find(id);
            if (hANGVE == null)
            {
                return HttpNotFound();
            }
            return View(hANGVE);
        }

        // GET: HANGVEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HANGVEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHangVe,TenHangVe")] HANGVE hANGVE)
        {
            if (ModelState.IsValid)
            {
                db.HANGVEs.Add(hANGVE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hANGVE);
        }

        // GET: HANGVEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANGVE hANGVE = db.HANGVEs.Find(id);
            if (hANGVE == null)
            {
                return HttpNotFound();
            }
            return View(hANGVE);
        }

        // POST: HANGVEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHangVe,TenHangVe")] HANGVE hANGVE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hANGVE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hANGVE);
        }

        // GET: HANGVEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANGVE hANGVE = db.HANGVEs.Find(id);
            if (hANGVE == null)
            {
                return HttpNotFound();
            }
            return View(hANGVE);
        }

        // POST: HANGVEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HANGVE hANGVE = db.HANGVEs.Find(id);
            db.HANGVEs.Remove(hANGVE);
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
