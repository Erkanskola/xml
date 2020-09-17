using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Modellering
{
    class Program
    {
        static void Main(string[] args)
        {
            Fotboll fotboll = new Fotboll();

            GetInput(fotboll);

            System.Console.WriteLine($"Din fotboll ser ut så här:\nDen väger {fotboll.weight} Viktenheter.\nDen befinner sig i område {fotboll.x},{fotboll.y}.\nStorleken på fotbollen är {fotboll.size}.");

            XmlSerializer serializer = new XmlSerializer(typeof(Fotboll));
            using(FileStream file = File.Open("fotboll.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(file, fotboll);
            }


            Console.ReadLine();
        }

        static void GetInput(Fotboll fotboll)
        {
            bool success = false;



            while (!success)
            {
                System.Console.WriteLine("Skriv in fotbollens vikt");
                success = float.TryParse(Console.ReadLine(), out float weight);
                fotboll.weight = weight;
            }

            success = false;

            while (!success)
            {
                System.Console.WriteLine("Skriv in fotbollens x-värde");
                success = int.TryParse(Console.ReadLine(), out int x);
                fotboll.x = x;
            }

            success = false;

            while (!success)
            {
                System.Console.WriteLine("Skriv in fotbollens y-värde");
                success = int.TryParse(Console.ReadLine(), out int y);
                fotboll.y = y;
            }

            success = false;

            while (!success)
            {
                System.Console.WriteLine("Skriv in fotbollens storlek");
                success = int.TryParse(Console.ReadLine(), out int size);
                fotboll.size = size;
            }

        }
    }
}

