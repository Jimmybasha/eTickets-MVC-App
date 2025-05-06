using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services.CinemaServices
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context)
        {
        }
    }
}
