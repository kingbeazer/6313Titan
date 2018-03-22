using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _6313Titan.DTOs;
using _6313Titan.Models;
using _6313Titan.ViewModels;

namespace _6313Titan.Controllers
{
    public class ImportController : Controller
    {
        private ApplicationDbContext _context;

        public ImportController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Import
        public ActionResult Index(Guid PortalId)
        {
            ViewBag.data = PortalId;


            return View();
        }

        public ActionResult New(Guid PortalId)
        {
            var viewModel = new ImportFormViewModel
            {
                PortalId = PortalId
            };

            return View("ImportForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(HttpPostedFileBase file,ImportFormViewModel viewModel)
        {
            if (file != null && file.ContentLength > 0)
            {
                //Get file and store it in a folder to later read from
                string subPath = "~/App_Data/uploads";
                var fileName = Path.GetFileName(file.FileName);                
                bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));
                if (!exists)
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
                var path = Path.Combine(Server.MapPath(subPath), fileName);
                file.SaveAs(path);

                //Prep data for Json serialization
                var csvData = System.IO.File.ReadAllLines(path)
                                   .Skip(1)
                                   .Select(x => x.Split(','))
                                   .Select(x => new Contact
                                   {
                                       Name = x[0] + " " + x[1],
                                       Email = x[2],
                                       MobileNumber = x[3],
                                       WorkNumber = x[4],
                                       PortalId = viewModel.PortalId
                                   });


                foreach (var contact in csvData)
                {
                    var contactController = new ContactController();
                   
                }
                


            }

            return RedirectToAction("New","Import", new { PortalId = viewModel.PortalId });
        }


    }
}