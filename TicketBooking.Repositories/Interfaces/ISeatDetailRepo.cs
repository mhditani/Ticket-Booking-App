using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Entities;

namespace TicketBooking.Repositories.Interfaces
{
    public interface ISeatDetailRepo
    {
        Task<IEnumerable<BusSeatDetail>> GetAll();

        Task<BusSeatDetail> GetById(int id);

        Task Insert(BusSeatDetail busSeatDetail);

        Task Update(BusSeatDetail busSeatDetail);

        Task Delete (BusSeatDetail busSeatDetail);
    }
}
