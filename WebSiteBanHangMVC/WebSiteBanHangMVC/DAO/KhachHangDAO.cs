using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteBanHangMVC.Models;

namespace WebSiteBanHangMVC.DAO
{
    public class KhachHangDAO
    {
        private readonly ApplicationDbContext db;
        // insert, update, delete
        private static KhachHangDAO instance;
        static object key = new object();
        public static KhachHangDAO Instance
        {
            get
            {
                //lock(key)
                //{
                if (instance == null)
                {
                    instance = new KhachHangDAO();
                }
                return instance;
                //}
            }
        }
        public KhachHangDAO()
        {
            db = new ApplicationDbContext();
        }
        // insert 
        public int insertKhacHang(KhachHang khachHang)
        {
            try
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return khachHang.KhachHangID;
            }
            catch (Exception)
            {
                return 0; // them that bai
            }
        } 
    }
}