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

        //Constructor
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

        public void addEUT()
        {
            EUTs.Add(new EUT());
        }
       
        public EUT SelectedEUT
        {
            get { return _selectedEUT; }
            set
            {
                _selectedEUT = value;
                OnpropertyChanged();
            }
        }

        public void removeSelectedEUT()
        {
            EUTs.Remove(_selectedEUT);
            //this.EUTs.Remove(SelectedItem);

            //EUTs.Remove(SelectedItem);
            /*if (EUTs.Count > 0)
            {
                EUTs.RemoveAt(EUTs.Count - 1);
            }*/
        }
        // ICommand functions
        public void addJobRequest()
        {

        }
    }
}
