using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster.Controllers
{
    public class genresController : Controller
    {
        //
        // GET: /genres/

        public ActionResult Index()
        {
            hypster_tv_DAL.mixManagement mixManager = new hypster_tv_DAL.mixManagement();

            List<hypster_tv_DAL.Mix_GetGenresAndCovers> model = new List<hypster_tv_DAL.Mix_GetGenresAndCovers>();
            model = mixManager.GetGenresAndCovers(50);




            if (hypster_tv_DAL.Mobile_Device_Recognition.CheckIfTablet(Request.UserAgent))
            {
                return View("IndexT", model);
            }

            return View(model);
        }




    }
}
