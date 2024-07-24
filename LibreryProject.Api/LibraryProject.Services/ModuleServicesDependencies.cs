using LibraryProject.Services.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryProject.Services
{
    public static class ModuleServicesDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            return services;
        }

    }
}