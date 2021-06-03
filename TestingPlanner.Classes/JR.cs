using System;
using System.Collections.Generic;
using System.Text;

namespace TestingPlanner
{
    // Bridge between UI and Datamodels
    // Use class so only one getter/setter/onPropertyChanged needs to be created
    public class JR
    {

        // Required variables for the job request
        // INCOMPLETE
        private int _idRequest;
        private string _jrNumber;
        private string _jrStatus;
        private string _requester;
        private string _eutProjectname;
        private string _eutPartnr;
        private string _hydraProjectnumber;
        private bool? _internRequest;
        private string _grossWeight;
        private string _netWeight;
        private bool _battery;
        private string _link;
        private string _remarks;
        private string _barcoDivision;
        private string _jobNature;
        private DateTime? _expEnddate;
        private DateTime? _requestDate;



        // JR Constructor
        public JR()
        {
            // TEMP FIX
            // Autofill Weights
            _grossWeight = "0";
            _netWeight = "0";
        }
        // PVGResponsobles for this test
        public string EMCpvg { get; set; }
        public string ENVpvg { get; set; }
        public string RELpvg { get; set; }
        public string SAVpvg { get; set; }
        public string PCKpvg { get; set; }
        public string ECOpvg { get; set; }

        // Getters/setters
        public int IdRequest { get => _idRequest; set => _idRequest = value; }
        public string JrNumber { get => _jrNumber; set => _jrNumber = value; }
        public string JrStatus { get => _jrStatus; set => _jrStatus = value; }
        public string Requester { get => _requester; set => _requester = value; }
        public string EutProjectname { get => _eutProjectname; set => _eutProjectname = value; }
        public string EutPartnr { get => _eutPartnr; set => _eutPartnr = value; }
        public string HydraProjectnumber { get => _hydraProjectnumber; set => _hydraProjectnumber = value; }
        public bool? InternRequest { get => _internRequest; set => _internRequest = value; }
        public string GrossWeight { get => _grossWeight; set => _grossWeight = value; }
        public string NetWeight { get => _netWeight; set => _netWeight = value; }
        public bool Battery { get => _battery; set => _battery = value; }
        public string Link { get => _link; set => _link = value; }
        public string Remarks { get => _remarks; set => _remarks = value; }
        public string BarcoDivision { get => _barcoDivision; set => _barcoDivision = value; }
        public string JobNature { get => _jobNature; set => _jobNature = value; }
        public DateTime? ExpEnddate { get => _expEnddate; set => _expEnddate = value; }
        public DateTime? RequestDate { get => _requestDate; set => _requestDate = value; }
    }
}
