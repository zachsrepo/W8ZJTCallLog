using CallLogTesting.Controllers;
using CallLogTesting.Models;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Runtime.CompilerServices;

namespace CallLogTesting
{
    public class NewLogEntry
    {
        public static async Task<string> NewEntry(En hamFromSearch, int lastPriviousHams, string defaultMode, int power) // add an ask for data method.
        {
            Ham newfoundOp = new Ham();
            var hamCtrl = new HamsController();
            var fccCtrl = new FccAmaController();
            List<Ham> hams = new List<Ham>();
            En? newHamLookup = new En();
            string? enteredCall = null;
            decimal? freq;
            Console.Clear();
        start:
            MainMenu.HeadingDisplay();
            try
            {
                if (hamFromSearch.Callsign == "continueNoData")
                {
                    goto next;
                }
                else //if(hamFromSearch.Callsign != "continueNoData")
                {
                    newHamLookup = hamFromSearch;
                    enteredCall = hamFromSearch.Callsign;
                    goto searchHam;
                }
            next:
                Console.Write("please enter a callsign or \"0\" to cancel: ");
                enteredCall = Console.ReadLine().ToUpper();
                Console.WriteLine();
                if (enteredCall.IsNullOrEmpty())
                {
                    Console.Clear();
                    Console.WriteLine("Callsign cannot be blank!");
                    Console.WriteLine();
                    goto start;
                }
                else if (enteredCall == "0")
                {
                    Console.WriteLine(); // we might need 2 methods here to get the data and assign the data.
                    return "";

                }
                newHamLookup = await fccCtrl.GetByCallsignAsync(enteredCall);
            searchHam:
                if (newHamLookup is not null)
                {
                    newfoundOp.Callsign = newHamLookup.Callsign;
                    newfoundOp.FirstName = newHamLookup.First;
                    newfoundOp.LastName = newHamLookup.Last;
                    newfoundOp.City = newHamLookup.City;
                    newfoundOp.State = newHamLookup.State;
                    newfoundOp.Address = newHamLookup.Address1;
                    newfoundOp.FccId = newHamLookup.Fccid.ToString();
                    newfoundOp.PostalCode = newHamLookup.Zip;
                    newfoundOp.DateAndTime = DateTime.Now;
                    MainMenu.DisplayHamLogFull(newfoundOp);
                    Console.WriteLine();
                    await ReturnPriviousLogs(enteredCall, lastPriviousHams);
                    Console.Write("Please enter a Frequency for this log or \"0\" to cancel: ");//try and get frequency from serial data
                    var freqToConvert = Console.ReadLine(); //need more work here. need to handle exceptions and bands
                    if(freqToConvert == "0")
                    {
                        return "";
                    }
                    else if (freqToConvert == "")
                    {
                        freq = 0.000m;
                    }
                    else
                    {
                        freq = Convert.ToDecimal(freqToConvert);
                    }
                    newfoundOp.Frequency = DataHandleing.HandleFrequency(freq);

                    newfoundOp.band = DataHandleing.CalculateBand(newfoundOp.Frequency);
                    Console.WriteLine();
                    Console.WriteLine($"Please select the mode of operation, if left blank the defualt mode: {defaultMode} will be used");
                    Console.WriteLine();
                    Console.WriteLine(" 1: SSB");
                    Console.WriteLine(" 2: AM");
                    Console.WriteLine(" 3: CW");
                    Console.WriteLine(" 4: PSK");
                    Console.WriteLine(" 5: DIG");
                    Console.WriteLine();
                    Console.Write("Entry: ");
                    string? enteredMode = Console.ReadLine();
                    switch (enteredMode)
                    {
                        case "1":
                            newfoundOp.Mode = "SSB";
                            break;
                        case "2":
                            newfoundOp.Mode = "AM";
                            break;
                        case "3":
                            newfoundOp.Mode = "CW";
                            break;
                        case "4":
                            newfoundOp.Mode = "PSK";
                            break;
                        case "5":
                            newfoundOp.Mode = "DIG";
                            break;
                        default: newfoundOp.Mode = defaultMode; break;
                    }
                    newfoundOp.Power = power;
                    var successADD = await hamCtrl.InsertAsync(newfoundOp);
                    if (!successADD)
                    {
                        return "Entry Failed";
                    }
                    return "Entry Successful";
                }
                else
                {
                    Console.WriteLine("Callsign not found in FCC database");//put a cancel in here
                    Console.WriteLine();
                    Console.WriteLine("would you like to enter the information manually?");
                    Console.WriteLine();
                    Console.WriteLine(" 1: Enter manually");
                    Console.WriteLine(" 2: Try the search again");
                    Console.WriteLine(" 0: Cancel");
                    Console.WriteLine();
                    Console.Write(" Entry: ");
                    string? input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.Clear();
                        goto manual;
                    }
                    else if (input == "2")
                    {
                        Console.Clear();
                        goto start;
                    }
                    else if (input == "0")
                    {
                        Console.Clear();
                        return "";
                    }
                }
            manual:
                Console.Write("please enter a first-name or press \"0\" to cancel: ");
                string? enteredFirstName = Console.ReadLine();// tons of stuff to add here for manual entry.
                if (enteredFirstName == "0")
                {
                    return "";
                }
                if (enteredFirstName.IsNullOrEmpty())
                {
                    throw new Exception("Please enter a first name!");

                }
                Console.Write("please enter a QTH: ");
                string? enteredQTH = Console.ReadLine();
                Console.Clear();
                Ham newOperator = new Ham();
                newOperator.Callsign = enteredCall;
                newOperator.FirstName = enteredFirstName;
                newOperator.QTH = enteredQTH;
                newOperator.DateAndTime = DateTime.Now;
                var success = await hamCtrl.InsertAsync(newOperator);
                if (!success)
                {
                    return "Entry Failed";
                }
                return "Entry Successful";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static async Task ReturnPriviousLogs(string callSearch, int lastPriviousHams)
        {

            var hamCtrl = new HamsController();
            int idxCount = 0;
            int idxStop = 0;
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
            var priviousWorks = await hamCtrl.GetAllByCallsign(callSearch);
            priviousWorks.Reverse();

            string columnHeading = $" {id,-5} | {callsign,-10} | {firstName,-12} | {lastName,-15} | {band,-4} | {frequency,10} | {mode,4} | {power,5} | {state,-5} | {date}";
            foreach (var p in priviousWorks)
            {
                idxCount++;
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
            if (priviousWorks.Count != 0)
            {
                Console.WriteLine();
                Console.WriteLine($"Here are your privious logs with {callSearch}");
                Console.WriteLine();
                Console.WriteLine(columnHeading);
                Console.WriteLine();
            }
            foreach (var p in priviousWorks)
            {
                idxStop++;
                //write data
                Console.WriteLine($" {p.Id,-5} | {p.Callsign,-10} | {p.FirstName,-12} | " +
                    $"{p.LastName,-15} | {p.band,4} | {p.Frequency,10} | {p.Mode,-4} | {p.Power,5} | {p.State,-5} | {p.DateAndTime}");
                if (idxStop == lastPriviousHams)
                {
                    break;
                }
            }
            Console.WriteLine();
            if (idxCount == 1)
            {
                Console.WriteLine((idxCount == 1) ? $"You have worked {callSearch} {idxCount} time!" :
                "You havent worked this callsign before!");
            }
            else
            {
                Console.WriteLine((idxCount > 0) ? $"You have worked {callSearch} {idxCount} times! Displaying the last {lastPriviousHams}" :
                    "You havent worked this callsign before!");
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine();
            return;
        }
    }
}
