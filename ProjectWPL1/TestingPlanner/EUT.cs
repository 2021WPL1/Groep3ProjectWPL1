using System;
using System.Collections.Generic;
using System.Text;

namespace TestingPlanner
{
    class EUT
    {
        private string _partNr;
        private DateTime _availabilityDate;
        private double _netWeight;
        private double _grossWeight;

        // tests to execute
        private bool _emc;
        private bool _env;
        private bool _rel;
        private bool _saf;
        private bool _pck;
        private bool _cmp;

        public EUT()
        {
            _partNr = null;
            _availabilityDate = new DateTime();
            _netWeight = 0;
            _grossWeight = 0;

            // Tests are not active on start
            _emc = false;
            _env = false;
            _rel = false;
            _saf = false;
            _pck = false;
            _cmp = false;
        }

        // Getters/Setters
        public string PartNr { get => _partNr; set => _partNr = value; }
        public DateTime AvailabilityDate { get => _availabilityDate; set => _availabilityDate = value; }
        public double NetWeight { get => _netWeight; set => _netWeight = value; }
        public double GrossWeight { get => _grossWeight; set => _grossWeight = value; }
        public bool EMC { get => _emc; set => _emc = value; }
        public bool ENV { get => _env; set => _env = value; }
        public bool REL { get => _rel; set => _rel = value; }
        public bool SAF { get => _saf; set => _saf = value; }
        public bool PCK { get => _pck; set => _pck = value; }
        public bool CMP { get => _cmp; set => _cmp = value; }
    }
}
