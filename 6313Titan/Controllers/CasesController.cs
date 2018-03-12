using _6313Titan.Models;
using _6313Titan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace _6313Titan.Controllers
{
    public class CasesController : Controller
    {
        private ApplicationDbContext _context;

        public CasesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cases

        public ActionResult New(Guid PortalId)
        {
            var Case = new Case();
            var ViewModel = new PortalCaseViewModel();
            ViewModel.Case = Case;
            ViewModel.PortalId = PortalId;
               
            return View("CaseForm", ViewModel);
        }

        [HttpPost]
        public ActionResult Save(PortalCaseViewModel ViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CaseForm", ViewModel.Case);
            }

            if (ViewModel.Case.Id == Guid.Empty)
            {
                ViewModel.Case.Id = Guid.NewGuid();
                ViewModel.Case.PortalId = ViewModel.PortalId;
                //var PortalCases = (from x in _context.Cases where x.PortalId == ViewModel.Case.PortalId select x).ToList();
                //ViewModel.PortalCases = PortalCases;
                //@case.PortalId = Titan.Controllers.PortalController.CurrentPortalGuid;
                _context.Cases.Add(ViewModel.Case);
            }
            else
            {
                var caseInDb = _context.Cases.Single(c => c.Id == ViewModel.Case.Id);
                caseInDb.Subject = ViewModel.Case.Subject;
                caseInDb.Description = ViewModel.Case.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Details", "Portals", new { Id = ViewModel.PortalId} );
        }

    }
}