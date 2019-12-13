using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using ShareSpace.Models.Transaction;

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
        public ActionResult InsertTransaction(Transaction transaction)
        {
            TransactionManager manager = new TransactionManager();
            //if (ModelState.IsValid)
            //{
            if (transaction != null && transaction.TransactionId > 0)
            {
                TransactionManager.UpdateTransaction(transaction);
            }
            else
            {
                TransactionManager.InsertTransaction(transaction);
            }

            //return RedirectToAction("InsertVendor");
            //}
            return RedirectToAction("AdminTransactions");
        }

        public ActionResult UpdateTransaction(int transactionId)
        {
            Transaction transaction = TransactionManager.GetTransactionById(transactionId);
            return View("~/Views/Transaction/InsertTransaction.cshtml", transaction);
        }



        public ActionResult AdminTransactions()
        {
            List<Transaction> allTransactions = TransactionManager.GetAllTransactions(1);
            return View("~/Views/Transaction/AdminTransactions.cshtml", allTransactions);
        }

        [HttpPost]
        public ActionResult DeleteTransaction(int transactionId)
        {

            TransactionManager deleteTransaction = new TransactionManager();
            return RedirectToAction("AdminTransactions", deleteTransaction);
        }
    }
}