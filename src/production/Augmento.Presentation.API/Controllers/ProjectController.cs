using System.Data;
using Agumento.Core.Application.Features.ScheduleInterviewFeatures.Commands;
using Agumento.Core.Application.Features.ScheduleInterviewFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Augmento.Presentation.API.Controllers
{
    //[Route("api/v1/[controller]")]
    //[ApiController]
    public class ScheduleInterviewController : BaseApiController
    {
        /// <summary>
        /// Create a new ScheduleInterview
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> Create(CreateScheduleInterviewCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        
        /// <summary>
        /// Gets all ScheduleInterview.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllScheduleInterviewsQuery()));
        }

        /// <summary>
        /// Gets ScheduleInterview Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetScheduleInterviewByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deletes ScheduleInterview Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteScheduleInterviewByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        [Authorize(Roles = "Proj_Manager")]
        public async Task<IActionResult> Update(Guid id, UpdateScheduleInterviewCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
