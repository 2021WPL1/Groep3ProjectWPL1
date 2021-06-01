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
using TestingPlanner.Viewmodels;

namespace TestingPlanner.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Timer timer;
        private static DAO _dao;
        public MainWindow()
        {
            DataContext = new ViewModelMain();
            InitializeComponent();
            
            Schedule_Timer();
        }
        static void Schedule_Timer()
        {
            DateTime nowtime = DateTime.Now;
            DateTime scheduletime = new DateTime(nowtime.Year, nowtime.Month, nowtime.Day, 14, 23, 0, 0);

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
            _dao.Sendmail();
            Schedule_Timer();
        }
    }
}