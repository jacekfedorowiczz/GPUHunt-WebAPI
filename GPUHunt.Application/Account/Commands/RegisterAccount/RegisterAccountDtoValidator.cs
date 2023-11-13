using FluentValidation;
using GPUHunt.Domain.Interfaces;
using GPUHunt.Models.DTOs.Acccount;

namespace GPUHunt.Application.Account.Commands.RegisterAccount
{
    public class RegisterAccountDtoValidator : AbstractValidator<RegisterAccountDto>
    {
        public RegisterAccountDtoValidator(IAccountRepository repository)
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Incorrect email format.");

            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Password cannot be shorter than 8 characters.");
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password).WithMessage("Passwords are not equal.");

            RuleFor(x => x.RoleId).GreaterThanOrEqualTo(1).WithMessage("Incorrect roleId value.");

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = repository.IsEmailInUse(value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "This email is already in use.");
                    }
                });

        }
    }
}
