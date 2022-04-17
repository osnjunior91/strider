using Microsoft.AspNetCore.Mvc;
using Strider.Lib.Strider.Lib.Domain.Commands;
using Strider.Lib.Strider.Lib.Domain.Queries;

namespace Nivello.Lib.Nivello.Application
{
    [ApiController]
    public abstract class ControllerBaseAPI : Controller
    {
        protected IActionResult ReturnCommandApi(CommandResult commandResult)
        {
            if (commandResult.Success)
                return Ok(commandResult);
            else
                return StatusCode(400, commandResult);
        }

        protected IActionResult ReturnQueryApi(QueryResult queryResult)
        {
            if (queryResult.Success)
                return Ok(queryResult);
            else
                return StatusCode(400, queryResult);
        }

    }
}