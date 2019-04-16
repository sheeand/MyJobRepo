using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class Contact
    {
        // Columns
        public int ContactId { get; set; }
        public int CompanyId { get; set; }
        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }

        // One-to-many relationships
        public virtual ICollection<PostingContact> PostingContacts { get; set; }
    }
}