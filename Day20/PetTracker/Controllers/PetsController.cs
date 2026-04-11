using Microsoft.AspNetCore.Mvc;
using PetTracker.Models;
using PetTracker.Service;

namespace PetTracker.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        public IActionResult Index(string? type)
        {
            var pets = string.IsNullOrEmpty(type)
                ? _petService.GetAll()
                : _petService.GetByType(type);

            ViewBag.Type = type;
            return View(pets);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new PetViewModel());
        }
        [HttpPost]
        public IActionResult Create(PetViewModel pet)
        {
            if (!ModelState.IsValid)
                return View(pet);

            _petService.Add(pet);

            ViewBag.Message = "Питомец добавлен";
            return View(new PetViewModel());
        }
        public IActionResult Age(int id)
        { 
            return NotFound();
        }
    }
}
