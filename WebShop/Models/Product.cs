using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Product
    {

        public string Name { get; private set; }

        public int Price { get; private set; }

        public int NumberInStock { get; private set; }

        public Product(string pName, int pPrice, int pNumInStock)
        {
            Name = pName;
            Price = pPrice;
            NumberInStock = pNumInStock;
        }

        public void ReduceStockCount()
        {
            NumberInStock--;
        }
    }
}
