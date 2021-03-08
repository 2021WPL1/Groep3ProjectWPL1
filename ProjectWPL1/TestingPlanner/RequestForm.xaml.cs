using System;
using System.Collections.Generic;
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
using TestingPlanner.Models;

namespace TestingPlanner
{
    /// <summary>
    /// Interaction logic for RequestForm.xaml
    /// </summary>
    public partial class RequestForm : Window
    {
        private DAO dao;
        private static Barco2021Context context = new Barco2021Context();

        public RequestForm()
        {
            InitializeComponent();
            dao = DAO.Instance();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addAllJobNaturesToCombobox();
            addAllDivionsToCombobox();
            txtRequestDate.Text = DateTime.Now.Date.ToShortDateString();
        }
        private void btnAddJobRequest_Click(object sender, RoutedEventArgs e)
        {
            addRequest();
        }
        private void addRequest()
        {
            dao.addJobRequest("50", "pending", txtRequesterInit.Text, txtProjectName.Text, txtPartNr.Text, txtProjectNr.Text,
                              ifChecked(cbInternal), Convert.ToInt16(txtGrossWeight.Text), Convert.ToInt16(txtNetWeight.Text),
                              ifChecked(cbBatteries), txtLinkTestPlan.Text, txtSpecialRemarks.Text, cmbDivision.Text, cmbJobNature.Text,
                              dpEndDate.SelectedDate.Value.Date);
        }
        private void addAllJobNaturesToCombobox()
        {
            var jobNaturs = context.RqJobNature.ToList();
            foreach (RqJobNature jobNature in jobNaturs)
            {
                cmbJobNature.Items.Add(jobNature.Nature);
            }
        }
        private void addAllDivionsToCombobox()
        {
            var divisions = context.RqBarcoDivision.ToList();
            foreach (RqBarcoDivision division in divisions)
            {
                cmbDivision.Items.Add(division.Afkorting);
            }
        }

        // Is the Checkbox checked return true or false
        private bool ifChecked(CheckBox cb)
        {
            bool cbChecked = false;
            if (cb.IsChecked == true)
            {
                cbChecked = true;
            }
            return cbChecked;
        }
        //  txtSpecialRemarks.Text = dao.GetJobRequest().Requester;

    }
}
