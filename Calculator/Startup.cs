using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Calculator.Services;

namespace Calculator
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
            services.AddTransient<ICalculationService, CalculationService>();
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy(CORsPolicyNames.AllowSpecificOrigin,
                    builder => builder.WithOrigins("http://localhost:60110"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CORsPolicyNames.AllowSpecificOrigin);
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                  "{controller}/{action}",
                  new { controller = "App" });
            });
        }
    }
}
