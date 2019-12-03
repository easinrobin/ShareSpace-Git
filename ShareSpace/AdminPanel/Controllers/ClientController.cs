using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using ShareSpace.Models.Client;

namespace AdminPanel.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult InsertClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertClient(Client client)
        {
            ClientManager manager = new ClientManager();
            
            if (client != null && client.ClientId > 0)
            {
                ClientManager.UpdateClient(client);
            }
            else
            {
                ClientManager.InsertClient(client);
            }

            return RedirectToAction("AdminClients");
        }

        public ActionResult UpdateClient(int clientId)
        {
            Client client = ClientManager.GetClientById(clientId);
            return View("~/Views/Client/InsertClient.cshtml", client);
        }


        public ActionResult AdminClients()
        {
            List<Client> allClients = ClientManager.GetAllClients();
            return View("~/Views/Client/AdminClients.cshtml", allClients);
        }


        public ActionResult DeleteClient(long clientId)
        {
            ClientManager.DeleteClient(clientId);
            return RedirectToAction("AdminClients");
        }
    }
}