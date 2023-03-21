using CallLogTesting;
using CallLogTesting.Controllers;
using CallLogTesting.Models;

bool logRunning = true;

var hamCtrl = new HamsController();
var fccCtrl = new FccAmaController();
UsersAndSettings user = new UsersAndSettings();
int lastXHams = user.NumberOfCallsToShow;
int lastPrivousHams = user.PriviousCallsToShow;
string defaultMode = user.DefaultMode;
int defaultPower = user.DefaultPower;
En hams = new En();
hams.Callsign = "continueNoData";
while (logRunning == true)
{
Start:

    int callEntry = MainMenu.Mneu(lastXHams);
    if (callEntry == 1)
    {
        var success = await NewLogEntry.NewEntry(hams, lastPrivousHams, defaultMode, defaultPower);
        Console.Clear();
        Console.WriteLine(success);
        Console.WriteLine();
    }
    else if (callEntry == 2)
    {
        Console.Clear();
        await GetLastXHams.GetNumberofHams(lastXHams);
    }
    else if (callEntry == 3)
    {
        await DeleteHam.DeleteEntry(lastXHams);  
    }
    else if (callEntry == 4)
    {
        await UpdateEntry.UpdateLog(lastXHams);
        Console.Clear();
    }
    else if (callEntry == 5)
    {
        await SearchData.Search(lastPrivousHams, defaultMode, defaultPower);
    }
    else if (callEntry == 6)
    {
        Console.Clear();
        user = SettingsMenu.Menu(lastPrivousHams, lastXHams, defaultMode, defaultPower);
        lastXHams = user.NumberOfCallsToShow;
        lastPrivousHams = user.PriviousCallsToShow;
        defaultMode = user.DefaultMode;
        defaultPower = user.DefaultPower;
        Console.Clear();

    }
    else if (callEntry == 0)
    {
        Console.WriteLine();
        Console.WriteLine("Thanks for playing.");
        logRunning = false;
    }
}
