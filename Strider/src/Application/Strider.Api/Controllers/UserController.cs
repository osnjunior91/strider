using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nivello.Lib.Nivello.Application;
using Strider.Domain.Commands.User.Commands;
using Strider.Domain.Queries.Users.Queries;
using System;
using System.Threading.Tasks;

namespace Strider.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBaseAPI
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
             return ReturnCommandApi(await _mediator.Send(command));
        }

        [HttpPost]
        [Route("unfollow")]
        public async Task<IActionResult> UnFollowAsync([FromBody] UnfollowCommand command)
        {
            return ReturnCommandApi(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return ReturnQueryApi(await _mediator.Send(new GetUserByIdQuery(id)));
        }
    }
}
