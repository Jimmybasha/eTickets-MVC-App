using eTickets.Data;
using eTickets.Data.Services.CinemaServices;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemaController : Controller
    {

        private readonly ICinemaService cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await cinemaService.GetAllAsync();
            return View(cinemas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinema = await cinemaService.GetByIdAsync(id);
            return View(cinema);
        }

        //Get Method
        public async Task<IActionResult> Create()
        {
            return View();
        }


        //Post Method
        [HttpPost]
        public async Task<IActionResult> Create(Cinema newCinema)
        {
            if (!ModelState.IsValid) return View(newCinema);
            await cinemaService.AddAsync(newCinema);
            return RedirectToAction("Index");
        }


        //Get Method
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await cinemaService.GetByIdAsync(id);
            return View(cinema);
        }


        //Post Method
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Cinema newCinema)
        {
            if (!ModelState.IsValid) return View(newCinema);
            await cinemaService.UpdateAsync(id, newCinema);
            return RedirectToAction("Index");
        }





        //Get Method
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await cinemaService.GetByIdAsync(id);
            return View(cinema);
        }


        //Post Method
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await cinemaService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
