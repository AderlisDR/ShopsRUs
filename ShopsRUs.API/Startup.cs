using Boundaries.Persistence;
using Boundaries.Persistence.Contexts;
using Boundaries.Services.Bill;
using Boundaries.Services.Client;
using Boundaries.Services.Discount;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace ShopsRUs.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<Startup>();
                    s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });
            services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();

            ConfigureDbContext(services);
            ConfigureSwagger(services);
            ConfigureCustomServices(services);
            ConfigureCors(services);
        }

        private static void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<DefaultContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Boundaries.Persistence")));
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ShopsRUs API",
                    Version = "v1",
                    Description = "RESTful API that provides the ability to calculate discounts, generate total costs and generate invoices for ShopsRUs customers.",
                    Contact = new OpenApiContact
                    {
                        Name = "Aderlis Díaz Rojas",
                        Email = "AderlisDR@hotmail.com",
                        Url = new Uri("https://github.com/AderlisDR")
                    }
                });
            });
        }

        private static void ConfigureCustomServices(IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IBillService, BillService>();
        }

        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ShopsRUsPolicy",
                builder =>
                {
                    builder.AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopsRUs API V1"); });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseCors("ShopsRUsPolicy");
        }
    }
}
