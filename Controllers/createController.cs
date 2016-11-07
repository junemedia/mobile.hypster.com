using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster.Controllers
{
    public class createController : Controller
    {


        // GET: /create/
        //--------------------------------------------------------------------------------------------------------
        public ActionResult Index()
        {
            hypster.ViewModels.createViewModel model = new ViewModels.createViewModel();



            return View(model);
        }
        //--------------------------------------------------------------------------------------------------------






       


    }
}
