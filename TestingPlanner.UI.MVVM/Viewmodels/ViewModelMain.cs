using Microsoft.Toolkit.Mvvm.Input;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestingPlanner.Classes;

namespace TestingPlanner.Viewmodels
{
    // Kaat
    class ViewModelMain : ViewModelBase
    {
        private ViewModelBase _viewModel;
        public BarcoUser User { get; set; }

        // TODO: check if ICommand also works
        public DelegateCommand DisplayNewJRCommand { get; set; }
        public DelegateCommand DisplayExistingJRCommand { get; set; }
        public DelegateCommand DisplayEmployeeStartupCommand { get; set; }
        public DelegateCommand DisplayPlannerStartupCommand { get; set; }
        public DelegateCommand DisplayTesterPlanCommand { get; set; }
        public DelegateCommand DisplayTesterTestCommand { get; set; }
        public DelegateCommand DisplayDevStartupCommand { get; set; }
        public DelegateCommand SaveJrCommand { get; set; }
        public DelegateCommand ApproveJRCommand { get; set; }
        public DelegateCommand DisplayTestPlanningCommand { get; set; }
        public DelegateCommand SaveTestsAndReturnCommand { get; set; }
        public DelegateCommand ApprovePlanAndReturnCommand { get; set; }
        public DelegateCommand TesterReturnCommand { get; set; }

        // Visibility of buttons
        public Visibility NewRequests { get; set; }
        public Visibility ApproveRequests { get; set; }
        public Visibility Test { get; set; }
        public Visibility SeeAll { get; set; }
       
        public ViewModelMain()
        {
            this.User = _dao.BarcoUser;

            DisplayNewJRCommand = new DelegateCommand(DisplayNewJR);
            DisplayExistingJRCommand = new DelegateCommand(DisplayExistingJR);
            DisplayEmployeeStartupCommand = new DelegateCommand(DisplayEmployeeStartup);
            DisplayPlannerStartupCommand = new DelegateCommand(DisplayPlannerStartup);
            DisplayTesterPlanCommand = new DelegateCommand(DisplayTesterPlan);
            DisplayTesterTestCommand = new DelegateCommand(DisplayTesterTest);
            DisplayDevStartupCommand = new DelegateCommand(DisplayDevStartup);
            ApproveJRCommand = new DelegateCommand(ApproveJR);
            DisplayTestPlanningCommand = new DelegateCommand(DisplayTestPlanning);
            SaveTestsAndReturnCommand = new DelegateCommand(SaveTestsAndReturn);
            ApprovePlanAndReturnCommand = new DelegateCommand(ApprovePlanAndReturn);
            TesterReturnCommand = new DelegateCommand(TesterReturn);

            SetWindowProperties();

        }

        // Getters/Setters
        public ViewModelBase ViewModel 
        { 
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnpropertyChanged();
            }
        }

        // Command methods
        // TODO: add method to switch return window based on function
        public void DisplayNewJR()
        {
            SaveJrCommand = new DelegateCommand(InsertJr);
            this.ViewModel = new ViewModelRequestformRD();
        }

        public void DisplayNewInternalJR()
        {
            SaveJrCommand = new DelegateCommand(InsertInternalJr);
            this.ViewModel = new ViewModelRequestformRD(true);
        }

        public void DisplayExistingJR()
        {
            SaveJrCommand = new DelegateCommand(UpdateJr);

            var ExistingJrId = ((ViewModelCollectionRQ)this.ViewModel).SelectedJR.IdRequest;

            if (this.ViewModel is ViewModelStartupPlanner)
            {
                 this.ViewModel = new ViewModelRequestFormPlan(ExistingJrId);
            }
            else
            {
                this.ViewModel = new ViewModelRequestformRD(ExistingJrId);
            }
        }

        public void DisplayEmployeeStartup()
        {
            this.ViewModel = new ViewModelStartupRD();
        }

        public void DisplayPlannerStartup()
        {
            this.ViewModel = new ViewModelStartupPlanner();
        }
        public void DisplayTesterPlan()
        {
            this.ViewModel = new ViewModelTesterPlan();
        }

