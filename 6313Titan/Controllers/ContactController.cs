using _6313Titan.DataAccess.Persistence.Repositories;
using _6313Titan.Models;
using _6313Titan.Models.App.Extensions;
using _6313Titan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6313Titan.Controllers
{
    public class ContactController : Controller
    {
        private UnitOfWork unitofwork;

        public ContactController()
        {
            unitofwork = new UnitOfWork(new ApplicationDbContext());
        }

       

        // GET: Contact
        public ActionResult Index(Guid PortalId)
        {
            ViewBag.data = PortalId;

            var contacts = unitofwork.Contacts.Find(contact => contact.PortalId == PortalId);
            ViewBag.datasource = contacts;


            return View(contacts);
        }

        [Authorize]
        public ActionResult New(Guid PortalId)
        {
            var contact = new Contact();
            var viewModel = new ContactFormViewModel();
            viewModel.Contact = contact;
            viewModel.PortalId = PortalId;

            return View("ContactForm", viewModel);

        }

        [HttpPost]
        public ActionResult Save(ContactFormViewModel contactFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ContactFormViewModel
                {

                    Contact = contactFormViewModel.Contact

                };
                return View("ContactForm", viewModel);
            }

            if (contactFormViewModel.Contact.Id == Guid.Empty)
            {
                contactFormViewModel.Contact.Id = Guid.NewGuid();
                //contact.PortalId = Titan.Controllers.PortalsController.CurrentPortalGuid;
                contactFormViewModel.Contact.PortalId = contactFormViewModel.PortalId;



                unitofwork.Contacts.Add(contactFormViewModel.Contact);
                unitofwork.Complete();
            }
            else
            {
                var contactInDb = unitofwork.Contacts.Get(contactFormViewModel.Contact.Id);
                contactInDb.Name = contactFormViewModel.Contact.Name;
                contactInDb.Email = contactFormViewModel.Contact.Email;
                contactInDb.MobileNumber = contactFormViewModel.Contact.MobileNumber;
                contactInDb.WorkNumber = contactFormViewModel.Contact.WorkNumber;
            }
                //unitofwork.Contacts.Add(contactFormViewModel.Contact);
            return RedirectToAction("Index", "Contact", new { PortalId = contactFormViewModel.PortalId });
        }
    }
}