using PetTracker.Models;

namespace PetTracker.Service
{
    public interface IPetService
    {
        void Add(Pet pet);
        IEnumerable<Pet> GetAll();
        IEnumerable<Pet> GetBySpecies(string type);
        Pet? GetById(int id);
        void Update(Pet pet);
        void Delete(int id);
    }
}