        public void DisplayTesterTest()
        {
            this.ViewModel = new ViewModelTesterTest();
        }

        public void DisplayDevStartup()
        {
            this.ViewModel = new ViewmodelTemporarilyStartUp();
        }

        // JR CRUD
        // Command functions
        // Adds and stores a job request and switches windows
        public void InsertJr()
        {
            var jr = _dao.AddJobRequest(((ViewModelContainer)this.ViewModel).JR); // SaveChanges included in function
            int count = 0;

            foreach (var thisEUT in ((ViewModelContainer)this.ViewModel).EUTs)
            {
                count++;
                _dao.AddEutToRqRequest(jr, thisEUT, count.ToString());
            }

            // Here we call the SaveChanges method, so that we can link several EUTs to one JR
            _dao.SaveChanges();
            DisplayDevStartup();
        }

        // Change so no JR and no 
        public void InsertInternalJr()
        {
            var jr = _dao.AddJobRequest(((ViewModelContainer)this.ViewModel).JR); // SaveChanges included in function

            jr.JrStatus = "In Plan";
            
            int count = 0;
            foreach (var thisEUT in ((ViewModelContainer)this.ViewModel).EUTs)
            {
                count++;
                _dao.AddEutToRqRequest(jr, thisEUT, count.ToString());
            }

            // Here we call the SaveChanges method, so that we can link several EUTs to one JR
            _dao.SaveChanges();

            _dao.ApproveInternalRequest(jr.IdRequest);

            DisplayDevStartup();
        }

        // Updates existing job request and switches windows
        public void UpdateJr()
        {
            string error = _dao.UpdateJobRequest(((ViewModelContainer)this.ViewModel).JR); // SaveChanges included in function

            if (error == null)
            {
                DisplayDevStartup();
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        // Switch screen for planner
        // Kaat
        public void ApproveJR()
        {
            int jrId = ((ViewModelContainer)this.ViewModel).JR.IdRequest;

            _dao.ApproveRequest(jrId);

            this.ViewModel = new ViewModelStartupPlanner();
        }

        // Switch to test planning for tester
        public void DisplayTestPlanning()
        {
            // get id from JR
            var plan = ((ViewModelTesterPlan)this.ViewModel).SelectedPlan;

            this.ViewModel = new ViewModelTestForm(plan);
        }

        public void SaveTestsAndReturn()
        {
            ((ViewModelTestForm)this.ViewModel).SaveTests();
            this.ViewModel = new ViewModelTesterPlan();
        }

        public void ApprovePlanAndReturn()
        {
            var isSaved = ((ViewModelTestForm)this.ViewModel).ApprovePlan();

            if (isSaved)
            {
                this.ViewModel = new ViewModelTesterPlan();
            }
        }

        public void TesterReturn()
        {
            _dao.RemoveChanges();
            this.ViewModel = new ViewModelTesterPlan();
        }

        private void SetWindowProperties()
        {
            switch (_dao.BarcoUser.Function)
            {
                case "DEV":
                    NewRequests = Visibility.Visible;
                    ApproveRequests = Visibility.Visible;
                    Test = Visibility.Visible;
                    SeeAll = Visibility.Visible;

                    this.ViewModel = new ViewmodelTemporarilyStartUp();

                    break;
                case "TEST":
                    NewRequests = Visibility.Visible;
                    ApproveRequests = Visibility.Hidden;
                    Test = Visibility.Visible;
                    SeeAll = Visibility.Hidden;

                    DisplayNewJRCommand = new DelegateCommand(DisplayNewInternalJR);

                    this.ViewModel = new ViewModelTesterPlan();

                    break;
                case "PLAN":
                    NewRequests = Visibility.Hidden;
                    ApproveRequests = Visibility.Visible;
                    Test = Visibility.Hidden;
                    SeeAll = Visibility.Hidden;

                    this.ViewModel = new ViewModelStartupPlanner();

                    break;
                default:
                    NewRequests = Visibility.Visible;
                    ApproveRequests = Visibility.Hidden;
                    Test = Visibility.Hidden;
                    SeeAll = Visibility.Hidden;

                    this.ViewModel = new ViewModelStartupRD();

                    break;
            }
        }

    }
}
