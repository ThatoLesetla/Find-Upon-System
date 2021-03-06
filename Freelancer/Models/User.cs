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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.MessageBoxes = new HashSet<MessageBox>();
            this.MessageRecipients = new HashSet<MessageRecipient>();
        }
    
        public int id { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public bool emailStatus { get; set; }
        public Nullable<System.DateTime> registerDate { get; set; }
        public string userRole { get; set; }
        public Nullable<int> freelancerID { get; set; }
        public Nullable<int> customerId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual FreelancerClient FreelancerClient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageBox> MessageBoxes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageRecipient> MessageRecipients { get; set; }
    }
}
