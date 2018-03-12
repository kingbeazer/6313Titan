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
    public class PortalsController : Controller
    {

        private ApplicationDbContext _context;

        public PortalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Portals
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            var @portals = _context.PortalUsers.Where(c => c.UserId == UserId).Select(x => x.Portal);
            return View(@portals);
        }

        [Authorize]
        public ActionResult New()
        {
            var portal = new Portal();
            return View(portal);
        }

        //GET: Portals/Details/5
        public ActionResult Details(Guid id)
        {
            ViewBag.Data = id;
            var UserId = User.Identity.GetUserId();
            var portal = _context.Portals.SingleOrDefault(p => p.Id == id);
            var @portals = _context.PortalUsers.Where(c => c.UserId == UserId).Select(x => x.Portal).ToList();
            var Authorised = @portals.Contains(portal);

            if (Authorised)
            {

            var ViewModel = new PortalUserViewModel();
                ViewModel.Portal = portal;
                ViewModel.UserID = id;
                return View("PortalForm", ViewModel);
            }
            else
                return Content("Sorry not Authorised to View!");
        }

        [HttpPost]
        public ActionResult Save(Portal @portal)
        {
            if (!ModelState.IsValid)
            {

                return View("PortalForm", portal);
            }

            if (portal.Id == Guid.Empty)
            {
                portal.Id = Guid.NewGuid();
                _context.PortalUsers.Add(new PortalUser { Portal = portal, UserId = User.Identity.GetUserId() });
                _context.Portals.Add(portal);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Portals");
        }
    }
}