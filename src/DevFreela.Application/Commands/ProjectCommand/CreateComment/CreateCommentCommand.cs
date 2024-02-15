using MediatR;

namespace DevFreela.Application.Commands.ProjectCommand.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; } = string.Empty;
        public int IdProject { get; set; }
        public int IdUser { get; set; }

    }
}
