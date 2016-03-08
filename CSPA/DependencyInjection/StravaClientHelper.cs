using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Strava.Clients;
using Strava.Authentication;

namespace CSPA.DependencyInjection
{
    public class StravaClientHelper
    {
        public StravaClient GetStravaClient()
        {
            var token = System.Configuration.ConfigurationManager.AppSettings["StravaToken"];
            StaticAuthentication auth = new StaticAuthentication(token);
            return new StravaClient(auth);
        }
    }
}