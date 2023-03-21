using CallLogTesting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallLogTesting.Exceptions;
using Azure.Identity;

namespace CallLogTesting
{
    public class SearchData
    {
        public static async Task Search(int lastPriviousHams, string defaultMode, int defaultPower)
        {
            try
            {
                var fccCtrl = new FccAmaController();
                Console.Clear();
                MainMenu.HeadingDisplay();
                Console.Write("Enter a Callsign to find it in the database or \"0\" to cancel: ");
                string? callSearch = Console.ReadLine().ToUpper();
                if (callSearch == "0")
                {
                    Console.Clear();
                    return;
                }
                var result = await fccCtrl.GetByCallsignAsync(callSearch);
                if (result is null)
                {
                    throw new LevelOneGeneralException("The callsign you entered may not exist!");
                }
                Console.WriteLine();
                MainMenu.DisplayENresult(result);

                Console.WriteLine();
                await NewLogEntry.ReturnPriviousLogs(callSearch, lastPriviousHams);
                Console.WriteLine("Would you like to add a new log?");
                Console.WriteLine();
                Console.WriteLine(" Y: YES");
                Console.WriteLine(" N: NO");
                Console.WriteLine(); 
                Console.Write(" Entry: ");
                string input = Console.ReadLine().ToUpper();
                if(input == "Y")
                {
                    var success = await NewLogEntry.NewEntry(result, lastPriviousHams, defaultMode, defaultPower);
                    Console.Clear();
                    Console.WriteLine(success);
                    Console.WriteLine() ;   

                }
                else if(input == "N")
                {
                    Console.Clear();
                    return;
                }
                

            }
            catch (LevelOneGeneralException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
