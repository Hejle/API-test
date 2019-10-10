using System;

namespace API_test.Models
{
    public class ProductLine
    {
      //  public Product Product { get; }
        public int Quantity { get; }



        public ProductLine(/*Product Product,*/ int Quantity)
        {
        //    this.Product = Product;
            this.Quantity = Quantity;
        }

        static void Main()
        {      
           // Product product1 = new Product(982375,"Tandbørste", 29);
           // Console.WriteLine("Produkt 1: ", product1.ProductName, product1.Price);
           // Console.WriteLine("Press any key to exit.");
           // Console.ReadKey();
        }
    }
}