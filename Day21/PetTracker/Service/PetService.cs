using PetTracker.Models;

namespace PetTracker.Service
{
    public class PetService : IPetService
    {
        private static readonly List<PetViewModel> _pets = new();
        private static int _nextId = 1;
        public void Add(PetViewModel pet)
        {
            pet.Id = _nextId++;
            _pets.Add(pet);
        }

        public void Delete(int id)
        {
            var pet = GetById(id);
            if (pet != null)
                _pets.Remove(pet);
        }

        public IEnumerable<PetViewModel> GetAll()
        {
            return _pets;
        }

        public PetViewModel? GetById(int id)
        {
            return _pets.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<PetViewModel> GetBySpecies(string species)
        {
            return _pets.Where(p => p.Species == species);
        } 

        public void Update(PetViewModel pet)
        {
            var existing = GetById(pet.Id);
            if (existing == null) return;

            existing.Name = pet.Name;
            existing.Species = pet.Species;
            existing.BirthDate = pet.BirthDate;
            existing.Notes = pet.Notes;
        }
    }
}
