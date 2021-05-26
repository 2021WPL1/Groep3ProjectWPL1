using Microsoft.Toolkit.Mvvm.Input;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class ViewmodelRequestForm : ViewModelBase
    {
       
        // Dataconnection
        // Can be moved to parent class?
        private DAO _dao;

        Barco2021Context context = new Barco2021Context();

        // Jobrequest data container
        // Only one getter/setter needs to be made for all changes in GUI
        private JR _jr;
        private EUT _eut;

        // EUT's
        // Does not necessarily need to be linked to JR? We can retrieve the JR ID and add it in DAO
        public ObservableCollection<EUT> EUTs { get; set; }
        private EUT _selectedEUT;

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
        public ViewmodelRequestForm(DAO dao)
        {
            init(dao);

            // JR = new JR
            refreshJR();

            // addJRCommand calls function to insert new JR
            addJobRequestCommand = new RelayCommand<Window>(InsertJr);


        }

        // Constructor for existing JR
        public ViewmodelRequestForm(DAO dao, int idRequest)
        {
            init(dao);

            // Look for JR with correct ID
            this._jr = _dao.GetJRWithId(idRequest);

            
            List<RqRequestDetail> eutList = _dao.rqDetail(idRequest);

            // We use a foreach to loop over every item in the eutList
            // And link the user inputed data to the correct variables
            foreach (var id in eutList)
            {
                Barco2021Context context = new Barco2021Context();
                var request = context.RqRequest.FirstOrDefault(e => e.IdRequest == id.IdRequest);
                JR jr = new JR
                {
                    IdRequest = request.IdRequest,
                    GrossWeight = request.GrossWeight,
                    NetWeight = request.NetWeight
                };

                // The following line uses the the requestDetail id to get the linked eut objects.
                int requestdetailId = id.IdRqDetail;
                FillEUT(idRequest,jr);
            }

            // addJRCommand calls function to save existing JR
            addJobRequestCommand = new RelayCommand<Window>(UpdateJr);
        }

        // Code reused in both constructors
        private void init(DAO dao)
        {
            this._dao = dao;

            // Collection initialization
            EUTs = new ObservableCollection<EUT>();
            JobNatures = new ObservableCollection<string>();
            Divisions = new ObservableCollection<string>();

            // Command initialization
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
        public EUT eut
        {
            get { return _eut; }
            set
            {
                _eut = value;
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

        /// <summary>
        /// Function used in code behind
        /// Loads jobNatures, divisions in cbb
        /// </summary>
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
        /// Command functions
        /// Adds and stores a job request and switches windows
        /// </summary>
        /// <param name="window"></param>
        public void InsertJr(Window window)
        {
         
            var jr =_dao.AddJobRequest(JR); // SaveChanges included in function

            // We declare a local variable to count the number of created EUTs
            int count = 0;

            // We use a foreach to loop over EUT object in the ObservableCollection EUTs
            foreach (var thisEUT in EUTs)
            {
                
                count++;
                _dao.AddEutToRqRequest(jr, thisEUT,count.ToString());
            }
            // Here we call the SaveChanges method, so that we can link several EUTs to one JR
            _dao.SaveChanges();
            ChangeWindows(window);          
        }

        /// <summary>
        /// Updates existing job request and switches windows
        /// </summary>
        /// <param name="window"></param>
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

        /// <summary>
        /// Adds and stores job request in DB via _dao instance
        /// </summary>
        /// <param name="window"></param>
        private void ChangeWindows(Window window)
        {
            Temp overviewWindow = new Temp();
            overviewWindow.Show();
            window.Close();
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
        public void FillEUT(int id,JR jr)
        { 

         Eut details = context.Euts.FirstOrDefault(e => e.IdRqDetail == id);
         List<Eut> eutss = context.Euts.Where(e => e.IdRqDetailNavigation.IdRequest == id).ToList();
         List<string> count = new List<string>();
         foreach (var eut in eutss)
         {
             
             if(count.Contains(eut.OmschrijvingEut) == false)
             {
                 count.Add(eut.OmschrijvingEut);
                 EUT EUTss = new EUT
                 {
                     IdRqDetail = details.IdRqDetail,
                     OmschrijvingEut = details.OmschrijvingEut,
                     PartNr = jr.EutPartnr,
                     GrossWeight = jr.GrossWeight,
                     NetWeight = jr.NetWeight
                 };
                 EUTs.Add(EUTss);
             }
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
