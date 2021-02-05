using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactsDemoWebApp.Models
{
    public class LegalPersonContactViewModel
    {
        public int Id { get; set; }

        #region Personal Information
        [Required]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Trade Name")]
        public string TradeName { get; set; }
        [Required]
        [MaxLength(18)]
        public string CNPJ { get; set; }
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
        [Display(Name = "Addressline 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Addressline 2")]
        public string AddressLine2 { get; set; }
        #endregion
    }
}
