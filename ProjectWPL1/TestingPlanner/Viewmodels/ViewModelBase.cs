using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using TestingPlanner.Data;

namespace TestingPlanner.Viewmodels
{
    // TODO: move window change to parent class
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected DAO _dao = DAO.Instance();

        // Constructor
        public ViewModelBase()
        {
            
        }

        // Implement propertyChanged
        // Start boilerplate code
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnpropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        // End boilerplate code
    }
}
