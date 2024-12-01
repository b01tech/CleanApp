using CleanApp.Application.UseCases.User;
using CleanApp.Communication.Requests;
using CleanApp.Communication.Responses;
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
        usecase.Validate(request);
        var response = usecase.Execute(request);
        return Created(string.Empty, response);
    }
}
