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
    /// Kaat
    /// </summary>
    public partial class App : Application
    {
        private DAO _dao;

        public App()
        {
            _dao = DAO.Instance();
        }

        /// <summary>
        /// Selects which window to open based on the user function in the registry
        /// Kaat
        /// </summary>
        private void AppStart(object sender, StartupEventArgs e)
        {
            Window StartWindow;

            switch (_dao.BarcoUser.Function)
            {
                case "TEST":
                    StartWindow = new Temp(); // To do: tester start screen
                    break;
                case "PLAN":
                    StartWindow = new Temp(); // To do: Planner start screen
                    break;
                default:
                    StartWindow = new Temp(); // To do: general start screen
                    break;
            }

            StartWindow.Show();
        }
    }
}
