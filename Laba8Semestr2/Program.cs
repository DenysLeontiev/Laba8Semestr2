using Laba8Semestr2.Helpers;
using Laba8Semestr2.Models;
using System;
using System.Collections.Generic;

namespace Laba8Semestr2
{
    public class Program
    {
        private const string FILE_PATH = "fileIO.txt";
        private static List<Ticket> ProcessedTickets = new List<Ticket>();
        public static List<Ticket> GetProcessedTickets() 
        {
            return ProcessedTickets; 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Composter program!");
            Composter composter = new Composter();
            ClassInitializer.InitializeFromConsoleInput(composter);
            Console.WriteLine("Init from console input");
            Console.WriteLine();
            composter.Control();

            string ticketNumber = "113225"; 
            composter.CheckTicket(ticketNumber); // does not exist
            Console.WriteLine(composter);

            //composter.Control(); // block composter if he has done more job

            composter.CheckTicket(ticketNumber); // alreadyExists

            foreach (var item in ProcessedTickets)
            {
                Console.WriteLine("All ProcessedTickets: " + item);
                Console.WriteLine();
            }

            composter.Control(ticketNumber);

            //Console.WriteLine();
            //Console.WriteLine("CopyCtor");
            //Composter composterCopyCtor = new Composter(composter);
            //Console.WriteLine(composterCopyCtor);
            //Console.WriteLine();

            //Console.WriteLine("Saving to file");
            //ClassInitializer.SaveToFile(composter, FILE_PATH);

            //Composter composter1 = ClassInitializer.LoadFromFile(FILE_PATH);
            //Console.WriteLine(composter1);
        }
    }
}
