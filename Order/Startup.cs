using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Order.DAL;
using Order.Services;
using Swashbuckle.AspNetCore.Swagger;
using Order.ExternalService;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;


namespace Order
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
             .AddDbContext<OrderContext>(opt => opt.UseSqlServer(Configuration.GetSection("ConnectionConfiguration:ConnectionString").Value), ServiceLifetime.Scoped);
            services.AddTransient<IOrderServices, OrderServices>();
            services.AddTransient<IOrderHistoryService, OrderHistoryService>();

            services.Configure<URLConfig>(Configuration.GetSection("urls"));
            services.AddHttpClient<ICartService,CartService>()
               .AddPolicyHandler(GetRetryPolicy())
               .AddPolicyHandler(GetCircuitBreakerPolicy());

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
                c.SwaggerDoc("v1", new Info { Title = "Order MICROSERVICE API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllHeaders");

            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
               
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order MICROSERVICE API");
            });

            app.UseMvc();
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
              .HandleTransientHttpError()
              .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
              .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        }

        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
        }
    }
}
