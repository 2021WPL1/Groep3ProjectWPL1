using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TestingPlanner.Domain.Models;

namespace TestingPlanner.Viewmodels
{
    class ViewModelTesterPlan : ViewModelBase
    {
        public ObservableCollection<PlPlanning> PlansToApprove { get; set; }
        protected PlPlanning _selectedPlan;

        //Constructor
        public ViewModelTesterPlan() : base()
        {
            // Collection initialization
            PlansToApprove = new ObservableCollection<PlPlanning>();

            foreach (var item in _dao.GetPlPlannings())
            {
                PlansToApprove.Add(item);
            }

            // empty jr selected by default
            _selectedPlan = new PlPlanning();
        }

        // Getters/Setters
        public PlPlanning SelectedPlan
        {
            get => _selectedPlan;
            set
            {
                _selectedPlan = value;
                OnpropertyChanged();
            }
        }
    }
}
