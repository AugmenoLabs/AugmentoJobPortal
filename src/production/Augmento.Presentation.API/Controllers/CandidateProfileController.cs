using Agumento.Core.Application.Features.CandidateProfileFeatures.Commands;
using Agumento.Core.Application.Features.CandidateProfileFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Augmento.Presentation.API.Controllers
{
    public class CandidateProfileController : BaseApiController
    {
        /// <summary>
        /// Creates a New CandidateProfile.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCandidateProfileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all CandidateProfile.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCandidateProfileQuery()));
        }

        [HttpGet]
        [Route("CandidateProfileSchedule")]
        public async Task<IActionResult> GetAllSchedule()
        {
            return Ok(await Mediator.Send(new GetAllCandidateScheduleProfileQuery()));
        }

        /// <summary>
        /// Gets Candidateprofile Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetCandidateProfileByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deletes CandidateProfile Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteCandidateProfileByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(Guid id, UpdateCandidateProfileCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
