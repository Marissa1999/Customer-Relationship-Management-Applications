using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookCRM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        Models.PhoneBookEntities database = new Models.PhoneBookEntities();

        public ActionResult Index()
        {
            return View(database.PhoneBooks);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Models.PhoneBook phoneBookMember = database.PhoneBooks.SingleOrDefault(c => c.phone_id == id);
            return View(phoneBookMember);
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
                Models.PhoneBook phoneBookMember = new Models.PhoneBook();

                phoneBookMember.name = collection["name"];
                phoneBookMember.number = collection["number"];

                database.PhoneBooks.Add(phoneBookMember);
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
            var phoneBookMember = (from c in database.PhoneBooks
                             where c.phone_id == id
                             select c).SingleOrDefault();

            var aPhoneBookMember = database.PhoneBooks.SingleOrDefault(c => c.phone_id == id);

            return View(aPhoneBookMember);

        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Models.PhoneBook phoneBookMember = database.PhoneBooks.SingleOrDefault(c => c.phone_id == id);

                phoneBookMember.name = collection["name"];
                phoneBookMember.number = collection["number"];

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
            Models.PhoneBook phoneBookMember = database.PhoneBooks.SingleOrDefault(c => c.phone_id == id);
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.PhoneBook phoneBookMember = database.PhoneBooks.SingleOrDefault(c => c.phone_id == id);

                database.PhoneBooks.Remove(phoneBookMember);
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
