using DevFreela.Application.Commands.ProjectCommand.CreateComment;
using DevFreela.Application.Commands.ProjectCommand.CreateProject;
using DevFreela.Application.Commands.ProjectCommand.DeleteProject;
using DevFreela.Application.Commands.ProjectCommand.FinishProject;
using DevFreela.Application.Commands.ProjectCommand.StartProject;
using DevFreela.Application.Commands.ProjectCommand.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = new GetProjectByIdQuery(id);

            await _mediator.Send(project);

            if(project is null) return NotFound();
            
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("comments")]
        public async Task<IActionResult> PostComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);  

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
