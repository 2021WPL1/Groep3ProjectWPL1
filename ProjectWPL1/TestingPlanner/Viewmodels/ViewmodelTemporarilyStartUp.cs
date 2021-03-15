using GalaSoft.MvvmLight.CommandWpf;
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

namespace TestingPlanner.Viewmodels
{
    public class ViewmodelTemporarilyStartUp : ViewModelBase
    {
        Window tempWindow = new Window(); //needed or runtime error for some reason
        public ICommand addNewRqCommand { get; set; }
        public ICommand showExistingRqCommand { get; set; }
        public ObservableCollection<int> idRequestsOnly { get; set; }

        private DAO _dao;
        

        public ViewmodelTemporarilyStartUp(DAO dao)
        {
            this._dao = dao;
            addNewRqCommand = new DelegateCommand(OpenEmptyRq);
            showExistingRqCommand = new DelegateCommand(OpenExistingJr);
            idRequestsOnly = new ObservableCollection<int>();
           
        }

        public void OpenEmptyRq()
        {
            OpenNewRq();
        }

        public void OpenExistingJr()
        {
            OpenSelectedJr();
        }

        public void OpenNewRq()
        {
            Temp temp = new Temp();
            CloseWindow(temp);
            OpenWindow();
        }

        public void OpenSelectedJr()
        {
            Temp temp = new Temp();
            CloseWindow(temp);
            OpenWindow();
            Load();
        }

        public void Load()
        {
            var requestIds = _dao.GetAllJobRequests();
            idRequestsOnly.Clear();
            foreach (var requestId in requestIds)
            {
                idRequestsOnly.Add(requestId.IdRequest);
            }
        }
        public void OpenWindow()
        {
            RequestForm requestformWindow = new RequestForm();
            requestformWindow.Show();
        }

        public void CloseWindow(Window window)
        {
            window.Close(); //window.close doesnt work (only this.close seems to work)
        }
    }
}
