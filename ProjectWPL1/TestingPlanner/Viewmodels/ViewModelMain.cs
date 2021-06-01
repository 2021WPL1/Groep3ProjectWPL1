using Microsoft.Toolkit.Mvvm.Input;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestingPlanner.Classes;

namespace TestingPlanner.Viewmodels
{
    // Kaat
    class ViewModelMain : ViewModelBase
    {
        private ViewModelBase _viewModel;
        public BarcoUser User { get; set; }

        // TODO: check if ICommand also works
        public DelegateCommand DisplayNewJRCommand { get; set; }
        public DelegateCommand DisplayExistingJRCommand { get; set; }
        public DelegateCommand DisplayEmployeeStartupCommand { get; set; }
        public DelegateCommand DisplayPlannerStartupCommand { get; set; }
        public DelegateCommand DisplayTesterStartupCommand { get; set; }
        public DelegateCommand DisplayDevStartupCommand { get; set; }
        public DelegateCommand SaveJrCommand { get; set; }
       
        public ViewModelMain()
        {
            this.ViewModel = new ViewmodelTemporarilyStartUp();
            this.User = _dao.BarcoUser;

            DisplayNewJRCommand = new DelegateCommand(DisplayNewJR);
            DisplayExistingJRCommand = new DelegateCommand(DisplayExistingJR);
            DisplayEmployeeStartupCommand = new DelegateCommand(DisplayEmployeeStartup);
            DisplayPlannerStartupCommand = new DelegateCommand(DisplayPlannerStartup);
            DisplayTesterStartupCommand = new DelegateCommand(DisplayTesterStartup);
            DisplayDevStartupCommand = new DelegateCommand(DisplayDevStartup);

        }

        // Getters/Setters
        public ViewModelBase ViewModel 
        { 
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnpropertyChanged();
            }
        }

        // Command methods
        // TODO: add method to switch return window based on function
        public void DisplayNewJR()
        {
            SaveJrCommand = new DelegateCommand(InsertJr);
            this.ViewModel = new ViewmodelRequestForm();
        }

        public void DisplayExistingJR()
        {
            SaveJrCommand = new DelegateCommand(UpdateJr);
            this.ViewModel = new ViewmodelRequestForm(((ViewModelCollection)this.ViewModel).SelectedJR);
        }

        public void DisplayEmployeeStartup()
        {
            this.ViewModel = new ViewModelStartupRD();
        }

        public void DisplayPlannerStartup()
        {
            this.ViewModel = new ViewModelStartupPlanner();
        }
        public void DisplayTesterStartup()
        {
            this.ViewModel = new ViewModelStartupTester();
        }

        public void DisplayDevStartup()
        {
            this.ViewModel = new ViewmodelTemporarilyStartUp();
        }

        // JR CRUD
        // Command functions
        // Adds and stores a job request and switches windows
        public void InsertJr()
        {
            var jr = _dao.AddJobRequest(((ViewModelContainer)this.ViewModel).JR); // SaveChanges included in function
            int count = 0;
            foreach (var thisEUT in ((ViewModelContainer)this.ViewModel).EUTs)
            {
                count++;
                _dao.AddEutToRqRequest(jr, thisEUT, count.ToString());
            }
            // Here we call the SaveChanges method, so that we can link several EUTs to one JR
            _dao.SaveChanges();
            DisplayDevStartup();
        }

        // Updates existing job request and switches windows
        public void UpdateJr()
        {
            string error = _dao.UpdateJobRequest(((ViewModelContainer)this.ViewModel).JR); // SaveChanges included in function

            if (error == null)
            {
                DisplayDevStartup();
            }
            else
            {
                MessageBox.Show(error);
            }
        }
    }
}
