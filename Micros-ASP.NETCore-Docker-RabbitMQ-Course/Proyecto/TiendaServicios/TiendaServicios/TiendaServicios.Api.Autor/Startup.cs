using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TiendaServicios.Api.Autor.Aplication;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        private readonly IWebHostEnvironment _env;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(cfg=> {
                cfg.RegisterValidatorsFromAssemblyContaining<New>();
            });
            var conn = _env.IsProduction() ? Environment.GetEnvironmentVariable("CONNECTION_DATA_BASE") : Configuration.GetConnectionString("CONNECTION_DATA_BASE");
            services.AddDbContext<DbContextAuthor>(options =>
            {
                options.UseNpgsql(conn);
            });
            services.AddMediatR(typeof(New.Management));
            services.AddAutoMapper(typeof(Query.Management));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
