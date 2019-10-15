using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Freelancer.Models
{
    [MetadataType(typeof(FreelancerClientMetaData))]
    public partial class FreelancerClient
    {
    }

    public class FreelancerClientMetaData
    {
        [Required]
        [StringLength(40)]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]
        public string freelancerName { get; set; }

        [Required]
        [StringLength(35)]
        [Display(Name = "Surname")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]
        public string freelancerSurname { get; set; }

        [Required]
        [StringLength(40)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string freelancerEmail { get; set; }

        [Required]
        [StringLength(10)]
        [Phone]
        [Display(Name = "Phone")]
        public string freelancerPhone { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name ="Address")]
        public string freelancerAddress { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "City")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]
        public string city { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^[0-9''-'\s]{1,40}$", ErrorMessage = "Enter valid staff number")]
        public string postalCode { get; set; }

        [StringLength(100)]
        [Display(Name = "Website URL")]
        public string freelancerWebsite { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string occupation { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Bio")]
        public string bio { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}