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

            Article[] art = conn.SelStory("SELECT * FROM story LIMIT 10");
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