using System;
using System.Collections.Generic;
using System.Linq;
using TestingPlanner.Models;

namespace TestingPlanner.Data
{
    public class DAO
    {//
        // SINGLETON PATTERN
        // We only want one instance of this class through the whole project.
        //
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

    
        public RqRequest addJobRequest(string requester,string division, string jobNature, string expectedEndDate,
                                       string hydraProjectNr, string eutProjectName, bool battery,string eutPartNr,
                                       bool internRequest,short netWeight,short grossWeight)
        {
          

            RqRequest rqrequest = new RqRequest()
            {
                Requester = requester,
                BarcoDivision = division,
                JobNature = jobNature,
                ExpectedEnddate = Convert.ToDateTime(expectedEndDate),
                HydraProjectNr = hydraProjectNr,
                EutProjectname = eutProjectName,
                Battery = battery,
                RequestDate = DateTime.Now.Date,
                JrNumber = "20",  // automatisch
                InternRequest = internRequest,
                //special remarks RqOptional
                EutPartnumbers = eutPartNr,
                //forseen availiability date
                NetWeight = netWeight,
                GrossWeight = grossWeight,
                //team (emc, reliability, ...)           
                JrStatus ="Pending",
               
            };

            context.RqRequest.Add(rqrequest);
            saveChanges();
            return rqrequest;
        }

        public RqOptionel rqOptionels()
        {
            RqOptionel rq = new RqOptionel
            {
                Link = "test",
                Remarks = "test"
                

            };
            context.RqOptionel.Add(rq);
            saveChanges();
            return rq;
        }
    public RqRequest GetJobRequest()
        {
            return context.RqRequest.FirstOrDefault(r => r.IdRequest == 3 );
        }
     
        public void saveChanges()
        {
            context.SaveChanges();
        }
    }
}
