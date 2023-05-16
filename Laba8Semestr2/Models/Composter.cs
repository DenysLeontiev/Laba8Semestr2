using Laba8Semestr2.Helpers;
using Laba8Semestr2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8Semestr2.Models
{
    [Serializable]
    public sealed class Composter : ComposterBase, IComposter
    {
        private List<string> VehiclesWhereComposterCanBeApplied = new List<string>();
        private Dictionary<string, string> CountryCity = new Dictionary<string, string>();

        public string this[int index]
        {
            get 
            { 
                if(index >= 0 && index < VehiclesWhereComposterCanBeApplied.Count)
                {
                    return VehiclesWhereComposterCanBeApplied[index];
                }
                else
                {
                    return null;
                }
            }
            set 
            { 
                if(index == VehiclesWhereComposterCanBeApplied.Count)
                {
                    VehiclesWhereComposterCanBeApplied.Add(value);
                }
                else if(index >= 0 && index < VehiclesWhereComposterCanBeApplied.Count)
                {
                    VehiclesWhereComposterCanBeApplied[index] = value;
                }
                VehiclesWhereComposterCanBeApplied[index] = value; 
            }
        }

        public string this[string key]
        {
            get { return CountryCity[key]; }
            set { CountryCity[key] = value; }
        }

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

        public static bool operator ==(Composter leftComposter, Composter rightComposter)
        {
            return leftComposter.BusNumber == rightComposter.BusNumber;
        }

        public static bool operator !=(Composter leftComposter, Composter rightComposter)
        {
            return leftComposter.RouteNumber != rightComposter.RouteNumber;
        }

        public static Composter operator +(Composter leftComposter, Composter rightComposter)
        {
            Composter newComposter = new Composter();

            newComposter.RouteNumber = leftComposter.RouteNumber + rightComposter.RouteNumber;
            newComposter.BusNumber = leftComposter.BusNumber + rightComposter.BusNumber;
            return newComposter;
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
            //canComposterBeUsed = processedTickets.Count() >= ticketRequestsPerDay ? false : true;
            canComposterBeUsed = ComposterProcessedTickets >= ticketRequestsPerDay ? false : true;
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

        public void OutputAllInstances(IComposter[] composters)
        {
            for (int i = 0; i < composters.Length; i++)
            {
                Console.WriteLine(composters[i].ToString());
            }
        }
    }
}
