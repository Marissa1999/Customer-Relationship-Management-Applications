using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientCRM.Controllers
{
    public class HomeController : Controller
    {
        Models.ClientEntities database = new Models.ClientEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(database.Clients);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Models.Client theClient = database.Clients.SingleOrDefault(c => c.client_id == id);
            return View(theClient);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.Client newClient = new Models.Client()
                {
                    first_name = collection["first_name"],
                    last_name = collection["last_name"]
                };

                database.Clients.Add(newClient);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var theClient = (from c in database.Clients
                            where c.client_id == id
                            select c).SingleOrDefault();

            var aClient = database.Clients.SingleOrDefault(c => c.client_id == id);

            return View(aClient);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Models.Client theClient = database.Clients.SingleOrDefault(c => c.client_id == id);
                {
                    theClient.first_name = collection["first_name"];
                    theClient.last_name = collection["last_name"];
                };

                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Client theClient = database.Clients.SingleOrDefault(c => c.client_id == id);
            return View(theClient);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Client theClient = database.Clients.SingleOrDefault(c => c.client_id == id);

                database.Clients.Remove(theClient);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
