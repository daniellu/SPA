using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using CSPA.Models;

namespace CSPA.Controllers.API
{
    public class ActivityAPIController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ActivityListViewModel> Get()
        {
            return new List<ActivityListViewModel> { 
                new ActivityListViewModel{
                    Id = 1,
                    Name = "Activity 1"
                },
                new ActivityListViewModel{
                    Id = 2,
                    Name = "Activity 2"
                },
                new ActivityListViewModel{
                    Id = 3,
                    Name = "Activity 3"
                }
            };
        }


    }
}