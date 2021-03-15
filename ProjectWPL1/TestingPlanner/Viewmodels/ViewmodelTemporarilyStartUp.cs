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
        public ICommand addNewRqCommand { get; set; }
        public ICommand showExistingRqCommand { get; set; }
        public ObservableCollection<int> idRequestsOnly { get; set; }

        private DAO _dao;
        

        public ViewmodelTemporarilyStartUp(DAO dao)
        {
            this._dao = dao;
            addNewRqCommand = new DelegateCommand(OpenEmtpyRq);
            showExistingRqCommand = new DelegateCommand(OpenExistingJr);
            idRequestsOnly = new ObservableCollection<int>();


        }

        public void OpenEmtpyRq()
        {
            ChangeWindow();
        }

        public void OpenExistingJr()
        {
            ChangeWindow();
            Load();
        }

        public void ChangeWindow()
        {
            Temp tempView = new Temp();
            RequestForm requestformView = new RequestForm();
            requestformView.Show();
            tempView.Close();
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
    }
}
