using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewRecord>>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetAllProjectsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjectViewRecord>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await GetAllProjects().Select(p => new ProjectViewRecord(p.Id, p.Title, p.CreatedAt)).ToListAsync();
        }

        private IQueryable<Project> GetAllProjects()
        {
            return _dbContext.Projects.AsNoTracking();
        }
    }
}
