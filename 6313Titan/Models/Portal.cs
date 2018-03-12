using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6313Titan.Models
{
    public class Portal
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public bool Active { get; set; }
        public String Description { get; set; }
    }
}