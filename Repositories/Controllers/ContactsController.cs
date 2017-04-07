using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Repositories.DomainServices;
using Repositories.Models.Domain;
using Repositories.Models.ViewModels;

namespace Repositories.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        // GET: ContactEntities
        public ActionResult Index()
        {
            var contacts = contactService.GetAllContacts();
            var viewmodel = contacts.Select(c => AutoMapper.Mapper.Map<ContactViewModel>(c)).ToList();
            return View(viewmodel);
        }

        // GET: ContactEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = contactService.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            var vm = AutoMapper.Mapper.Map<ContactViewModel>(contact);
            return View(vm);
        }

        // GET: ContactEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,LastName,IsActive")] CreateContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var domainObject = AutoMapper.Mapper.Map<Contact>(contact);
                contactService.CreateContact(domainObject);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: ContactEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = contactService.GetContact(id.Value);
            var viewmodel = AutoMapper.Mapper.Map<ContactViewModel>(contact);

            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(viewmodel);
        }

        // POST: ContactEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,IsActive")] ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var c = AutoMapper.Mapper.Map<Contact>(contact);
                contactService.UpdateContact(c);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: ContactEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = contactService.GetContact(id.Value);
            var viewmodel = AutoMapper.Mapper.Map<ContactViewModel>(contact);

            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(viewmodel);
        }

        // POST: ContactEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactService.DeleteContact(id);
            return RedirectToAction("Index");
        }


        public ActionResult Disable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = contactService.GetContact(id.Value);
            if (contact != null)
            {
                contactService.DisableContact(contact);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = contactService.GetContact(id.Value);
            if (contact != null)
            {
                contactService.EnableContact(contact);
            }

            return RedirectToAction("Index");
        }

    }
    
}
