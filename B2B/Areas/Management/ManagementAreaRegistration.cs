using System.Web.Mvc;

namespace B2B.Areas.Management
{
    public class ManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Management";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                 name: "ManagementRoot",
                 url: "management",
                 defaults: new { controller = "Dashboard", action = "Index" },
                 namespaces: new[] { "B2B.Areas.Management.Controllers" }
            );

            context.MapRoute(
                name: "ManagementDefault",
                url: "management/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "B2B.Areas.Management.Controllers" }
            );
        }
    }
}