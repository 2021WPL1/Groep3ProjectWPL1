using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestingPlanner.Data;
using TestingPlanner.Domain.Models;

namespace TestingPlanner.Viewmodels
{
    public class ViewmodelRequestForm : ViewModelBase
    {
        // Jobrequest data container
        private JR _jr;

        // We create an ICommand variable addJobRequestCommand
        public RelayCommand<Window> addJobRequestCommand { get; set; }
        public ObservableCollection<RqRequest> jrs { get; set; }

        // Data connection
        private DAO _dao;

        // VieuwModelRequestForm Constructor
        public ViewmodelRequestForm(DAO dao)
        {
            this._dao = dao;
            addJobRequestCommand = new RelayCommand<Window>(InsertJr);
            jrs = new ObservableCollection<RqRequest>();
            this._jr = new JR();
        }

        // Getter and setter for JR
        public JR JR
        {
            get { return _jr; }
            set
            {
                _jr = value;
                OnpropertyChanged();
            }
        }

        // This function adds a job request and stores this job request in the _dao instance
        public void InsertJr(Window window)
        {
            _dao.AddJobRequest(JR); // SaveChanges included in function

            Temp overviewWindow = new Temp();
            overviewWindow.Show();
            window.Close();
        }
    }
}
