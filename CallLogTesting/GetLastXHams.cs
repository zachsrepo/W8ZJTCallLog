using CallLogTesting.Controllers;
using CallLogTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallLogTesting
{
    public class GetLastXHams
    {
        public static async Task<List<int>> GetNumberofHams(int lastXHams)
        {
            var hamCtrl = new HamsController();
            List<Ham> hams = new List<Ham>();
            List<int> iDs = new List<int>();
            hams = await hamCtrl.GetAllAsync();
            hams.Reverse();
            MainMenu.HeadingDisplay();
            iDs = MainMenu.DisplayHamsLogs(hams, lastXHams);
            return iDs;
        }
    }
}
