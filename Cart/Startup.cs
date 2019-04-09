using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cart.DAL;
using Cart.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Cart
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
            services.AddMvc();
            services
               .AddDbContext<CartContext>(opt => opt.UseSqlServer(Configuration.GetSection("ConnectionConfiguration:ConnectionString").Value), ServiceLifetime.Scoped);
               

            services.AddTransient<ICartServices, CartServices>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder
                          .AllowAnyOrigin()
                                 .AllowAnyHeader()
                                  .AllowAnyMethod()
                                 .AllowCredentials()
                                 .WithExposedHeaders("X-Pagination");

                      });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Cart MICROSERVICE API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseCors("AllowAllHeaders");

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cart MICROSERVICE API");
            });

            app.UseMvc();
        }
    }
}
