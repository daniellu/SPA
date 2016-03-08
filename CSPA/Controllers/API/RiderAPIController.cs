using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;

using Strava.Api;
using Strava.Activities;
using Strava.Clients;
using Strava.Authentication;
using Strava.Athletes;

using CSPA.Models;
using System.Threading.Tasks;


namespace CSPA.Controllers.API
{
    public class RiderAPIController : ApiController
    {
        private StravaClient _client = null;

        public RiderAPIController(StravaClient client)
        {
            _client = client;
        }
        // GET api/<controller>/5
        public async Task<RiderProfileViewModel> Get()
        {
            var athleteClient = _client.Athletes;
            var activityClient = _client.Activities;
            var currentAthlete = await athleteClient.GetAthleteAsync();
            var totalActivityCount = await activityClient.GetTotalActivityCountAsync();            
            
            var viewModel = new RiderProfileViewModel();
            viewModel.Id = currentAthlete.Id;
            viewModel.FirstName = currentAthlete.FirstName;
            viewModel.LastName = currentAthlete.LastName;
            viewModel.Country = currentAthlete.Country;
            viewModel.State = currentAthlete.State;
            viewModel.ProfileSmallImage = currentAthlete.ProfileMedium;
            viewModel.ProfileLargeImage = currentAthlete.Profile;
            viewModel.TotalActivitiesCount = totalActivityCount;            

            return viewModel;
        }
    }
}