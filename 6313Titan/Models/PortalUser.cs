using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6313Titan.Models
{
    public class PortalUser
    {
        public int ID { get; set; }
        public Portal Portal { get; set; }
        public long PortalId { get; set; }
        public String UserId { get; set; }
    }
}
