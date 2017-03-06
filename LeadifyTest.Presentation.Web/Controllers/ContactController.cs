using System.Web.Mvc;
using LeadifyTest.Services;
using LeadifyTest.Presentation.Web.Mappers;
using System;
using LeadifyTest.Entities;
using System.Net;
using LeadifyTest.Presentation.Web.Models;

namespace LeadifyTest.Presentation.Web.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: Contact
        public ActionResult Index()
        {
            var list = _contactService.GetAllContacts().MapToViewModelList();
            return View(list);
        }

        // GET: Contact/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contactService.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact.MapToViewModel());
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var contact = new Contact()
                {
                    ContactId = Guid.NewGuid(),
                    Firstname = collection["Firstname"],
                    Lastname = collection["Lastname"],
                    Email = collection["Email"],
                    Cellphone = collection["Cellphone"],
                };

                _contactService.Create(contact);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _contactService.GetById(id).MapToViewModel();

            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contact = new Contact()
                    {
                        ContactId = id,
                        Firstname = collection["Firstname"],
                        Lastname = collection["Lastname"],
                        Email = collection["Email"],
                        Cellphone = collection["Cellphone"],
                    };

                    _contactService.Update(contact);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contactService.GetById(id);
            _contactService.Remove(contact);
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}