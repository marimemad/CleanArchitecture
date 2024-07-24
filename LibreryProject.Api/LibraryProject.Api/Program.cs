
using LibraryProject.Core;
using LibraryProject.Core.Middleware;
using LibraryProject.Infrustructure;
using LibraryProject.Infrustructure.AppDbContext;
using LibraryProject.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            _ = builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            _ = builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen();

            //Connection SQL
            _ = builder.Services.AddDbContext<ApplicationDBContext>(option =>
            {
                _ = option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
            });

            _ = builder.Services.AddInfrustructureDependencies().AddServicesDependencies().AddCoreDependencies();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI();
            }

            _ = app.UseMiddleware<ErrorHandlerMiddleware>();

            _ = app.UseHttpsRedirection();

            _ = app.UseAuthorization();

            _ = app.MapControllers();

            app.Run();
        }
    }
}