using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CoronaVirusSolution2._0
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalFilters.Filters.Add(new ValidateInputAttribute(false));
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }



        // protected void Application_Error(object sender, EventArgs e)
        //{
        //    // Do whatever you want to do with the error

        //    //Show the custom error page...
        //    Server.ClearError();
        //    var routeData = new RouteData();
        //    routeData.Values["controller"] = "PageNotFound";

        //    if ((Context.Server.GetLastError() is HttpException) && ((Context.Server.GetLastError() as HttpException).GetHttpCode() != 404))
        //    {
        //        routeData.Values["action"] = "Index";
        //    }
        //    else
        //    {
        //        // Handle 404 error and response code
        //        Response.StatusCode = 404;
        //        routeData.Values["action"] = "Index";
        //    }
        //    Response.TrySkipIisCustomErrors = true; // If you are using IIS7, have this line
        //    IController errorsController = new PageNotFoundController();
        //    HttpContextWrapper wrapper = new HttpContextWrapper(Context);
        //    var rc = new System.Web.Routing.RequestContext(wrapper, routeData);
        //    errorsController.Execute(rc);

        //    Response.End();
        //}
    }


}
