﻿using System;
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
    public class HOADONsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: HOADONs
        public ActionResult Index()
        {
            var hOADONs = db.HOADONs.Include(h => h.DOANHTHUTHANG).Include(h => h.KHACHHANG).Include(h => h.NHANVIEN);
            return View(hOADONs.ToList());
        }

        // GET: HOADONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // GET: HOADONs/Create
        public ActionResult Create()
        {
            ViewBag.MaDoanhThuThang = new SelectList(db.DOANHTHUTHANGs, "MaDoanhThuThang", "MaDoanhThuNam");
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang");
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: HOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,NgayHoaDon,ThanhTien,CMND,MaNhanVien,MaDoanhThuThang")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDoanhThuThang = new SelectList(db.DOANHTHUTHANGs, "MaDoanhThuThang", "MaDoanhThuNam", hOADON.MaDoanhThuThang);
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang", hOADON.CMND);
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "TenNhanVien", hOADON.MaNhanVien);
            return View(hOADON);
        }

        // GET: HOADONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDoanhThuThang = new SelectList(db.DOANHTHUTHANGs, "MaDoanhThuThang", "MaDoanhThuNam", hOADON.MaDoanhThuThang);
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang", hOADON.CMND);
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "TenNhanVien", hOADON.MaNhanVien);
            return View(hOADON);
        }

        // POST: HOADONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,NgayHoaDon,ThanhTien,CMND,MaNhanVien,MaDoanhThuThang")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDoanhThuThang = new SelectList(db.DOANHTHUTHANGs, "MaDoanhThuThang", "MaDoanhThuNam", hOADON.MaDoanhThuThang);
            ViewBag.CMND = new SelectList(db.KHACHHANGs, "CMND", "TenKhachHang", hOADON.CMND);
            ViewBag.MaNhanVien = new SelectList(db.NHANVIENs, "MaNhanVien", "TenNhanVien", hOADON.MaNhanVien);
            return View(hOADON);
        }

        // GET: HOADONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
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
