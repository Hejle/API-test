using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_test.Models
{


    public class Receipt
    {
        public List<ProductLine> boughtProducts;

        public Receipt ()
        {
            boughtProducts = new List<ProductLine>();

            //***DUMMY DATA***//
            ProductLine productLine1 = new ProductLine(new Product(01, "NATUR 24H ANSIGTSCREME", 119.95), 1);
            ProductLine productLine2 = new ProductLine(new Product(02, "ZEND.JUNIOR ASTERIX", 16.95), 2);
            ProductLine productLine3 = new ProductLine(new Product(03, "ORAL-B TANDP.STAGES", 79.95), 2);

            boughtProducts.Add(productLine1);
            boughtProducts.Add(productLine2);
            boughtProducts.Add(productLine3);
        }


        public List <ProductLine> getProducts ()
        {
            return boughtProducts;
        }


    }
}