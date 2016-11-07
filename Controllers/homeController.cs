using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace hypster.Controllers
{
    public class homeController : ControllerBase
    {


        //
        // GET: /home/
        public ActionResult Index()
        {
            
            if(hypster_tv_DAL.Mobile_Device_Recognition.CheckIfTablet(Request.UserAgent))
            {
                return View("IndexT");
            }


            return View();
        }

        





        public ActionResult GetRandomHomeGenres(int id = 11)
        {
            hypster_tv_DAL.mixManagement mixManager = new hypster_tv_DAL.mixManagement();

            List<hypster_tv_DAL.Mix_GetGenresAndCovers> album_covers = new List<hypster_tv_DAL.Mix_GetGenresAndCovers>();
            album_covers = mixManager.GetGenresAndCovers(id);


            return View(album_covers);
        }


        public ActionResult Ads()
        {
            return View();
        }




    }
}
