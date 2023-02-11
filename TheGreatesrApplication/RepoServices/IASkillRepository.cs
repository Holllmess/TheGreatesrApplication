using TheGreatesrApplication.Models;

namespace TheGreatesrApplication.Services
{
    public interface IASkillRepository : IRepository<ASkills, int>
    {
        IList<ASkills> GetAllByAnimalId(int id);
        IList<ASkills> GetAllBySkillId(int id);
    }
}
