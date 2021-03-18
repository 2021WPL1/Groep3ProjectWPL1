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
        private ViewmodelRequestForm viewModel;
        private DAO dao;
        private static Barco2021Context context = new Barco2021Context();

        // Constructor empty
        public RequestForm()
        {
            InitializeComponent();
            dao = DAO.Instance();
            viewModel = new ViewmodelRequestForm(DAO.Instance());
            DataContext = viewModel;
            viewModel.Load();
        }

        // Constructor existing
        public RequestForm(int idRequest)
        {
            InitializeComponent();
            dao = DAO.Instance();
            viewModel = new ViewmodelRequestForm(DAO.Instance(), idRequest);
            DataContext = viewModel;
            viewModel.Load();

        }
    }
}
