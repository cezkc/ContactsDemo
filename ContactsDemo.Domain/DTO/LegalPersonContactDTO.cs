using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ContactsDemo.Domain.DTO
{
    /// <summary>
    /// ViewModel class for Legal Person Contact
    /// </summary>
    public class LegalPersonContactDTO
    {
        public int Id { get; set; }

        #region Personal Information
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string TradeName { get; set; }
        [Required]
        [MaxLength(18)]
        public string CNPJ { get; set; }
        #endregion

        public string Teste { get; set; }
        #region Address Information
        public string Teste { get; set; }
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

        public bool IsCNPJValid()
        {
            return Regex.IsMatch(CNPJ, @"^\d\d\.\d\d\d\.\d\d\d\/\d\d\d\d\-\d\d");
        }
    }
}
