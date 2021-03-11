using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestingPlanner.Data;

namespace TestingPlanner.Viewmodels
{
    public class ViewmodelRequestform : ViewModelBase
    {
        // Jobrequest data container
        private JR _jr;

        public ICommand addJobRequestCommand { get; set; }

        // Data connection
        private DAO _dao;

        public ViewmodelRequestform(DAO dao)
        {
            this._dao = dao;

            addJobRequestCommand = new DelegateCommand(addJobRequest);

            // Testing
            // this._jr = new JR();
            this._jr = new JR
            {
                JrNumber = "TEST",
                Requester = "MV",
                HydraProjectnumber = "1234",
                EutProjectname = "SmortProject",
                EutPartnr = "420",
                NetWeight = "69kg",
                GrossWeight = "420kg"
            };

        }

        public JR JR
        {
            get { return _jr;}
            set
            {
                _jr = value;
                OnpropertyChanged();
            }
        }

        public void addJobRequest()
        {

        }
    }
}
