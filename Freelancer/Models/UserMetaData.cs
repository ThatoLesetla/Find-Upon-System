using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Freelancer.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }
        public class UserMetaData
    {
        [Required]
        [StringLength(60)]
        [Display(Name ="User name")]
        public string userName { get; set; }

    }
}