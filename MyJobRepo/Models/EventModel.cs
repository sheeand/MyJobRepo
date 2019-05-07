using System;

namespace MyJobRepo.Models
{
    public class EventModel
    {
        public int EventId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public int PostingId { get; set; }
        public int CompanyId { get; set; }
        public string Action { get; set; }
        public bool IsActionRequired { get; set; }
    }
}