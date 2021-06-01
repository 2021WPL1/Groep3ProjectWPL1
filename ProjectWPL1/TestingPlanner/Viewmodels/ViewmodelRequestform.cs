using Microsoft.Toolkit.Mvvm.Input;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
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


            List<RqRequestDetail> eutList = _dao.rqDetail(idRequest);
            // We use a foreach to loop over every item in the eutList
            // And link the user inputed data to the correct variables
            var request = new RqRequest();
            foreach (var id in eutList)
            {
                request = context.RqRequest.FirstOrDefault(e => e.IdRequest == id.IdRequest);
               
            }
            FillEUT(request);
            // addJRCommand calls function to save existing JR
            addJobRequestCommand = new RelayCommand<Window>(UpdateJr);
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

        /// <summary>
        /// This function adds an new EUT instance into the GUI RequestForm
        /// EUT in Database
        /// </summary>
        public void addEUT()
        {
            EUTs.Add(new EUT());
        }

        /// <summary>
        /// This function ensures that the existing data of an eut is read from the database and loaded into the requestForm xaml
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jr"></param>
        public void FillEUT( RqRequest rq)
        {
            foreach (var objecten in _dao.GetEut(rq))
            {
                EUTs.Add(objecten);
            }
        }


        /// <summary>
        /// Clear all data in JR
        /// </summary>
        private void refreshJR()
        {
            this.JR = _dao.GetNewJR();
            EUTs.Clear();
        }

        /// <summary>
        /// deletes selected EUT via _selectedEut variable
        /// </summary>
        public void removeSelectedEUT()
        {
            EUTs.Remove(SelectedEUT);
        }

        /// <summary>
        /// Temporary function to demo loading EUT datatemplate
        /// </summary>
        public void addMockEUT()
        {
            EUTs.Add(new EUT
            {
                AvailabilityDate = new DateTime(2021, 03, 12),
                EMC = true,
                REL = true
            });
        }
    }
}
