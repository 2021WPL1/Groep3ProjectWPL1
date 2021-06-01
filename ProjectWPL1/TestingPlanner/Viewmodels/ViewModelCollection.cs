using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestingPlanner.Viewmodels
{
    public abstract class ViewModelCollection : ViewModelBase
    {
        public ObservableCollection<int> idRequestsOnly { get; set; }
        protected int _selectedJR;

        //Constructor
        public ViewModelCollection()
        {
            // Collection initialization
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
    }
}
