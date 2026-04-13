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
        public IActionResult Index(string? species)
        {
            var pets = string.IsNullOrEmpty(species)
                ? _petService.GetAll()
                : _petService.GetBySpecies(species);

            ViewBag.Species = species;
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
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pet = _petService.GetById(id);
            if (pet == null)
                return NotFound();

            return View(pet);
        }
        [HttpPost]
        public IActionResult Edit(PetViewModel pet)
        {
            if (!ModelState.IsValid)
                return View(pet);

            _petService.Update(pet);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var pet = _petService.GetById(id);
            if (pet == null)
                return NotFound();

            return View(pet);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _petService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Age(int id)
        {
            var pet = _petService.GetById(id);
            if (pet == null)
                return NotFound();

            int age = CalculateAge(pet.BirthDate);

            ViewBag.Pet = pet;
            ViewBag.Age = age;

            return View();
        }
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
                age--;
            return age < 0 ? 0 : age;
        }
    }
}
