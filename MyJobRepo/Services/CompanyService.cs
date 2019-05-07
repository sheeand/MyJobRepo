using MyJobRepo.DataAccess;
using MyJobRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJobRepo.Services
{
    public class CompanyService
    {
        public bool SaveNewCompany(CompanyModel model)
        {

            var entity = new Company()
            {
                CompanyId = model.CompanyId,
                Description = model.Description,
                Link = model.Link,
                CompanyName = model.CompanyName,
                IsEmployer = model.IsEmployer
            };

            using (var context = new MyJobRepo_DataContext())
            {
                try
                {
                    context.Companies.Add(entity);
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