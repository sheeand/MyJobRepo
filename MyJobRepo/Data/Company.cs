using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Data
{
    public class Company
    {
        // Columns
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsEmployer { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        // One-to-many relationships
        //public virtual ICollection<Contact> Contacts { get; set; }
    }
}