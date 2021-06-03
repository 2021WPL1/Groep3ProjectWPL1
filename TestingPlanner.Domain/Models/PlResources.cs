using System;
using System.Collections.Generic;

namespace TestingPlanner.Domain.Models
{
    public partial class PlResources
    {
        public PlResources()
        {
            PlPlanningsKalenders = new HashSet<PlPlanningsKalender>();
            PlResourcesDivisions = new HashSet<PlResourcesDivision>();

            // Kleur = int.Parse(KleurRgb);
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public string KleurRgb { get; set; }
        // public int Kleur { get; set; }
        public string KleurHex { get; set; }

        public virtual ICollection<PlPlanningsKalender> PlPlanningsKalenders { get; set; }
        public virtual ICollection<PlResourcesDivision> PlResourcesDivisions { get; set; }
    }
}
