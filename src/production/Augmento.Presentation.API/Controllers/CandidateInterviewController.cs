using System.Data;
using Agumento.Core.Application.Features.CandidateInterviewFeatures.Commands;
using Agumento.Core.Application.Features.CandidateInterviewFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Augmento.Presentation.API.Controllers
{
    public class CandidateInterviewController : BaseApiController
    {
        /// <summary>
        /// Creates a New CandidateInterview.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "interviewr")]
        public async Task<IActionResult> Create(CreateCandidateInterviewCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all CandidateInterviews.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "interviewr")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCandidateInterviewsQuery()));
        }

        /// <summary>
        /// Gets Accounr Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "interviewr")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetCandidateInterviewByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deletes CandidateInterview Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "interviewr")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteCandidateInterviewByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        [Authorize(Roles = "interviewr")]
        public async Task<IActionResult> Update(Guid id, UpdateCandidateInterviewCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}