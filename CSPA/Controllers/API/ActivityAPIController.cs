using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using Strava.Api;
using Strava.Activities;
using Strava.Clients;
using Strava.Authentication;

using CSPA.Models;


namespace CSPA.Controllers.API
{
    public class ActivityAPIController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ActivityListViewModel> Get()
        {
            var token = System.Configuration.ConfigurationManager.AppSettings["StravaToken"];
            StaticAuthentication auth = new StaticAuthentication(token);
            StravaClient client = new StravaClient(auth);
            var activities = client.Activities.GetActivitiesAfter(DateTime.Now.AddDays(-7));

            var viewModels = from activity in activities
                             select new ActivityListViewModel
                             {
                                 Id = activity.Id,
                                 Name = activity.Name,
                                 ActivityType = activity.Type.ToString(),
                                 DateTime = activity.DateTimeStartLocal,
                                 ElapseTimeSeconds = activity.ElapsedTime,
                                 Distance = (float)(Math.Round(activity.Distance / 1000, 3))
                             };

            return viewModels.OrderByDescending(x => x.DateTime);
        }


    }
}