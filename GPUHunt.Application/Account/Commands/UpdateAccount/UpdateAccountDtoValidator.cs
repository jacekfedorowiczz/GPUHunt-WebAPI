using FluentValidation;
using GPUHunt.Models.DTOs.Acccount;

namespace GPUHunt.Application.Account.Commands.UpdateAccount
{
    public class UpdateAccountDtoValidator : AbstractValidator<UpdateAccountDto>
    {
        public UpdateAccountDtoValidator()
        {
            RuleFor(x => x.NewPassword).MinimumLength(8).WithMessage("Password cannot be shorter than 8 characters.");    
        }
    }
}
