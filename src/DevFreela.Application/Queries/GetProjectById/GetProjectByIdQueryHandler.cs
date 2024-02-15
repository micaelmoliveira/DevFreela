using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewRecord?>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetProjectByIdQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectDetailsViewRecord?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
                .AsNoTracking()
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (project is null) return null;

            return new ProjectDetailsViewRecord(
                        project.Id,
                        project.Title,
                        project.Description,
                        project.TotalCost,
                        project.StartedAt,
                        project.FinishedAt,
                        project.Client.FullName,
                        project.Freelancer.FullName);
        }
    }
}
