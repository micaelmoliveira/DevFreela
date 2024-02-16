using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Commands.UserCommand.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserRecord>
    {
        public string Email { get;  set; }
        public string Password { get;  set; }
    }
}
