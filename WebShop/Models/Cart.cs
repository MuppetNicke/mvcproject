using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Models
{
    class Cart
    {
        public List<Product> ProductList;

        public Cart()
        {
            ProductList = new List<Product>();
        }
    }
}
