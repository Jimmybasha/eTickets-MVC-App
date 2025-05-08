using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eTickets.Data.Services.MovieServices
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieViewModelAsync(NewMovieViewModel data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                CinemaId = data.CinemaId,
                Description = data.Description,
                EndDate = data.EndDate,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                ProducerId = data.ProducerId,
                Price = data.Price,
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var actorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId,

                };

                await _context.Actors_Movies.AddAsync(actorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.MovieActors).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
            return movieDetails!;
        }

        public async Task<NewMovieDropdownsViewModel> GetNewMovieDropDownsValues()
        {
            var response = new NewMovieDropdownsViewModel();

            response.Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync();

            response.Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync();

            response.Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync();

            return response;
        }

        public async Task UpdateMovieVMAsync(NewMovieViewModel data)
        {


            var dbMovie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Id = data.Id;
                dbMovie.Name = data.Name;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.Description = data.Description;
                dbMovie.EndDate = data.EndDate;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.StartDate = data.StartDate;
                dbMovie.ProducerId = data.ProducerId;
                dbMovie.Price = data.Price;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors

            var existingDbActors = await _context.Actors_Movies.Where(n=>n.MovieId == data.Id).ToListAsync();
            _context.Actors_Movies.RemoveRange(existingDbActors);
            await _context.SaveChangesAsync();


            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var actorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId,

                };

                await _context.Actors_Movies.AddAsync(actorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
