using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_DottiesShoes.Models
{
    public class OrderDao
    {
        ShopDottiesShoesEntities1 db = null;
        public OrderDao()
        {
            db = new ShopDottiesShoesEntities1();
        }
        public int Insert(HoaDonBan order)
        {
            db.HoaDonBans.Add(order);
            db.SaveChanges();
            return order.MaHDB;
        }
    }
}