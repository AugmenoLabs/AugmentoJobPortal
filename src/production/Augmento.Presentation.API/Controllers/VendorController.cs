using Agumento.Core.Application.Features.VendorFeatures.Commands;
using Agumento.Core.Application.Features.VendorFeatures.Queries;
using Agumento.Core.Application.Features.VendorFeatures.Commands;
using Agumento.Core.Application.Features.VendorFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Augmento.Presentation.API.Controllers
{

    public class VendorController : BaseApiController
    {
        /// <summary>
        /// Create a new Vendor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> Create(CreateVendorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        
        /// <summary>
        /// Gets all Vendor.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllVendorsQuery()));
        }

        /// <summary>
        /// Gets Vendor Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetVendorByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deletes Vendor Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteVendorByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> Update(Guid id, UpdateVendorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
