using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactsDemoWebApp.Models
{
    public class NaturalPersonContactViewModel
    {
        public int Id { get; set; }

        #region Personal Information
        [Required]
        public string Name { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string CPF { get; set; }
        #endregion

        #region Address Information
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        #endregion
    }
}
