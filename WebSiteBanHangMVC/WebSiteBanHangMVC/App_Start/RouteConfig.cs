using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSiteBanHangMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "AddItem",
               url: "them-sp-gio-hang/{id}",
               defaults: new { controller = "GioHang", action = "AddItem" }
            );
            routes.MapRoute(
               name: "AddItems",
               url: "them-nhieu-sp-gio-hang/{ids}",
               defaults: new { controller = "GioHang", action = "AddItems" }
           );
            routes.MapRoute(
              name: "DanhSachSanPham",
              url: "danh-sach-san-pham-theo-loai/{CategoryID}",
              defaults: new { controller = "DanhSachSanPham", action = "DanhSachSanPhamTheoLoai" }
          );
            routes.MapRoute(
                name: "ChiTietSanPham",
                url: "chi-tiet-san-pham/{id}",
                defaults: new { controller = "ChiTietSanPham", action = "Index" }
             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
