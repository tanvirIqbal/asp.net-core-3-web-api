﻿using Microsoft.Extensions.DependencyInjection;
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
    }
}
