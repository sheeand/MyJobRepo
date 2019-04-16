using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class ContactType
    {
        // Columns
        public int ContactTypeId { get; set; }
        public string Name { get; set; }

        // One-to-many relationships
        public virtual ICollection<Contact> Contacts { get; set; }

    }
}