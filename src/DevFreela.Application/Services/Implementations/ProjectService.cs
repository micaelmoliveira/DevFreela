using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using static DevFreela.Application.InputDTO.Inputs;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewProjectInputRecord input)
        {
            var project = new Project(input.Title, input.Description, input.IdClient, input.IdFreelancer, input.TotalCost);

            _dbContext.Projects.Add(project);
            
            _dbContext.SaveChanges();
            
            return project.Id;
        }

        public void CreateComment(CreateCommentInputRecord input)
        {
            var comment = new ProjectComment(input.Content, input.ProjectId, input.IdUser);

            _dbContext.ProjectComments.Add(comment);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.AsNoTracking().FirstOrDefault(p => p.Id == id);

            project.Cancel();

            _dbContext.SaveChanges();

        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.AsNoTracking().FirstOrDefault(p => p.Id == id);

            project.Finish();

            _dbContext.SaveChanges();
        }

        public List<ProjectViewRecord> GetAll(string query)
        {
            var projects = _dbContext.Projects.AsNoTracking();

            return projects.Select(p => new ProjectViewRecord(p.Id, p.Title, p.CreatedAt)).ToList();
        }

        public ProjectDetailsViewRecord? GetById(int id)
        {
            var project = _dbContext.Projects
                .AsNoTracking()
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .FirstOrDefault(p => p.Id == id);

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

        public void Start(int id)
        {
            var project = _dbContext.Projects.AsNoTracking().FirstOrDefault(p => p.Id == id);

            project.Start();

            _dbContext.SaveChanges();
        }

        public void Update(UpdateProjectInputRecord input)
        {
            var project = _dbContext.Projects.AsNoTracking().SingleOrDefault(p => p.Id == input.Id);

            project.Update(input.Title, input.Description, input.TotalCost);

            _dbContext.SaveChanges();

        }
    }
}
