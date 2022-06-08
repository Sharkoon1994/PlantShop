using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlantShop.Data;
using PlantShop.Service;

namespace PlantShop.Api
{
    public class Startup
    {
        private const string SwaggerTitle = "PlantShop Api";
        private const string SwaggerJsonEndpoint = "/swagger/v1/swagger.json";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PlantShopContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = SwaggerTitle, Version = "v1"
                });
            });

            services.AddTransient<IPlantService, PlantService>();
            services.AddControllers();
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
                s.SwaggerEndpoint(SwaggerJsonEndpoint, SwaggerTitle);
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
