using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _6313Titan.Models
{
    public class Case
    {
        public Guid Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public Portal Portal { get; set; }

        public Guid PortalId { get; set; }
    }
}