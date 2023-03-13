using System.Data;
using Agumento.Core.Application.Features.ProjectFeatures.Commands;
using Agumento.Core.Application.Features.ProjectFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Augmento.Presentation.API.Controllers
{
    //[Route("api/v1/[controller]")]
    //[ApiController]
    public class ProjectController : BaseApiController
    {
        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> Create(CreateProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        
        /// <summary>
        /// Gets all Project.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProjectsQuery()));
        }

        /// <summary>
        /// Gets Project Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetProjectByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deletes Project Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteProjectByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> Update(Guid id, UpdateProjectCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
