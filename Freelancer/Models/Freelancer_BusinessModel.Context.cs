﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Freelancer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FreelanceDbContext : DbContext
    {
        public FreelanceDbContext()
            : base("name=FreelanceDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<MessageBox> MessageBoxes { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<FreelancerClient> FreelancerClients { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<MessageRecipient> MessageRecipients { get; set; }
    
        public virtual int SP_FreelancerBooking(Nullable<int> customerID, Nullable<int> jobCode, Nullable<decimal> discount, Nullable<decimal> callOutFee, Nullable<decimal> vat)
        {
            var customerIDParameter = customerID.HasValue ?
                new ObjectParameter("customerID", customerID) :
                new ObjectParameter("customerID", typeof(int));
    
            var jobCodeParameter = jobCode.HasValue ?
                new ObjectParameter("jobCode", jobCode) :
                new ObjectParameter("jobCode", typeof(int));
    
            var discountParameter = discount.HasValue ?
                new ObjectParameter("discount", discount) :
                new ObjectParameter("discount", typeof(decimal));
    
            var callOutFeeParameter = callOutFee.HasValue ?
                new ObjectParameter("callOutFee", callOutFee) :
                new ObjectParameter("callOutFee", typeof(decimal));
    
            var vatParameter = vat.HasValue ?
                new ObjectParameter("vat", vat) :
                new ObjectParameter("vat", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_FreelancerBooking", customerIDParameter, jobCodeParameter, discountParameter, callOutFeeParameter, vatParameter);
        }
    }
}
