using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;

namespace AdminPanel.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult InsertTransaction()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertTransaction([Bind(Include = "")] Transaction transaction)
        {
            TransactionManager manager = new TransactionManager();
            //if (ModelState.IsValid)
            //{

            var id = manager.InsertTransaction(transaction);
            //return RedirectToAction("InsertTransaction");
            //}
            return View(transaction);
        }

        public ActionResult AdminTransactions()
        {
            List<Transaction> allTransactions = TransactionManager.GetAllTransactions(1);
            return View("~/Views/Transaction/AdminTransactions.cshtml", allTransactions);
        }
    }
}