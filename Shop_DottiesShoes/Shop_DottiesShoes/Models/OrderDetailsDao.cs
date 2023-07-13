using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_DottiesShoes.Models
{
    public class OrderDetailsDao
    {
        ShopDottiesShoesEntities1 db = null;
        public OrderDetailsDao()
        {
            db = new ShopDottiesShoesEntities1();
        }
        public bool Insert(CT_HoaDonBan detail)
        {
            try
            {
                db.CT_HoaDonBan.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}