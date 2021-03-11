using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingPlanner.Domain.Models;



namespace TestingPlanner.Data
{
    public class DAO
    {
        private static readonly DAO instance = new DAO();
        public static DAO Instance()
        {
            return instance;
        }
        // Private constructor!
        private DAO()
        {
            this.context = new Barco2021Context();
        }
        // DBContext
        private Barco2021Context context;

        public RqRequest addJobRequest(string jrNumber, string jrStatus, string requester, string eutProjectName,
                                        string eutPartNr, string hydraProjectNr, bool internRequest, string grossWeight,
                                        string netWeight, bool battery, string link, string remarks, string barcoDivision,
                                      string jobNature, DateTime ExpEndDate, string pvgResp, DateTime AvailabilityDate)  
        { 
            RqRequest rqrequest = new RqRequest()
            {
                JrNumber = jrNumber,  //automatisch
                JrStatus = jrStatus,
                RequestDate = DateTime.Now.Date,
                Requester = requester,
                BarcoDivision = barcoDivision,
                JobNature = jobNature,
                EutProjectname = eutProjectName,
                EutPartnumbers = eutPartNr,
                HydraProjectNr = hydraProjectNr,
                ExpectedEnddate = ExpEndDate,
                InternRequest = internRequest,
                GrossWeight = grossWeight,
                NetWeight = netWeight,
                Battery = battery,
                RqOptionel = new List<RqOptionel> { new RqOptionel
                {
                    Link = link,
                    Remarks = remarks
                } },
                RqRequestDetail = new List<RqRequestDetail> {new RqRequestDetail
                {
                    Pvgresp = pvgResp,
                   // Testdivisie = "EMC",
                Eut = new List<Eut>{new Eut
                {
                    AvailableDate=AvailabilityDate
                }},  TestdivisieNavigation  = new RqTestDevision { Afkorting ="EMC"}}
                }
            };

            context.RqRequests.Add(rqrequest);
            saveChanges();
            return rqrequest;
        }


        public List<RqRequest> GetJobRequest()
        {
            // return context.RqRequest.FirstOrDefault(r => r.IdRequest == 3 );
            return context.RqRequests.Include(r => r.RqOptionel).ToList();
        }
        public void saveChanges()
        {
            context.SaveChanges();
        }


    }
}
