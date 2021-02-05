using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Domain.Classes
{
    /// <summary>
    /// Base class for Person
    /// </summary>
    public class Person
    {
        public NaturalPerson NaturalPerson
        {
            get
            {
                if (IsNaturalPerson())
                    return this as NaturalPerson;
                else
                    return null;
            }
        }

        public LegalPerson LegalPerson
        {
            get
            {
                if (IsNaturalPerson())
                    return this as LegalPerson;
                else
                    return null;
            }
        }

        public bool IsNaturalPerson()
        {
            return this is NaturalPerson;
        }

        public bool IsLegalPerson()
        {
            return this is LegalPerson;
        }
    }
}
