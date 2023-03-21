using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CallLogTesting.Models;
using System.ComponentModel.DataAnnotations;
using Azure.Identity;

namespace CallLogTesting
{
    public class MainMenu
    {
        public static int Mneu(int lastXHams)
        {
            HeadingDisplay();   
            Console.WriteLine("Select an option");
            Console.WriteLine();
            Console.WriteLine(" 1: Enter a new log");
            Console.WriteLine($" 2: View last {lastXHams} logs");
            Console.WriteLine(" 3: Delete an entry");
            Console.WriteLine(" 4: Update an entry");
            Console.WriteLine(" 5: Search FCC database");
            Console.WriteLine(" 6: Settings menu");
            Console.WriteLine(" 0: Exit");
            Console.WriteLine();
            Console.Write(" Entry: ");
            try
            {
                string? callEntry = Console.ReadLine();
                bool isNumber = int.TryParse(callEntry, out int numValue);
                if (callEntry.IsNullOrEmpty())
                {
                    Console.WriteLine();
                    throw new Exception("Entry number cannot be blank. \n Please enter a valid number!");
                }
                else if (isNumber == false)
                {
                    Console.WriteLine();
                    throw new Exception("Entry cannot be a letter or symbol. \n Please enter a valid number!");
                }
                else if(numValue < 0 || numValue > 6)
                {
                    Console.WriteLine();    
                    throw new Exception("The number you entered is not an option! \n Please enter a valid number!");    
                }
                return numValue;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                return -1;
            }
        }
        public static void HeadingDisplay()
        {
            string textToEnter = "W8ZJT Callsign Logging Program";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.WriteLine();
        }
        public static List<int> DisplayHamsLogs(List<Ham> inst, int lastXHams)
        {
            List<int> iDs = new List<int>();
            int idx = 0;
            string id = "ID";
            string callsign = "CALLSIGN";
            string firstName = "FIRST NAME";
            string lastName = "LAST NAME";
            string band = "BAND";
            string frequency = "FREQUENCY";
            string mode = "MODE";
            string power = "POWER";
            string date = "DATE";
            string fccid = "FCCID";
            string address = "ADDRESS";
            string city = "CITY";
            string state = "STATE";
            string zip = "ZIPCODE";

            string columnHeading = $" {id,-2} | {callsign,-10} | {firstName,-12} | {lastName,-15} | {band,-4} | {frequency,10} | {mode,4} | {power,5} | {state,-5} | {date}";
            //int lr = inst.Max(n => n.LastName.Length);
            Console.WriteLine(columnHeading);
            Console.WriteLine();
            foreach(Ham ham in inst)
            {
                idx++;
                iDs.Add(ham.Id);
                ham.Id = idx;
                Console.WriteLine($" {ham.Id,-2} | {ham.Callsign,-10} | {ham.FirstName,-12} | " +
                    $"{ham.LastName,-15} | {ham.band,4} | {ham.Frequency,10} | {ham.Mode,-4} | {ham.Power,5} | {ham.State,-5} | {ham.DateAndTime}");
                if(idx == lastXHams)
                {
                    break;
                }
            }
            Console.WriteLine();
            return iDs;
        }
        public static void DisplayAllHam(Ham inst)
        {
            string id = "ID";
            string callsign = "CALLSIGN";
            string firstName = "FIRST NAME";
            string lastName = "LAST NAME";
            string band = "BAND";
            string frequency = "FREQUENCY";
            string mode = "MODE";
            string date = "DATE";
            string fccid = "FCCID";
            string address = "ADDRESS";
            string city = "CITY";
            string state = "STATE";
            string zip = "ZIPCODE";
            string power = "POWER";

            string columnHeading = $" {id} | {callsign,-10} | {firstName,-12} | {lastName,-15} | {frequency,10} | {band,4} | {mode,-4} | " +
                $"{power,5} | {fccid,-10} | {address,-20} | {city,-15} | {state,-5} | {zip,-10} | {date}";

            Console.WriteLine(columnHeading);
            Console.WriteLine();
            Console.WriteLine($" {inst.Id} | {inst.Callsign,-10} | {inst.FirstName,-12} | " +
                    $"{inst.LastName,-15} | {inst.Frequency,10} | {inst.band,4} | {inst.Mode,-4} | {inst.Power,5} | {inst.FccId,-10}" +
                    $" | {inst.Address,-20} | {inst.City,-15} | {inst.State,-5} | {inst.PostalCode,-10} | {inst.DateAndTime}");
        }
        public static void DisplayHamLogFull(Ham inst)
        {
            string id = "ID";
            string callsign = "CALLSIGN";
            string firstName = "FIRST NAME";
            string lastName = "LAST NAME";
            string band = "BAND";
            string frequency = "FREQUENCY";
            string mode = "MODE";
            string date = "DATE";
            string fccid = "FCCID";
            string address = "ADDRESS";
            string city = "CITY";
            string state = "STATE";
            string zip = "ZIPCODE";

            string columnHeading = $" {callsign,-10} | {firstName,-12} | {lastName,-15} |" +
                $" {fccid,-10} | {address,-20} | {city,-15} | {state,-5} | {zip,-10} | {date}";

            Console.WriteLine(columnHeading);
            Console.WriteLine();
            Console.WriteLine($" {inst.Callsign,-10} | {inst.FirstName,-12} | " +
                    $"{inst.LastName,-15} | {inst.FccId,-10} | " +
                    $"{inst.Address,-20} | {inst.City,-15} | {inst.State,-5} | {inst.PostalCode,-10} | {inst.DateAndTime}");
        }
        public static void DisplayENresult(En inst)
        {
            string id = "ID";
            string callsign = "CALLSIGN";
            string firstName = "FIRST NAME";
            string lastName = "LAST NAME";
            string band = "BAND";
            string frequency = "FREQUENCY";
            string mode = "MODE";
            string date = "DATE";
            string fccid = "FCCID";
            string address = "ADDRESS";
            string city = "CITY";
            string state = "STATE";
            string zip = "ZIPCODE";

            string columnHeading = $" {fccid,-10} | {callsign,-10} | {firstName,-12} | {lastName,-15} |" +
                $" {address,-20} | {city,-15} | {state,-5} | {zip,-10}";
            Console.WriteLine(columnHeading);
            Console.WriteLine();
            
            Console.WriteLine($" {inst.Fccid,-10} | {inst.Callsign,-10} | {inst.First,-12} | " +
                $"{inst.Last,-15} | {inst.Address1,-20} | {inst.City,-15} | {inst.State,-5} | " +
                $"{inst.Zip,-10}");
        }
    }
}
