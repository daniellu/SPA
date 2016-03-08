using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

using Strava.Clients;

namespace CSPA.DependencyInjection
{
    public class DependencyConfigure
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            var container = RegisterServices(builder);

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }

        public static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(
                typeof(MvcApplication).Assembly
                ).PropertiesAutowired();

            //deal with your dependencies here
            var stravaClient = (new StravaClientHelper()).GetStravaClient();
            builder.RegisterInstance<StravaClient>(stravaClient);
            builder.Register(c => stravaClient).As<StravaClient>().SingleInstance();
            


            return builder.Build();
        }
    }
}