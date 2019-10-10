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

        }


        public List <ProductLine> getProducts ()
        {
            return boughtProducts;
        }


    }
}