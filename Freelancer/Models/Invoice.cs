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
    
    public partial class Invoice
    {
        public int invoiceNo { get; set; }
        public System.DateTime invoiceDate { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> totalAmount { get; set; }
        public Nullable<decimal> vat { get; set; }
        public Nullable<int> serviceID { get; set; }
        public Nullable<bool> status { get; set; }
    
        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
