using eTickets.Data;
using eTickets.Data.Services.MovieServices;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            var movies = await movieService.GetAllAsync(n => n.Cinema);
            return View(movies);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await movieService.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower())
                || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
            return View("Index",filteredResult);
            }
            return View("Index",allMovies);
        }


        public async Task<IActionResult> Details(int id)
        {
            var movies = await movieService.GetMovieById(id);
            return View(movies);
        }


        public async Task<IActionResult> Create()
        {

            var DropDownData = await movieService.GetNewMovieDropDownsValues();
            //Pass Data 
            ViewBag.Cinemas = new SelectList(DropDownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(DropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new MultiSelectList(DropDownData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieViewModel newMovie)
        {

            if (!ModelState.IsValid)
            {
                var DropDownData = await movieService.GetNewMovieDropDownsValues();
                //Pass Data 
                ViewBag.Cinemas = new SelectList(DropDownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(DropDownData.Producers, "Id", "FullName");
                ViewBag.Actors = new MultiSelectList(DropDownData.Actors, "Id", "FullName");
                return View(newMovie);
            }

            await movieService.AddNewMovieViewModelAsync(newMovie);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {

            var movieDetails = await movieService.GetMovieById(id);
            if (movieDetails is null) return View("NotFound");


            var response = new NewMovieViewModel()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.MovieActors.Select(N => N.ActorId).ToList(),

            };

            var DropDownData = await movieService.GetNewMovieDropDownsValues();
            //Pass Data 
            ViewBag.Cinemas = new SelectList(DropDownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(DropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new MultiSelectList(DropDownData.Actors, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieViewModel newMovie)
        {

            if (id != newMovie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var DropDownData = await movieService.GetNewMovieDropDownsValues();
                //Pass Data 
                ViewBag.Cinemas = new SelectList(DropDownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(DropDownData.Producers, "Id", "FullName");
                ViewBag.Actors = new MultiSelectList(DropDownData.Actors, "Id", "FullName");
                return View(newMovie);
            }

            await movieService.UpdateMovieVMAsync(newMovie);
            return RedirectToAction("Index");

        }





    }
}
