using GalaSoft.MvvmLight.CommandWpf;
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
        public RelayCommand<Window> CloseWindowCommand { get; set; }

        public ViewmodelTemporarilyStartUp(DAO dao)
        {
            this._dao = dao;
            //addNewRqCommand = new DelegateCommand(OpenEmtpyRq);
           // showExistingRqCommand = new DelegateCommand(OpenExistingJr);
            idRequestsOnly = new ObservableCollection<int>();
            this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
        }

        public void CloseWindow(Window window)
        {
            if(window != null)
            {
                window.Close();
            }
        }

        /*public void OpenEmtpyRq(Window window)
        {
            CloseWindow(window);
        }

        /*public void OpenExistingJr()
        {
            CloseWindow();
            Load();
        }*/

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
