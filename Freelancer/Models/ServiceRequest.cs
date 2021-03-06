//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ServiceRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceRequest()
        {
            this.Invoices = new HashSet<Invoice>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> requestDate { get; set; }
        public Nullable<int> customerID { get; set; }
        public string serviceDescription { get; set; }
        public Nullable<bool> verified { get; set; }
        public Nullable<int> jobCode { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public string Category { get; set; }
        public Nullable<System.DateTime> deliveryDate { get; set; }
        public Nullable<decimal> budget { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual Job Job { get; set; }
    }
}
