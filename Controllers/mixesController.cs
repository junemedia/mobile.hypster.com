using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Xml.XPath;

namespace hypster.Controllers
{
    public class mixesController : Controller
    {
        //
        // GET: /mixes/



        public ActionResult Index()
        {
            string request_url1 = "http://8tracks.com/mixes.xml?per_page=72&tag=&sort=popular&api_key=443c4639830c723d8b866f08b79abbab5918770e";
            List<hypster_tv_DAL.c_Mix> mixes_list = new List<hypster_tv_DAL.c_Mix>();

            try
            {
                XPathDocument doc1 = new XPathDocument(request_url1);
                XPathNavigator navigator1 = doc1.CreateNavigator();
                XPathNodeIterator nodes1 = navigator1.Select("/response/mixes/mix");

                
                while (nodes1.MoveNext())
                {
                    hypster_tv_DAL.c_Mix curr_mix = new hypster_tv_DAL.c_Mix();

                    XPathNavigator navigator2 = nodes1.Current;
                    curr_mix.Mix_ID = navigator2.SelectSingleNode("id").Value;
                    curr_mix.Mix_Cover = navigator2.SelectSingleNode("cover-urls/sq133").Value;
                    curr_mix.Mix_Name = navigator2.SelectSingleNode("name").Value;
                    curr_mix.Mix_Tags = navigator2.SelectSingleNode("tag-list-cache").Value;

                    mixes_list.Add(curr_mix);
                }
                
            }
            catch (Exception ex)
            {
            }


            if (hypster_tv_DAL.Mobile_Device_Recognition.CheckIfTablet(Request.UserAgent))
            {
                return View("IndexT", mixes_list);
            }

            return View(mixes_list);
        }

       



        public ActionResult GetRandomMix(string id)
        {
            hypster_tv_DAL.c_Mix ret_mix = new hypster_tv_DAL.c_Mix();


            try
            {
                string tag_enc = "";
                tag_enc = id.ToLower().Replace('_', ' ');
                tag_enc = HttpUtility.UrlEncode(tag_enc);

                string request_url1 = "http://8tracks.com/mixes.xml?per_page=40&tag=" + tag_enc + "&sort=popular&api_key=443c4639830c723d8b866f08b79abbab5918770e";

                XPathDocument doc1 = new XPathDocument(request_url1);
                XPathNavigator navigator1 = doc1.CreateNavigator();
                XPathNodeIterator nodes1 = navigator1.Select("/response/mixes/mix");

                List<hypster_tv_DAL.c_Mix> mixes_list = new List<hypster_tv_DAL.c_Mix>();
                while (nodes1.MoveNext())
                {
                    hypster_tv_DAL.c_Mix curr_mix = new hypster_tv_DAL.c_Mix();

                    XPathNavigator navigator2 = nodes1.Current;
                    curr_mix.Mix_ID = navigator2.SelectSingleNode("id").Value;
                    curr_mix.Mix_Cover = navigator2.SelectSingleNode("cover-urls/sq250").Value;
                    curr_mix.Mix_Tags = navigator2.SelectSingleNode("tag-list-cache").Value;


                    mixes_list.Add(curr_mix);
                }


                Random random = new Random();
                if (mixes_list.Count > 0)
                {
                    ret_mix = mixes_list[random.Next(0, mixes_list.Count - 1)];
                }

            }
            catch (Exception ex)
            {
            }

            return View(ret_mix);
        }

        public string GetNextRandomMix(string id)
        {
            hypster_tv_DAL.c_Mix ret_mix = new hypster_tv_DAL.c_Mix();


            try
            {
                string tag_enc = "";
                if (id != null && id != "")
                {
                    tag_enc = id.ToLower().Replace('_', ' ');
                    tag_enc = HttpUtility.UrlEncode(tag_enc);
                }

                string request_url1 = "http://8tracks.com/mixes.xml?per_page=40&tag=" + tag_enc + "&sort=popular&api_key=443c4639830c723d8b866f08b79abbab5918770e";

                XPathDocument doc1 = new XPathDocument(request_url1);
                XPathNavigator navigator1 = doc1.CreateNavigator();
                XPathNodeIterator nodes1 = navigator1.Select("/response/mixes/mix");

                List<hypster_tv_DAL.c_Mix> mixes_list = new List<hypster_tv_DAL.c_Mix>();
                while (nodes1.MoveNext())
                {
                    hypster_tv_DAL.c_Mix curr_mix = new hypster_tv_DAL.c_Mix();

                    XPathNavigator navigator2 = nodes1.Current;
                    curr_mix.Mix_ID = navigator2.SelectSingleNode("id").Value;
                    curr_mix.Mix_Cover = navigator2.SelectSingleNode("cover-urls/sq250").Value;
                    curr_mix.Mix_Tags = navigator2.SelectSingleNode("tag-list-cache").Value;

                    mixes_list.Add(curr_mix);
                }


                Random random = new Random();
                if (mixes_list.Count > 0)
                {
                    ret_mix = mixes_list[random.Next(0, mixes_list.Count - 1)];
                }
            }
            catch (Exception ex)
            {
            }


            return ret_mix.Mix_ID + "|" + ret_mix.Mix_Cover;
        }





