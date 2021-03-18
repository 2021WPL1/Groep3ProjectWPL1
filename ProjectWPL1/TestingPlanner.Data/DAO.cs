using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
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
        public string AddJobRequest(JR Jr)
        {
            string message = null;

            RqRequest rqrequest = new RqRequest()
            {
                // JrNumber = "test", // temporary name (hardcoded)
                JrStatus = Jr.JrStatus,
                RequestDate = DateTime.Now.Date,
                Requester = Jr.Requester,
                BarcoDivision = Jr.BarcoDivision,
                JobNature = Jr.JobNature == null ? string.Empty : Jr.JobNature,
                EutProjectname = Jr.EutProjectname == null ? string.Empty : Jr.EutProjectname,
                EutPartnumbers = Jr.EutPartnr == null ? string.Empty : Jr.EutPartnr,
                HydraProjectNr = Jr.HydraProjectnumber,
                ExpectedEnddate = Jr.ExpEnddate,
                InternRequest = Jr.InternRequest,
                GrossWeight = Jr.GrossWeight == null ? string.Empty : Jr.GrossWeight,
                NetWeight = Jr.NetWeight == null ? string.Empty : Jr.NetWeight,
                Battery = Jr.Battery,

                //Created but not yet loaded when JR gets returned
                RqOptionel = new List<RqOptionel> { new RqOptionel
                {

                    Link = Jr.Link,

                    // The value of Remarks does not get pushed to the Barco2021 Database
                    Remarks = Jr.Remarks
                } },
                RqRequestDetail = new List<RqRequestDetail> {new RqRequestDetail
                    {
                        Pvgresp = Jr.PvgResp,
                       
                        
                        Eut = new List<Eut>{new Eut
                        {
                            AvailableDate= Jr.ExpEnddate
                        }},
                            TestdivisieNavigation  = context.RqTestDevisions.FirstOrDefault(r => r.Afkorting == "a")   
                            //TestdivisieNavigation = new RqTestDevision { Afkorting = "a"} // Vervangen indien z nog niet bestaat
                        }
                    }
                };

                context.RqRequests.Add(rqrequest);
                SaveChanges();
            
       

            return message;
        }

        public string UpdateJobRequest(JR Jr) // INCOMPLETE
        {
            string message = null;

            if (Jr.JrNumber != null)
            {
                RqRequest rqrequest = context.RqRequests.FirstOrDefault(r => r.IdRequest == Jr.IdRequest);

                rqrequest.JrNumber = Jr.JrNumber;
                rqrequest.JrStatus = Jr.JrStatus;
                rqrequest.RequestDate = Jr.RequestDate;
                rqrequest.Requester = Jr.Requester;
                rqrequest.BarcoDivision = Jr.BarcoDivision;
                rqrequest.JobNature = Jr.JobNature;
                rqrequest.EutProjectname = Jr.EutProjectname;
                rqrequest.HydraProjectNr = Jr.HydraProjectnumber;
                rqrequest.ExpectedEnddate = Jr.ExpEnddate;
                rqrequest.InternRequest = Jr.InternRequest;
                rqrequest.GrossWeight = Jr.GrossWeight;
                rqrequest.NetWeight = Jr.NetWeight;
                rqrequest.Battery = Jr.Battery;

                context.RqRequests.Update(rqrequest);
                SaveChanges();
            }
            else
            {
                message = "Error - empty job request\n" +
                    "Please fill in all necessary fields";
            }

            return message;
        }

        // This function returns all the job request and stores them in a list
        public List<RqRequest> GetAllJobRequests()
        {
            return context.RqRequests.Include(r => r.IdRequest).ToList();
            // return context.RqRequests.ToList();
        }

        public List<RqJobNature> GetAllJobNatures()
        {
            return context.RqJobNatures.ToList();
        }

        public List<RqBarcoDivision> GetAllDivisions()
        {
            return context.RqBarcoDivisions.ToList();
        }


        public JR GetJRWithId(int idrequest)
        {
            // ToDo: EUT's (via RqRequestDetail)
            // ToDo: RqOptionel
           
            // Find selected RqRequest
            RqRequest selectedRQ = context.RqRequests.FirstOrDefault(rq => rq.IdRequest == idrequest);

            // Create new JR with necessary data
            JR selectedJR = new JR
            {
                IdRequest = selectedRQ.IdRequest,
                JrNumber = selectedRQ.JrNumber,
                JrStatus = selectedRQ.JrStatus,
                RequestDate = selectedRQ.RequestDate,
                Requester = selectedRQ.Requester,
                BarcoDivision = selectedRQ.BarcoDivision,
                JobNature = selectedRQ.JobNature,
                EutProjectname = selectedRQ.EutProjectname,
                HydraProjectnumber = selectedRQ.HydraProjectNr,
                ExpEnddate = selectedRQ.ExpectedEnddate,
                InternRequest = selectedRQ.InternRequest,
                GrossWeight = selectedRQ.GrossWeight,
                NetWeight = selectedRQ.NetWeight,
                Battery = selectedRQ.Battery
            };
           
            return selectedJR;
      

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
