using PetTracker.Models;

namespace PetTracker.Service
{
    public interface IPetService
    {
        void Add(PetViewModel pet);
        IEnumerable<PetViewModel> GetAll();
        IEnumerable<PetViewModel> GetByType(string type);
    }
}
