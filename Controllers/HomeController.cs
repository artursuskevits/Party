using Party.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using static System.Web.Helpers.WebMail;

namespace PArty2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kutse()
        {
            int hour = DateTime.Now.Hour;

            ViewBag.Greeting = hour < 10 ? "Tere hommikust" : "Tere päevast";

            ViewBag.Message = "Ootan sind oma peoloe! Tule kindlasti!!!Ootan sind!";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "MINU INFOOOOOOOOOOOOOOOOOOOOOOOO!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Minu contact leht.";

            return View();
        }
        [HttpGet]
        public ActionResult Ankeet()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            if (ModelState.IsValid)
            {
                E_mail(guest);
                return View("Thanks",guest);
            }
            else
            {
                return View();
            }
        }

        public void E_mail(Guest guest)
        {
            try
            {
            System.Web.Helpers.WebMail.SmtpServer = "smtp.gmail.com";
                System.Web.Helpers.WebMail.SmtpPort = 587;
                System.Web.Helpers.WebMail.EnableSsl = true;
                System.Web.Helpers.WebMail.UserName = guest.Email;
                System.Web.Helpers.WebMail.Password = "eofw mnpw ncuw ruzc ";
                System.Web.Helpers.WebMail.From = "artursuskevits@gmail.com";
                System.Web.Helpers.WebMail.Send("artursuskevits@gmail.com", "Vastus Kustele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ? "tuleb peole " : " ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja sada";
            }
        }
        


    }
}