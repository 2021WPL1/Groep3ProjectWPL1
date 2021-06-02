using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TestingPlanner.Domain.Models;

namespace TestingPlanner.Viewmodels
{
    class ViewModelTestForm : ViewModelBase
    {
        // Listbox with equipment
        public ObservableCollection<PlResources> Resources { get; set; }

        // Plan for these tests
        public PlPlanning SelectedPlan { get; set; }

        public ObservableCollection<PlPlanningsKalender> Tests { get; set; }
        private PlPlanningsKalender selectedTest;

        public ICommand AddNewTestCommand { get; set; }

        public ViewModelTestForm(PlPlanning planning)
        {
            SelectedPlan = planning;

            Resources = new ObservableCollection<PlResources>();
            Tests = new ObservableCollection<PlPlanningsKalender>();

            foreach (var item in _dao.GetResources(planning.TestDiv))
            {
                Resources.Add(item);
            }

            AddNewTestCommand = new DelegateCommand(AddTest);

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

        public void AddTest()
        {
            Tests.Add(new PlPlanningsKalender());
        }

    }
}
