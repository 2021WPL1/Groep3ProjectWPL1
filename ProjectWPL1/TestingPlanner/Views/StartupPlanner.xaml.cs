using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestingPlanner.Views
{
    /// <summary>
    /// Interaction logic for StartupPlanner.xaml
    /// </summary>
    public partial class StartupPlanner : Window
    {
        public StartupPlanner()
        {
            InitializeComponent();
            AddDataToListbox();
        }

        private void AddDataToListbox()
        {
            lstDiv.Items.Add("HC");
            lstProjectname.Items.Add("MDPC-8127");
            lstJrnr.Items.Add("000798");
            lstStatus.Items.Add("Planned");
            lstForeseendate.Items.Add("29/05/2021");

            lstEnvdiv.Items.Add("HC");
            lstEnvprojectname.Items.Add("MDPC-7927");
            lstEnvjrnr.Items.Add("000753");
            lstEnvstatus.Items.Add("Delayed");
            lstEnvforeseendate.Items.Add("30/05/2021");

            lstReldiv.Items.Add("HC");
            lstRelprojectname.Items.Add("MDPC-7428");
            lstReljrnr.Items.Add("000453");
            lstRelstatus.Items.Add("Delayed");
            lstRelforeseendate.Items.Add("02/06/2021");

            lstSafdiv.Items.Add("HC");
            lstSafprojectname.Items.Add("MDPC-8051");
            lstSafjrnr.Items.Add("000946");
            lstSafstatus.Items.Add("Completed");
            lstSafforeseendate.Items.Add("01/06/2021");

            lstPckdiv.Items.Add("HC");
            lstPckprojectname.Items.Add("MDPC-7362");
            lstPckjrnr.Items.Add("000451");
            lstPckstatus.Items.Add("Planned");
            lstPckforeseendate.Items.Add("02/06/2021");
        }
    }
}
