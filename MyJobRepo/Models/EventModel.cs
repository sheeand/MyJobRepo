using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class EventModel
    {
        public int EventId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public int CompanyId { get; set; }
        public int CompanyName { get; set; }
        public string Action { get; set; }
        public bool IsActionRequired { get; set; }
    }
}