using FluentValidation;
using LibraryProject.Core.Features.UserFeature.Commands.Requests;
using LibraryProject.Core.Shared;
using LibraryProject.Services.Services.UserService;
using Microsoft.Extensions.Localization;

namespace LibraryProject.Core.Features.UserFeature.Commands.Validators
{
    public class EditeStudentValidator : AbstractValidator<EditeUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public EditeStudentValidator(IUserService userService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            ApplyValidationsRoles();
            ApplyCustomValidationsRoles();
            _userService = userService;
            _stringLocalizer = stringLocalizer;
        }

        public void ApplyValidationsRoles()
        {
            _ = RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name " + _stringLocalizer[SharedResourcesKeys.Empty])
                            .NotNull().WithMessage("Name " + _stringLocalizer[SharedResourcesKeys.Require])
                            .MaximumLength(100).WithMessage("Max length must be 10 ");
            _ = RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name " + _stringLocalizer[SharedResourcesKeys.Empty])
                .NotNull().WithMessage("Name " + _stringLocalizer[SharedResourcesKeys.Require])
                .MaximumLength(100).WithMessage("Max length must be 10 ");

            _ = RuleFor(x => x.Email).NotEmpty().WithMessage("Email " + _stringLocalizer[SharedResourcesKeys.Empty])
                .NotNull().WithMessage("Email " + _stringLocalizer[SharedResourcesKeys.Require])
                .MaximumLength(200).WithMessage("Max length must be 20 ");
        }

        public void ApplyCustomValidationsRoles()
        {
            _ = RuleFor(x => x.Email).MustAsync(async (model, key, CancellationToken) => !await _userService.IsEmailExsistExcludeSelfAsync(key, model.UserID))
                .WithMessage("Email is Exsist validation");
        }
    }
}
