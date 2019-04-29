using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyJobRepo.Data
{
    public class Posting
    {
        // Columns
        public int PostingId { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // One-to-many relationships
        //public virtual ICollection<Event> Events { get; set; }
        //public virtual ICollection<PostingContact> PostingContacts { get; set; }

        public static implicit operator Task<object>(Posting v)
        {
            throw new NotImplementedException();
        }
    }
}