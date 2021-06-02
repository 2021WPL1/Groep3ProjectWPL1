using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using TestingPlanner.Domain.Models;

namespace TestingPlanner.Viewmodels
{
    class ViewModelStartupPlanner: ViewModelCollectionRQ
    {
        private ICollectionView filterdevisionview;
        private string filter;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> Devisions { get; private set; }
        //Constructor
        public ViewModelStartupPlanner() : base()
        {
            Load();
            Devisions = new ObservableCollection<string>();
            filterdevisionview = CollectionViewSource.GetDefaultView(Devisions);
            filterdevisionview.Filter = s => string.IsNullOrEmpty(filter) ? true : ((string)s).Contains(filter);
        }

        // Function used in code behind
        // Loads all JR IDs in LB
        public void Load()
        {
            var requestIds = _dao.GetAllJobRequests();
            idRequestsOnly.Clear();

            foreach (var requestId in requestIds)
            {
                idRequestsOnly.Add(requestId);
            }

            // first JR selected by default --> Selected JR can't be null
            base.SelectedJR = idRequestsOnly[0];
        }
        public string FilterDevisions
        {
            get
            {
                return filter;
            }
            set
            {
                if(value != filter)
                {
                    filter = value;
                    filterdevisionview.Refresh();
                    RaisePropertyChanged("filter");
                }
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
