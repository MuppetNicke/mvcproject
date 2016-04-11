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

        public string Picture { get; private set; }
        public Product(string pName, int pPrice, int pNumInStock, string pPicture)
        {
            Name = pName;
            Price = pPrice;
            NumberInStock = pNumInStock;
            Picture = pPicture;
        }

        public bool ReduceStockCount()
        {
            if (NumberInStock <= 0)
            {
                return false;
            }

            else
            {
                NumberInStock--;
                return true;
            }

        }

        public void IncreaseStockCount()
        {
            NumberInStock++;
        }

        public void ChangePrice(int newPrice)
        {
            Price = newPrice;

        }

        public void ChangeStock(int newStock)
        {
            NumberInStock = newStock;

        }

    }
}
