using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_test.Models
{
    public class Product
    {
        public int EAN { get; set; }
        public string PRODUCT { get; set; }
        public double PRICE { get; set; }

        public Product (int EAN, string PRODUCT, double PRICE)
        {
            this.EAN = EAN;
            this.PRODUCT = PRODUCT;
            this.PRICE = PRICE;
        }

    }
}