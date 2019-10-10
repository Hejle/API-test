using API_test.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace API_test.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReceiptController : ApiController
    {

       Printer printer = new Printer();


        /*
        // POST: api/Receipt/Print
        [ActionName("Print")]
        public string PostPrint([FromBody]string value)
        {
            Receipt receipt = new Receipt();
            Debug.WriteLine(value);

            receipt.getProducts();

            //reciept
            //printer.PrintText(Receipt);
            printer.PrintText(value); 
            return "Success";
        }
        */


        private Product[] products = new Product[]
       {
        new Product(01,"Tandbørste", 19.95),
        new Product(02,"Tandpasta", 9.95),
        new Product(03,"Håndcreme", 29.95),
        new Product(04,"Hårvoks", 34.95),
        new Product(05,"Chokoladekage", 29.95)
        };


        // GET: api/Users
        [ResponseType(typeof(IEnumerable<Product>))]
            public IEnumerable<Product> Get()
            {
                return products;
            }


        [Route("api/Receipt/Add"), HttpPost]
           public async Task<string> PostRawBufferManual()
        {
            string result = await Request.Content.ReadAsStringAsync();

            var convertedResult = JsonConvert.DeserializeObject<RootObject>(result);

            Receipt receipt = new Receipt();



            return result;
        }


    }
    public class RootObject
    {
        public List<Product> Products { get; set; }
    }

}
