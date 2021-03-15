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
    public class ViewmodelRequestform : ViewModelBase
    {
        // Jobrequest data container
        private JR _jr;


        public ICommand addJobRequestCommand { get; set; }
        public ObservableCollection<RqRequest> jrs { get; set; }

        // Data connection
        private DAO _dao;

        Window temp;

        public ViewmodelRequestform(DAO dao)
        {
            this._dao = dao;
            addJobRequestCommand = new DelegateCommand(InsertJr);
            jrs = new ObservableCollection<RqRequest>();
            this._jr = new JR();
        }

        public JR JR
        {
            get { return _jr; }
            set
            {
                    _jr = value;
                OnpropertyChanged();
            }
        }

        public void InsertJr()
        {
            _dao.AddJobRequest(JR);
        }

        public void ShowJr()
        {
            foreach (RqRequest jr in _dao.GetAllJobRequests())
            {
                //JR.EutPartnr= jr.EutProjectname.ToString();
               // lst.Items.Add(jr.EutProjectname);
            }
        }
   
        public void UpdateJr()
        {

            _dao.SaveChanges();
        }
  
    }
}
