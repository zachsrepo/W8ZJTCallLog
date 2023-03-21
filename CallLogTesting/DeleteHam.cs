using CallLogTesting.Controllers;
using CallLogTesting.Exceptions;
using CallLogTesting.Models;
using Microsoft.IdentityModel.Tokens;

namespace CallLogTesting
{
    public class DeleteHam
    {
        public static async Task<bool> DeleteEntry(int lastXHams)
        {
            var hamCtrl = new HamsController();
            var delHam = new Ham();
            bool isRunning = true;
            do
            {
                Console.Clear();
            start:
                 var matchID = await GetLastXHams.GetNumberofHams(lastXHams);
                Console.WriteLine();
                Console.Write("Select an entry to DELETE by ID or \"0\" to cancel: ");
                try
                {
                    string? entryDelete = Console.ReadLine();
                    bool isNumber = int.TryParse(entryDelete, out int numEntryValue);
                    if (entryDelete.IsNullOrEmpty())
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
                    if (numEntryValue > matchID.Count)
                    {
                        throw new LevelOneGeneralException("The ID you entered could not be found");
                    }
                    int finalDelete = matchID[numEntryValue - 1];
                    delHam = await hamCtrl.GetByIdAsync(finalDelete);
                    if (delHam is null)
                    {
                        throw new LevelOneGeneralException("The ID you entered may not exist");
                    }
                    else
                    {
                        var success = await hamCtrl.DeleteAsync(finalDelete);
                        if (!success)
                        {
                            throw new LevelOneGeneralException("Delete Failed!");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Deleted ID: {numEntryValue}");
                            isRunning = false;
                        }
                    }
                }
                catch (LevelOneGeneralException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                    goto start;
                }
            } while (isRunning);
            return true;

        }
    }
}
