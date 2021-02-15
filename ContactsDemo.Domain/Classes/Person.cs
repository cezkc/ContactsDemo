using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Domain.Classes
{
    /// <summary>
    /// Base class for Person
    /// </summary>
    public class Person : BaseEntity
    {
        public Person()
        {
            if (this is NaturalPerson)
                IsNaturalPerson = true;
            else
                IsLegalPerson = true;
        }

        public NaturalPerson NaturalPerson
        {
            get
            {
                if (IsNaturalPerson)
                    return this as NaturalPerson;
                else
                    return null;
            }
        }

        public LegalPerson LegalPerson
        {
            get
            {
                if (IsLegalPerson)
                    return this as LegalPerson;
                else
                    return null;
            }
        }

        public bool IsNaturalPerson { get; set; }

        public bool IsLegalPerson { get; set; }

    }
}
