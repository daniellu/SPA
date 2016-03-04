using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CSPA.Models;

namespace CSPA.Controllers.API
{
    public class RiderAPIController : ApiController
    {
        // GET api/<controller>/5
        public RiderProfileViewModel Get(int id)
        {
            var viewModel = new RiderProfileViewModel();
            viewModel.Id = id;
            viewModel.UserName = "username";
            viewModel.FullName = "fulname";

            return viewModel;
        }
    }
}