using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace TestingPlanner.Viewmodels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnpropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        
        /*public RelayCommand<Window> CloseWindowCommand { get; set; }

        public ViewModelBase()
        {
            this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
        }
        
        public void CloseWindow(Window window)
        {
            if (window!= null)
            {
                window.Close();
            }
        }
        */
    }
}
