using DevFreela.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewRecord?>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDetailsViewRecord?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

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
