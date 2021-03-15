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
using TestingPlanner.Domain.Models;
using TestingPlanner.Viewmodels;

namespace TestingPlanner
{
    /// <summary>
    /// Interaction logic for Temporarily.xaml
    /// </summary>
    public partial class Temp : Window
    {
        private ViewmodelTemporarilyStartUp tempviewmodel;
        private DAO dao;
       // private static Barco2021Context context = new Barco2021Context();
        public Temp()
        {
            InitializeComponent();
            dao = DAO.Instance();
            tempviewmodel = new ViewmodelTemporarilyStartUp(DAO.Instance());
            DataContext = tempviewmodel;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
