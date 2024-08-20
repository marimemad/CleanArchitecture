
using LibraryProject.Core;
using LibraryProject.Core.Middleware;
using LibraryProject.Infrustructure;
using LibraryProject.Infrustructure.AppDbContext;
using LibraryProject.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

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

            #region Localization
            builder.Services.AddLocalization(options =>
            {
                options.ResourcesPath = "";
            });
            const string defaultCulture = "en-US";

            var supportedCultures = new[]
            {
                new CultureInfo(defaultCulture),
                new CultureInfo("ar-EG")
            };

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI();
            }
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            _ = app.UseMiddleware<ErrorHandlerMiddleware>();

            _ = app.UseHttpsRedirection();

            _ = app.UseAuthorization();

            _ = app.MapControllers();

            app.Run();
        }
    }
}