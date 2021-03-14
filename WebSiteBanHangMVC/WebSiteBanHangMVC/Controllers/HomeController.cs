using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHangMVC.Models;

namespace WebSiteBanHangMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var lstDanhSachSanPham = db.SanPhams.ToList();
                ViewData["lstDanhSachSanPham"] = lstDanhSachSanPham;
            }
            // Add, Delete, FirstOfDefualt(), ToList(), Single, Take, Skip, OrderBy = > ....

            return View();
        }

    }
}