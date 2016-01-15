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
        BaseConnect conn = new BaseConnect();
        Story story;
        Article[] art;

        // GET: Home
        /// <summary>
        /// Это всем понятно - контроллер главной страницы,
        /// но вдруг я забуду. На время работ по созданию и тестирование пусть будет с комментарием
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            story = new Story(conn);

            string getID = (string)RouteData.Values["id"];
            if (getID != null)
            {
                int getIntID = (int.Parse(getID)-1) * 10;
                art = story.SelStoryLimitId(getIntID,10);
            }
            else
                art =  story.SelStoryLimitId(0,10);
              
            ViewBag.Art = art;
            ViewBag.ArtCount = art.Count();
            return View();
        }

        /// <summary>
        /// О проекте
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();

        }

        /// <summary>
        /// случайная статья
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStoryByRandomID()
        {
            Random rand = new Random();
      
            int id = rand.Next(0, 60); 
            story = new Story(conn);
            ViewBag.Art = story.SelStoryByID(id);
            ViewBag.ArtCount = 1;
            return View("Index");

        }
    }
}