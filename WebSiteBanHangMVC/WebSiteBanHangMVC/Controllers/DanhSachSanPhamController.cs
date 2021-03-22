using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHangMVC.Models;

namespace WebSiteBanHangMVC.Controllers
{
    public class DanhSachSanPhamController : Controller
    {
        // GET: DanhSachSanPham
        public ActionResult DanhSachSanPhamTheoLoai(int? CategoryID)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                if (CategoryID.HasValue)
                {
                    var tenLoaiSanPham = db.PhanLoaiSanPhams.Where(x => x.PhanLoaiSanPhamID == CategoryID).Select(x => x.TenPhanLoaiSanPham).FirstOrDefault();
                    var listSPTheoLoai = db.SanPhams.Where(x => x.LoaiSanPhamID == CategoryID).OrderByDescending(x => x.SanPhamID).ToList();
                    ViewData["listSPTheoLoai"] = listSPTheoLoai;
                    ViewBag.tenLoaiSanPham = tenLoaiSanPham;
                }
                else
                {
                    var listSPTheoLoai = db.SanPhams.OrderByDescending(x => x.SanPhamID).Take(12).ToList();
                    ViewData["listSPTheoLoai"] = listSPTheoLoai;
                    ViewBag.tenLoaiSanPham = "Sản phẩm";
                }
                
            }
            return View();
        }
    }
}