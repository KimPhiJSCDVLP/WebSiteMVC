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
        // Home
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var lstDanhSachSanPhamDangHot = db.SanPhams.Where(x => x.Hot == true).Take(8).ToList();
                ViewData["lstDanhSachSanPhamDangHot"] = lstDanhSachSanPhamDangHot;
                var lstDanhSachSanPhamDangMoi = db.SanPhams.OrderByDescending(x => x.NgayTao).Take(16).ToList();
                ViewData["lstDanhSachSanPhamDangMoi"] = lstDanhSachSanPhamDangMoi;
                // ViewData["tenDoiTuong"] = gia tri cua no;
            }
            // Add, Delete, FirstOfDefualt(), ToList(), Single, Take, Skip, OrderBy = > ....
            //Test branch
            return View();
        }
    }
}