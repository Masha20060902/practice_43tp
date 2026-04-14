using PetTracker.DbPets;
using PetTracker.Models;

namespace PetTracker.Service
{
    public class PetService : IPetService
    {

        private readonly AppDbContext _context;

        public PetService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null) return;

            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }

        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets.ToList();
        }

        public Pet? GetById(int id)
        {
            return _context.Pets.Find(id);
        }

        public IEnumerable<Pet> GetBySpecies(string species)
        {
            return _context.Pets
                           .Where(p => p.Species == species)
                           .ToList();
        }

        public void Update(Pet pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }
    }
}
