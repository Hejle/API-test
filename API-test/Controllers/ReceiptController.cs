using API_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_test.Controllers
{
    public class ReceiptController : ApiController
    {

        Printer printer = new Printer();

        // POST: api/Receipt/Print
        [ActionName("Print")]
        public string PostPrint([FromBody]string value)
        {
            printer.PrintText(value); 
            return "Success";
        }

    }
}
