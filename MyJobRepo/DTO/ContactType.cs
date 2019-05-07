
namespace MyJobRepo.DataAccess
{
    public class ContactType
    {
        // Columns
        public int ContactTypeId { get; set; }
        public string Name { get; set; }

        // One-to-many relationships
        //public virtual ICollection<Contact> Contacts { get; set; }

    }
}