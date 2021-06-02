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
        public ObservableCollection<PlResources> Resources { get; set; }

        public ObservableCollection<PlPlanning> Tests { get; set; }
        public PlPlanning SelectedPlan;

        private PlPlanningsKalender selectedTest;


        public ViewModelTestForm(PlPlanning planning)
        {
            Resources = new ObservableCollection<PlResources>();

            foreach (var item in _dao.GetResources(planning.TestDiv))
            {
                Resources.Add(item);
            }
            // Initialize Resources
            // Initialize Tests

            SelectedPlan = planning;
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
