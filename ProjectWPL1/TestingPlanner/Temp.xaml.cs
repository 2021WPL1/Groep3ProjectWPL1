using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestingPlanner.Data;
using TestingPlanner.Domain.Models;
using TestingPlanner.Viewmodels;

namespace TestingPlanner
{
    /// <summary>
    /// Interaction logic for Temporarily.xaml
    /// </summary>
    public partial class Temp : Window
    {
       
        // Global variables
        private ViewmodelTemporarilyStartUp tempviewmodel;
        static DAO dao;
        private static Timer timer;

        // Constructor
        public Temp()
        {
            InitializeComponent();
            dao = DAO.Instance();
            tempviewmodel = new ViewmodelTemporarilyStartUp(DAO.Instance());
            DataContext = tempviewmodel;
            tempviewmodel.Load();

            Schedule_Timer();
        }
        static void Schedule_Timer()
        {
            DateTime nowtime = DateTime.Now;
            DateTime scheduletime = new DateTime(nowtime.Year, nowtime.Month, nowtime.Day, 9, 40, 0, 0);

            if (nowtime > scheduletime)
            {
                scheduletime = scheduletime.AddDays(1);
            }

            double tickTime = (double)(scheduletime - DateTime.Now).TotalMilliseconds;
            timer = new Timer(tickTime);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Timer has stopped");
            timer.Stop();
            dao.Sendmail();
            Schedule_Timer();
        }
    }
}
