using static DevFreela.Application.InputDTO.Inputs;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewRecord> GetAll(string query);
        ProjectDetailsViewRecord GetById(int id);
        int Create(NewProjectInputRecord input);
        void Update(UpdateProjectInputRecord input);
        void Delete(int id);
        void CreateComment(CreateCommentInputRecord input);
        void Start(int id);
        void Finish(int id);
    }
}
