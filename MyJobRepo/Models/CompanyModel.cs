﻿
namespace MyJobRepo.Models
{
    public class CompanyModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsEmployer { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}