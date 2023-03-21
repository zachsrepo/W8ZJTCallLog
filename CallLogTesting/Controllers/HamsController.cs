using CallLogTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallLogTesting.Controllers
{
    public class HamsController
    {
        private readonly HamsDbContext _context;
        public HamsController()
        {
            _context = new HamsDbContext();
        }
        public async Task<List<Ham>> GetAllAsync()
        {
            return await _context.Hams.ToListAsync();
        }
        public async Task<List<Ham>> GetAllByCallsign(string callSearch)
        {
            return await (from calls in _context.Hams
                          where calls.Callsign == callSearch
                          select calls).ToListAsync();
        }
        public async Task<Ham?> GetByIdAsync(int id) // maybe change this to an Icollection.
        {
            return await _context.Hams.FindAsync(id);

        }
        public async Task<bool> InsertAsync(Ham ham) //may want to return the id of the new log
        {
            _context.Hams.Add(ham);
            return await SaveDbAsync();
        }
        public async Task<bool> UpdateAsync(Ham ham) // we want to change this so if anything goes wrong it will throw an exception see codefirst
        {
            var aHam = await GetByIdAsync(ham.Id);
            if (aHam is null)
            {
                return false;
            }
            _context.Hams.Entry(ham).State = EntityState.Modified;
            return await SaveDbAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var aHam = await GetByIdAsync(id);
            if (aHam is null)
            {
                return false;
            }
            _context.Hams.Remove(aHam);
            return await SaveDbAsync();
        }
        private async Task<bool> SaveDbAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes == 1 ? true : false;
        }
    }
}
