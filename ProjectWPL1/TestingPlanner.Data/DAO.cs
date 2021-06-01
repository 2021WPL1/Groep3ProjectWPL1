using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using TestingPlanner.Classes;
using TestingPlanner;
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
        
        // Counter for JR number
        private int jrCounter;

        public BarcoUser BarcoUser { get; }

        //List with all addresses 
        List<string> addresses = new List<string>();
        //Email login info
        private static string mailFrom = "groep3testprog@gmail.com";
        private static string mailFromPassword = "Testtest123";

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
            this.BarcoUser = RegistryConnection.GetValueObject<BarcoUser>(@"SOFTWARE\VivesBarco\Test");
            this.jrCounter = 0;
        }


        // LISTS

        // Returns list of all JRs
        public List<RqRequest> GetAllJobRequests()
        {
            return context.RqRequest.Include(r => r.IdRequest).ToList();
        }

        // Returns list of all jobNatures
        public List<RqJobNature> GetAllJobNatures()
        {
            return context.RqJobNature.ToList();
        }

        // Returns list of all BarcoDivisions
        public List<RqBarcoDivision> GetAllDivisions()
        {
            return context.RqBarcoDivision.ToList();
        }

        // JR CHANGES

        /// <summary>
        /// Gets a JR with user data autofilled
        /// Kaat
        /// </summary>
        public JR GetNewJR()
        {
            JR autofilledJR = new JR()
            {
                Requester = BarcoUser.Name,
                BarcoDivision = BarcoUser.Division
            };

            return autofilledJR;
        }

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
                HydraProjectNr = Jr.HydraProjectnumber == null ? string.Empty : Jr.HydraProjectnumber,
                
                ExpectedEnddate = Jr.ExpEnddate == null ? DateTime.Now : (DateTime)Jr.ExpEnddate, // Not nullable, so needs to be casted
                InternRequest = Jr.InternRequest, // Bool, default false
                Battery = Jr.Battery // Bool, default false
            };


            //Matti voorlopig
            // We create a rqo object of the RqOptionel class to save the following fields in the database with the user input
            RqOptionel rqo = new RqOptionel
            {
                Link = Jr.Link == null ? string.Empty : Jr.Link,
                Remarks = Jr.Remarks == null ? string.Empty : Jr.Remarks,

            };
            // We combine the rqo object with the rqrequest object and return the combined object
            rqrequest.RqOptionels.Add(rqo);


            return rqrequest;
        }

        //MOHAMED
        //Matti
        /// <summary>
        /// This function adds the input from the EUT part to the request object
        /// We create local variables to address the fields of the corresponding tables
        /// The combined object is eventually given to the context
        /// </summary>
        /// <param name="request"></param>
        /// <param name="eut"></param>
        public void AddEutToRqRequest(RqRequest request, EUT eut, string EutNr)
        {

            List<string> testDivision = new List<string>();

            request.GrossWeight = "0";
            request.NetWeight = "0";
            request.EutPartnumbers = request.EutPartnumbers == null ? string.Empty : request.EutPartnumbers;

            //We call the TestDivisionEutIsChecked function to check which testdivisions are checked
            TestDivisionEutIsChecked(eut, testDivision);

            // We link each testdivision to the corresponding id_request
            foreach (string testeut in testDivision)
            {
                var detail = new RqRequestDetail();
                detail.Testdivisie = testeut;
                detail.Euts.Add(new Eut
                {
                    OmschrijvingEut = "EUT" + EutNr,
                    AvailableDate = DateTime.Now
                });

                detail.Pvgresp = GetPVGResp(testeut, request.BarcoDivision);

                request.RqRequestDetails.Add(detail);
            };
            context.RqRequest.Add(request);
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
            if (Jr.BarcoDivision != null)
            {
                RqRequest rqrequest = context.RqRequest.FirstOrDefault(r => r.IdRequest == Jr.IdRequest);

                rqrequest.JrNumber = Jr.JrNumber;
                rqrequest.JrStatus = Jr.JrStatus;
                rqrequest.RequestDate = Jr.RequestDate;
                rqrequest.Requester = Jr.Requester;
                rqrequest.BarcoDivision = Jr.BarcoDivision;
                rqrequest.JobNature = Jr.JobNature;
                rqrequest.EutProjectname = Jr.EutProjectname;
                rqrequest.HydraProjectNr = Jr.HydraProjectnumber;
                rqrequest.ExpectedEnddate = (DateTime)Jr.ExpEnddate; // Not nullable, so needs to be casted
                rqrequest.InternRequest = Jr.InternRequest;
                rqrequest.GrossWeight = Jr.GrossWeight;
                rqrequest.NetWeight = Jr.NetWeight;
                rqrequest.Battery = Jr.Battery;

                // Matti voorlopig
                // We create the rqo RqOptionel object to link the user data to the db data and saves the changes in the Barco database
                RqOptionel rqo = context.RqOptionels.FirstOrDefault(o => o.IdRequest == Jr.IdRequest);
                rqo.Link = Jr.Link;
                rqo.Remarks = Jr.Remarks;
                // We combine the rqo and rqrequest objects
                rqrequest.RqOptionels.Add(rqo);



                context.RqRequest.Update(rqrequest);
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
        public JR GetJRWithId(int idrequest)
        {
            // Find selected RqRequest
            RqRequest selectedRQ = context.RqRequest.FirstOrDefault(rq => rq.IdRequest == idrequest);
            RqOptionel selectedRQO = context.RqOptionels.FirstOrDefault(rqo => rqo.IdRequest == idrequest);
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
                Battery = selectedRQ.Battery,
                //EutPartnr = selectedRQ.EutPartnumbers,

                // Testing
                Link = selectedRQO.Link,
                Remarks = selectedRQO.Remarks,

            };

            return selectedJR;
        }

        //Create and send Mail to all gmail account from list
        public void Sendmail()
        {
            using (SmtpClient client = new SmtpClient(/*"smtp.office365.com"*/"smtp.gmail.com", 587))
            {
                //addresses.Add("mohamed.elouzatie@student.vives.be");
                //addresses.Add("Kaat.ceusters@student.vives.be");
                addresses.Add("matti.snauwaert@student.vives.be");
                addresses.Add("dewintere.arne@gmail.com");
                addresses.Add("arne.dewintere@student.vives.be");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mailFrom, mailFromPassword);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(mailFrom);
                mail.Body = "Am i on time?";
                mail.Subject = "I'm a scheduled mail";
                foreach (var address in addresses)
                {
                    mail.To.Add(address);
                }
                client.Send(mail);
            }
        }
        // Mohamed, Kaat
        public List <EUT> GetEut(RqRequest rq)
        {
            List<RqRequestDetail> rqDetailsForJR = context.RqRequestDetails.Where(r => r.IdRequest == rq.IdRequest).ToList();
            List<EUT> EUTObjects = new List<EUT>();
            

            foreach (var detail in rqDetailsForJR)
            {
                List<Eut> eutsForDetail = context.Euts.Where(e => e.IdRqDetail == detail.IdRqDetail).ToList(); ;

                var divisionBool = typeof(EUT).GetProperty(detail.Testdivisie);
                var divisionPVGResp = typeof(EUT).GetProperty(detail.Testdivisie + "pvg");

                foreach (var eut in eutsForDetail)
                {
                    EUT selectedEUTObject = EUTObjects.SingleOrDefault(obj => obj.OmschrijvingEut == eut.OmschrijvingEut);

                    if (selectedEUTObject is null)
                    {
                        selectedEUTObject = new EUT
                        {
                            IdRqDetail = eut.IdRqDetail,
                            AvailabilityDate = eut.AvailableDate,
                            OmschrijvingEut = eut.OmschrijvingEut,
                        };
    
                        EUTObjects.Add(selectedEUTObject);
                    }

                    // Set division to true
                    divisionBool.SetValue(selectedEUTObject, true);

                    // Copy PVGResponsible
                    divisionPVGResp.SetValue(selectedEUTObject, detail.Pvgresp);
                }
            }

            return EUTObjects;
        }

        // Approval
        /// <summary>
        /// Approved items will be displayed in the queue for the respective teams
        /// Creates a record in the Pl_planning table.
        /// </summary>
        /// <param name="request">Request object</param>
        public void ApproveRequest(int jrId)
        {
            var DetailList = rqDetail(jrId);
            var request = context.RqRequest.FirstOrDefault(rq => rq.IdRequest == jrId);

            // List of unique test divisions checked in this JR
            var divisions = DetailList.Select(d => d.Testdivisie).Distinct();

            // On approval, set JR number and request date
            // Change JR status too?
            request.JrNumber = $"JRDEV{jrCounter}";
            request.RequestDate = DateTime.Now;

            // increase job request counter
            jrCounter++;

            // Create a new planning record for each unique division
            foreach (string division in divisions)
            {
                var planning = CreatePlPlanning(request, division);
                context.Add(planning);
            }

            SaveChanges();

        }

        // SAVING
        // Stores all data from GUI in DB
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// This function creates a list of rqRequestDetails objects that are linked to the given idRequest via the parameter
        /// </summary>
        /// <param name="idrequest"></param>
        /// <returns></returns>
        public List<RqRequestDetail> rqDetail(int idrequest)
        {
            List<RqRequestDetail> DetailRQ = context.RqRequestDetails.Where(rq => rq.IdRequest == idrequest).ToList();
            return DetailRQ;
        }

        /// <summary>
        /// This function checks which of the testdivision are checked via the user input
        /// If a test division is selected, we store this data in the test division list
        /// The user input is given via the eut object as a parameter
        /// </summary>
        private void TestDivisionEutIsChecked(EUT eut, List<string> testDivision)
        {
            // Kaat
            // Iterate over all properties of an EUT
            foreach (var property in typeof(EUT).GetProperties())
            {
                // Divisions are bools
                // Skip if the property is not a bool
                if (property.PropertyType == typeof(bool))
                {
                    // If the division is checked
                    if ((bool)property.GetValue(eut))
                    {
                        // Add the division to the list
                        testDivision.Add(property.Name);
                    }
                };
            }
        }

        /// <summary>
        /// Returns a PlPlanning for the given job request and division
        /// </summary>
        /// <param name="request">Job Request</param>
        /// <param name="division">Test team division</param>
        /// <returns>PlPlanning with request and division data</returns>
        /// Kaat
        private PlPlanning CreatePlPlanning(RqRequest request, string division)
        {
            var planning = new PlPlanning
            {
                IdRequest = request.IdRequest,
                JrNr = request.JrNumber,
                Requestdate = request.RequestDate,
                DueDate = DateTime.Now.AddDays(5),
                TestDiv = division,
                TestDivStatus = "In plan", // use enums?
            };

            return planning;
        }

        /// <summary>
        /// Returns a string with the PVGResponsible(s)
        /// </summary>
        // Kaat
        private string GetPVGResp(string testDivision, string barcoDivision)
        {
            // Get the PVGResponsibles for this division combination
            // possibly more than one
            var responsiblesList = context.RqBarcoDivisionPerson.
                Where(bpd => bpd.AfkDevision == barcoDivision && bpd.Pvggroup == testDivision).
                Select(bdp => bdp.AfkPerson);

            // Create a string from the list
            string responsiblesString = String.Join(", ", responsiblesList);

            return responsiblesString;
        }
    }
}
