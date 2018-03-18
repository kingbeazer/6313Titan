using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _6313Titan.Models
{
    public class Contact : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Work Number")]
        [Phone]
        public string WorkNumber { get; set; }

        [Display(Name = "Mobile Number")]
        [Phone]
        public string MobileNumber { get; set; }

        [Required]
        public Guid PortalId { get; set; }

    }
}