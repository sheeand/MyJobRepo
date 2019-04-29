using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public async Task<ContactType> GetContactTypeAsync(int contactTypeId)
        {
            IQueryable<ContactType> query = dbContext.ContactTypes
                .Where(x => x.ContactTypeId == contactTypeId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Contact> GetContactAsync(int contactId)
        {
            IQueryable<Contact> query = dbContext.Contacts
                .Where(x => x.ContactId == contactId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Contact[]> GetContactsByContactTypeAsync(string contactType)
        {
            IQueryable<ContactType> query1 = dbContext.ContactTypes
                .Where(z => z.Name == contactType);
            var x = await query1.FirstOrDefaultAsync();

            IQueryable<Contact> query2 = dbContext.Contacts
                .Where(y => y.ContactTypeId == x.ContactTypeId);
            return await query2.ToArrayAsync();
        }

        public async Task<Company> GetCompanyAsync(int companyId)
        {
            IQueryable<Company> query = dbContext.Companies
                .Where(x => x.CompanyId == companyId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Posting[]> GetAllPostingsAsync()
        {
            IQueryable<Posting> query = dbContext.Postings;
            return await query.ToArrayAsync();
        }

        public async Task<Posting> GetPostingAsync(int postingId)
        {
            IQueryable<Posting> query = dbContext.Postings
                .Where(x => x.PostingId == postingId);
            return await query.FirstOrDefaultAsync();
        }
    }
}