﻿using Agumento.Core.Application.Features.OpenPositionFeatures.Commands;
using Agumento.Core.Application.Features.OpenPositionFeatures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Augmento.Presentation.API.Controllers
{
    public class OpenPositionController : BaseApiController
    {
        /// <summary>
        /// Creates a New OpenPosition.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateOpenPositionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all OpenPosition.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllOpenPositionsQuery()));
        }

        /// <summary>
        /// Gets all OpenPositions report.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OpenPositionsReport")]
        public async Task<IActionResult> GetAllOpenPositionsReport(int PageNumber, int PageSize) 
        {
            return Ok(await Mediator.Send(new GetAllOpenPositionsReportQuery { PageNumber = PageNumber, PageSize = PageSize }));
        }

        /// <summary>
        /// Gets OpenPosition Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetAllOpenPositionsByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deletes JobOpening Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteOpenPositionByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(Guid id, UpdateOpenPositionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Returns open position details for screening
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        [HttpGet("OpenPositionScreeningReport/{positionId}")]
        public async Task<IActionResult> GetAllOpenPositionScreeningReport(Guid positionId)
        {
            return Ok(await Mediator.Send(new GetOpenPositionScreeningQuery { Id = positionId }));
        }

        [HttpGet("WorkflowDetails/{openPositionId}")]
        public async Task<IActionResult> GetAllWorkflowDetails(Guid openPositionId)
        {
            return Ok(await Mediator.Send(new GetOpenPositionWorkflowDetailsQuery { OpenPositionId = openPositionId }));
        }
    }
}
