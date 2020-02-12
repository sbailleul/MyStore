using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Common.Contracts;
using MyStore.Services.Contracts.State;
using MyStore.Services.Services;
using MyStore.Web.Framework;

namespace MyStore.Web.Controllers.Api
{
    /// <summary>Functionality relating to MyStore management.</summary>
    /// <seealso cref="StoreApiController" />
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/state")]
    public class StateController : StoreApiController
    {
        private readonly IStateService _addressService;

        public StateController(IStateService addressService)
        {
            _addressService = addressService;
        }

        /// <summary>Get all States.</summary>
        [HttpGet("", Name = "States_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<StateDto>))]
        public async Task<ActionResult<IList<StateDto>>> GetAsync([FromQuery] PagingOptions pagingOptions)
        {
            var result = await _addressService.GetAsync(UserId, pagingOptions);

            return Ok(result);
        }

        /// <summary>Get a an State by Id.</summary>
        [HttpGet("{id}", Name = "State_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<StateDto>))]
        public async Task<ActionResult<StateDto>> GetAsync(int id)
        {
            var result = await _addressService.GetAsync(UserId, id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
