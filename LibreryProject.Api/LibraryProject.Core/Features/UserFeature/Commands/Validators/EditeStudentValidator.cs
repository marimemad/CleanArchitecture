using FluentValidation;
using LibraryProject.Core.Features.UserFeature.Commands.Requests;
using LibraryProject.Services.Services.UserService;

namespace LibraryProject.Core.Features.UserFeature.Commands.Validators
{
    public class EditeStudentValidator : AbstractValidator<EditeUserCommand>
    {
        private readonly IUserService _userService;
        public EditeStudentValidator(IUserService userService)
        {
            ApplyValidationsRoles();
            ApplyCustomValidationsRoles();
            _userService = userService;
        }

        public void ApplyValidationsRoles()
        {
            _ = RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be not Empty")
                            .NotNull().WithMessage("Name must be not Null")
                            .MaximumLength(100).WithMessage("Max length must be 10 ");

            _ = RuleFor(x => x.Email).NotEmpty().WithMessage("Email must be not Empty")
                .NotNull().WithMessage("Email must be not Null")
                .MaximumLength(200).WithMessage("Max length must be 20 ");
        }

        public void ApplyCustomValidationsRoles()
        {
            _ = RuleFor(x => x.Email).MustAsync(async (model, key, CancellationToken) => !await _userService.IsEmailExsistExcludeSelfAsync(key, model.UserID))
                .WithMessage("Email is Exsist validation");
        }
    }
}
