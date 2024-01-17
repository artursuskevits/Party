using Party.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using static System.Web.Helpers.WebMail;

namespace Party.Controllers
{

    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;

            if (hour >= 5 && hour <= 10)
            {
                @ViewBag.Greeting = "Tere hommikust";
            }
            else if (hour >= 11 && hour <= 15)
            {
                @ViewBag.Greeting = "Tere paäeavst";
            }
            else if (hour >= 16 && hour <= 23)
            {
                @ViewBag.Greeting = "Tere õhtuni";
            }
            else if (hour >= 0)
            {
                @ViewBag.Greeting = "Tere öö";
            }
            return View();

        }
        public ActionResult Kutse()
        {
            int hour = DateTime.Now.Hour;
            int month = DateTime.Now.Month;

            ViewBag.Greeting = hour < 10 ? "Tere hommikust" : "Tere päevast";

            string baseMessage = "Ootan sind oma peoloe! Tule kindlasti!!! Ootan sind!";
            month = 3;
            if (month == 1 || month == 2)
            {
                ViewBag.Message = baseMessage + " - Jaanuar või Veebruar sünnipäevalaps!";
                ViewBag.ImagePath = "january.jpg";
            }
            else if (month == 3 || month == 4)
            {
                ViewBag.Message = baseMessage + " - Märts või Aprill sünnipäevalaps!";
                ViewBag.ImagePath = "march.jpg";
            }
            else if (month == 5 || month == 6)
            {
                ViewBag.Message = baseMessage + " - Mai või Juuni sünnipäevalaps!";
                ViewBag.ImagePath = "june.jpg";
            }
            else if (month == 7 || month == 8)
            {
                ViewBag.Message = baseMessage + " - Juuli või August sünnipäevalaps!";
                ViewBag.ImagePath = "august.jpg";
            }
            else if (month == 9 || month == 10)
            {
                ViewBag.Message = baseMessage + " - September või Oktoober sünnipäevalaps!";
                ViewBag.ImagePath = "september.jpg";
            }
            else if (month == 11 || month == 12)
            {
                ViewBag.Message = baseMessage + " - November või Detsember sünnipäevalaps!";
                ViewBag.ImagePath = "detsember.jpg";
            }

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
                return View("Thanks", guest);

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
                System.Web.Helpers.WebMail.UserName = "artursuskevits@gmail.com";
                System.Web.Helpers.WebMail.Password = "zktl wbuc gukc jtks ";
                System.Web.Helpers.WebMail.From = guest.Email;
                System.Web.Helpers.WebMail.Send("artursuskevits@gmail.com", "Vastus Kustele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ? "tuleb peole " : " ei tule peole"));

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saata. Error: " + ex.Message;
            }


        }
        [HttpPost]
        public ActionResult TuletaClicked(Guest guest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    E_mail(guest);
                    ViewBag.Message = "Email sent successfully!";
                    return View("Thanks", guest);
                }
                catch (Exception ex)
                {

                    // Display a user-friendly message
                    ViewBag.Message = "Sorry! Unable to send email at the moment." + ex.Message; ;
                    return View("Thanks", guest); // You might want to handle this case differently
                }
            }
            else
            {
                // Handle validation errors
                ViewBag.Message = "Invalid input. Please check the form.";
                return View("Thanks", guest); // You might want to handle this case differently
            }
        }


    }

}