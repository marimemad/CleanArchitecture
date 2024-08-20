using LibraryProject.Services.Services.BookService;
using LibraryProject.Services.Services.BorrowingService;
using LibraryProject.Services.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryProject.Services
{
    public static class ModuleServicesDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBorrowingService, BorrowingService>();
            return services;
        }

    }
}