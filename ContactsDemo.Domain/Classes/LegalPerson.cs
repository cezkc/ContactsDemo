using ContactsDemo.Domain.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace ContactsDemo.Domain
{
    /// <summary>
    /// Class for Legal person with basic information
    /// </summary>
    public class LegalPerson : Person
    {
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string CNPJ { get; set; }
    }
}
