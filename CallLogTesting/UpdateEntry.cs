using CallLogTesting.Controllers;
using CallLogTesting.Exceptions;
using CallLogTesting.Models;
using Microsoft.IdentityModel.Tokens;

namespace CallLogTesting
{
    public class UpdateEntry
    {

        public static async Task<bool> UpdateLog(int lastXHams)
        {
            bool loopRunning = true;
            int numEntryValue = 0;
            do
            {
                Console.Clear();
                var hamCtrl = new HamsController();
                var hamUp = new Ham();
                List<Ham> hams = new List<Ham>();
            begin:
                var matchID = await GetLastXHams.GetNumberofHams(lastXHams);
                hams = await hamCtrl.GetAllAsync();
                hams.Reverse();
                Console.Write("Select an entry to UPDATE by ID or \"0\" to cancel: ");
                try
                {
                    string? entryUpdate = Console.ReadLine();
                    bool isNumber = int.TryParse(entryUpdate, out numEntryValue);
                    if (entryUpdate.IsNullOrEmpty())
                    {
                        Console.WriteLine();
                        throw new LevelOneGeneralException("Entry number cannot be blank. \n Please enter a valid number!");
                    }
                    else if (isNumber == false)
                    {
                        Console.WriteLine();
                        throw new LevelOneGeneralException("Entry cannot be a letter or symbol. \n Please enter a valid number!");
                    }
                    Console.WriteLine();
                    if (numEntryValue == 0)
                    {
                        Console.WriteLine();
                        return false;
                    }
                    if(numEntryValue > matchID.Count)
                    {
                        throw new LevelOneGeneralException("The ID you entered could not be found");
                    }
                    int finalUpdate = matchID[numEntryValue - 1];
                    hamUp = await hamCtrl.GetByIdAsync(finalUpdate);
                    if (hamUp is null)
                    {
                        throw new Exception("The ID you entered could not be found");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    goto begin;
                }
                Console.Clear();
            start:
                MainMenu.HeadingDisplay();
                try
                {
                    MainMenu.DisplayAllHam(hamUp);
                    Console.WriteLine();
                    Console.WriteLine("Select an option:");
                    Console.WriteLine();
                    Console.WriteLine(" 1: Update Callsign               10: Update City");
                    Console.WriteLine(" 2: Update FirstName              11: Update StateCode");
                    Console.WriteLine(" 3: Update LastName");
                    Console.WriteLine(" 4: Update Frequency");
                    Console.WriteLine(" 5: Update Mode");
                    Console.WriteLine(" 6: Update TX Power");
                    Console.WriteLine(" 7: Update ZIP");
                    Console.WriteLine(" 8: Update Address");
                    Console.WriteLine(" 9: SAVE Changes!");
                    Console.WriteLine(" 0: Cancel");
                    Console.Write(" Entry: ");
                    string? updateEntry = Console.ReadLine();
                    bool isUpNumber = int.TryParse(updateEntry, out int numEntryValueUp);
                    if (updateEntry.IsNullOrEmpty())
                    {
                        Console.WriteLine();
                        throw new LevelTwoGeneralException("Entry number cannot be blank. \n Please enter a valid number!");
                    }
                    else if (isUpNumber == false)
                    {
                        Console.WriteLine();
                        throw new LevelTwoGeneralException("Entry cannot be a letter or symbol. \n Please enter a valid number!");
                    }
                    else if (numEntryValueUp < 0 || numEntryValueUp > 11)
                    {
                        Console.WriteLine();
                        throw new LevelTwoGeneralException("The number you entered is not an option! \n Please enter a valid number!");
                    }
                    switch (numEntryValueUp)
                    {
                        case 1:
                            Console.Write("Please enter the updated callsign: ");
                            hamUp.Callsign = Console.ReadLine().ToUpper();
                            Console.Clear();
                            goto start;
                        case 2:
                            Console.Write("Please enter the updated FirstName: ");
                            hamUp.FirstName = Console.ReadLine();
                            Console.Clear();
                            goto start;
                        case 3:
                            Console.Write("Please enter the updated LastName: ");
                            hamUp.LastName = Console.ReadLine();
                            Console.Clear();
                            goto start;
                        case 4:
                            Console.Write("Please enter the updated frequency: ");
                            string newFreq = Console.ReadLine();
                            hamUp.Frequency = DataHandleing.HandleFrequency(Convert.ToDecimal(newFreq));
                            hamUp.band = DataHandleing.CalculateBand(hamUp.Frequency);

                            Console.Clear();
                            goto start;
                        case 10:
                            Console.Write("Please enter the updated city: ");
                            hamUp.City = Console.ReadLine();
                            Console.Clear();
                            goto start;
                        case 11:
                            Console.Write("Please enter the updated StateCode: ");
                            hamUp.State = Console.ReadLine();
                            Console.Clear();
                            goto start;
                        case 7:
                            Console.Write("Please enter the updated ZIP: ");
                            hamUp.PostalCode = Console.ReadLine();
                            Console.Clear();
                            goto start;
                        case 8:
                            Console.Write("Please enter the updated Address: ");
                            hamUp.Address = Console.ReadLine();
                            Console.Clear();
                            goto start;
                        case 9:
                            var success = await hamCtrl.UpdateAsync(hamUp);
                            if (success)
                            {
                                Console.Clear();
                                Console.WriteLine("Update Successful!");
                            }
                            loopRunning = false;
                            return false;
                        case 5:
                            Console.WriteLine();
                            Console.WriteLine("     1: SSB");
                            Console.WriteLine("     2: AM");
                            Console.WriteLine("     3: CW");
                            Console.WriteLine("     4: PSK");
                            Console.WriteLine("     5: DIG");
                            Console.WriteLine();
                            Console.Write("      Entry: ");
                            string newBand = Console.ReadLine();
                            switch (newBand)
                            {
                                case "1": 
                                    hamUp.Mode = "SSB";
                                    Console.Clear();
                                    goto start;
                                case "2": 
                                    hamUp.Mode = "AM";
                                    Console.Clear();
                                    goto start;
                                case "3": 
                                    hamUp.Mode = "CW";
                                    Console.Clear();
                                    goto start;
                                case "4":
                                    hamUp.Mode = "PSK";
                                    Console.Clear();    
                                    goto start;
                                case "5":
                                    hamUp.Mode = "DIG";
                                    Console.Clear();
                                    goto start;
                                default:
                                    Console.WriteLine("Invalid selection!");
                                    break;
                            }
                            goto start;
                        case 6:
                            Console.Write("Please enter the updated TX power: ");
                            hamUp.Power = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            goto start;
                        case 0:
                            Console.Clear();
                            loopRunning = false;
                            return false;
                        default:
                            Console.WriteLine("Your selection is invalid please try again!");
                            goto start;
                    }
                }
                catch (LevelTwoGeneralException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                    goto start;
                }
            } while (loopRunning);
        }
    }
}
