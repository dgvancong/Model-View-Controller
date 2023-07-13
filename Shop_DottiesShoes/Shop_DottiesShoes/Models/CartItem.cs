using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_DottiesShoes.Models
{
    [Serializable]
    public class CartItem
    {
        public SanPham SanPham { set; get; }
        public int SoLuong { set; get; }
    }
}