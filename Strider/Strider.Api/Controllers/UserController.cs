using MediatR;
using Microsoft.AspNetCore.Mvc;
using Strider.Domain.Commands.User.Commands;
using Strider.Domain.Queries.Users.Queries;
using System;
using System.Threading.Tasks;

namespace Strider.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("follow")]
        public async Task<IActionResult> FollowAsync([FromBody] FollowCommand command)
        {
            var result = _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = _mediator.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }


    }
}
