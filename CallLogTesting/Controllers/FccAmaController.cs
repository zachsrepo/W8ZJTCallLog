using CallLogTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallLogTesting.Controllers
{
    public class FccAmaController
    {
        private readonly FccAmateurContext _context;
        public FccAmaController()
        {
            _context = new FccAmateurContext();
        }
        //public async Task<List<En>> GetAllAsync()
        //{
        //    return await _context.Ens.ToListAsync();
        //}
        public async Task<En?> GetByCallsignAsync(string callSearch) // maybe change this to an Icollection.
        {
            return await (from calls in _context.Ens
                          join active in _context.Hds
                          on calls.Fccid equals active.Fccid
                          where calls.Callsign == callSearch && active.Status == "A"
                          select calls).SingleOrDefaultAsync();
            
            //return await _context.Ens.FirstOrDefaultAsync(n => n.Callsign == callSearch);
        }
        //private async Task<bool> SaveDbAsync()
        //{
        //    var changes = await _context.SaveChangesAsync();
        //    return changes == 1 ? true : false;
        //}
    }
}
