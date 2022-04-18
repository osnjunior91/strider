using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nivello.Lib.Nivello.Application;
using Strider.Domain.Commands.User.Commands;
using Strider.Domain.Queries.Post.Queries;
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
            => ReturnCommandApi(await _mediator.Send(command));

        [HttpPost]
        [Route("unfollow")]
        public async Task<IActionResult> UnFollowAsync([FromBody] UnfollowCommand command) 
            => ReturnCommandApi(await _mediator.Send(command));

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id) 
            => ReturnQueryApi(await _mediator.Send(new GetUserByIdQuery(id)));

        [HttpGet]
        [Route("myposts/{id}")]
        public async Task<IActionResult> GetPostsByIdAsync(Guid id, [FromQuery] int page)
            => ReturnQueryApi(await _mediator.Send(new GetUserLastPostsQuery(id, page, 5)));


        [HttpGet]
        [Route("{userId}/follower/{followerId}")]
        public async Task<IActionResult> GetPostsByIdAsync(Guid userId, Guid followerId)
            => ReturnQueryApi(await _mediator.Send(new VerifyExistFollowerQuery(userId, followerId)));

    }
}
