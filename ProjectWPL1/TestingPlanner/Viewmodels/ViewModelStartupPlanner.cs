using System;
using System.Collections.Generic;
using System.Text;

namespace TestingPlanner.Viewmodels
{
    class ViewModelStartupPlanner: ViewModelCollectionRQ
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
            var requestIds = _dao.GetAllJobRequests();
            idRequestsOnly.Clear();

            foreach (var requestId in requestIds)
            {
                idRequestsOnly.Add(requestId);
            }

            // first JR selected by default --> Selected JR can't be null
            base.SelectedJR = idRequestsOnly[0];
        }
    }
}
