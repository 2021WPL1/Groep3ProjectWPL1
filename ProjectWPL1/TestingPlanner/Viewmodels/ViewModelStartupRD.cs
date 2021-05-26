using Microsoft.Toolkit.Mvvm.Input;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestingPlanner.Data;

namespace TestingPlanner.Viewmodels
{
    public class ViewModelStartupRD : ViewModelCollection
    {
        //Constructor
        public ViewModelStartupRD() : base()
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
                idRequestsOnly.Add(requestId.IdRequest);
            }

            // first JR selected by default --> Selected JR can't be null
            base.SelectedJR = idRequestsOnly[0];
        }
    }
}
