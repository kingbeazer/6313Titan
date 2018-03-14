using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _6313Titan.Models;

namespace _6313Titan.DTOs
{
    public class CaseDTO
    {
        public Guid Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public Guid PortalId { get; set; }
    }
}