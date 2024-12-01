using FluentValidation;
using CleanApp.Exception;
using CleanApp.Communication.Requests;

namespace CleanApp.Application.UseCases.User
{
    public class UserCreateValidator : AbstractValidator<RequestUserCreateJson>
    {
        public UserCreateValidator()
        {
            RuleFor(_ => _.Name).NotEmpty().WithMessage(ResourceExceptionMessages.NAME_EMPTY);
            RuleFor(_ => _.Email).NotEmpty().WithMessage(ResourceExceptionMessages.EMAIL_EMPTY);
            RuleFor(_ => _.Email).EmailAddress().WithMessage(ResourceExceptionMessages.EMAIL_INVALID);
            RuleFor(_ => _.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceExceptionMessages.PASSWORD_INVALID);
        }

    }
}
