using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Models
{
    public class MyJobRepo_Resources
    {
        public IQueryable<CompanyModel> CompanyModels { get; set; }
        public IQueryable<ContactModel> ContactModels { get; set; }
        public IQueryable<ContactTypeModel> ContactTypeModels { get; set; }
        public IQueryable<PostingModel> PostingModels { get; set; }
        public IQueryable<EventModel> EventModels { get; set; }
    }
}