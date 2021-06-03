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
    /// Interaction logic for PlannedTestScherm.xaml
    /// </summary>
    public partial class PlannedTestScherm : Window
    {
        public PlannedTestScherm()
        {
            InitializeComponent();
            cmbResources.Items.Add("EMC");
        }
    }
}
