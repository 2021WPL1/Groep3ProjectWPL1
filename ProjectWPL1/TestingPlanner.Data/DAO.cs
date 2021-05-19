using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using TestingPlanner.Domain.Models;



namespace TestingPlanner.Data
{
    // SINGLETON PATTERN
    // Private constructor, static instance
    // Ensures only one DBconnection is opened at a time
    // Ensures connection is closed when not in use
    public class DAO
    {
        // Variables
        private Barco2021Context context;
        private static readonly DAO instance = new DAO();

        // Calls an DAO instance
        public static DAO Instance()
        {
            return instance;
        }

        // DAO Constructor - PRIVATE
        // Calls an instance from the Barco2021Context and stores this context in the current context
        private DAO()
        {
            this.context = new Barco2021Context();
        }


        // LISTS

        // Returns list of all JRs
        public List<RqRequest> GetAllJobRequests()
        {
            return context.RqRequests.Include(r => r.IdRequest).ToList();
        }

        // Returns list of all jobNatures
        public List<RqJobNature> GetAllJobNatures()
        {
            return context.RqJobNatures.ToList();
        }

        // Returns list of all BarcoDivisions
        public List<RqBarcoDivision> GetAllDivisions()
        {
            return context.RqBarcoDivisions.ToList();
        }


        // JR CHANGES

        // INCOMPLETE
        // Creates and saves RqRequest based on JR
        // TODO: save data stored in other tables
        public RqRequest AddJobRequest(JR Jr)
        {
            // Copy data from JR to new RqRequest
            // Used ternary operator to use String.Empty when null
            RqRequest rqrequest = new RqRequest()
            {
                JrStatus = Jr.JrStatus == null ? string.Empty : Jr.JrStatus,
                RequestDate = Jr.ExpEnddate, // Nullable
                Requester = Jr.Requester == null ? string.Empty : Jr.Requester,
                BarcoDivision = Jr.BarcoDivision == null ? string.Empty : Jr.BarcoDivision,
                JobNature = Jr.JobNature == null ? string.Empty : Jr.JobNature,
                EutProjectname = Jr.EutProjectname == null ? string.Empty : Jr.EutProjectname,
               // EutPartnumbers = Jr.EutPartnr == null ? string.Empty : Jr.EutPartnr,
                HydraProjectNr = Jr.HydraProjectnumber == null ? string.Empty : Jr.HydraProjectnumber,
                ExpectedEnddate = Jr.ExpEnddate == null ? DateTime.Now : Jr.ExpEnddate,
                InternRequest = Jr.InternRequest, // Bool, default false
               // GrossWeight = Jr.GrossWeight == null ? string.Empty : Jr.GrossWeight,
              //  NetWeight = Jr.NetWeight == null ? string.Empty : Jr.NetWeight,
                Battery = Jr.Battery // Bool, default false
            };

            // StaticEutMockData();

            // We add the combined object and link it to the database using the following code 
            //context.RqRequests.Add(rqrequest);

            return rqrequest;
            //SaveChanges();
        }

        public void AddEutToRqRequest(RqRequest request, EUT eut, JR jr)
        {
            request.GrossWeight = request.GrossWeight == null ? string.Empty : request.GrossWeight;
            request.NetWeight = request.NetWeight == null ? string.Empty : request.NetWeight;
            request.EutPartnumbers = request.EutPartnumbers == null ? string.Empty : request.EutPartnumbers;


            var detail = new RqRequestDetail
            {
                //Pvgresp = detail.Pvgresp,
                Pvgresp = "Test",
            };

            var Eut = new Eut
            {
                OmschrijvingEut = "Test",
                AvailableDate = eut.AvailabilityDate,
            };

            //Nullreference exception EMC
            if (eut.EMC)
            {
                detail.Testdivisie = eut.EMC.ToString();
            }
            else if (eut.ENV)
            {
                detail.Testdivisie = eut.ENV.ToString();
            }
            else if (eut.CMP)
            {
                detail.Testdivisie = eut.CMP.ToString();
            }

            detail.Eut.Add(Eut);
            request.RqRequestDetail.Add(detail);
            context.RqRequests.Add(request);
            SaveChanges();
        }

        // INCOMPLETE
        // Finds RqRequest by ID, updates based on JR, and saves changes
        // Sends error message
        // TODO: update data stored in other tables
        public string UpdateJobRequest(JR Jr)
        {
            string message = null; // message is null on success
            // Error control
            // JR Number not empty?
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

        // INCOMPLETE
        // Gets existing JR by ID
        // TODO: catch nullRefEx - Currently impossible due to selecting listitem on load
        // TODO: link EUT's (via RqRequestDetail)
        // TODO: link RqOptionel
        public JR GetJRWithId(int idrequest)
        {
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


        // SAVING
        // Stores all data from GUI in DB
        public void SaveChanges()
        {
            context.SaveChanges();
        }


        private void StaticEutMockData()
        {
            // We create an object of the rqRequestDetail class to statically address the fields of the RqRequestDetail class in the database
            // Static values added to the Pvgresp and Testdivision fields
            // TESTFUNCTIE
            // public void staticEUT(){
            //var detail = new RqRequestDetail
            //{
            //    Pvgresp = "Test",
            //};

            //if (Eut.EMC)
            //{
            //    detail.Testdivisie = "EMC";
            //}

            //// We create an object of the Eut class to statically address the fields of the Eut class in the database
            //// Static values added to the OmschrijvingEut and AvailabilityDate fields
            //var eut = new Eut
            //{
            //    OmschrijvingEut = "Test",
            //    AvailableDate = new DateTime(2021, 8, 26),

            //};

            //// We add the recent created object eut to the previous detail object
            //detail.Eut.Add(eut);
            //// We combine the detail and rqrequest objects to create one object with all the data 
            //rqrequest.RqRequestDetail.Add(detail);  
        }
    }
}
