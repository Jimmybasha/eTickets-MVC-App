using eTickets.Data;
using eTickets.Data.Services.ProducerServices;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {

        private readonly IProducerService producerService;

        public ProducerController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var producers = await producerService.GetAllAsync();
            return View(producers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var producer = await producerService.GetByIdAsync(id);
            if (producer == null) return View("NotFound");
            return View(producer);
        }


        //The Get Method
        public IActionResult Create()
        {
            return View();
        }

        //The Post Method
        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
          if (!ModelState.IsValid) return View(producer);
          await producerService.AddAsync(producer);
          return RedirectToAction("Index");
        }

        //The Get Method
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await producerService.GetByIdAsync(id);
            if (producer == null) return View("NotFound");
            return View(producer);
        }

        //The Post Method
        [HttpPost]
        public async Task<IActionResult> Edit(int id , Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            if(id == producer.Id)
            {
                await producerService.UpdateAsync(id, producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }


        //The Get Method
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await producerService.GetByIdAsync(id);
            if (producer == null) return View("NotFound");
            return View(producer);
        }

        //The Post Method
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
                await producerService.DeleteAsync(id);
                return RedirectToAction("Index");
        }
    } 
}
