using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
    /// Interaction logic for RequestForm.xaml
    /// </summary>
    public partial class RequestForm : Window
    {
        // variables
        private ViewmodelRequestform viewModel;
        private DAO dao;
        private static Barco2021Context context = new Barco2021Context();

        // Constructor
        public RequestForm()
        {
            InitializeComponent();
            dao = DAO.Instance();
            viewModel = new ViewmodelRequestform(DAO.Instance(), 6); // Temporarily hardcoded
            DataContext = viewModel;
        }

        // The following functions are beign executed when the Request Form GUI is loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddAllJobNaturesToCombobox();
            AddAllDivionsToCombobox();
            FillInRequestDate();
        }

        // This function retrieves the information of the job natures from the Barco2021 database and returns these
        // values in the correct combobox in the Request Form GUI
        private void AddAllJobNaturesToCombobox()
        {
            var jobNatures = context.RqJobNatures.ToList();
            foreach (RqJobNature jobNature in jobNatures)
            {
                cmbJobNature.Items.Add(jobNature.Nature);
            }
        }

        // This function retrieves the information of the divisions from the Barco2021 database and returns these values 
        // into the correct combobox in the Request Form GUI
        private void AddAllDivionsToCombobox()
        {
            var divisions = context.RqBarcoDivisions.ToList();
            foreach (RqBarcoDivision division in divisions)
            {
                cmbDivision.Items.Add(division.Afkorting);
            }
        }

        // This function automatically fills in the request date to the current day of the job request 
        private void FillInRequestDate()
        {
            txtRequestDate.Text = DateTime.Now.Date.ToShortDateString();
        }

        //If the Checkbox is checked we return the value : true and if the checkbox is not checked we return the value : false
        private bool ifChecked(CheckBox cb)
        {
            bool cbChecked = false;
            if (cb.IsChecked == true)
            {
                cbChecked = true;
            }
            return cbChecked;
        }

   
    }
}
