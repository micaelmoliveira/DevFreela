using Azure.Core;
using DevFreela.Application.ViewModels;
using DevFreela.Infra.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    internal class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel?>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetProjectByIdHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectDetailsViewModel?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            if (project is null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }
    }
}
