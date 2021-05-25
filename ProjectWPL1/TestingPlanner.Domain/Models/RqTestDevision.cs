using System;
using System.Collections.Generic;

namespace TestingPlanner.Domain.Models
{
    public partial class RqTestDevision
    {
        public RqTestDevision()
        {
            PlResourcesDivisions = new HashSet<PlResourcesDivision>();
            RqRequestDetails = new HashSet<RqRequestDetail>();
        }

        public string Afkorting { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<PlResourcesDivision> PlResourcesDivisions { get; set; }
        public virtual ICollection<RqRequestDetail> RqRequestDetails { get; set; }
    }
}
