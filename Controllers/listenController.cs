using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.XPath;

namespace hypster.Controllers
{
    public class listenController : Controller
    {
        //
        // GET: /listen/



        public ActionResult Index(string genre)
        {
            hypster.ViewModels.listenViewModel model = new ViewModels.listenViewModel();

            ViewBag.GENRE = genre;

            if (Request.QueryString["t"] != null)
            {
                string search_type = Request.QueryString["t"].ToString();
                ViewBag.ST = search_type;
            }
            else
            {
                ViewBag.ST = "";
            }
            



            if (hypster_tv_DAL.Mobile_Device_Recognition.CheckIfTablet(Request.UserAgent))
            {
                return View("IndexT");
            }

            return View(model);
        }







        public ActionResult Mix(int id)
        {
            hypster_tv_DAL.c_Mix curr_mix = new hypster_tv_DAL.c_Mix();


            string request_url1 = "http://8tracks.com/mixes/" + id + ".xml?api_key=443c4639830c723d8b866f08b79abbab5918770e";

            XPathDocument doc1 = new XPathDocument(request_url1);
            XPathNavigator navigator1 = doc1.CreateNavigator();
            XPathNodeIterator nodes1 = navigator1.Select("/response/mix");

            List<hypster_tv_DAL.c_Mix> mixes_list = new List<hypster_tv_DAL.c_Mix>();
            while (nodes1.MoveNext())
            {
                XPathNavigator navigator2 = nodes1.Current;
                curr_mix.Mix_ID = navigator2.SelectSingleNode("id").Value;
                curr_mix.Mix_Cover = navigator2.SelectSingleNode("cover-urls/sq250").Value;
                curr_mix.Mix_Tags = navigator2.SelectSingleNode("tag-list-cache").Value;
            }



            if (hypster_tv_DAL.Mobile_Device_Recognition.CheckIfTablet(Request.UserAgent))
            {
                return View("MixT", curr_mix);
            }


            return View(curr_mix);
        }


        



    }
}
