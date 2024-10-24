using FluentValidation;
using MyApp.Application.DTOs.User;

namespace MyApp.Application.Validators {
    public  class UserValidator : AbstractValidator<CreateUserDto>{
        public UserValidator(){
            RuleFor(x => x.First_name).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.Last_name).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
        }
    }
}