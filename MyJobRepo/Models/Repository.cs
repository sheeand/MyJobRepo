using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class Repository : IRepository
    {
        private MyJobRepoContext db;

        public Repository(MyJobRepoContext db)
        {
            this.db = db;
        }

        // End points 

        public IQueryable<ContactType> GetAllContactTypes()
        {
            return db.ContactTypes;
        }

        public ContactType GetContactTypeById(int id)
        {
            return db.ContactTypes.Find(id);
        }


        public IQueryable<Contact> GetAllContacts()
        {
            return db.Contacts;
        }

        public Contact GetContactById(int id)
        {
            return db.Contacts.Find(id);
        }


        public IQueryable<Company> GetAllCompanies()
        {
            return db.Companies;
        }

        public Company GetCompanyById(int id)
        {
            return db.Companies.Find(id);
        }


        public IQueryable<Posting> GetAllPostings()
        {
            return db.Postings;
        }

        public Posting GetPostingById(int id)
        {
            return db.Postings.Find(id);
        }


        public IQueryable<PostingContact> GetAllPostingContacts()
        {
            return db.PostingContacts;
        }

        public PostingContact GetPostingContactById(int id)
        {
            return db.PostingContacts.Find(id);
        }


        public IQueryable<Event> GetAllEvents()
        {
            return db.Events;
        }

        public Event GetEventsById(int id)
        {
            return db.Events.Find(id);
        }

    }
}