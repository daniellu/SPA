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
using Newtonsoft.Json.Linq;


namespace CSPA.Controllers.API
{
    public class ActivityAPIController : ApiController
    {
        private StravaClient _client = null;

        public ActivityAPIController(StravaClient client)
        {
            _client = client;
        }

        // GET api/<controller>
        public IEnumerable<ActivityListViewModel> Get()
        {

            var activities = _client.Activities.GetActivitiesAfter(DateTime.Now.AddDays(-7));

            var viewModels = from activity in activities
                             orderby activity.DateTimeStartLocal descending
                             select new ActivityListViewModel
                             {
                                 Id = activity.Id,
                                 Name = activity.Name,
                                 ActivityType = activity.Type.ToString(),
                                 DateTime = activity.DateTimeStartLocal,
                                 ElapseTimeSeconds = activity.ElapsedTime,
                                 Distance = (float)(Math.Round(activity.Distance / 1000, 3))
                             };

            return viewModels;
        }

        public async Task<ActivityDetailViewModel> Get(string id)
        {
            
            var activity = await _client.Activities.GetActivityAsync(id, true);
            var viewModel = new ActivityDetailViewModel
            {
                Id = activity.Id,
                Name = activity.Name,
                ActivityType = activity.Type.ToString(),
                DateTime = activity.DateTimeStartLocal,
                ElapseTimeSeconds = activity.ElapsedTime,
                Distance = (float)(Math.Round(activity.Distance / 1000, 3)),
                AverageSpeed = (float)(Math.Round(activity.AverageSpeed * 3.6, 3)),
                MaxSpeed = (float)(Math.Round(activity.MaxSpeed * 3.6, 3)),
                CenterLat = (float)((activity.StartLatitude + activity.EndLatitude) / 2),
                CenterLng = (float)((activity.StartLongitude + activity.EndLongitude) / 2),
            };

            return viewModel;
        }

        public async Task<ActivityTrackDataViewModel> GetTrackData(string id)
        {
            var trackStream = await _client.Streams.GetActivityStreamAsync(id, Strava.Streams.StreamType.LatLng, Strava.Streams.StreamResolution.High);

            var coordinateData = trackStream.Where(x => x.StreamType == Strava.Streams.StreamType.LatLng).FirstOrDefault();

            if(coordinateData != null)
            {
                var coordinateViewModels = coordinateData.Data.Cast<JArray>().Select(x => new Coordinate(x.First.Value<float>(), x.Last.Value<float>()));
                return new ActivityTrackDataViewModel
                {
                    Id = long.Parse(id),
                    Coordinates = coordinateViewModels
                };
            }
            return null;
            
            
        }


    }
}