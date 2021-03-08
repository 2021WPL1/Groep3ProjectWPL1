using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingPlanner.Domain.Models;
using TestingPlanner.Models;
using Barco2021Context = TestingPlanner.Models.Barco2021Context;

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
                                        string eutPartNr, string hydraProjectNr, bool internRequest, short grossWeight,
                                        short netWeight, bool battery, string link, string remarks, string barcoDivision,
                                        string jobNature, DateTime ExpEndDate)
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
                RqOptionel = new List<RqOptionel> {new RqOptionel
                {
                  Link = link,
                  Remarks = remarks
                }},
                RqRequestDetail = new List<RqRequestDetail> {new RqRequestDetail
                    {
                      Pvgresp="c",
                      TestdivisieNavigation = new RqTestDevision{Afkorting="f"
                    }}}
            };
            context.RqRequest.Add(rqrequest);
            saveChanges();
            return rqrequest;
        }
        public List<RqRequest> GetJobRequest()
        {
            // return context.RqRequest.FirstOrDefault(r => r.IdRequest == 3 );
            return context.RqRequest.Include(r => r.RqOptionel).ToList();
        }
        public void saveChanges()
        {
            context.SaveChanges();
        }
    }
}
