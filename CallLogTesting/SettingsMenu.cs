using CallLogTesting.Models;
using Microsoft.IdentityModel.Tokens;

namespace CallLogTesting
{
    public class SettingsMenu
    {
        public static UsersAndSettings Menu(int priviousLogs, int lastXHams, string defaultMode, int defaultPower)
        {
            UsersAndSettings user = new UsersAndSettings();
            user.PriviousCallsToShow = priviousLogs;
            user.NumberOfCallsToShow = lastXHams;
            user.DefaultMode = defaultMode;
            user.DefaultPower = defaultPower;



            MainMenu.HeadingDisplay();
        start:
            Console.WriteLine();
            Console.WriteLine("Settings Menu");
            Console.WriteLine();
            Console.WriteLine($" 1: Number of logs to show:               {user.NumberOfCallsToShow}");
            Console.WriteLine($" 2: Number of duplicate contacts to show: {user.PriviousCallsToShow}");
            Console.WriteLine($" 3: Default mode of operation:            {user.DefaultMode}");
            Console.WriteLine($" 4: Default transmitter power:            {user.DefaultPower}");
            Console.WriteLine(" 5: SAVE changes!");
            Console.WriteLine(" 0: Exit");
            Console.WriteLine();
            Console.Write("Entry: ");
            string? settingsEntry = Console.ReadLine();
            switch (settingsEntry)
            {
                case "1":
                    try
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine($"The current number of logs to show is {lastXHams}");
                        Console.WriteLine();
                        Console.Write("Enter the number of logs you would like to show: ");
                        string? newNumOfLogs = Console.ReadLine();
                        bool isNumber = int.TryParse(newNumOfLogs, out int numValue);
                        if (newNumOfLogs.IsNullOrEmpty())
                        {
                            Console.WriteLine();
                            throw new Exception("Entry number cannot be blank. \n Please enter a valid number!");
                        }
                        else if (isNumber == false)
                        {
                            Console.WriteLine();
                            throw new Exception("Entry cannot be a letter or symbol. \n Please enter a valid number!");
                        }
                        user.NumberOfCallsToShow = numValue;
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        goto start;
                    }
                    Console.Clear();
                    goto start;
                case "2":
                    try
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine($"The current number of duplicate contacts to show is {priviousLogs}");
                        Console.WriteLine();
                        Console.Write("Enter the number of contacts you would like to show: ");
                        string? newNumOfLogs = Console.ReadLine();
                        bool isNumber = int.TryParse(newNumOfLogs, out int numValue);
                        if (newNumOfLogs.IsNullOrEmpty())
                        {
                            Console.WriteLine();
                            throw new Exception("Entry number cannot be blank. \n Please enter a valid number!");
                        }
                        else if (isNumber == false)
                        {
                            Console.WriteLine();
                            throw new Exception("Entry cannot be a letter or symbol. \n Please enter a valid number!");
                        }
                        user.PriviousCallsToShow = numValue;
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        goto start;
                    }
                    Console.Clear();
                    goto start;
                case "3":
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"The current default mode of operation is {defaultMode}");
                    Console.WriteLine();
                    Console.WriteLine("Please select the default mode you would like to use");
                    Console.WriteLine();
                    Console.WriteLine(" 1: SSB");
                    Console.WriteLine(" 2: AM");
                    Console.WriteLine(" 3: CW");
                    Console.WriteLine(" 4: PSK");
                    Console.WriteLine(" 5: DIG");
                    Console.WriteLine();
                    Console.Write("Entry: ");
                    string? modeEntry = Console.ReadLine();
                    switch (modeEntry)
                    {
                        case "1":
                            user.DefaultMode = "SSB";
                            goto start;
                        case "2":
                            user.DefaultMode = "AM";
                            goto start;
                        case "3":
                            user.DefaultMode = "CW";
                            goto start;
                        case "4":
                            user.DefaultMode = "PSK";
                            goto start;
                        case "5":
                            user.DefaultMode = "DIG";
                            goto start;
                        default:
                            Console.WriteLine("Please enter a valid option");
                            goto start;
                    }
                case "4":
                    try
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine($"The current transmitter power is set to {defaultPower}");
                        Console.WriteLine();
                        Console.Write("Enter the transmitter power you are running: ");
                        string? newNumOfLogs = Console.ReadLine();
                        bool isNumber = int.TryParse(newNumOfLogs, out int numValue);
                        if (newNumOfLogs.IsNullOrEmpty())
                        {
                            Console.WriteLine();
                            throw new Exception("Entry number cannot be blank. \n Please enter a valid number!");
                        }
                        else if (isNumber == false)
                        {
                            Console.WriteLine();
                            throw new Exception("Entry cannot be a letter or symbol. \n Please enter a valid number!");
                        }
                        user.DefaultPower = numValue;
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        goto start;
                    }
                    Console.Clear();
                    goto start;

                case "5": return user;
                case "0": break;


            }
            return user;
        }
    }
}
