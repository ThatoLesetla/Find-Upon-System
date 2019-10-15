using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Freelancer.Models
{
    [MetadataType(typeof(ServiceMetaData))]
    public partial class ServiceRequest
    {
    }

    public class ServiceMetaData
    {
        
        public Nullable<System.DateTime> requestDate { get; set; }
        public Nullable<int> customerID { get; set; }
        public string serviceDescription { get; set; }
        public Nullable<bool> verified { get; set; }
        public Nullable<int> jobCode { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public string Category { get; set; }
        public Nullable<System.DateTime> deliveryDate { get; set; }
        public Nullable<decimal> budget { get; set; }
    }
}