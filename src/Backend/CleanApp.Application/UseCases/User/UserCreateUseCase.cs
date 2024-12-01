using CleanApp.Application.Services.Cryptography;
using CleanApp.Application.Services.Mapping;
using CleanApp.Communication.Requests;
using CleanApp.Communication.Responses;
using CleanApp.Exception;

namespace CleanApp.Application.UseCases.User;
public class UserCreateUseCase
{
    public ResponseUserCreateJson Execute(RequestUserCreateJson request)
    {
        var crypto = new PasswordEncoder();
        var mapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());

            }).CreateMapper();

        Validate(request);
        var user = mapper.Map<Domain.Entities.User>(request);

        user.Password = crypto.Encrypt(request.Password);

        return new ResponseUserCreateJson
        {
            Name = request.Name
        };

    }

    private void Validate(RequestUserCreateJson request)
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
