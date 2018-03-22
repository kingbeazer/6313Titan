using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _6313Titan.Models;

namespace _6313.Controllers
{
    public class AdministrationController : Controller
    {
        private ApplicationDbContext _context;

        public AdministrationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Administration
        public ActionResult Index(Guid PortalId)
        {
            ViewBag.data = PortalId;
            return View();
        }
    }
}