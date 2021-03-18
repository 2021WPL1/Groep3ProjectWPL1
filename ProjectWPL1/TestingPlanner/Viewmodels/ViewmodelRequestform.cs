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


        // Command declaration
        public RelayCommand<Window> addJobRequestCommand { get; set; }
        public RelayCommand<Window> cancelCommand { get; set; }
        public ICommand addEUTCommand { get; set; }
        public ICommand removeEUTCommand { get; set; }
        public ICommand refreshJRCommand { get; set; }
        public ICommand addMockEUTCommand { get; set; }

        public ObservableCollection<RqRequest> jrs { get; set; }

        // Data connection
        private DAO _dao;

        // Constructor for new JR
        public ViewmodelRequestForm(DAO dao)
        {
            init(dao);
            refreshJR();

            // addJRCommand calls function to insert new JR
            addJobRequestCommand = new RelayCommand<Window>(InsertJr);
        }

        // Constructor for existing JR
        public ViewmodelRequestForm(DAO dao, int idRequest)
        {
            init(dao);
            this._jr = _dao.GetJRWithId(idRequest);

            // addJRCommand calls function to save existing JR
            addJobRequestCommand = new RelayCommand<Window>(UpdateJr);
        }

        // Code reused in both constructors
        private void init(DAO dao)
        {
            this._dao = dao;

            // Collection initialization
            EUTs = new ObservableCollection<EUT>();

            // ICommand initialization
            cancelCommand = new RelayCommand<Window>(ChangeWindows);
            refreshJRCommand = new DelegateCommand(refreshJR);
            addEUTCommand = new DelegateCommand(addEUT);
            removeEUTCommand = new DelegateCommand(removeSelectedEUT);
            addMockEUTCommand = new DelegateCommand(addMockEUT);
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

        public EUT SelectedEUT
        {
            get { return _selectedEUT; }
            set
            {
                _selectedEUT = value;
                OnpropertyChanged();
            }
        }

        // Command functions
        // This function adds and stores a job request and switches windows
        public void InsertJr(Window window)
        {
            string message = "The required fields are empty, please fill in all required fields";
           try
           {
                _dao.AddJobRequest(JR); // SaveChanges included in function
                ChangeWindows(window); 
            }
            catch (Exception ex)
            {

               MessageBox.Show(message);
            }
        }

        // This function updates an existing job request and switches windows
        public void UpdateJr(Window window)
        {
            string error = _dao.UpdateJobRequest(JR); // SaveChanges included in function

            if (error == null)
            {
                ChangeWindows(window);
            }
            else
            {
                MessageBox.Show(error);
            }
            
        }

        // This function adds a job request and stores this job request in the _dao instance
        private void ChangeWindows(Window window)
        {
            Temp overviewWindow = new Temp();
            overviewWindow.Show();
            window.Close();
        }

        private void refreshJR()
        {
            this.JR = new JR();
            EUTs.Clear();
        }

        // This function adds an new EUT instance into the GUI RequestForm
        public void addEUT()
        {
            EUTs.Add(new EUT());
        }

        // This function will delete the user selected EUT using the _selectedEut variable 
        // as stated in the previous function 
        public void removeSelectedEUT()
        {
            EUTs.Remove(SelectedEUT); 
        }

        // Temporary function to demo datatemplate
        public void addMockEUT()
        {
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
    }
}
