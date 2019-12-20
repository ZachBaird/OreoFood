using Autofac;
using Autofac.Integration.Mvc;
using OreoFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OreoFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            // First, we declare our container builder.
            var builder = new ContainerBuilder();

            // Then, we register our controllers with Autofac, so Autofac knows about the controllers in the
            //  application. We give it the assembly of our MvcApplication class.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Here we register a class type. This allows us to, whenever IRestaurantData is used in the app,
            //  for that location to receive an InMemoryRestaurantData. We declare this as a singleton instance.
            builder.RegisterType<InMemoryRestaurantData>()
                   .As<IRestaurantData>()
                   .SingleInstance();

            // Now we use the builder to build our container, and then tell our application's dependency resolver to 
            //  use this container (wrapped in the Autofac dependency resolver) whenever we inject dependencies.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}