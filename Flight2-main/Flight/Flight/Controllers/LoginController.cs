using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flight.Models;

namespace Flight.Controllers
{
    public class LoginController : Controller
    {
        private ModelDbContext db = new ModelDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(KHACHHANG kHACHHANG)
        {
            using (ModelDbContext db = new ModelDbContext())
            {
                var userDetail = db.KHACHHANGs.Where(x => x.DienThoai == kHACHHANG.DienThoai && x.Password == kHACHHANG.Password).FirstOrDefault();
                if(userDetail == null)
                    {
                    return View("Index", kHACHHANG);
                    }
                else
                {
                    Session["UserID"] = userDetail.DienThoai;
                    return RedirectToAction("Index", "Home");
                }
            }   
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "CMND,TenKhachHang,DienThoai,Password")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(kHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index" ,kHACHHANG);
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}