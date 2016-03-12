using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

using CSPA.Models;


namespace CSPA.Controllers.API
{
    public class EarnDateAPIController : ApiController
    {
        // GET api/<controller>
        public async Task<IEnumerable<EarnDateDecideResult>> Get(string stockCodes)
        { 
            if(string.IsNullOrEmpty(stockCodes))
            {
                return null;
            }

            var codes = stockCodes.Split(',');

            return new List<EarnDateDecideResult> { 
                new EarnDateDecideResult{
                    Code = "THO.TO",
                    IsSuccess = true,
                    Level = "Info",
                    Comments = "Good",
                    EarnReleaseDate = new DateTime(2016, 3, 3)
                }
            };
        }
    }
}