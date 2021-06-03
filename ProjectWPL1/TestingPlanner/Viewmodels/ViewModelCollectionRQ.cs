using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestingPlanner.Domain.Models;

namespace TestingPlanner.Viewmodels
{
    public abstract class ViewModelCollectionRQ : ViewModelBase
    {
        public ObservableCollection<RqRequest> idRequestsOnly { get; set; }
        protected RqRequest _selectedJR;

        //Constructor
        public ViewModelCollectionRQ() : base()
        {
            // Collection initialization
            idRequestsOnly = new ObservableCollection<RqRequest>();

            // empty jr selected by default
            _selectedJR = new RqRequest();
        }

        // Getters/Setters
        public RqRequest SelectedJR
        {
            get => _selectedJR;
            set
            {
                _selectedJR = value;
                OnpropertyChanged();
            }
        }
    }
}
