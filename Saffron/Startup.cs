using Saffron.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.ML;
using SaffronML.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Saffron.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saffron.Areas;
using Saffron.Areas.Identity.Data;
using Saffron.Services.CoreServices;

namespace Saffron
{
    public class Startup
    {
        private readonly string modelPath;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            modelPath = UtilityService.GetAbsolutePath("MLModel.zip");
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            #region Basic

            services.AddRazorPages();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.AddControllersWithViews();
            services.AddProgressiveWebApp();

            #endregion

            #region Database

            services.AddDbContext<SaffronContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("SQLiteConnection")));
            services.AddDefaultIdentity<SaffronUser>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SaffronContext>();
            services.AddDatabaseDeveloperPageExceptionFilter();

            #endregion

            services.AddScoped<AuthenticationStateProvider,
                ReValidatingIdentityAuthenticationStateProvider<SaffronUser>>();
            services.AddPredictionEnginePool<ModelInput, ModelOutput>()
                .FromFile(modelPath);

            services.AddSaffronServices();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePagesWithRedirects("/NotFound/{0}");
            app.UseRequestLocalization();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/_Host");
            });
        }

    }
}
