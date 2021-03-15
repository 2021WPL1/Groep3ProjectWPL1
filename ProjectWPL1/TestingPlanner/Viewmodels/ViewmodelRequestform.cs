using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestingPlanner.Data;

namespace TestingPlanner.Viewmodels
{
    public class ViewmodelRequestform : ViewModelBase
    {
        // Jobrequest data container
        private JR _jr;

        // Variable _selectedEUT to store the user selected EUT
        private EUT _selectedEUT;

        // EUT list
        // Does not necessarily need to be linked to JR? We can retrieve the JR ID and add it in DAO
        public ObservableCollection<EUT> EUTs { get; set; }


        // ICommand declaration
        public ICommand addJobRequestCommand { get; set; }
        public ICommand addEUTCommand { get; set; }
        public ICommand removeEUTCommand { get; set; }
        

        // Data connection
        private DAO _dao;

        // viewModelRequestForm Constructor
        public ViewmodelRequestform(DAO dao)
        {
            this._dao = dao;

            // Collection initialization
            EUTs = new ObservableCollection<EUT>();

            // ICommand initialization
            addJobRequestCommand = new DelegateCommand(addJobRequest);
            addEUTCommand = new DelegateCommand(addEUT);
            removeEUTCommand = new DelegateCommand(removeSelectedEUT);

            // Testing
            // this._jr = new JR();
            this._jr = new JR
            {
                JrNumber = "TEST",
                Requester = "MV",
                HydraProjectnumber = "1234",
                EutProjectname = "SmortProject",
                EutPartnr = "420",
                NetWeight = "69kg",
                GrossWeight = "420kg"
            };

            EUTs.Add(new EUT
            {
                PartNr = "TEST",
                AvailabilityDate = new DateTime(2021, 03, 12),
                NetWeight = 1.8,
                GrossWeight = 2.3,
                EMC = true,
                REL = true
            });

        }

        // Getters/Setters
        public JR JR
        {
            get { return _jr;}
            set
            {
                _jr = value;
                OnpropertyChanged();
            }
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
            EUTs.Remove(_selectedEUT);
            
        }
        // ICommand functions
        public void addJobRequest()
        {

        }
    }
}
