using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestingPlanner.Domain.Models;

namespace TestingPlanner.Viewmodels
{
    class ViewModelTestForm : ViewModelBase
    {
        // Listbox with equipment
        public ObservableCollection<string> Resources { get; set; }

        public ObservableCollection<PlPlanning> Tests { get; set; }

        private PlPlanningsKalender selectedTest;

        public ViewModelTestForm()
        {
            // Initialize Resources
            // Initialize Tests
        }


        public PlPlanningsKalender SelectedTest
        {
            get => selectedTest;
            set
            {
                selectedTest = value;
                OnpropertyChanged();
            }
        }


    }
}
