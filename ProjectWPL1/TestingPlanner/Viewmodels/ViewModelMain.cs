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

        public DelegateCommand DisplayNewJRCommand { get; set; }
       
        public ViewModelMain()
        {
            this.ViewModel = new ViewmodelTemporarilyStartUp();
            this.User = _dao.BarcoUser;

            DisplayNewJRCommand = new DelegateCommand(DisplayView);
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

        public void DisplayView()
        {
            this.ViewModel = new ViewmodelRequestForm();
        }
    }
}
