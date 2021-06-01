using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Serialization;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestingPlanner.Data;
using TestingPlanner.Domain.Models;
using TestingPlanner.Views;

namespace TestingPlanner.Viewmodels
{
    // TEMPORARY SCREEN
    // Proof of concept: loading list of JR's from database
    // TODO: datatemplate for JR's
    public class ViewmodelTemporarilyStartUp : ViewModelCollection
    {
        // Command declaration
        // RelayCommand<Class> takes object of type class as input
        public RelayCommand<Window> addNewRqCommand { get; set; }
        public RelayCommand<Window> showExistingRqCommand { get; set; }
        public ICommand openTesterStartupCommand { get; set; }
        public ICommand openPlannerStartupCommand { get; set; }
        public ICommand openEmployeeStartupCommand { get; set; }

        //Constructor
        public ViewmodelTemporarilyStartUp():base()
        {
            // Command initialization
            addNewRqCommand = new RelayCommand<Window>(OpenEmptyJR);
            showExistingRqCommand = new RelayCommand<Window>(OpenExistingJr);
            openTesterStartupCommand = new DelegateCommand(openTesterStartup);
            openPlannerStartupCommand = new DelegateCommand(openPlannerStartup);
            openEmployeeStartupCommand = new DelegateCommand(openEmployeeStartup);

            Load();
        }

        // Function used in code behind
        // Loads all JR IDs in LB
        public void Load()
        {
            var requestIds = _dao.GetAllJobRequests();
            idRequestsOnly.Clear();

            foreach (var requestId in requestIds)
            {
                idRequestsOnly.Add(requestId.IdRequest);
            }

            // first JR selected by default --> Selected JR can't be null
            this.SelectedJR = idRequestsOnly[0];
        }

        // Command functions
        public void OpenEmptyJR(Window window)
        {
            MainWindow requestformWindow = new MainWindow();
            requestformWindow.Show();
            window.Close();
        }

        public void OpenExistingJr(Window window)
        {
            // Passes selected JR ID to new RQF
            MainWindow requestformWindow = new MainWindow();
            requestformWindow.Show();
            window.Close();
        }

        // Kaat
        public void openTesterStartup()
        {
            Window testerStartup = new MainWindow();
            testerStartup.Show();
        }

        // Kaat
        public void openPlannerStartup()
        {
            Window plannerStartup = new MainWindow();
            plannerStartup.Show();
        }

        // Kaat
        public void openEmployeeStartup()
        {
            Window employeeStartup = new MainWindow();
            employeeStartup.Show();
        }
    }
}
