using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TestingPlanner.Classes;
using TestingPlanner.Domain.Models;

namespace TestingPlanner.Viewmodels
{
    class ViewModelTestForm : ViewModelBase
    {
        // Listbox with equipment
        public ObservableCollection<PlResources> Resources { get; set; }

        // Plan for these tests
        public PlPlanning SelectedPlan { get; set; }

        public ObservableCollection<Test> Tests { get; set; }
        private Test selectedTest;
        private Test editingTest;

        public ICommand AddNewTestCommand { get; set; }
        public ICommand ClearTestCommand { get; set; }

        public ViewModelTestForm(PlPlanning planning)
        {
            SelectedPlan = planning;

            Resources = new ObservableCollection<PlResources>();
            Tests = new ObservableCollection<Test>();

            foreach (var item in _dao.GetResources(planning.TestDiv))
            {
                Resources.Add(item);
            }

            AddNewTestCommand = new DelegateCommand(AddTest);
            ClearTestCommand = new DelegateCommand(ClearTest);

            EditingTest = new Test();
        }


        public Test SelectedTest
        {
            get => selectedTest;
            set
            {
                selectedTest = value;
                EditingTest = selectedTest;
                //EditingTest.Description = SelectedTest.Description;
                //EditingTest.StartDate = SelectedTest.StartDate;
                //EditingTest.EndDate = SelectedTest.EndDate;
                //EditingTest.Resource = SelectedTest.Resource;
                OnpropertyChanged();
            }
        }

        public Test EditingTest
        {
            get => editingTest;
            set
            {
                editingTest = value;
                OnpropertyChanged();
            }
        }

        public void AddTest()
        {
            Test newTest = new Test
            {
                Description = EditingTest.Description,
                RQId = SelectedPlan.IdRequest,
                TestDivision = SelectedPlan.TestDiv,
                StartDate = editingTest.StartDate,
                EndDate = editingTest.EndDate,
                Resource = editingTest.Resource,
                // Status = TBD
            };

            Tests.Add(newTest);
            EditingTest = new Test();
        }

        public void ClearTest()
        {
            EditingTest = new Test();
        }

    }
}
