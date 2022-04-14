using System;

namespace Saving_Entered_Stings_into_Variables_And_Typing_them_In_Console 
{

    internal class Program
    {
        static void Main(string[] args)
        {
            StringSaver stringSaver = new StringSaver();
            stringSaver.Reader();
            stringSaver.Printer();
        }

        public class StringSaver
        {
            public string townName, streetName;
            public int houseNumber;
            public string enteredText;
            public string town = "Town";
            public string street = "Street name";
            public string housenumber = "HOUSE number";
            public string establishdate = "an ESTABLISH date(Format:xxxx-xx-xx for YEAR-MONTH-DAY)";
            public DateTime establishDate;


            public void StarInfoPlacer()
            {
                Console.Clear();
                Console.WriteLine(">Program saves entered parameters into variables and Print them in Console");
                Console.WriteLine(">_________________________________________________________________________");
            }
            public void Reader()
            {
                Checker checker = new Checker();
                StarInfoPlacer();
                Console.WriteLine(">Press ENTER to continue...");
                StringRecorder(town, townName);
                StringRecorder(street, streetName);
                StringRecorder(housenumber, Convert.ToString(houseNumber));
                StringRecorder(establishdate, Convert.ToString(establishDate));
            }
            public void Printer()
            {
                StarInfoPlacer();
                Console.WriteLine($">{town} is: <<{townName}>>.");
                Console.WriteLine($">{street} is: <<{streetName}>>");
                Console.WriteLine($">{housenumber} is: <<{houseNumber}>>");
                Console.WriteLine($">{establishdate} is: <<{establishDate}>>");
                Console.ReadLine();
            }

            public void StringRecorder(string name, string variable)
            {
                Checker checker = new Checker();
                Console.WriteLine($">Enter {name} and press Enter...");
                if (variable == townName)
                {
                   townName = checker.IfStringIsANumber(enteredText, name);
                } 
                else if (variable == streetName)
                {
                   streetName = checker.IfStringIsANumber(enteredText, name);
                } 
                else if (name == "a HOUSE number")
                {
                   houseNumber = Convert.ToInt32(checker.IfNumberIsAString(enteredText, name));
                } 
                else
                {
                   establishDate = checker.IfEstablishDateIsInRightInterval(establishDate);
                }               
            }
        }

        public class Checker
        {
            
            StringSaver StringSaver = new StringSaver();
            public string IfStringIsANumber(string enteredText, string stringType)
            {
                enteredText = Console.ReadLine();
                while (int.TryParse(enteredText, out int num) == true)
                {
                    StringSaver.StarInfoPlacer();
                    Console.WriteLine($">Enter a <string> value for a {stringType} and press ENTER...");
                    enteredText = Console.ReadLine();
                }
                return enteredText;
            }

            public string IfNumberIsAString(string enteredText, string stringType)
            {
                enteredText = Console.ReadLine();
                while (!int.TryParse(enteredText, out int num) == true)
                {
                    StringSaver.StarInfoPlacer();
                    Console.WriteLine($">Enter an <int> value for a {stringType} and press ENTER...");
                    enteredText = Console.ReadLine();
                }
                return enteredText;
            }

            public DateTime IfEstablishDateIsInRightInterval(DateTime enteredText)
            {
                DateTime lowerDate = new DateTime(1900, 1, 1);
                DateTime upperDate = DateTime.Now;
                enteredText = Convert.ToDateTime(Console.ReadLine());
                while ((enteredText < lowerDate || enteredText > upperDate) == true)
                {
                    StringSaver.StarInfoPlacer();
                    Console.WriteLine($">House must be older than {lowerDate} and younger tnan {upperDate}.Enter a valid establish date and press ENTER...");
                    enteredText = Convert.ToDateTime(Console.ReadLine());
                }
                return Convert.ToDateTime(enteredText);
            }
        }
    }
}