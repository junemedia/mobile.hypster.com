using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recaptcha;

namespace hypster.Controllers
{
    public class hypsterController : ControllerBase
    {
        //
        // GET: /hypster/

        public ActionResult Index()
        {
            return RedirectPermanent("/home/index");
        }




        //----------------------------------------------------------------------------------------------------------
        public ActionResult ContactUs()
        {
            return View();
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        [RecaptchaControlMvc.CaptchaValidator]
        [HttpPost]
        public ActionResult ContactUs(string YourEmail, string Subject, string Message, bool captchaValid, string captchaErrorMessage)
        {
            if (captchaValid)
            {
                hypster_tv_DAL.Hypster_Entities HypDB = new hypster_tv_DAL.Hypster_Entities();


                hypster_tv_DAL.userContact userContact = new hypster_tv_DAL.userContact();
                userContact.contactType = 1;
                userContact.contactEmail = YourEmail;
                userContact.contactSubject = Subject;
                userContact.contactText = Message;
                HypDB.userContacts.AddObject(userContact);
                HypDB.SaveChanges();


                hypster_tv_DAL.Email_Manager emailManager = new hypster_tv_DAL.Email_Manager();

                emailManager.SendContactUsEmail("noah@baronsmedia.com", "orville@baronsmedia.com", "jim@baronsmedia.com", Subject, YourEmail, Message);

                return View("ContactsThanks");
            }


            return View("ContactUs");
        }
        //----------------------------------------------------------------------------------------------------------







        //----------------------------------------------------------------------------------------------------------
        public ActionResult ContactsThanks()
        {
            return View();
        }
        //----------------------------------------------------------------------------------------------------------









        //----------------------------------------------------------------------------------------------------------
        public ActionResult AboutUs()
        {
            return View();
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public ActionResult TermsofService()
        {
            return View();
        }
        //----------------------------------------------------------------------------------------------------------


    }
}
