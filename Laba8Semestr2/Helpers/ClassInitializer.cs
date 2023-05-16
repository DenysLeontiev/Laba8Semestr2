using Laba8Semestr2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Laba8Semestr2.Helpers
{
    public static class ClassInitializer
    {
        public static void InitializeFromConsoleInput(Composter composter) 
        {
            Console.WriteLine("Initializing class from console input");
            if (composter == null)
            {
                composter = new Composter();
            }

            Console.Write("Enter your route number: ");
            var routeNumber = Console.ReadLine();
            composter.RouteNumber = routeNumber;

            Console.Write("Enter your bus number: ");
            var busNumber = Console.ReadLine();
            composter.BusNumber = busNumber;
        }


        public static void SaveToFile(Composter composter, string filePath)
        {
            using var fileStream = new FileStream(filePath, FileMode.Create);
    

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, composter);   
        }

        public static Composter LoadFromFile(string filePath)
        {
            Composter composter = null;

            using var fileStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            composter = binaryFormatter.Deserialize(fileStream) as Composter;

            return composter;
        }
    }
}
