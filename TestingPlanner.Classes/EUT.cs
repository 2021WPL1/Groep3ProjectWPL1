using System;
using System.Collections.Generic;
using System.Text;

namespace TestingPlanner
{
    // Bridge between UI and Datamodels
    // Use class so only one getter/setter/onPropertyChanged needs to be created
    public class EUT
    {
        // Variables
        private int _idRqDetail;
        private DateTime _availabilityDate;
        private string _omschrijvingEut;
        private string _partNr;
        private string _netWeight;
        private string _grossWeight;

        // Tests to execute
        // TODO: function to check if necessart RQDetail already exists
        private bool _emc;
        private bool _env;
        private bool _rel;
        private bool _sav;
        private bool _pck;
        private bool _eco;

        // PVGResponsobles for this test
        public string EMCpvg { get; set; }
        public string ENVpvg { get; set; }
        public string RELpvg { get; set; }
        public string SAVpvg { get; set; }
        public string PCKpvg { get; set; }
        public string ECOpvg { get; set; }


        // Constructor
        public EUT()
        {
            _partNr = null;
            _availabilityDate = DateTime.Now;
            _netWeight = "0";
            _grossWeight = "0";

            // Tests are not active on start
            _emc = false;
            _env = false;
            _rel = false;
            _sav = false;
            _pck = false;
            _eco = false;
        }

        // Getters/Setters
        public string PartNr { get => _partNr; set => _partNr = value; }
        public int IdRqDetail { get => _idRqDetail; set => _idRqDetail = value; }
        public DateTime AvailabilityDate { get => _availabilityDate; set => _availabilityDate = value; }
        public string OmschrijvingEut { get => _omschrijvingEut; set => _omschrijvingEut = value; }

        public bool EMC { get => _emc; set => _emc = value; }
        public bool ENV { get => _env; set => _env = value; }
        public bool REL { get => _rel; set => _rel = value; }
        public bool SAV { get => _sav; set => _sav = value; }
        public bool PCK { get => _pck; set => _pck = value; }
        public bool ECO { get => _eco; set => _eco = value; }
    }
}
