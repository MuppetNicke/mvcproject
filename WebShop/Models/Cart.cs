using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Cart
    {
        public Dictionary<Product, int> ProductList
        {
            get; private set;
        }

        public Cart()
        {
            ProductList = new Dictionary<Product, int>();
        }

        public void AddProduct(Product pProduct)
        {

            if (ProductList.ContainsKey(pProduct))
            {
                ProductList[pProduct] += 1;
            }

            else
            {
                ProductList.Add(pProduct, 1);
            }
        }
    }
}
