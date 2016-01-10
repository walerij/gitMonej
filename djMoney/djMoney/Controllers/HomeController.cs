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
            string query = "SELECT * FROM story LIMIT 10";
          
            string getID = (string)RouteData.Values["id"];
            if (getID != null)
            {
                getID = (int.Parse(getID) * 10).ToString();
                query = "SELECT * FROM story LIMIT "+getID+", 10";

            }
           
            Article[] art = conn.SelStory(query);
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