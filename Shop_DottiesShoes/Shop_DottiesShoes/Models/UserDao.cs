using Shop_DottiesShoes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_DottiesShoes.Models
{
    public class UserDao
    {
        ShopDottiesShoesEntities1 db = null;
        public UserDao()
        {
            db = new ShopDottiesShoesEntities1();
        }

        public string Insert(KhachHang entity)
        {
            db.KhachHangs.Add(entity);
            db.SaveChanges();
            return entity.Username;
        }
        public bool CheckUserName(string userName)
        {
            return db.KhachHangs.Count(x => x.Username == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.KhachHangs.Count(x => x.Email == email) > 0;
        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.KhachHangs.SingleOrDefault(x => x.Username == userName);
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
                        if (result.TrangThai == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.MatKhau == passWord)
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
                    if (result.TrangThai == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.MatKhau == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }
        public KhachHang GetById(string userName)
        {
            return db.KhachHangs.SingleOrDefault(x => x.Username == userName);
        }
    }
}