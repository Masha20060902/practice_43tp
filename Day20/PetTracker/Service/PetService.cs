using PetTracker.Models;

namespace PetTracker.Service
{
    public class PetService : IPetService
    {
        private static readonly List<PetViewModel> _pets = new List<PetViewModel>();
        public void Add(PetViewModel pet)
        {
            _pets.Add(pet);
        }

        public IEnumerable<PetViewModel> GetAll()
        {
            return _pets;
        }

        public IEnumerable<PetViewModel> GetByType(string type)
        {
            return _pets.Where(p => p.Type == type);
        }
    }
}
