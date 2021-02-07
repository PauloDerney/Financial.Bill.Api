using AutoMapper;
using Financial.Bill.Domain.Commands.v1.BillAdd;
using Financial.Bill.Domain.Queries.v1.BillSearchPaginated;
using Financial.Framework.Domain.DependencyInjection;
using Financial.Framework.Infra.Data.DependencyInjection;
using Financial.Framework.Infra.Service.AppModels;
using Financial.Framework.Infra.Service.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Financial.Bill.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.InjectBaseRepository(Configuration);

            services.InjectDomain();

            services.InjectMessageQueue(Configuration);
            
            services.AddMediatR(typeof(BillAddCommandHandler), typeof(BillSearchPaginatedQueryHandler));

            services.AddMvc();

            services.AddAutoMapper(typeof(BillAddCommandProfile));

            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Financial.Bill.Api",
                    Version = "v1",
                    Description = "Api de Gastos Financeiros.",
                    Contact = new OpenApiContact { Email = "paulo.e.derney@gmail.com", Name = "Paulo Derney" },
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Financial API");
            });

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