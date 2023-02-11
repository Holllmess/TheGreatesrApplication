using TheGreatesrApplication.Models;

namespace TheGreatesrApplication.Services
{
    public interface ISkillRepository : IRepository<Skills, int>
    {
        IList<Skills> GetAllByAnimalKindId(int id);
    }
}
