using FluentValidation;
using LibraryProject.Core.Features.UserFeature.Commands.Requests;
using LibraryProject.Services.Services.UserService;

namespace LibraryProject.Core.Features.UserFeature.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IUserService _userService;
        public AddStudentValidator(IUserService userService)
        {
            ApplyValidationsRoles();
            ApplyCustomValidationsRoles();
            _userService = userService;
        }

        public void ApplyValidationsRoles()
        {
            _ = RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be not Empty")
                            .NotNull().WithMessage("Name must be not Null")
                            .MaximumLength(10).WithMessage("Max length must be 10 ");

            _ = RuleFor(x => x.Email).NotEmpty().WithMessage("Email must be not Empty")
                .NotNull().WithMessage("Email must be not Null")
                .MaximumLength(20).WithMessage("Max length must be 20 ");
        }

        public void ApplyCustomValidationsRoles()
        {
            _ = RuleFor(x => x.Email).MustAsync(async (key, CancellationToken) => !await _userService.IsEmailExsistAsync(key))
                .WithMessage("Email is Exsist validation");
        }
    }
}
