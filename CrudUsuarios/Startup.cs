using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudUsuarios.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CrudUsuarios.Services;
using CrudUsuarios.Services.Interfaces;
using CrudUsuarios.Repository;
using CrudUsuarios.Repository.Interfaces;

namespace CrudUsuarios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Crud Usuários"
                });
            });

            services.AddDbContext<CrudUserContext>(opt =>
               opt.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddControllers();

            #region DEPENDENCY INJECTION

            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Crud usuários");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
