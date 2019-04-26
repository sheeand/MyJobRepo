using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class EventModel
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public int PostingId { get; set; }
        public string Description { get; set; }
        public bool IsActionRequired { get; set; }
    }
}