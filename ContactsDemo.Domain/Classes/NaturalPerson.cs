using ContactsDemo.Domain.Classes;
using ContactsDemo.Domain.Enums;
using System;
namespace ContactsDemo.Domain
{
    /// <summary>
    /// Class for Natural person with basic information
    /// </summary>
    public class NaturalPerson : Person
    {
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
    }
}
