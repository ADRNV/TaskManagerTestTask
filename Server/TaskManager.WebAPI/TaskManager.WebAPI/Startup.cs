using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TaskManager.Core.Models;
using TaskManager.Core.Repositories;
using TaskManager.Core.Services;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Entities.Mapping;
using TaskManager.DataAccess.Repositories;
using TaskManager.Domain;
using TaskManager.WebAPI.Middlewares;

namespace TaskManager.WebAPI
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectsContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("Projects"));
            });

            services.AddAutoMapper(c =>
            {
                c.AddProfile<ProjectMappingConfiguration>();
                c.AddProfile<TaskMappingConfiguration>();
                c.AddProfile<CommentMappingConfiguration>();
            });

            services.AddScoped<IRepository<Project>, ProjectsRepository>();

            services.AddScoped<IService<Project>, ProjectsService>();

            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddMvcCore()
                .AddApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SupportNonNullableReferenceTypes();

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task manager API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            using (var scope =
                        app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<ProjectsContext>())
            {
                context.Database.EnsureCreated();
            }

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}