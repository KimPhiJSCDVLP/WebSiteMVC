using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteBanHangMVC.Common;
using WebSiteBanHangMVC.Models;

namespace WebSiteBanHangMVC.DAO
{
    public class UserDAO
    {
        ApplicationDbContext db = null;
        private static UserDAO instance;
        static object key = new object();
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)//bất đồng bộ , chiếm dụng tài nguyên....
                    {
                        instance = new UserDAO();
                    }
                }
                return instance;
            }
        }
        public UserDAO() { db = new ApplicationDbContext(); }
        public long Insert(User entity)
        {
            //Mac dinh cho kich hoat
            entity.Status = true;
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                if (entity.GroupID == null)
                {
                    entity.GroupID = 3;
                }
                KhachHang kh = new KhachHang();
                kh.GioiTinh = true;
                kh.Email = entity.Email;
                kh.HoTen = entity.Name;
                kh.SoDienThoai = entity.Phone;
                kh.DiaChi = entity.DiaChiChiTiet;
                KhachHangDAO.Instance.insertKhachHang(kh);
                entity.CreatedDate = DateTime.Now;
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.UserID;
            }
            else
            {
                return user.UserID;
            }
        }
        public long InsertForFacebook(User entity)
        {
            entity.Status = true;
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                if (entity.GroupID == null)
                {
                    entity.GroupID = 3;
                }
                KhachHang kh = new KhachHang();
                kh.GioiTinh = true;
                kh.Email = entity.Email;
                kh.HoTen = entity.Name;
                kh.SoDienThoai = entity.Phone;
                kh.DiaChi = entity.DiaChiChiTiet;
                KhachHangDAO.Instance.insertKhachHang(kh);
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.UserID;
            }
            else
                return user.UserID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.UserID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                    user.PasswordSalt = entity.PasswordSalt;
                }
                user.GroupID = entity.GroupID;
                user.UserName = entity.UserName;
                user.DiaChiChiTiet = entity.DiaChiChiTiet;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString) || x.Email.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public int Login(string userName, string passWordSalt, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)
                            return -1;
                        else
                        {
                            if (result.PasswordSalt == passWordSalt)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == true)
                    {
                        if (result.PasswordSalt == passWordSalt)
                            return 1;
                        else
                            return -2;
                    }
                    else
                        return -1;
                }
            }
        }
        public bool? ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
        public List<User> ListAll()
        {
            return db.Users.ToList();
        }
    }
}