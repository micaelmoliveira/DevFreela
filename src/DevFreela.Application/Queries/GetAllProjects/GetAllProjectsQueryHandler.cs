using DevFreela.Core.Repositories;
using MediatR;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewRecord>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectViewRecord>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();

            return projects
                .Select(p => new ProjectViewRecord(p.Id, p.Title, p.CreatedAt))
                .ToList();
        }
    }
}
