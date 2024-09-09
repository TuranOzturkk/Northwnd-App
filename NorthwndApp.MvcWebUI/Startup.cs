using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Contexts;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories;

namespace NorthwndApp.MvcWebUI
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddSingleton<IProductBs, ProductBs>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ICategoryBs, CategoryBs>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ISupplierBs, SupplierBs>();
            services.AddSingleton<ISupplierRepository, SupplierRepository>();
            services.AddSingleton<IEmployeeBs, EmployeeBs>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IOrderDetailBs, OrderDetailBs>();
            services.AddSingleton<IOrderDetailRepository, OrderDetailRepository>();
            services.AddSingleton<IProductPhotoBs, ProductPhotoBs>();
            services.AddSingleton<IProductPhotoRepository, ProductPhotoRepository>();
            services.AddSingleton<ICustomerBs, CustomerBs>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IMusterilerBs, MusterilerBs>();
            services.AddSingleton<IMusterilerRepository, MusterilerRepository>();
            services.AddSingleton<IOrderBs, OrderBs>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IProductYorumBs, ProductYorumBs>();
            services.AddSingleton<IProductYorumRepository, ProductYorumRepository>();
            services.AddSingleton<IIletisimBs, IletisimBs>();
            services.AddSingleton<IIletisimRepository, IletisimRepository>();
            services.AddSingleton<ISepetBs, SepetBs>();
            services.AddSingleton<ISepetRepository, SepetRepository>();

            services.AddSession();

            services.AddAutoMapper(typeof(Startup));
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
           

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                  name: "AdminLogIn",
                  areaName: "Admin",
                  pattern: "Admin/{controller=Authentication}/{action=LogIn}");

                endpoints.MapAreaControllerRoute(
                  name: "SaticiLogIn",
                  areaName: "Satici",
                  pattern: "Satici/{controller=Login}/{action=Login}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                

            });
        }
    }
}
