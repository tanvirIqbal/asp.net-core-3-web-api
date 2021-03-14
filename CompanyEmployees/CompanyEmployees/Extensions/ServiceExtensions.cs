using Contracts;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        /*
        AllowAnyOrigin()
        WithOrigins("https://example.com")
        AllowAnyMethod()
        WithMethods("POST", "GET")
        AllowAnyHeader()
        WithHeaders("accept", "content-type")
         */
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options => { options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

        /*
         We do not initialize any of the properties inside the options because we are fine with the default values for now.
         
         */
        public static void ConfigureIISIntegration(this IServiceCollection services) => services.Configure<IISOptions>(options => { });

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => 
            services.AddDbContext<RepositoryContext>(opts => 
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => 
            b.MigrationsAssembly("CompanyEmployees")));
    }
}
