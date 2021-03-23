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
                sessionGioHang = new GioHang();
            return View(sessionGioHang);
        }
        public ActionResult AddItem(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                GioHang sessionGioHang = Session["GioHang"] as GioHang;
                if (sessionGioHang == null)
                    sessionGioHang = new GioHang();
                SanPham sanPham = db.SanPhams.Where(x => x.SanPhamID == id).FirstOrDefault();
                sessionGioHang.Add(sanPham);
                Session["GioHang"] = sessionGioHang;
                var t = Request.UrlReferrer.AbsolutePath;
                return RedirectToAction("Index", "ChiTietSanPham", new { id = Request.UrlReferrer.Segments.Last() });
            }
        }
        public ActionResult RemoveProDuct(int id, int soLuong)
        {
            var sessionGioHang = Session["GioHang"] as GioHang;
            sessionGioHang.ChangeAmount(id, soLuong);
            Session["GioHang"] = sessionGioHang;
            return RedirectToAction("Index");
        }
        public ActionResult RemoveAllItem(int id)
        {
            var sessionGioHang = Session["GioHang"] as GioHang;
            sessionGioHang.RemoveAll(id);
            Session["GioHang"] = sessionGioHang;
            return RedirectToAction("Index");
        }
        public ActionResult Total(int id)
        {
            var sessionGioHang = Session["GioHang"] as GioHang;
            return RedirectToAction("Index");
        }
    }
}