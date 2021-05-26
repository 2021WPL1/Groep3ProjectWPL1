using Microsoft.Toolkit.Mvvm.Input;
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
using TestingPlanner.Views;

namespace TestingPlanner.Viewmodels
{
    public class ViewmodelRequestForm : ViewModelContainer
    {
        // Combobox contents
        public ObservableCollection<string> JobNatures { get; set; }
        public ObservableCollection<string> Divisions { get; set; }

        // Command declaration
        // RelayCommand<Class> takes object of type class as input
        public RelayCommand<Window> addJobRequestCommand { get; set; }
        public RelayCommand<Window> cancelCommand { get; set; }
        // ICommand does not take pinput
        public ICommand addEUTCommand { get; set; }
        public ICommand removeEUTCommand { get; set; }
        public ICommand refreshJRCommand { get; set; }
        public ICommand addMockEUTCommand { get; set; }

        // Constructor for new JR
        public ViewmodelRequestForm() : base()
        {
            init();
            Load();

            // JR = new JR
            refreshJR();
        }

        // Constructor for existing JR
        public ViewmodelRequestForm(int idRequest) : base()
        {
            init();
            Load();

            // Look for JR with correct ID
            this._jr = _dao.GetJRWithId(idRequest);
        }

        // Code reused in both constructors
        private void init()
        {
            // Collection initialization
            JobNatures = new ObservableCollection<string>();
            Divisions = new ObservableCollection<string>();

            // Command initialization
            refreshJRCommand = new DelegateCommand(refreshJR);
            addEUTCommand = new DelegateCommand(addEUT);
            removeEUTCommand = new DelegateCommand(removeSelectedEUT);
            addMockEUTCommand = new DelegateCommand(addMockEUT);
        }

        // Loads jobNatures, divisions in cbb
        public void Load()
        {
            var jobNatures = _dao.GetAllJobNatures();
            var divisions = _dao.GetAllDivisions();
            JobNatures.Clear();
            Divisions.Clear();

            foreach (var jobNature in jobNatures)
            {
                JobNatures.Add(jobNature.Nature);
            }

            foreach (var division in divisions)
            {
                Divisions.Add(division.Afkorting);
            }
        }

        // This function adds an new EUT instance into the GUI RequestForm
        // EUT in Database
        public void addEUT()
        {
            EUTs.Add(new EUT());
        }

        // Clear all data in JR
        private void refreshJR()
        {
            this.JR = _dao.GetNewJR();
            EUTs.Clear();
        }

        // deletes selected EUT via _selectedEut variable
        public void removeSelectedEUT()
        {
            EUTs.Remove(SelectedEUT); 
        }

        // Temporary function to demo loading EUT datatemplate
        public void addMockEUT()
        {
            EUTs.Add(new EUT
            {
                PartNr = "TEST",
                AvailabilityDate = new DateTime(2021, 03, 12),
                NetWeight = "1.8",
                GrossWeight = "2.3",
                EMC = true,
                REL = true
            });
        }
    }
}
