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


            //Här kallar jag en av mina metoder. Den består av flera loops som upprepas om spelaren inte lyckas göra success = true.
            GetInput(fotboll);

            //Efter all input, skrivs värdena ut. Enklare på detta sätt än med en lista eller array, då det inte behöver vara dynamiskt.
            System.Console.WriteLine($"Din fotboll ser ut så här:\nDen väger {fotboll.weight} Viktenheter.\nDen befinner sig i område {fotboll.x},{fotboll.y}.\nStorleken på fotbollen är {fotboll.size}.");

            //Xml-serializern som skapar eller uppdaterar en xml-fil med informationen som spelaren kommer skriva in i programmet.
            XmlSerializer serializer = new XmlSerializer(typeof(Fotboll));
            using(FileStream file = File.Open("fotboll.xml", FileMode.OpenOrCreate)){
                serializer.Serialize(file, fotboll);
            }


            Console.ReadLine();
        }

        //Metoden för input med instruktioner för varje typ av input. Om success = true, får man gå vidare och skriva in resten av informationen. Om "!success", får man upp samma meddelande igen.
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

        //Testar att göra en RNG för att man ska kunna "spela" spelet på något sätt. Tänker att man ska kalla metoden efter man skrivit in all information. Lite early WIP då jag fortfarande är ganska grön inom programmeringen och jag har inte lagt ned så mycket tid som jag velat.
        static void kickBall(){


            /*Random generator = new Random();

            fotboll.x = generator.Next(0,11);
            fotboll.y = generator.Next(0,11);

            System.Console.WriteLine(fotboll.x, Fotboll.y);*/
            
         }
    }
}