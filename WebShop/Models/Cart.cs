using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Cart
    {
        private Dictionary<Product, int> productList;

        public Cart()
        {
            productList = new Dictionary<Product, int>();
        }

        public void AddProduct(Product pProduct)
        {

            if (productList.ContainsKey(pProduct))
            {
                productList[pProduct] += 1;
            }

            else
            {
                productList.Add(pProduct, 1);
            }
        }
    }
}
