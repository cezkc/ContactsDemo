using ContactsDemo.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ContactsDemo.Domain.DTO
{
    /// <summary>
    /// ViewModel class for Natural Person Contact
    /// </summary>
    public class NaturalPersonContactDTO
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
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        #endregion
        public bool IsCPFValid()
        {
            return Regex.IsMatch(CPF, @"^\d\d\d\.\d\d\d\.\d\d\d\-\d\d");
        }

    }
}
