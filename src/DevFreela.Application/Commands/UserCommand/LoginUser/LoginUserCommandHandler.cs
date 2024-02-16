using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using static DevFreela.Application.ViewDTO.Views;

namespace DevFreela.Application.Commands.UserCommand.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserRecord?>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserRecord?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user is null) return null;

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserRecord(user.Email, token);

        }
    }
}
