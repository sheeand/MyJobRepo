using System;
using System.Threading.Tasks;

namespace MyJobRepo.DataAccess
{
    public class Posting
    {
        // Columns
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



        // One-to-many relationships
        //public virtual ICollection<Event> Events { get; set; }
        //public virtual ICollection<PostingContact> PostingContacts { get; set; }

        public static implicit operator Task<object>(Posting v)
        {
            throw new NotImplementedException();
        }
    }
}