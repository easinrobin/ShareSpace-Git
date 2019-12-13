using System.Collections.Generic;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Testimonial;

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
            public ActionResult InsertTestimonial(Testimonial testimonial)
            {

                TestimonialManager manager = new TestimonialManager();
                if (testimonial != null && testimonial.TestimonialId > 0)
                {
                    TestimonialManager.UpdateTestimonial(testimonial);
                }
                else
                {
                    TestimonialManager.InsertTestimonial(testimonial);
                }


                return RedirectToAction("AdminTestimonials");
            }

            public ActionResult UpdateTestimonial(int testimonialId)
            {
                Testimonial testimonial = TestimonialManager.GetTestimonialById(testimonialId);
                return View("~/Views/Testimonial/InsertTestimonial.cshtml", testimonial);
            }

            public ActionResult DeleteTestimonial(long testimonialId)
            {
                TestimonialManager.DeleteTestimonial(testimonialId);
                return RedirectToAction("AdminTestimonials");
            }

    }
}