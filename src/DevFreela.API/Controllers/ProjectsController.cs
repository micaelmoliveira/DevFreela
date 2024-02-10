using DevFreela.API.Models;
using DevFreela.Application.InputDTO;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static DevFreela.Application.InputDTO.Inputs;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if(project is null) return NotFound();
            
            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post(NewProjectInputRecord input)
        {
            if(input.Title.Length > 50)
            {
                return BadRequest();
            }
            var id = _projectService.Create(input);

            return CreatedAtAction(nameof(GetById), new { id }, input);
        }

        [HttpPut]
        public IActionResult Put(UpdateProjectInputRecord input)
        {
            if(input.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectService.Update(input);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);

            return NoContent();
        }

        [HttpPost("comments")]
        public IActionResult PostComment(CreateCommentInputRecord input)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