        public ActionResult GetSearchMix(string id)
        {
            hypster_tv_DAL.c_Mix ret_mix = new hypster_tv_DAL.c_Mix();


            try
            {
                string tag_enc = "";
                tag_enc = id.ToLower().Replace('_', ' ');
                tag_enc = HttpUtility.UrlEncode(tag_enc);

                string request_url1 = "http://8tracks.com/mixes.xml?per_page=40&q=" + tag_enc + "&sort=popular&api_key=443c4639830c723d8b866f08b79abbab5918770e";

                XPathDocument doc1 = new XPathDocument(request_url1);
                XPathNavigator navigator1 = doc1.CreateNavigator();
                XPathNodeIterator nodes1 = navigator1.Select("/response/mixes/mix");

                List<hypster_tv_DAL.c_Mix> mixes_list = new List<hypster_tv_DAL.c_Mix>();
                while (nodes1.MoveNext())
                {
                    hypster_tv_DAL.c_Mix curr_mix = new hypster_tv_DAL.c_Mix();

                    XPathNavigator navigator2 = nodes1.Current;
                    curr_mix.Mix_ID = navigator2.SelectSingleNode("id").Value;
                    curr_mix.Mix_Cover = navigator2.SelectSingleNode("cover-urls/sq250").Value;
                    curr_mix.Mix_Tags = navigator2.SelectSingleNode("tag-list-cache").Value;


                    mixes_list.Add(curr_mix);
                }


                Random random = new Random();
                if (mixes_list.Count > 0)
                {
                    ret_mix = mixes_list[random.Next(0, mixes_list.Count - 1)];
                }

            }
            catch (Exception ex)
            {
            }

            return View(ret_mix);
        }

        public string GetNextSearchMix(string id)
        {
            hypster_tv_DAL.c_Mix ret_mix = new hypster_tv_DAL.c_Mix();


            try
            {
                string tag_enc = "";
                if (id != null && id != "")
                {
                    tag_enc = id.ToLower().Replace('_', ' ');
                    tag_enc = HttpUtility.UrlEncode(tag_enc);
                }

                string request_url1 = "http://8tracks.com/mixes.xml?per_page=40&q=" + tag_enc + "&sort=popular&api_key=443c4639830c723d8b866f08b79abbab5918770e";

                XPathDocument doc1 = new XPathDocument(request_url1);
                XPathNavigator navigator1 = doc1.CreateNavigator();
                XPathNodeIterator nodes1 = navigator1.Select("/response/mixes/mix");

                List<hypster_tv_DAL.c_Mix> mixes_list = new List<hypster_tv_DAL.c_Mix>();
                while (nodes1.MoveNext())
                {
                    hypster_tv_DAL.c_Mix curr_mix = new hypster_tv_DAL.c_Mix();

                    XPathNavigator navigator2 = nodes1.Current;
                    curr_mix.Mix_ID = navigator2.SelectSingleNode("id").Value;
                    curr_mix.Mix_Cover = navigator2.SelectSingleNode("cover-urls/sq250").Value;
                    curr_mix.Mix_Tags = navigator2.SelectSingleNode("tag-list-cache").Value;

                    mixes_list.Add(curr_mix);
                }


                Random random = new Random();
                if (mixes_list.Count > 0)
                {
                    ret_mix = mixes_list[random.Next(0, mixes_list.Count - 1)];
                }
            }
            catch (Exception ex)
            {
            }


            return ret_mix.Mix_ID + "|" + ret_mix.Mix_Cover;
        }







        public string GetPlay_Token()
        {
            string CURR_PLAY_TOKEN = "";


            try
            {
                #region GET_PLAY_TOKEN
                string request_url1 = "http://8tracks.com/sets/new.xml?api_key=443c4639830c723d8b866f08b79abbab5918770e";

                XPathDocument doc1 = new XPathDocument(request_url1);
                XPathNavigator navigator1 = doc1.CreateNavigator();
                XPathNodeIterator nodes1 = navigator1.Select("/response/play-token");
                while (nodes1.MoveNext())
                {
                    XPathNavigator node1 = nodes1.Current;
                    CURR_PLAY_TOKEN = node1.Value;
                }
                #endregion
            }
            catch (Exception ex)
            {
            }

            return CURR_PLAY_TOKEN;
        }




