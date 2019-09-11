using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;



namespace ObtenerPesoSAP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.        
            //System.IO.File.WriteAllText(@"D:\auto.txt", "This is generated from Session_End");
            Session["uid_GUID"] = null;
            


            //Response.Redirect("~/Error.aspx");

            //return Redirect("/Home/Index");
            //FormsAuthentication.SignOut();

            Server.ClearError();
            //Response.Clear();
            //HttpContext.Current.Response.Redirect("~/Usuarios/login.cshtml");

            Response.Redirect("~/Usuarios/login.cshtml");
            //return;       
        }


    }
}
