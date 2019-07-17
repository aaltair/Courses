using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Courses.Entities;
using Courses.Infrastructure.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Courses.Api.Extensions
{
    public static class MiddlewareConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CoursesConnection"));
            });

            return services;
        }

        public static IServiceCollection AutoServiceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.Contains($"{nameof(Courses.Infrastructure)}")  |
                            a.FullName.Contains($"{nameof(Courses.Services)}"));

            services.Scan(scan =>
                scan.FromAssemblies(assemblies)
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithScopedLifetime());


            return services;
        }

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Version = "v1", Title = "Course Apis" });

                var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } } };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(security);

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation version 1");
                c.DefaultModelRendering(ModelRendering.Model);
                c.EnableDeepLinking();
                c.DocumentTitle = "Course Apis";

            });
            app.UseSwagger();
            return app;
        }

        public static IApplicationBuilder UseExceptionConfig(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(ReqDelegate);
            });
            return app;
        }

        private static async Task ReqDelegate(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                

                var ex = error.Error;
         

                var errorId = Activity.Current?.Id ?? context.TraceIdentifier;
                var jsonResponse = JsonConvert.SerializeObject(new 
                {
                    ErrorId = errorId,
                    Message = error.Error.Message ?? "error happened."
                });

                await context.Response.WriteAsync(jsonResponse, Encoding.UTF8);
            }

        }


        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = Boolean.Parse(configuration.GetSection("IdentityConfiguration")
                        .GetSection("RequireDigit").Value);
                    options.Password.RequireLowercase = Boolean.Parse(configuration.GetSection("IdentityConfiguration")
                        .GetSection("RequireLowercase").Value);
                    options.Password.RequireUppercase = Boolean.Parse(configuration.GetSection("IdentityConfiguration")
                        .GetSection("RequireUppercase").Value);
                    options.Password.RequireNonAlphanumeric = Boolean.Parse(configuration
                        .GetSection("IdentityConfiguration").GetSection("RequireNonAlphanumeric").Value);
                    options.Password.RequiredLength = int.Parse(configuration.GetSection("IdentityConfiguration")
                        .GetSection("RequiredLength").Value);
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }


        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.ClaimsIssuer = configuration["Issuer"];
                options.Audience = configuration["Audience"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["Issuer"],
                    ValidAudience = configuration["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecurityKey"])),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            return services;
        }


    }
}