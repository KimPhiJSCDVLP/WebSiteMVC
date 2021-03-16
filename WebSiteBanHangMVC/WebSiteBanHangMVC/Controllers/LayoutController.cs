using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHangMVC.Models;

namespace WebSiteBanHangMVC.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Header()
        {
            using (var db = new ApplicationDbContext())
            {
                var phanLoaiSanPhams = db.PhanLoaiSanPhams.ToList();
                var danhMucSanPhams = db.DanhMucSanPhams.ToList();
                var dsPhanLoaiSanPhamNam = from plsp in phanLoaiSanPhams
                                           join dm in danhMucSanPhams on plsp.DanhMucSanPhamID equals dm.DanhMucSanPhamID
                                           where dm.LaDoNam == true
                                           select plsp;

                var dsPhanLoaiSanPhamNu = from plsp in phanLoaiSanPhams
                                           join dm in danhMucSanPhams on plsp.DanhMucSanPhamID equals dm.DanhMucSanPhamID
                                           where dm.LaDoNu == true
                                           select plsp;
                ViewData["dsPhanLoaiSanPhamNam"] = dsPhanLoaiSanPhamNam.ToList();
                ViewData["dsPhanLoaiSanPhamNu"] = dsPhanLoaiSanPhamNu.ToList();
            }
            return View();
        }

        public ActionResult Footer()
        {
            return View();
        }
    }
}