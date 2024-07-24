using FluentValidation;
using LibraryProject.Core.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace LibraryProject.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            _ = services.AddAutoMapper(Assembly.GetExecutingAssembly());

            _ = services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            _ = services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}