using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        public List<SkillViewRecord> GetAll()
        {
            var skills = new List<Skill>();

            return skills.Select(s => new SkillViewRecord(s.Id, s.Description)).ToList();
        }
    }
}
