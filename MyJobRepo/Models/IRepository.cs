using System.Linq;

namespace MyJobRepo.Models
{
    public interface IRepository
    {
        IQueryable<ContactType> GetAllContactTypes();
        ContactType GetContactTypeById(int id);
    }
}