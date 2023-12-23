using Application.Services;
using Application.Services.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class DependencyInjection
    {

        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            #region Identity Configuration
            // Configure Identity
            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            #region Database Configuration
            // Configure database settings
            var databaseSettings = configuration.GetSection("ConnectionStrings");
            var connectionString = databaseSettings["DefaultConnection"]
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found in ConnectionStrings section in appsetting.json.");
            #endregion

            #region DbContext Configuration
            // Configure DbContext (AppDbContext)
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)),
                ServiceLifetime.Transient);
            #endregion

            #region Dependency Injection Configuration

            // Register DbContext and its interface
            services.AddScoped<IApplicationDbContext>(provider
                => provider.GetService<ApplicationDbContext>());

            // Register services and repositories
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDataSetService, DataSetService>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IDataSetRepository, DataSetRepository>();
            //services.AddScoped(typeof(IPdfGenerator<>), typeof(PdfGenerator<>));

            #endregion


            return services;
        }

    }
}
