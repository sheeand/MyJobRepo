using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class PostingModel
    {
        public int PostingId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public int HRRepContactId { get; set; }
        public int SrDevContactId { get; set; }
        public int DevContactId { get; set; }
        public int HiringMgrContactId { get; set; }
        public int RecruiterContactId { get; set; }
        public int AcctManagerContactId { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}