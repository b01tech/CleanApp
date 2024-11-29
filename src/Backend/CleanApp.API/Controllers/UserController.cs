using CleanApp.Communication;
using Microsoft.AspNetCore.Mvc;

namespace CleanApp.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUserCreateJson), StatusCodes.Status201Created)]
    public IActionResult Create(RequestUserCreateJson request)
    {
        return Created();
    }
}
