using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingPlanner.Domain.Models;



namespace TestingPlanner.Data
{
    public class DAO
    {
        private Barco2021Context context;
        private static readonly DAO instance = new DAO();

        public static DAO Instance()
        {
            return instance;
        }

        private DAO()
        {
            this.context = new Barco2021Context();
        }

        public RqRequest AddJobRequest(JR Jr)
        {
            RqRequest rqrequest = new RqRequest()
            {
                JrNumber = Jr.JrNumber,
                JrStatus = Jr.JrStatus,
                RequestDate = DateTime.Now.Date,
                Requester = Jr.Requester,
                BarcoDivision = Jr.BarcoDivision,
                JobNature = Jr.JobNature,
                EutProjectname = Jr.EutProjectname,
                EutPartnumbers = Jr.EutPartnr,
                HydraProjectNr = Jr.HydraProjectnumber,
                ExpectedEnddate = DateTime.Now.Date,
                InternRequest = Jr.InternRequest,
                GrossWeight = Jr.GrossWeight,
                NetWeight = Jr.NetWeight,
                Battery = Jr.Battery,
                RqOptionel = new List<RqOptionel> { new RqOptionel
                {
                    Link = Jr.Link,
                    Remarks = Jr.Remarks
                } },
                RqRequestDetail = new List<RqRequestDetail> {new RqRequestDetail
                {
                    Pvgresp = Jr.PvgResp,
                   // Testdivisie = "EMC",
                Eut = new List<Eut>{new Eut
                {
                    AvailableDate= DateTime.Now.Date
                }},  TestdivisieNavigation  = new RqTestDevision { Afkorting = "z"}}
                }
            };
            context.RqRequests.Add(rqrequest);
            SaveChanges();
            return rqrequest;
        }

        public List<RqRequest> GetAllJobRequests()
        {
            return context.RqRequests.Include(r => r.IdRequest).ToList();
           // return context.RqRequests.ToList();
        }

        //private string getPvgResp()
        //{
        //    var division = context.RqBarcoDivisionPersons
        //                   .Include(d => d.AfkPerson).Where(d => d.Pvggroup == PvgGroup)
        //                   .FirstOrDefault(d => d.AfkDevision == );
        //    return division.AfkPerson;
        //}

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
