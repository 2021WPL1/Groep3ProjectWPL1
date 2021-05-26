using Microsoft.Toolkit.Mvvm.Input;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void DisplayNewJR()
        {
            this.ViewModel = new ViewmodelRequestForm();
        }

        public void DisplayExistingJR()
        {
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
    }
}
