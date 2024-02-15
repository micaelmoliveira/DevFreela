using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewRecord>>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillViewRecord>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
           return await GetAllSkills().Select(s => new SkillViewRecord(s.Id, s.Description)).ToListAsync();
        }

        private IQueryable<Skill> GetAllSkills()
        {
            return _dbContext.Skills.AsNoTracking();

        }
    }
}
