using System.Web.Mvc;

namespace Shop_DottiesShoes.Areas.ADminDVC
{
    public class ADminDVCAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ADminDVC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ADminDVC_default",
                "ADminDVC/{controller}/{action}/{id}",
                new {controller ="Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}