using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.GData;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.YouTube;


namespace hypster.Controllers
{
    //
    // controller for music search
    public class searchController : ControllerBase
    {
        //----------------------------------------------------------------------------------------------------------
        private int MAX_RECENT_SEARCHES_NUM = 255;
        //----------------------------------------------------------------------------------------------------------




       

        //----------------------------------------------------------------------------------------------------------
        // perform youtube search
        public ActionResult Music()
        {
            return View();
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        // perform youtube search
        public ActionResult MusicYTID()
        {
            
            Video video = null;
            

            return View(video);
        }
        //----------------------------------------------------------------------------------------------------------






    }
}
