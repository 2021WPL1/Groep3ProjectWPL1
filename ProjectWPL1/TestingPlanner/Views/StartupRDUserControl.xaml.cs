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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestingPlanner.Views
{
    /// <summary>
    /// Interaction logic for StartupRDUserControl.xaml
    /// </summary>
    public partial class StartupRDUserControl : UserControl
    {
        public StartupRDUserControl()
        {
            InitializeComponent();
            AddDataToSearch();
        }

        private void AddDataToSearch()
        {
            cbmSearchdevision.Items.Add("HC");
            cbmSearchdevision.Items.Add("EP-LD");
            cbmSearchdevision.Items.Add("EP-NET-KAR");
            cbmSearchdevision.Items.Add("EP-NET-KND");
            cbmSearchdevision.Items.Add("EP-PROJ-CAV");

            cbmSearchstatus.Items.Add("Planned");
            cbmSearchstatus.Items.Add("JR Planned");
            cbmSearchstatus.Items.Add("Passed");
            cbmSearchstatus.Items.Add("Not Planned");
            cbmSearchstatus.Items.Add("Ongoing");
        }
    }
}
