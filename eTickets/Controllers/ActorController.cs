using eTickets.Data;
using eTickets.Data.Services.ActorServices;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService actorService;

        public ActorController(IActorService actorService)
        {
            this.actorService = actorService;
        }

        public async Task<IActionResult> Index()
        {
            var actors = await actorService.GetAllAsync();
             
            return View(actors);
        }


        //This one is the get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor newActor)
        {
            if (!ModelState.IsValid)
            {
            return View(newActor);
            }
            await actorService.AddAsync(newActor);
            //If success it'll return to the Index
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {

            var actorDetails = await actorService.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }


        //This one is the get
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await actorService.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Actor newActor)
        {
            if (!ModelState.IsValid)
            {
                return View(newActor);
            }
            await actorService.UpdateAsync(id,newActor);
            //If success it'll return to the Index
            return RedirectToAction(nameof(Index));
        }



        //This one is the get
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await actorService.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Action name used because we cant use the same function name
        //And same parameters
        //but when it is called it will be called with Delete as usual
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await actorService.DeleteAsync(id);
            //If success it'll return to the Index
            return RedirectToAction(nameof(Index));
        }
    }
}
