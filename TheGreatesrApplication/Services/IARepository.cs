using TheGreatesrApplication.Models;

namespace TheGreatesrApplication.Services
{
    public interface IARepository : IRepository<Animal, int>
    {
        IList<Animal> GetAllByKindOfAnimalId(int id);
    }
}
