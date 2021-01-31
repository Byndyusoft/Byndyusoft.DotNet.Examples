using System.Reflection;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Domain;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prometheus;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Version = "v1",
                            Title = Assembly.GetExecutingAssembly().GetName().Name
                        });
                });

            services.AddMvcCore()
                .AddApiExplorer();

            services.AddOpenTracing();

            services.AddSingleton<OrderService>();
            services.AddHostedService<DianosticHostedService>();
            services.AddDiagnosticObserver<PrometheusOrderDiagnosticObserver>();
            services.AddDiagnosticObserver<LoggingOrderDiagnosticObserver>();
            services.AddDiagnosticObserver<TraceOrderDiagnosticObserver>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMetricServer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(options =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                        options.DisplayRequestDuration();
                        options.DefaultModelRendering(ModelRendering.Model);
                        options.DefaultModelExpandDepth(3);
                    });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics();
            });
        }
    }
}