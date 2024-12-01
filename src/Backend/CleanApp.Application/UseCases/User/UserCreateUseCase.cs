using CleanApp.Communication.Requests;
using CleanApp.Communication.Responses;
using CleanApp.Exception;

namespace CleanApp.Application.UseCases.User;
public class UserCreateUseCase
{
    public ResponseUserCreateJson Execute(RequestUserCreateJson request)
    {
        return new ResponseUserCreateJson
        {
            Name = request.Name
        };

    }

    public void Validate(RequestUserCreateJson request)
    {
        var validator = new UserCreateValidator();
        var result = validator.Validate(request);
        if(result.IsValid == false)
        {
            var message = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(message);
        }
        
    }
}
