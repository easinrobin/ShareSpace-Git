using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using ShareSpace.Models.Property;
using ShareSpace.Models.Transaction;
using ShareSpace.Models.Vendor;

namespace AdminPanel.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult InsertTransaction()
        {
            _loadProperties();
            _loadVendors();
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
            return RedirectToAction("AdminTransactions");
        }

        public ActionResult UpdateTransaction(int transactionId)
        {
            _loadProperties();
            _loadVendors();
            Transaction transaction = TransactionManager.GetTransactionById(transactionId);
            return View("~/Views/Transaction/InsertTransaction.cshtml", transaction);
        }

        public ActionResult AdminTransactions()
        {
            List<Transaction> allTransactions = TransactionManager.GetAllTransactions(1);
            return View("~/Views/Transaction/AdminTransactions.cshtml", allTransactions);
        }

        public ActionResult DeleteTransaction(int transactionId)
        {
            TransactionManager.DeleteTransaction(transactionId);
            return RedirectToAction("AdminTransactions");
        }

        private void _loadProperties()
        {
            List<Property> dataList = PropertyManager.GetAllProperties();
            ViewBag.PropertyList = new SelectList(dataList, "PropertyId", "PropertyName");
        }

        private void _loadVendors()
        {
            List<Vendor> dataList = VendorManager.GetAllVendors();
            ViewBag.VendorList = new SelectList(dataList, "VendorId", "FirstName");
        }
    }
}