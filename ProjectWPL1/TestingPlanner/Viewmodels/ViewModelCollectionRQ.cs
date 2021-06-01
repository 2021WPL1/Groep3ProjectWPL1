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
        public ViewModelCollectionRQ()
        {
            // Collection initialization
            idRequestsOnly = new ObservableCollection<RqRequest>();
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
