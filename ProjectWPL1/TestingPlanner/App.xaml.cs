using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestingPlanner.Data;

namespace TestingPlanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DAO _dao;

        public App()
        {
            _dao = DAO.Instance();
        }

        private void AppStart(object sender, StartupEventArgs e)
        {
            Window StartWindow;
            if (_dao.BarcoUser.Function == "TEST")
            {
                StartWindow = new Temp();
            }
            else
            {
                StartWindow = new RequestForm();
            }

            StartWindow.Show();
        }
    }
}
