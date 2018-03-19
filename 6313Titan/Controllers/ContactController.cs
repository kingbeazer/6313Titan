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
        private ApplicationDbContext _context;

        public ContactController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Contact
        public ActionResult Index(Guid PortalId)
        {
            ViewBag.data = PortalId;

            var contacts = _context.Contact
                .Where(pId => pId.PortalId == PortalId)
                .ToList();
            ViewBag.datasource = contacts;


            return View();
        }

        [Authorize]
        public ActionResult New()
        {

            var viewModel = new ContactFormViewModel
            {
                Contact = new Contact()

            };


            return View("ContactForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ContactFormViewModel
                {

                    Contact = contact

                };
                return View("ContactForm", viewModel);
            }

            if (contact.Id == Guid.Empty)
            {
                contact.Id = Guid.NewGuid();
                //contact.PortalId = Titan.Controllers.PortalsController.CurrentPortalGuid;
                var portalId = User.Identity.GetUserId();
                contact.PortalId = Guid.Parse(portalId);
                _context.Contact.Add(contact);
            }
            else
            {
                var contactInDb = _context.Contact.Single(c => c.Id == contact.Id);
                contactInDb.Name = contact.Name;
                contactInDb.Email = contact.Email;
                contactInDb.MobileNumber = contact.MobileNumber;
                contactInDb.WorkNumber = contact.WorkNumber;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Contact");
        }
    }
}