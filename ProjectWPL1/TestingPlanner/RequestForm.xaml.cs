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
using TestingPlanner.Data;



namespace TestingPlanner
{
    /// <summary>
    /// Interaction logic for RequestForm.xaml
    /// </summary>
    public partial class RequestForm : Window
    {
        private DAO dao;
        public RequestForm()
        {
            InitializeComponent();
            dao = DAO.Instance();
            List<string> cmb = new List<string>() { "Test1", "Test2" };
            foreach (string item in cmb)
            {
                cmbJobNature.Items.Add(item);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addRequest();
           
        }
        private void addRequest()
        {
          
            dao.addJobRequest(txtRequesterInit.Text,txtDivision.Text,cmbJobNature.SelectedValue.ToString(),
                              dpEndDate.SelectedDate.Value.Date.ToShortDateString(),txtProjectNr.Text,
                              txtProjectName.Text, cbBatteries.IsEnabled,txtPartNr.Text,cbInternal.IsEnabled,
                              Convert.ToInt16(txtNetWeight.Text),Convert.ToInt16(txtGrossWeight.Text));

            txtSpecialRemarks.Text = dpEndDate.SelectedDate.Value.Date.ToShortDateString();
        }
        //  txtSpecialRemarks.Text = dao.GetJobRequest().Requester;


    }
}
