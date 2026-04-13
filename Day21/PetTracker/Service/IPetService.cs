using PetTracker.Models;

namespace PetTracker.Service
{
    public interface IPetService
    {
        void Add(PetViewModel pet);
        IEnumerable<PetViewModel> GetAll();
        IEnumerable<PetViewModel> GetBySpecies(string type);
        PetViewModel? GetById(int id);
        void Update(PetViewModel pet);
        void Delete(int id);
    }
}
