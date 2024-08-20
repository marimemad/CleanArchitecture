using LibraryProject.Infrustructure.InfrustructureBases;
using LibraryProject.Infrustructure.Repositories.BookRepo;
using LibraryProject.Infrustructure.Repositories.BorrowingRepo;
using LibraryProject.Infrustructure.Repositories.UserRepo;
using LibraryProject.Infrustructure.RepositoriesUserRepo;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryProject.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IBookRepo, BookRepo>();
            services.AddTransient<IBorrowingRepo, BorrowingRepo>();
            services.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            return services;
        }
    }
}