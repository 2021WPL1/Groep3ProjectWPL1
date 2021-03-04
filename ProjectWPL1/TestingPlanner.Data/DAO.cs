using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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

    
        public RqRequest addJobRequest(string requester,string eutProjectName, string eutPartNr
                                        
                                       /*string jobNature,string hydraProjectNr,
                                       DateTime expectedEndDate,bool internRequest, short grossWeight,
                                       short netWeight,bool battery,*/  )
        {
            RqRequest rqrequest = new RqRequest()
            {
                Requester=requester,
                JrNumber = "20",
                EutProjectname = eutProjectName,
                EutPartnumbers = eutPartNr,
                BarcoDivision = "test"
               /* JobNature = jobNature,
                JrStatus ="Pending",
                HydraProjectNr = hydraProjectNr,
                ExpectedEnddate = expectedEndDate,
                InternRequest = internRequest,
                GrossWeight = grossWeight,
                NetWeight = netWeight,
                Battery=battery*/
            };

            context.RqRequest.Add(rqrequest);
            saveChanges();
            return rqrequest;
        }

        public RqRequest GetJobRequest()
        {
            return context.RqRequest.FirstOrDefault(r => r.IdRequest == 3);
        }
     
        public void saveChanges()
        {
            context.SaveChanges();
        }
    }
}
