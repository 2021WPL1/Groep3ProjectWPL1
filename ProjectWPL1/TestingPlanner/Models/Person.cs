using System;
using System.Collections.Generic;

namespace TestingPlanner.Models
{
    public partial class Person
    {
        public Person()
        {
            RqBarcoDivisionPerson = new HashSet<RqBarcoDivisionPerson>();
        }

        public string Afkorting { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }

        public virtual ICollection<RqBarcoDivisionPerson> RqBarcoDivisionPerson { get; set; }
    }
}
