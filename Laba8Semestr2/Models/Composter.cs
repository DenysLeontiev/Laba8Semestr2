using Laba8Semestr2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8Semestr2.Models
{
    [Serializable]
    public class Composter
    {
        private const int ticketRequestsPerDay = 1;
        private bool canComposterBeUsed = true;

        public Ticket Ticket { get; set; } 
        protected static string Code { get; set; } // Шифр // for marking tickets
        private string Number { get; set; } // unique composter number
        private int ComposterProcessedTickets { get; set; } = 0; // how many tickets this composter has already processed
        public string BusNumber { get; set; }
        public string RouteNumber { get; set; }

        static Composter()
        {
            Code = "RandomSecretCode";
        }

        public Composter()
        {
            Number = CodeGenerator.GenerateUniqueCode();
        }

        public Composter(Ticket ticket, string number)
        {
            Number = CodeGenerator.GenerateUniqueCode();

            Ticket = ticket;
            Number = number;
        }

        public Composter(string busNumber, string routeNumber)
        {
            Number = CodeGenerator.GenerateUniqueCode();
            BusNumber = busNumber;
            RouteNumber = routeNumber;
        }

        public Composter(Composter composter)
        {
            Number = CodeGenerator.GenerateUniqueCode();
            Ticket = composter.Ticket;
            BusNumber = composter.BusNumber;
            RouteNumber = composter.RouteNumber;
        }

        public string GetCode()
        {
            return Code;
        }

        public string GetNumber()
        {
            return Number;
        }

        public bool CheckTicket(string ticketNumber)
        {
            if(!canComposterBeUsed)
            {
                Console.WriteLine($"Composter cant be used(JobDone: {ticketRequestsPerDay} /Out of: {ComposterProcessedTickets})");
                return false;
            }

            ComposterProcessedTickets++;
            var processedTickets = Program.GetProcessedTickets();
            var ticket = processedTickets.Where(x => x.TicketNumber == ticketNumber).FirstOrDefault();
            if (ticket != null) 
            {
                Console.WriteLine("Ticket has already been used.You can't use that anymore");
                return false;
            }

            Ticket ticketToAdd = new Ticket() 
            { 
                IsMarked = true, 
                TicketNumber = ticketNumber 
            };

            ticketToAdd.DateOfLastCheck = DateTime.Now;
            processedTickets.Add(ticketToAdd);

            Console.WriteLine("Your ticket was processed successfully");
            return true;
        }

        public void Control(string ticketNumber)
        {
            if (canComposterBeUsed == false)
            {
                Console.WriteLine($"Composter cant be used(JobDone: {ticketRequestsPerDay} /Out of: {ComposterProcessedTickets})");
                return;
            }
            var processedTickets = Program.GetProcessedTickets();
            var ticket = processedTickets.Where(x => x.TicketNumber == ticketNumber).FirstOrDefault();
            if (ticket == null)
            {
                Console.WriteLine($"Ticket with id - {ticketNumber} is not found");
            }

            if(ticket.TicketNumber.EndsWith("5"))
            {
                Console.WriteLine($"Ticket with id - {ticketNumber} can be used infinite number of times");
                ticket.IsMarked = false;
            }
        }

        public void Control()
        {
            var processedTickets = Program.GetProcessedTickets();
            canComposterBeUsed = processedTickets.Count() >= ticketRequestsPerDay ? false : true;
        }

        public override string ToString()
        {
            string objectInString = string.Empty;
            objectInString += $"BusNumber: {BusNumber} \n"
                              + $"RouteNumber: {RouteNumber} \n"
                              + $"Code: {Code} \n" +
                              $"ComposterProcessedTickets: {ComposterProcessedTickets} \n" +
                              $"ComposterNumber: {Number}";

            return objectInString;
            
        }
    }
}
