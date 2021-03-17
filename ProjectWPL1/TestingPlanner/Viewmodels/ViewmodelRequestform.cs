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

        // Variable _selectedEUT to store the user selected EUT
        private EUT _selectedEUT;

        // EUT list
        // Does not necessarily need to be linked to JR? We can retrieve the JR ID and add it in DAO
        public ObservableCollection<EUT> EUTs { get; set; }


        // ICommand declaration
        public RelayCommand<Window> addJobRequestCommand { get; set; }
        public ICommand addEUTCommand { get; set; }
        public ICommand removeEUTCommand { get; set; }
        // We create an ICommand variable addJobRequestCommand

        public ObservableCollection<RqRequest> jrs { get; set; }

        // Data connection
        private DAO _dao;

        // Constructor for new JR
        public ViewmodelRequestForm(DAO dao)
        {
            this._jr = new JR();
            init(dao);

            // Testing
            EUTs.Add(new EUT
            {
                PartNr = "TEST",
                AvailabilityDate = new DateTime(2021, 03, 12),
                NetWeight = 1.8,
                GrossWeight = 2.3,
                EMC = true,
                REL = true
            });
            // Testing
        }

        // Constructor for existing JR
        public ViewmodelRequestForm(DAO dao, int idRequest)
        {
            
            this._jr = _dao.GetJRWithId(idRequest);
            init(dao);
        }

        // Code reused in both constructors
        private void init(DAO dao)
        {
            this._dao = dao;

            // Collection initialization
            EUTs = new ObservableCollection<EUT>();

            // ICommand initialization
            addJobRequestCommand = new RelayCommand<Window>(InsertJr);
            addEUTCommand = new DelegateCommand(addEUT);
            removeEUTCommand = new DelegateCommand(removeSelectedEUT);
        }

        // Getters/Setters
        public JR JR
        {
            get { return _jr; }
            set
            {
                _jr = value;
                OnpropertyChanged();
            }
        }

        // ICommand functions
        // This function adds a job request and stores this job request in the _dao instance
        public void InsertJr(Window window)
        {
            _dao.AddJobRequest(JR); // SaveChanges included in function
            Temp overviewWindow = new Temp();
            overviewWindow.Show();
            window.Close();
        }

        // This function adds an new EUT instance into the GUI RequestForm
        public void addEUT()
        {
            EUTs.Add(new EUT());
        }

        // This function is responsible to select the user selected eut in the GUI and stores this in the variable _selectedEUT
        // We will need this variable in the removeSelectedEUT function 
        public EUT SelectedEUT
        {
            get { return _selectedEUT; }
            set
            {
                _selectedEUT = value;
                OnpropertyChanged();
            }
        }

        // This function will delete the user selected EUT using the _selectedEut variable 
        // as stated in the previous function 
        public void removeSelectedEUT()
        {
            EUTs.Remove(SelectedEUT); 
        }
    }
}
