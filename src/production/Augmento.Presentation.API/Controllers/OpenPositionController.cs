﻿using System.Data;
using Agumento.Core.Application.Features.OpenPositionFeatures.Commands;
using Agumento.Core.Application.Features.OpenPositionFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> Create(CreateOpenPositionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all OpenPosition.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "HR")]
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
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> GetAllOpenPositionsReport()
        {
            return Ok(await Mediator.Send(new GetAllOpenPositionsReportQuery()));
        }

        /// <summary>
        /// Gets OpenPosition Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "HR")]
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
        [Authorize(Roles = "HR")]
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
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> Update(Guid id, UpdateOpenPositionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
