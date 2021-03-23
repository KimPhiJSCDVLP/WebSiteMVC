using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteBanHangMVC.Models
{
    public class GioHang
    {
        private int _valueTongTien;
        private int _valueTongSanpham;

        public class LuongSanPham
        {
            public SanPham SanPham { get; set; }
            public int SoLuong { get; set; }
            public double TongTien
            {
                get
                {
                    return SanPham.GiaSanPham.Value * SoLuong;
                }
                private set { }
            }
            public static bool IsSanPham(List<LuongSanPham> lstLuongSanPham, SanPham sanPham)
            {
                LuongSanPham lSanPham = lstLuongSanPham.FirstOrDefault(x => x.SanPham.SanPhamID == sanPham.SanPhamID);
                if (lSanPham == null)
                {
                    return false;
                }
                lSanPham.SoLuong = lSanPham.SoLuong + 1;
                return true;
            }
            public LuongSanPham(int soLuong, SanPham sanPham)
            {
                SoLuong = soLuong;
                SanPham = sanPham;
            }
        }
        public List<LuongSanPham> Gio { get; set; }
        public int TongTien
        {
            get
            {
                this.TinhTong();
                return _valueTongTien;
            }
            private set { }
        }

        public int TongSoLuong
        {
            get
            {
                this.TinhTongSanPham();
                return _valueTongSanpham;
            }
            private set { }
        }

        void TinhTongSanPham()
        {
            _valueTongSanpham = 0;
            foreach (var item in Gio)
            {
                _valueTongSanpham += item.SoLuong;
            }
        }

        public GioHang()
        {
            Gio = new List<LuongSanPham>();
            TongTien = 0;
        }
        void TinhTong()
        {
            _valueTongTien = 0;
            foreach (var item in Gio)
            {
                if (item.SanPham.GiaSanPham != null)
                {
                    _valueTongTien = _valueTongTien + ((int)item.SanPham.GiaSanPham.Value * item.SoLuong);
                }
            }
        }
        public void Add(SanPham sanPham)
        {
            if (sanPham == null)
                return;
            if (!LuongSanPham.IsSanPham(this.Gio, sanPham))
            {
                this.Gio.Add(new LuongSanPham(1, sanPham));
            }
            TinhTong();
        }
        public void ChangeAmount(int id, int soLuong)
        {
            var RemoveItem = this.Gio.FirstOrDefault(x => x.SanPham.SanPhamID == id);
            if (RemoveItem == null) return;
            if (soLuong == 0 || soLuong < 0)
            {
                this.Gio.Remove(RemoveItem);
                TinhTong();
                return;
            }
            RemoveItem.SoLuong = soLuong;
            TinhTong();
            return;
        }
        public void RemoveAll(int id)
        {
            var RemoveItem = this.Gio.FirstOrDefault(x => x.SanPham.SanPhamID == id);
            if (RemoveItem == null) return;
            this.Gio.Remove(RemoveItem);
            TinhTong();
        }
    }
}