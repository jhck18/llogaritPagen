using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            Llogaritja_pages lp = new Llogaritja_pages();
            var fakeDataFromDB  = lp.getJsonData();
            return fakeDataFromDB;
        }

        // POST api/values
        public string Post([FromBody] ExpectedInput value)
        {
            Llogaritja_pages lp = new Llogaritja_pages();
            
            return JsonConvert.SerializeObject(lp.llogaritPagen(value));
        }
    }
}
