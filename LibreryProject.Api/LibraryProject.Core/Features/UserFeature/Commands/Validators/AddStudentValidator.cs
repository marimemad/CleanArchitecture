using FluentValidation;
using LibraryProject.Core.Features.UserFeature.Commands.Requests;
using LibraryProject.Core.Shared;
using LibraryProject.Services.Services.UserService;
using Microsoft.Extensions.Localization;

namespace LibraryProject.Core.Features.UserFeature.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public AddStudentValidator(IUserService userService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            ApplyValidationsRoles();
            ApplyCustomValidationsRoles();
            _userService = userService;
            _stringLocalizer = stringLocalizer;
        }

        public void ApplyValidationsRoles()
        {
            _ = RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name " + _stringLocalizer[SharedResourcesKeys.Empty])
                            .NotNull().WithMessage("Name " + _stringLocalizer[SharedResourcesKeys.Require])
                            .MaximumLength(10).WithMessage("Max length must be 10 ");
            RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name " + _stringLocalizer[SharedResourcesKeys.Empty])
                            .NotNull().WithMessage("Name " + _stringLocalizer[SharedResourcesKeys.Require])
                            .MaximumLength(10).WithMessage("Max length must be 10 ");

            _ = RuleFor(x => x.Email).NotEmpty().WithMessage("Email " + _stringLocalizer[SharedResourcesKeys.Empty])
                .NotNull().WithMessage("Email " + _stringLocalizer[SharedResourcesKeys.Require])
                .MaximumLength(20).WithMessage("Max length must be 20 ");
        }

        public void ApplyCustomValidationsRoles()
        {
            _ = RuleFor(x => x.Email).MustAsync(async (key, CancellationToken) => !await _userService.IsEmailExsistAsync(key))
                .WithMessage("Email is Exsist validation");
        }
    }
}
