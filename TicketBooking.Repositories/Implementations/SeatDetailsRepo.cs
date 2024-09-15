using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Entities;
using TicketBooking.Repositories.Data;
using TicketBooking.Repositories.Interfaces;

namespace TicketBooking.Repositories.Implementations
{
    

    public class SeatDetailsRepo : ISeatDetailRepo
    {
        private readonly ApplicationDbContext context;

        public SeatDetailsRepo(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task Delete(BusSeatDetail busSeatDetail)
        {
            context.BusSeatDetails.Remove(busSeatDetail);
            await context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<BusSeatDetail>> GetAll()
        {
            return await context.BusSeatDetails.ToListAsync();
        }

        public async Task<BusSeatDetail> GetById(int id)
        {
            return await context.BusSeatDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(BusSeatDetail busSeatDetail)
        {
            await context.AddAsync(busSeatDetail);
            await context.SaveChangesAsync();
        }

        public Task Update(BusSeatDetail busSeatDetail)
        {
            throw new NotImplementedException();
        }
    }
}
