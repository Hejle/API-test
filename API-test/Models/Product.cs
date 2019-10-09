using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_test.Models
{
    public class Product
    {
        public float Ean { get; }
        public string ProductName { get; }
        public double Price { get; }


        public Product (float Ean, string ProductName, double Price)
        {
            this.Ean = Ean;
            this.ProductName = ProductName;
            this.Price = Price;
        }

    }
}