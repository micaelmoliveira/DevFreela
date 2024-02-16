using DevFreela.API.Models;
using DevFreela.Application.Commands.UserCommand.CreateUser;
using DevFreela.Application.Commands.UserCommand.LoginUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var user = new GetUserQuery(id);

            await _mediator.Send(user);

            if (user is null) return NotFound();
            
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var loginUser = await _mediator.Send(command);

            if (loginUser is null) return NotFound("Usuário ou senha incorretos");

            return Ok(loginUser);
        }
    }
}
