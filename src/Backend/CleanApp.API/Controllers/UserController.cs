using CleanApp.Application.UseCases.User;
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
        var usecase = new UserCreateUseCase();
        var response = usecase.Execute(request);
        return Created(string.Empty, response);
    }
}
