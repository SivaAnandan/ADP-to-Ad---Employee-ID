using HBSADScheduler.ScheduleTask;
using HBSADScheduler.Services;
using Microsoft.AspNetCore.Builder;

namespace HBSADScheduler
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddScoped<IReportGenerator, ReportGenerator>();
            services.AddScoped<IUserRead, UserRead>();
            // services.AddSingleton<IHostedService, SampleTask1>();
            services.AddSingleton<IHostedService, ScheduleTask1>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
