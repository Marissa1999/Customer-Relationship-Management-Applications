using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientCRM.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Models.ClientEntities database = new Models.ClientEntities();

        public ActionResult Index(int id) //Missing client-id
        {
            ViewBag.id = id;

            var theContact = database.Clients.SingleOrDefault(c => c.client_id == id);
            return View(theContact);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id) //Missing contact-id
        {
            Models.Contact theContact = database.Contacts.SingleOrDefault(c => c.contact_id == id);
            return View(theContact);
        }

        // GET: Contact/Create
        public ActionResult Create(int id) //Missing client-id
        {
            Models.Contact theContact = database.Contacts.SingleOrDefault(c => c.client_id == id);
            return View(theContact);
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection) //Missing the client-id
        {
            try
            {
                // TODO: Add insert logic here
                Models.Contact newContact = new Models.Contact()
                {
                    client_id = id,
                    info = collection["info"],
                    type = collection["type"]
                };

                database.Contacts.Add(newContact);
                database.SaveChanges();

                return RedirectToAction("Index", new { id = id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)//contact-id
        {
            var theContact = database.Contacts.SingleOrDefault(c => c.contact_id == id);
            return View(theContact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)//contact-id
        {
            try
            {
                // TODO: Add update logic here
                Models.Contact theContact = database.Contacts.SingleOrDefault(c => c.contact_id == id);

                theContact.info = collection["info"];
                theContact.type = collection["type"];
              
                database.SaveChanges();

                return RedirectToAction("Index", new { id = theContact.client_id });
            }
            catch
            {
                return Content("An exception has occured.");
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id) //contact-id
        {
            Models.Contact theContact = database.Contacts.SingleOrDefault(c => c.contact_id == id);
            return View(theContact);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) //contact-id
        {
            try
            {
                // TODO: Add delete logic here
                Models.Contact theContact = database.Contacts.Single(c => c.contact_id == id);
                database.Contacts.Remove(theContact);
                database.SaveChanges();

                return RedirectToAction("Index", new { id = theContact.client_id });
            }
            catch
            {
                return View();
            }
        }
    }
}
