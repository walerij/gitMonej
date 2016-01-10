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
        public ActionResult Index()
        {
            Article art = new Article();

            art.Title = "Заголовок 1";
            art.Context = "Здесь наш текст";
            art.ArtDateTime = DateTime.Now.ToString();
            
            return View(art);
        }
    }
}