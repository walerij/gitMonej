using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using djMoney.Models;

namespace djMoney.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            BaseConnect conn = new BaseConnect();
            Story story = new Story(conn);
            //string query = "SELECT * FROM story LIMIT 10";
            Article[] art;
            string getID = (string)RouteData.Values["id"];
            if (getID != null)
            {
                int getIntID = int.Parse(getID) * 10;

                //query = "SELECT * FROM story LIMIT "+getID+", 10";
                art = story.SelStoryLimitId(getIntID);
            }
            else
                art =  story.SelStoryLimitId(0);
                //conn.SelStory(query);
            ViewBag.Art = art;
            ViewBag.ArtCount = art.Count();
            return View();
        }

        public ActionResult ArtSelect()
        {
            return View();

        }
    }
}