using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nokat.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "increaseRank", // Route name
               "Joke/IncreaseJoke", // URL with parameters
               new { controller = "Joke", action = "IncreaseJoke" } // Parameter defaults
           );
            routes.MapRoute(
               "decreaseRank", // Route name
               "Joke/DecreaseJoke", // URL with parameters
               new { controller = "Joke", action = "DecreaseJoke" } // Parameter defaults
           );

            routes.MapRoute(
               "JokeList", // Route name
               "Joke/indexPartial", // URL with parameters
               new { controller = "Joke", action = "indexPartial" } // Parameter defaults
           );

            routes.MapRoute(
               "JokeListMember", // Route name
               "Joke/MemberIndexPartial", // URL with parameters
               new { controller = "Joke", action = "MemberIndexPartial" } // Parameter defaults
           );

            routes.MapRoute(
                "AddMember", // Route name
                "Joke/AddMember", // URL with parameters
                new { controller = "Joke", action = "AddMember" } // Parameter defaults
            );

            routes.MapRoute(
                "AddJoke", // Route name
                "Joke/PostJoke", // URL with parameters
                new { controller = "Joke", action = "PostJoke" } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "", // URL with parameters
                new { controller = "Joke", action = "Index" } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            AppDomain.CurrentDomain.SetData("NokatDBEntities", true);


            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}