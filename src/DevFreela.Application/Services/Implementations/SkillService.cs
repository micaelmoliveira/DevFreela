using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SkillViewRecord> GetAll()
        {
            var skills = _dbContext.Skills.AsNoTracking();

            return skills.Select(s => new SkillViewRecord(s.Id, s.Description)).ToList();
        }
    }
}
