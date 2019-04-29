using System.Linq;
using System.Threading.Tasks;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace MyJobRepo.Data
{
    public interface IRepository
    {
        Task<ContactType> GetContactTypeAsync(int contactTypeId);
        Task<ContactType[]> GetAllContactTypesAsync();
        Task<Contact> GetContactAsync(int contactId);
        Task<Contact[]> GetAllContactsAsync();
        Task<Contact[]> GetContactsByContactTypeAsync(string contactType);
        Task<Company> GetCompanyAsync(int companyId);
        Task<Company[]> GetAllCompaniesAsync();
        Task<Posting> GetPostingAsync(int postingId);
        Task<Posting[]> GetAllPostingsAsync();
    }
}
