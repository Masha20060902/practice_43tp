using Microsoft.AspNetCore.Mvc;
using PetTracker.Models;

namespace PetTracker.Controllers
{
    public class PetsController : Controller
    {
        public static List<Pet> pets = new List<Pet>();
        public IActionResult Index()
        {
            return View(pets);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pet pet)
        {
            if (!ModelState.IsValid)
                return View(pet);

            pet.Id = pets.Count == 0 ? 1 : pets.Max(p => p.Id) + 1;
            pets.Add(pet);

            return RedirectToAction("Index");
        }
        public IActionResult Age(int id)
        {
            var pet = pets.FirstOrDefault(p => p.Id == id);
            if (pet == null)
                return NotFound();

            var age = DateTime.Today.Year - pet.Birthday.Year;
            if (pet.Birthday.Date > DateTime.Today.AddYears(-age))
                age--;

            ViewBag.Pet = pet;
            ViewBag.Age = age;
            return View();
        }
    }
}
