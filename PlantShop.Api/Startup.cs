using Microsoft.EntityFrameworkCore;
using PlantShop.Data.Context;
using PlantShop.Service.Repository;

namespace PlantShop.Api
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
            services.AddDbContext<PlantContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(apiDescriptions =>
                    apiDescriptions.First());
            });

            services.AddScoped<IPlantRepository, PlantRepository>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc().AddControllersAsServices();
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
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
