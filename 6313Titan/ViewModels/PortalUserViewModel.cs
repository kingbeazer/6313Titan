using _6313Titan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6313Titan.ViewModels
{
    public class PortalUserViewModel
    {
        public Portal Portal { get; set; }

        public Guid UserID { get; set; }

        public IEnumerable<Case> PortalCases { get; set; }

    }
}