        public ActionResult NextTrack(string id)
        {
            string CURR_MIX_ID = "";
            string CURR_PLAY_TOKEN = id;
            
            string CURR_SONG_URL = "";
            string SONG_NAME = "";



            try
            {
                if (Request.QueryString["mix_id"] != null)
                {
                    CURR_MIX_ID = Request.QueryString["mix_id"].ToString();
                    ViewBag.TRACK_ID = CURR_MIX_ID;
                }




                #region GET_SONG_FOR_PLAY
                string request_url2 = "http://8tracks.com/sets/" + CURR_PLAY_TOKEN + "/next.xml?api_key=443c4639830c723d8b866f08b79abbab5918770e&mix_id=" + CURR_MIX_ID;

                XPathDocument doc2 = new XPathDocument(request_url2);
                XPathNavigator navigator2 = doc2.CreateNavigator();
                XPathNavigator node2 = navigator2.SelectSingleNode("/response/set/track/url");
                CURR_SONG_URL = node2.Value;

                XPathNavigator node2_Name = navigator2.SelectSingleNode("/response/set/track/name");
                SONG_NAME = node2_Name.Value;

                XPathNavigator node2_Performer = navigator2.SelectSingleNode("/response/set/track/performer");
                SONG_NAME = SONG_NAME + " - " + node2_Performer.Value;
                #endregion





                #region GENERATE_RESPONSE
                //------------------------------------------------------------------------------------------------------------------------
                ViewBag.SONG_URL = CURR_SONG_URL;
                ViewBag.SONG_NAME = SONG_NAME;
                //------------------------------------------------------------------------------------------------------------------------
                #endregion

            }
            catch (Exception ex)
            {
            }


            return View();
        }



        public ActionResult SkipTrack(string id)
        {

            //------------------------------------------------------------------------------------------------------------------------
            string CURR_MIX_ID = "";
            string CURR_PLAY_TOKEN = id;

            string CURR_SONG_URL = "";
            string SONG_NAME = "";



            try
            {
                if (Request.QueryString["mix_id"] != null)
                {
                    CURR_MIX_ID = Request.QueryString["mix_id"].ToString();
                    ViewBag.TRACK_ID = CURR_MIX_ID;
                }


                //------------------------------------------------------------------------------------------------------------------------
                #region GET_SONG_FOR_PLAY
                string request_url2 = "http://8tracks.com/sets/" + CURR_PLAY_TOKEN + "/skip.xml?api_key=443c4639830c723d8b866f08b79abbab5918770e&mix_id=" + CURR_MIX_ID;

                try
                {
                    XPathDocument doc2 = new XPathDocument(request_url2);
                    XPathNavigator navigator2 = doc2.CreateNavigator();


                    XPathNavigator node2_status = navigator2.SelectSingleNode("/response/status");
                    if (node2_status.Value == "200 OK")
                    {
                        ViewBag.SKIP_ALLOWED = "true";
                    }
                    else
                    {
                        ViewBag.SKIP_ALLOWED = "false";
                    }

                    XPathNavigator node2 = navigator2.SelectSingleNode("/response/set/track/url");
                    CURR_SONG_URL = node2.Value;

                    XPathNavigator node2_Name = navigator2.SelectSingleNode("/response/set/track/name");
                    SONG_NAME = node2_Name.Value;

                    XPathNavigator node2_Performer = navigator2.SelectSingleNode("/response/set/track/performer");
                    SONG_NAME = SONG_NAME + " - " + node2_Performer.Value;
                }
                catch (Exception ex) //(when server return 403)
                {
                    ViewBag.SKIP_ALLOWED = "false";
                }
                #endregion
                //------------------------------------------------------------------------------------------------------------------------




                #region GENERATE_RESPONSE
                //------------------------------------------------------------------------------------------------------------------------
                ViewBag.SONG_URL = CURR_SONG_URL;
                ViewBag.SONG_NAME = SONG_NAME;
                //------------------------------------------------------------------------------------------------------------------------
                #endregion


            }
            catch (Exception ex)
            {
            }



            return View();
        }




        public string ReportSong()
        {
            string PLAY_TOKEN = "";
            string TRACK_ID = "";
            string MIX_ID = "";
            string ret_res = "";

            try
            {

                if (Request.QueryString["PLAY_TOKEN"] != null)
                {
                    PLAY_TOKEN = Request.QueryString["PLAY_TOKEN"];
                }

                if (Request.QueryString["TRACK_ID"] != null)
                {
                    TRACK_ID = Request.QueryString["TRACK_ID"];
                }

                if (Request.QueryString["MIX_ID"] != null)
                {
                    MIX_ID = Request.QueryString["MIX_ID"];
                }

                string request_url1 = "http://8tracks.com/sets/" + PLAY_TOKEN + "/report.xml?track_id=" + TRACK_ID + "&mix_id=" + MIX_ID + "&api_key=443c4639830c723d8b866f08b79abbab5918770e";

                XPathDocument doc1 = new XPathDocument(request_url1);
                XPathNavigator navigator1 = doc1.CreateNavigator();

                ret_res = navigator1.SelectSingleNode("/response/status").Value;


            
                hypster_tv_DAL.Radio_Usage radio_u = new hypster_tv_DAL.Radio_Usage();
                radio_u.Radio_Usage_Date = DateTime.Now;
                radio_u.PLAY_TOKEN = Int32.Parse(PLAY_TOKEN);
                radio_u.TRACK_ID = Int32.Parse(TRACK_ID);
                radio_u.MIX_ID = Int32.Parse(MIX_ID);
                
                
                hypster_tv_DAL.mixManagement mixManager = new hypster_tv_DAL.mixManagement();
                mixManager.ReportSong(radio_u);
            }
            catch (Exception ex)
            {
            }

            return ret_res;
        }



    }
}
