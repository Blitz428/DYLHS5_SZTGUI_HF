using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Repository;

namespace DYLHS5_HFT_2021221.Endpoint
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
            //services.AddRazorPages();


            //Handling the dependency injections
            services.AddScoped<IOrderLogic, OrderLogic>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ICustomerLogic, CustomerLogic>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProductLogic, ProductLogic>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IShopLogic, ShopLogic>();
            services.AddScoped<IShopRepository, ShopRepository>();

            services.AddScoped<XYZDbContext, XYZDbContext>();

            services.AddControllers();
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
            }

            //app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
