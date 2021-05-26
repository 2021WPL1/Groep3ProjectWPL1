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

        // ROYCODE
        // CallerMember: Decorator, attribute; 
        // geeft de naam van de eigenschap die de methode heeft aangeroepen
        //protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        //{
        //    if (object.Equals(member, val)) return;
        //    member = val;
        //    RaisePropertyChanged(propertyName);
        //}

        //protected virtual void RaisePropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        protected virtual void OnpropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        // End boilerplate code
    }
}
