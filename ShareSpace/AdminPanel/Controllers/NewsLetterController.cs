using System.Collections.Generic;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.NewsLetter;

namespace AdminPanel.Controllers
{
    public class NewsLetterController : Controller
    {
        // GET: NewsLetter
        public ActionResult InsertNewsLetter()
        {
            return View();
        }



        public ActionResult AdminNewsLetters()
        {
            List<NewsLetter> allNewsLetters = NewsLetterManager.GetAllNewsLetters();
            return View("~/Views/NewsLetter/AdminNewsLetters.cshtml", allNewsLetters);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertNewsLetter(NewsLetter newsletter)
        {

            NewsLetterManager manager = new NewsLetterManager();
            if (newsletter != null && newsletter.NewsLetterId > 0)
            {
                NewsLetterManager.UpdateNewsLetter(newsletter);
            }
            else
            {
                NewsLetterManager.InsertNewsLetter(newsletter);
            }


            return RedirectToAction("AdminNewsLetters");
        }




        public ActionResult UpdateNewsLetter(int newsletterId)
        {
            NewsLetter newsletter = NewsLetterManager.GetNewsLetterById(newsletterId);
            return View("~/Views/NewsLetter/InsertNewsLetter.cshtml", newsletter);
        }



        public ActionResult DeleteNewsLetter(long newsletterId)
        {
            NewsLetterManager.DeleteNewsLetter(newsletterId);
            return RedirectToAction("AdminNewsLetters");
        }
    }
}