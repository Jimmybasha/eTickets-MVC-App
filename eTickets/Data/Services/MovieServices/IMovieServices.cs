using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services.MovieServices
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {

        public Task<Movie> GetMovieById(int id);

        public Task<NewMovieDropdownsViewModel> GetNewMovieDropDownsValues();
        public Task AddNewMovieViewModelAsync(NewMovieViewModel newMovie);
        public Task UpdateMovieVMAsync(NewMovieViewModel newMovie);


    }
}
