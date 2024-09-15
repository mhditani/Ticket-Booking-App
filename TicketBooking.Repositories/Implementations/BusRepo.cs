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
    public class BusRepo : IBusRepo
    {
        private readonly ApplicationDbContext context;

        public BusRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Delete(Bus bus)
        {
            context.Buses.Remove(bus);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bus>> GetAll()
        {
            return await context.Buses.ToListAsync();
        }

        public async Task<Bus> GetById(int id)
        {
            return await context.Buses.FirstOrDefaultAsync(b => b.Id == id);     
        }

        public async Task Insert(Bus bus)
        {
            await context.Buses.AddAsync(bus);
            await context.SaveChangesAsync();
        }

        public async Task Update(Bus bus)
        {
            await context.SaveChangesAsync();
        }
    }
}
