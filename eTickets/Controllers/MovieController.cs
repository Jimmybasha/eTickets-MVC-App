using eTickets.Data;
using eTickets.Data.Services.MovieServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await movieService.GetAllAsync(n=>n.Cinema);
            return View(movies);
        }

        public async Task<IActionResult> Details(int id )
        {
            var movies = await movieService.GetMovieById(id);
            return View(movies);
        }
    }
}
