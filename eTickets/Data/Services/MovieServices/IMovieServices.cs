using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services.MovieServices
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {

        public Task<Movie> GetMovieById(int id);

    }
}
