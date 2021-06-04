using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingPlanner.Viewmodels
{
    class ViewModelStartupPlanner: AbstractViewModelCollectionRQ
    {
        //Constructor
        public ViewModelStartupPlanner() : base()
        {
            Load();
        }

        // Function used in code behind
        // Loads all JR IDs in LB
        public void Load()
        {
            // Get unapproved JR's
            var requestIds = _dao.GetAllJobRequests().Where(rq => rq.JrStatus == "To approve");
            idRequestsOnly.Clear();

            foreach (var requestId in requestIds)
            {
                idRequestsOnly.Add(requestId);
            }
        }
    }
}
