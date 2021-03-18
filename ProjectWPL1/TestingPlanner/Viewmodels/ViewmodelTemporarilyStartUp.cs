using GalaSoft.MvvmLight.CommandWpf;
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
    public class ViewmodelTemporarilyStartUp : ViewModelBase
    {
        //public ICommand addNewRqCommand { get; set; }
        //public ICommand showExistingRqCommand { get; set; }
        public RelayCommand<Window> addNewRqCommand { get; set; }
        public RelayCommand<Window> showExistingRqCommand { get; set; }

        public ObservableCollection<int> idRequestsOnly { get; set; }

        private DAO _dao;
        private int _selectedJR;
        

        public ViewmodelTemporarilyStartUp(DAO dao)
        {
            this._dao = dao;

            addNewRqCommand = new RelayCommand<Window>(OpenEmptyJR);
            showExistingRqCommand = new RelayCommand<Window>(OpenExistingJr);

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

        // Functions
        public void OpenEmptyJR(Window window)
        {
            RequestForm requestformWindow = new RequestForm();
            requestformWindow.Show();
            window.Close();
        }

        public void OpenExistingJr(Window window)
        {
           

            RequestForm requestformWindow = new RequestForm(SelectedJR);

            requestformWindow.Show();


            window.Close(); 
           
        }

        public void Load()
        {
            var requestIds = _dao.GetAllJobRequests();
            idRequestsOnly.Clear();

            foreach (var requestId in requestIds)
            {
                idRequestsOnly.Add(requestId.IdRequest);
            }

            // This code ensures that we select the first job request by default 
            // This ensures that we cannot select an not existing job request
            this.SelectedJR = idRequestsOnly[0];
        }
    }
}
