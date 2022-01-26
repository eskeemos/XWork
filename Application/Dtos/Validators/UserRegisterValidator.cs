using Application.Dtos.UserDtos;
using FluentValidation;
using Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidator(Context context)
        {
            RuleFor(x => x.Email)
                .Custom((v, c) =>
                {
                    if(context.User.Any(x => x.Email == v))
                    {
                        c.AddFailure("Email", "This email is already in use");
                    }
                });
        }
    }
}
