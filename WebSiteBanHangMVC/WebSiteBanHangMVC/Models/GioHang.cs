using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteBanHangMVC.Models
{
    public class GioHang
    {
        //SanPham
        //SoLuong
        private int _tongSLSanPham; // tong so luong san pham dang co trong gio
        private int _tongSoTienCuaGioHang; // tong so tien cua gio hang
        public class SLSanPham
        {
            public SanPham SanPham { get; set; }
            public int SoLuongSp { get; set; }
            public double TongTien { 
                get {
                    return SoLuongSp * (SanPham.GiaSanPham.HasValue ? SanPham.GiaSanPham.Value : 0);
                }
                private set { }
            }

            public static bool CapNhatSoLuong(SanPham sanPham, List<SLSanPham> sanPhams, int? SoLuong = 1)
            {
                var slSanPham = sanPhams.FirstOrDefault(x => x.SanPham.SanPhamID == sanPham.SanPhamID);
                if (slSanPham == null)
                {
                    return false;
                }
                slSanPham.SoLuongSp = slSanPham.SoLuongSp + 1;
                return true;
            }

            public SLSanPham(int _soLuongSP, SanPham _sanPham)
            {
                SanPham = _sanPham;
                SoLuongSp = _soLuongSP;
            }
        }
        public List<SLSanPham> Gio { get; set; }

        public int TongSLSanPham
        {
            get
            {
                TinhSLSanPham();
                return _tongSLSanPham;
            }
            private set { }
        }

        void TinhSLSanPham()
        {
            _tongSLSanPham = 0; // 
            foreach (var item in Gio)
            {
                _tongSLSanPham += item.SoLuongSp;
            }
        }

        public int TongTien
        {
            get
            {
                TinhTongTien();
                return _tongSoTienCuaGioHang;
            }
            private set { }
        }
        void TinhTongTien()
        {
            _tongSoTienCuaGioHang = 0;
            // do tat ca nhung san pham trong gio hang ra va tinh toan tien theo soluong
            foreach (var item in Gio)
            {
                _tongSoTienCuaGioHang += (int)item.TongTien;
            }
        }

        public GioHang()
        {
            Gio = new List<SLSanPham>();
            TongTien = 0;
        }

        //AddItem
        public void Add(SanPham sanPham) {
            if (sanPham == null)
                return;
            try
            {
                if (!SLSanPham.CapNhatSoLuong(sanPham, this.Gio)) { // kiem tra xem da co sanpham do chua
                    // neu co roi t khong insert nua ma chi cap nhat so luong thoi
                    this.Gio.Add(new SLSanPham(1, sanPham));
                }
                TinhTongTien(); // tinh tong tien
            }
            catch (Exception)
            {
                return;
            }
        }

        //UpdateItem
        public void ChangeAmount(int sanPhamId, int soLuong)
        {
            var slSanPham = this.Gio.FirstOrDefault(x => x.SanPham.SanPhamID == sanPhamId);
            if (slSanPham != null) {
                slSanPham.SoLuongSp = soLuong;
                TinhTongTien();
                return;
            }
        }


        //RemoveItem
        public void RemoveItem(int sanPhamId)
        {
            var slSanPham = this.Gio.FirstOrDefault(x => x.SanPham.SanPhamID == sanPhamId);
            if (slSanPham != null)
            {
                this.Gio.Remove(slSanPham); // xoa san pham do khoi gio hang 
                TinhTongTien(); // tinh lai tong tien
                return;
            }
        }

        //CapNhatSoLuong
        public void UpdateSoLuong(int id, int soLuong)
        {
            var sanPham = this.Gio.FirstOrDefault(x => x.SanPham.SanPhamID == id).SanPham;
            if (sanPham == null)
                return;
            SLSanPham.CapNhatSoLuong(sanPham, this.Gio, soLuong);
            TinhTongTien();
        }
    }
}