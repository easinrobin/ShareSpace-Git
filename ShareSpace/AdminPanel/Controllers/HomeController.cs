﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Property()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Vendors()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
         public ActionResult Client()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Booking()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Transactions()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallerys()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Property_Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Property_Rating()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Property_Address()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult New_contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}