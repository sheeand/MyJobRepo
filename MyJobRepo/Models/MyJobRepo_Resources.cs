using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class MyJobRepo_Resources
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLink { get; set; }
        public string CompanyDescription { get; set; }

        public int ContactId { get; set; }
        public int ContactCompanyId { get; set; }
        public int ContactContactTypeId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactNotes { get; set; }

        public int ContactTypeId { get; set; }
        public string ContactTypeName { get; set; }

        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public int EventPostingId { get; set; }
        public string EventDescription { get; set; }
        public bool IsActionRequired { get; set; }

        public int PostingId { get; set; }
        public int PostingCompanyId { get; set; }
        public string PostingTitle { get; set; }
        public string PostingLink { get; set; }
        public string PostingDescription { get; set; }
        public bool IsActive { get; set; }

    }
}