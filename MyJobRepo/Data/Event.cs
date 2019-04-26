using System;

namespace MyJobRepo.Data
{
    public class Event
    {
        // Columns
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public int PostingId { get; set; }
        public string Description { get; set; }
        public bool IsActionRequired { get; set; }
    }
}