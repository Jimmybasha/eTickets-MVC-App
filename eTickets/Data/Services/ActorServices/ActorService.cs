using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services.ActorServices
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {
        public ActorService(AppDbContext context) : base(context)
        {
        }
    }
}
