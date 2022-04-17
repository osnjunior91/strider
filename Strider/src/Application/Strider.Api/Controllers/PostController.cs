using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nivello.Lib.Nivello.Application;
using Strider.Domain.Commands.Post.Commands;
using Strider.Domain.Queries.Post.Queries;
using System.Threading.Tasks;

namespace Strider.Api.Controllers
{
    [Route("api/v1/post")]
    [ApiController]
    public class PostController : ControllerBaseAPI 
    {
        public IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostCommand command)
        {
            return ReturnCommandApi(await _mediator.Send(command));
        }

        [HttpPost]
        [Route("repost")]
        public async Task<IActionResult> RePost([FromBody] CreateRepostCommand command)
        {
            return ReturnCommandApi(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ReturnQueryApi(await _mediator.Send(new GetAllPostsQuery()));
        }
    }
}
