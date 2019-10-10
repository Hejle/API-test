using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace API_test.Controllers
{
   

    public class Order
    {
        public RootObject GetProducts(string json)
        {
            var result = JsonConvert.DeserializeObject<RootObject>(json);
            return result;
        }
    }



}



