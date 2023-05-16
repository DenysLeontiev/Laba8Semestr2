using Laba8Semestr2.Helpers;
using Laba8Semestr2.Interfaces;
using Laba8Semestr2.Models;
using System;
using System.Collections.Generic;

namespace Laba8Semestr2
{
    public class Program
    {
        private const string FILE_PATH = "testFile.bin";
        private static List<Ticket> ProcessedTickets = new List<Ticket>();
        public static List<Ticket> GetProcessedTickets() 
        {
            return ProcessedTickets; 
        }

        public static void PolymorphMethod(ComposterBase[] composters)
        {
            foreach (var composter in composters)
            {
                Console.WriteLine(composter);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {

            Composter myComposter = new Composter();

            //myComposter[0] = "Tram";
            //myComposter[1] = "Bus";
            //myComposter[2] = "Plane";

            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine(myComposter[i]);
            //    Console.WriteLine();
            //}

            //myComposter["Ukraine"] = "Kyiv";
            //myComposter["USA"] = "New York";
            //myComposter["France"] = "Paris";

            //string city1 = myComposter["Ukraine"]; // "Kyiv"
            //string city2 = myComposter["USA"]; 
            //string city3 = myComposter["France"];

            //Console.WriteLine("Country - City pairs:");
            //Console.WriteLine($"Ukraine: {city1}");
            //Console.WriteLine($"USA: {city2}");
            //Console.WriteLine($"France: {city3}");



            //Composter composter1 = new Composter("Bus123", "RouteA");
            //Composter composter2 = new Composter("Bus456", "RouteB");
            //Composter composter3 = new Composter("Bus123", "RouteC");

            //bool isEqual = composter1 == composter3;
            //Console.WriteLine($"composter1 == composter3: {isEqual}"); 

            //bool isNotEqual = composter1 != composter2;
            //Console.WriteLine($"composter1 != composter2: {isNotEqual}");

            //Composter combinedComposter = composter1 + composter2;
            //Console.WriteLine($"combinedComposter: {combinedComposter.RouteNumber}, {combinedComposter.BusNumber}");












            //var firstComposter = new Composter("4", "23");
            //var secondComposter = new Composter("13", "23");
            //var thirdComposter = new Composter("8", "23");
            //var fourthComposter = new Composter("2", "23");
            //Composter[] composterArray = { firstComposter, secondComposter, thirdComposter, fourthComposter };

            //Console.WriteLine("Before Sorting");
            //foreach (var item in composterArray)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //}

            //Console.WriteLine("After Sorting");
            //fourthComposter.SortInstances(composterArray);
            //foreach (var item in composterArray)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //}

            //PolymorphMethod(composterArray); // й реалізує взаємодію через посилання набазові класи
        }
    }
}
