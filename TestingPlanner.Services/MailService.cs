using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Timers;

namespace TestingPlanner.Services
{
    public class MailService
    {
        private System.Timers.Timer _timer;
        
        //List with all addresses 
        private List<string> _addresses = new List<string>();

        //Email login info
        private static string _mailFrom = "groep3testprog@gmail.com";
        private static string _mailFromPassword = "Testtest123";

        //Create and send Mail to all gmail account from list// Arne
        public void Sendmail()
        {
            Schedule_Timer();
            using (SmtpClient client = new SmtpClient(/*"smtp.office365.com"*/"smtp.gmail.com", 587))
            {
                _addresses.Add("dewintere.arne@gmail.com");
                _addresses.Add("arne.dewintere@student.vives.be");
                _addresses.Add("matti.snauwaert@student.vives.be");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_mailFrom, _mailFromPassword);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_mailFrom);
                mail.Body = "Am i on time?";
                mail.Subject = "I'm a scheduled mail";
                foreach (var address in _addresses)
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
                _timer = new System.Timers.Timer(tickTime);
                _timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
                _timer.Start();
        }

        // Wanneer de timer stopt voert hij de sendmail functie uit en roept opnieuw de schedule_timer aan en die gaat dan een 
        // dag bij tellen.
        public void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
                Console.WriteLine("Timer has stopped");
                _timer.Stop();
                Sendmail();
                Schedule_Timer();
        }

    }
}

