using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Freelancer.Models;

namespace Freelancer.Validations
{
    public class memberValidation : ValidationAttribute
    {
        private FreelanceDbContext db = new FreelanceDbContext();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = validationContext.ObjectInstance.ToString();

            var customerRecord = db.Customers.Where(a => a.customerEmail == email).FirstOrDefault();
            var freelancerRecord = db.FreelancerClients.Where(a => a.freelancerEmail == email).FirstOrDefault();

            if(customerRecord == null || freelancerRecord == null)
            {
                return ValidationResult.Success;
            } else
            {
                return new ValidationResult("email already exits in database");
            }
        }
    }
}