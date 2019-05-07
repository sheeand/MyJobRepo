using MyJobRepo.DataAccess;
using MyJobRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing.Constraints;

namespace MyJobRepo.Services
{
    public class PostingService
    {
        public bool SaveNewPosting(PostingModel model)
        {
            var postingEntity = new Posting()
            {
                CompanyName = model.CompanyName,
                Title = model.Title,
                Link = model.Link,
                Description = model.Description,
                IsActive = model.IsActive,
                HRRepContactId = model.HRRepContactId,
                SrDevContactId = model.SrDevContactId,
                DevContactId = model.DevContactId,
                HiringMgrContactId = model.HiringMgrContactId,
                RecruiterContactId = model.RecruiterContactId,
                AcctManagerContactId = model.AcctManagerContactId
            };

            using (var context = new MyJobRepo_DataContext())
            {
                try
                {
                    context.Postings.Add(postingEntity);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }
    }
}