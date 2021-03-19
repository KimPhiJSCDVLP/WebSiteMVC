using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHangMVC.Models;
using static WebSiteBanHangMVC.Models.GioHang;

namespace WebSiteBanHangMVC.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            var sessionGioHang = Session["GioHang"];
            if (sessionGioHang == null)
            {
                sessionGioHang = new GioHang();
            }
            else
            {
                var lstSanPham = (sessionGioHang as GioHang).Gio.Distinct().ToList();
            }
            return View(sessionGioHang);
        }
        public ActionResult AddItem(int id)
        {
            // logic them 1 san pham vao gio hang
            using (var db = new ApplicationDbContext())
            {
                GioHang sessionGioHang = Session["GioHang"] as GioHang;
                if (sessionGioHang == null)
                {
                    sessionGioHang = new GioHang();
                }
                SanPham sanPham = db.SanPhams.FirstOrDefault(x => x.SanPhamID == id);
                if (sanPham != null)
                {
                    sessionGioHang.Add(sanPham);
                }
                Session["GioHang"] = sessionGioHang;
                var transation = Request.UrlReferrer;
                return RedirectToAction("Index", "ChiTietSanPham", new { id = transation.Segments.Last() });

            }
        }

        public ActionResult AddItems(List<int> ids)
        {
            // logic them nhieu san pham vao gio hang
            return View();
        }

        public ActionResult CapNhatSoLuong(int id, int soLuong)
        {
            // Cap nhat so luong cua san pham
            var sessionGioHang = Session["GioHang"] as GioHang;
            sessionGioHang.UpdateSoLuong(id, soLuong);
            Session["GioHang"] = sessionGioHang;
            return RedirectToAction("Index");
        }
    }
}