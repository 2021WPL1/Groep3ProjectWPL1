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

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dao.addJobRequest(txtRequesterInit.Text, txtProjectName.Text, txtPartNr.Text);
            txtSpecialRemarks.Text = dao.GetJobRequest().Requester;
        }

      
    }
}
