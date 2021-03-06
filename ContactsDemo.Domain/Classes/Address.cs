﻿namespace ContactsDemo.Domain
{

    /// <summary>
    /// Address information
    /// </summary>
    public class Address :BaseEntity
    {

        private Address()
        {

        }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }
}