using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Freelancer.Validations;

namespace Freelancer.Models
{

    [MetadataType(typeof(CustomerMetaData))]
    public partial class Customer
    {
    }

    public class CustomerMetaData
    {
        [Required]
        [StringLength(20)]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]

        public string customerName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Surame")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]

        public string customerSurname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Address")]
        public string customerAddress { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "City")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]
        public string customerCity { get; set; }

        [Required]
        [StringLength(60)]
        [EmailAddress]
        [Display(Name = "Email")]
        [memberValidation]
        public string customerEmail { get; set; }

        [Required]
        [Phone]
        [StringLength(10)]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string customerPhone { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "PostalCode")]
        [RegularExpression(@"^[0-9''-'\s]{1,40}$", ErrorMessage = "This entry can only contain numbers")]
        public string postalCode { get; set; }
    }
}