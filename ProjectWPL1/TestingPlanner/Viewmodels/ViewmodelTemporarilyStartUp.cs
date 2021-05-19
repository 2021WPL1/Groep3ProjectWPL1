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

namespace TestingPlanner.Viewmodels
{
    // TEMPORARY SCREEN
    // Proof of concept: loading list of JR's from database
    // TODO: datatemplate for JR's
    public class ViewmodelTemporarilyStartUp : ViewModelBase
    {
        // Dataconnection
        // Can be moved to parent class?
        private DAO _dao;

        // Jobrequest IDs
        public ObservableCollection<int> idRequestsOnly { get; set; }
        private int _selectedJR; // Will be passed to ctor RQF to open existing JR

        // Command declaration
        // RelayCommand<Class> takes object of type class as input
        public RelayCommand<Window> addNewRqCommand { get; set; }
        public RelayCommand<Window> showExistingRqCommand { get; set; }

        //Constructor
        public ViewmodelTemporarilyStartUp(DAO dao)
        {
            this._dao = dao;

            // Collection initialization
            idRequestsOnly = new ObservableCollection<int>(); 

            // Command initialization
            addNewRqCommand = new RelayCommand<Window>(OpenEmptyJR);
            showExistingRqCommand = new RelayCommand<Window>(OpenExistingJr);
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

        // Command functions
        public void OpenEmptyJR(Window window)
        {
            RequestForm requestformWindow = new RequestForm();
            requestformWindow.Show();
            window.Close();
        }

        public void OpenExistingJr(Window window)
        {
            // Passes selected JR ID to new RQF
            RequestForm requestformWindow = new RequestForm(SelectedJR);
            requestformWindow.Show();
            window.Close();
        }
    }
}
