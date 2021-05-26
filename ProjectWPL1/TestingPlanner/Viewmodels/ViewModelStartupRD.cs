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
    public class ViewModelStartupRD : ViewModelBase
    {
        // Jobrequest IDs
        public ObservableCollection<int> idRequestsOnly { get; set; }
        private int _selectedJR; // Will be passed to ctor RQF to open existing JR

        //Constructor
        public ViewModelStartupRD(DAO dao)
        {
            this._dao = dao;

            // Collection initialization
            idRequestsOnly = new ObservableCollection<int>();
        }

        // Getters/Setters
        public int SelectedJR
        {
            get => _selectedJR;
            set
            {
                _selectedJR = value;
                OnpropertyChanged();
            }
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
            this.SelectedJR = idRequestsOnly[0];
        }
    }
}
