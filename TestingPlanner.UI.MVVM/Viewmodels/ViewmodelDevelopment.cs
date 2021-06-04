using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Serialization;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestingPlanner.Data;
using TestingPlanner.Domain.Models;
using TestingPlanner.Views;

namespace TestingPlanner.Viewmodels
{
    // TEMPORARY SCREEN
    // Proof of concept: loading list of JR's from database
    // TODO: datatemplate for JR's
    public class ViewmodelDevelopment : AbstractViewModelCollectionRQ
    {
        //Constructor
        public ViewmodelDevelopment():base()
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
        }
    }
}
