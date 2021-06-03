using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestingPlanner.Classes;
using TestingPlanner.Domain.Models;

namespace TestingPlanner.Viewmodels
{
    class ViewModelTesterTest : ViewModelBase
    {
        public ObservableCollection<Test> Tests { get; set; }

        private Test selectedTest;

        public ViewModelTesterTest()
        {
            Tests = new ObservableCollection<Test>();

            foreach (var item in _dao.GetAllTests())
            {
                Tests.Add(item);
            }

            selectedTest = new Test();
        }
        public Test SelectedTest 
        { 
            get => selectedTest;
            set
            {
                selectedTest = value;
                OnpropertyChanged();
            }
        }
    }
}
