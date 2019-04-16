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

        public IQueryable<ContactType> GetAllContactTypes()
        {
            return db.ContactTypes;
        }

        public ContactType GetContactTypeById(int id)
        {
            return db.ContactTypes.Find(id);
        }

    }
}