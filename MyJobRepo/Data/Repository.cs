using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Newtonsoft.Json.Linq;

namespace MyJobRepo.Data
{
    public class Repository : IRepository
    {

        private MyJobRepoContext dbContext;

        public Repository(MyJobRepoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // End points 

        public async Task<ContactType[]> GetAllContactTypesAsync()
        {
            IQueryable<ContactType> query = dbContext.ContactTypes;
            return await query.ToArrayAsync();
        }

        public async Task<Company[]> GetAllCompaniesAsync()
        {
            IQueryable<Company> query = dbContext.Companies;
            return await query.ToArrayAsync();
        }

        public async Task<Contact[]> GetAllContactsAsync()
        {
            IQueryable<Contact> query = dbContext.Contacts;
            return await query.ToArrayAsync();
        }

        public Contact GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Company> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Posting> GetAllPostings()
        {
            throw new NotImplementedException();
        }

        public Posting GetPosting(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PostingContact> GetAllPostingContacts()
        {
            throw new NotImplementedException();
        }

        public PostingContact GetPostingContact(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Event GetEvents(int id)
        {
            throw new NotImplementedException();
        }

        public ContactType GetContactType(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Contact> GetAllContacts()
        {
            throw new NotImplementedException();
        }
    }
}