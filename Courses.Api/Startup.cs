using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Courses.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {    /// <summary>
        /// 
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Configuration Prop
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDatabaseConfiguration(Configuration)
                .AddIdentityConfiguration(Configuration)
                .AddAuthenticationConfiguration(Configuration)
                .AddAutoMapper()
                .AutoServiceRegister(Configuration)
                .AddSwaggerConfiguration(Configuration);
        }

        /// <summary>
        ///    This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
               // app.UseDeveloperExceptionPage();
               app.UseExceptionConfig();
            }

            app.UseMvc();
            app.UseSwaggerConfig();
        

        }
    }
}
