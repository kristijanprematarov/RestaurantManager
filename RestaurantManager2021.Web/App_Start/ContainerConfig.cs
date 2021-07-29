using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using RestaurantManager2021.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace RestaurantManager2021.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            //BUILDER
            var builder = new ContainerBuilder();
            //REGISTER Implementation => Interface
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<RestaurantData>()
                   .As<IRestaurantData>()
                   .InstancePerRequest();
            builder.RegisterType<DataContext>().InstancePerRequest();
            //BUILD CONTAINER FOR RESOLVING DEPENDENCIES
            var container = builder.Build();
            //TELL MVC TO USE CONTAINER TO RESOLVE DEPENDENCIES
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
