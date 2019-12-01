using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using slack.Domain.Commands;

namespace slack.Api.Controllers
{
    public class SlackController : Controller
    {
        private readonly IMediator _mediator;

        public SlackController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpGet("ouvintes/{CpfOuEmail}")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> Get([FromRoute]SlackCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

        [HttpPost("ouvinte")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostOuvinte([FromBody]SlackCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}