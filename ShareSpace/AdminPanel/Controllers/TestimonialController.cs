using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Admin;
using ShareSpace.Models.Testimonial;
using ShareSpace.Models.Vendor;

namespace AdminPanel.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        public ActionResult InsertTestimonial()
        {
            return View();
        }

        public ActionResult AdminTestimonials()
        {
            List<Testimonial> allTestimonials = TestimonialManager.GetAllTestimonials();
            return View("~/Views/Testimonial/AdminTestimonials.cshtml", allTestimonials);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertTestimonial(AdminVWModel adminVwModel, HttpPostedFileBase image)
        {

            TestimonialManager manager = new TestimonialManager();
            if (adminVwModel.Testimonial != null && adminVwModel.Testimonial.TestimonialId > 0)
            {
                _UploadImage(adminVwModel, image);
                TestimonialManager.UpdateTestimonial(adminVwModel.Testimonial);
            }
            else
            {
                _UploadImage(adminVwModel, image);
                TestimonialManager.InsertTestimonial(adminVwModel.Testimonial);
            }

            return RedirectToAction("AdminTestimonials");
        }

        public ActionResult UpdateTestimonial(AdminVWModel adminVwModel, int testimonialId)
        {
            adminVwModel.Testimonial = TestimonialManager.GetTestimonialById(testimonialId);
            return View("~/Views/Testimonial/InsertTestimonial.cshtml", adminVwModel);
        }

        public ActionResult DeleteTestimonial(long testimonialId)
        {
            TestimonialManager.DeleteTestimonial(testimonialId);
            return RedirectToAction("AdminTestimonials");
        }

        private void _UploadImage(AdminVWModel adminVwModel, HttpPostedFileBase images)
        {
            foreach (var file in adminVwModel.Files.Take(1))
            {
                string pathUrl = "";

                if (file.ContentLength > 0)
                {
                    string savepath, savefile;
                    var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                    savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);
                    savefile = Path.Combine(savepath, filename);
                    file.SaveAs(savefile);
                    pathUrl = "/img/Offices/" + filename;
                    adminVwModel.Testimonial.ProfileImage = pathUrl;
                }
            }
        }
    }
}