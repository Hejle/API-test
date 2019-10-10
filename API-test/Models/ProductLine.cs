using System;

namespace API_test.Models
{
    public class ProductLine
    {
        public Product Product { get; }
        public int Quantity { get; }



        public ProductLine(Product Product, int Quantity)
        {
            this.Product = Product;
            this.Quantity = Quantity;
        }

    }
}