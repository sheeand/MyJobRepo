using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        public int CompanyId { get; set; }
        public int ContactTypeId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        //public string Name { get; internal set; }
    }
}