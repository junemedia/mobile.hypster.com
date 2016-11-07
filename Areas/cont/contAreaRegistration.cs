using System.Web.Mvc;

namespace hypster.Areas.cont
{
    public class contAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "cont";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "cont_default",
                "cont/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }


    }
}
