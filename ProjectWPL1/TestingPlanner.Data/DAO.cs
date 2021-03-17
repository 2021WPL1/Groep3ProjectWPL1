using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingPlanner.Domain.Models;



namespace TestingPlanner.Data
{
    public class DAO
    {
        // Variables
        private Barco2021Context context;
        private static readonly DAO instance = new DAO();

        // This functions calls an DAO instance
        public static DAO Instance()
        {
            return instance;
        }

        // DAO Constructor 
        // Calls an instance from the Barco2021Context and stores this context in the current context
        private DAO()
        {
            this.context = new Barco2021Context();
        }

        // This function creates a Job Request with the following data,
        // the data is beign retrieved from the requester using the GUI
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

        // This function returns all the job request and stores them in a list
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


        // This function stores all the data from the GUI in the Barco2021 database
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
