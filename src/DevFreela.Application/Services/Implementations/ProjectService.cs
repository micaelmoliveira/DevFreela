using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using static DevFreela.Application.InputDTO.Inputs;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        public int Create(NewProjectInputRecord input)
        {
            var project = new Project(input.Title, input.Description, input.ClientId, input.FreelancerId, input.TotalCost);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputRecord input)
        {
            var comment = new ProjectComment(input.Content, input.ProjectId, input.UserId);
        }

        public void Delete(int id)
        {
            var project = new Project("teste","teste",1,1,600);

            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = new Project("teste", "teste", 1, 1, 600);

            project.Finish();
        }

        public List<ProjectViewRecord> GetAll(string query)
        {
            var projects = new List<Project>()
            {
                new Project("teste", "teste", 1, 1, 600),
                new Project("teste2", "teste2", 1, 1, 600)
            };

            return projects.Select(p => new ProjectViewRecord(p.Id, p.Title, p.CreatedAt)).ToList();
        }

        public ProjectDetailsViewRecord? GetById(int id)
        {
            var project = new Project("teste", "teste", 1, 1, 600);

            if (project is null) return null;

            return new ProjectDetailsViewRecord(
                project.Id, 
                project.Title, 
                project.Description, 
                project.TotalCost,
                project.StartedAt, 
                project.FinishedAt);
        }

        public void Start(int id)
        {
            var project = new Project("teste", "teste", 1, 1, 600);

            project.Start();
        }

        public void Update(UpdateProjectInputRecord input)
        {
            var project = new Project("teste", "teste", 1, 1, 600);
        }
    }
}
