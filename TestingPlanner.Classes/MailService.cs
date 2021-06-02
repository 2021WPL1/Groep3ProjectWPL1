using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Timers;

namespace TestingPlanner.Classes
{
    public class MailService
    {
        private System.Timers.Timer timer;
        
        
        //List with all addresses 
        List<string> addresses = new List<string>();
            //Email login info
            private static string mailFrom = "groep3testprog@gmail.com";
            private static string mailFromPassword = "Testtest123";

        //Create and send Mail to all gmail account from list// Arne
        public void Sendmail()
        {
            Schedule_Timer();
            using (SmtpClient client = new SmtpClient(/*"smtp.office365.com"*/"smtp.gmail.com", 587))
            {
                //addresses.Add("mohamed.elouzatie@student.vives.be");
                //addresses.Add("Kaat.ceusters@student.vives.be");
                //addresses.Add("matti.snauwaert@student.vives.be");
                addresses.Add("dewintere.arne@gmail.com");
                addresses.Add("arne.dewintere@student.vives.be");
                addresses.Add("matti.snauwaert@student.vives.be");
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
        // zorgt voor een vast tijdstip op een dag die dan iets moet uitvoeren
        public void Schedule_Timer()
        {
                DateTime nowtime = DateTime.Now;
                DateTime scheduletime = new DateTime(nowtime.Year, nowtime.Month, nowtime.Day, 14, 23, 0, 0);

                if (nowtime > scheduletime)
                {
                    scheduletime = scheduletime.AddDays(1);
                }

                double tickTime = (double)(scheduletime - DateTime.Now).TotalMilliseconds;
                //timer = new Timer(tickTime);
                //door de using threading en timer weet VS niet welke timer ik bedoel, dus moeten we het voluit schrijven
                timer = new System.Timers.Timer(tickTime);
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.Start();
            }
        // Wanneer de timer stopt voert hij de sendmail functie uit en roept opnieuw de schedule_timer aan en die gaat dan een 
        // dag bij tellen.
        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
                Console.WriteLine("Timer has stopped");
                timer.Stop();
                Sendmail();
                Schedule_Timer();
        }

    }
}

