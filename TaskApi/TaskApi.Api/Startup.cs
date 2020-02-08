namespace TaskApi.Api
{
    using AutoMapper;
    using TaskApi.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TaskApi.Services;
    using System.Net;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services
                .AddDbContext<TaskApiDbContext>(options => options
                     .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            // Routing with lowercase Urls
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMvc(o => o.EnableEndpointRouting = true)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddSingleton(this.Configuration);

            // App Services
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IOfficeService, OfficeService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            // Database Migrations
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<TaskApiDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                SeedDbContext.SeedData(dbContext);
            }

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(application =>
                {
                    application.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            await context.Response
                                .WriteAsync(JsonConvert.SerializeObject(new { ex.Error?.Message, ex.Error?.StackTrace }))
                                .ConfigureAwait(continueOnCapturedContext: false);
                        }
                    });
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseMvc(routes => routes.MapRoute("default", "api/{controller}/{action}/{id?}"));
        }
    }
}
