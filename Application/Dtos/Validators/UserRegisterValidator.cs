using Application.Dtos.AccountDtos;
using FluentValidation;
using Infrastucture.Data;
using System.Linq;

namespace Application.Dtos.Validators
{
    public class UserRegisterValidator : AbstractValidator<AccountRegister>
    {
        public UserRegisterValidator(Context context)
        {
            RuleFor(x => x.Email)
                .Custom((v, c) =>
                {
                    if(context.Account.Any(x => x.Email == v))
                    {
                        c.AddFailure("Email", "This email is already in use");
                    }
                });
        }
    }
}
