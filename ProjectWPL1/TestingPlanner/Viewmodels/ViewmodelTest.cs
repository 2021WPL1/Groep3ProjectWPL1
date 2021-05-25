using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Serialization;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TestingPlanner.Data;
using TestingPlanner.Domain.Models;
using TestingPlanner.Views;

namespace TestingPlanner.Viewmodels
{

    public class ViewmodelTest : ViewModelBase
    {

        private DAO _dao;

        //Constructor
        public ViewmodelTest(DAO dao)
        {
            this._dao = dao;
        }
    }
}