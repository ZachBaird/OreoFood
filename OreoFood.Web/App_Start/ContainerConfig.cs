using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OreoFood.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace OreoFood.Web
{
    public class ContainerConfig
    {
        // When we just were using Autofac for the MVC controller, we didn't pass any arguments into this method. However,
        //  because we want to use Autofac with Api controllers as well, we now pass in an HttpConfiguration object that
        //  we implement with .DependencyResolver below.
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            // First, we declare our container builder.
            var builder = new ContainerBuilder();

            // Then, we register our controllers with Autofac, so Autofac knows about the controllers in the
            //  application. We give it the assembly of our MvcApplication class.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // NOTE: We added this to register Api controllers as well!!!
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            // Here we register a class type. This allows us to, whenever IRestaurantData is used in the app,
            //  for that location to receive an InMemoryRestaurantData. We declare this as a singleton instance.
            builder.RegisterType<InMemoryRestaurantData>()
                   .As<IRestaurantData>()
                   .SingleInstance();

            // Now we use the builder to build our container, and then tell our application's dependency resolver to 
            //  use this container (wrapped in the Autofac dependency resolver) whenever we inject dependencies.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // We added this line, with the Autofac WebApi dependency, to configure Autofac with our Api Controllers.
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}