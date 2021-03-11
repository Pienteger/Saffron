using Saffron.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.ML;
using SaffronML.Model;
using System.IO;
using Saffron.DataContex;
using Microsoft.EntityFrameworkCore;
using SaffronEngine.Identity;
using Microsoft.AspNetCore.Http;

namespace Saffron
{
    public class Startup
    {
        private readonly string _modelPath;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _modelPath = GetAbsolutePath("MLModel.zip");
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<SaffronDbContex>(options =>
            options.UseSqlite(
                    Configuration.GetConnectionString("SqliteConnection")));

            services.AddDefaultIdentity<AppUser>(options => 
            options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SaffronDbContex>();

            services.AddRazorPages();
            services.AddSingleton<UtilityService>();
            services.AddPredictionEnginePool<ModelInput, ModelOutput>()
                .FromFile(_modelPath);
            services.AddServerSideBlazor();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSaffronServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/Shared/_Host");
            });
        }
        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }
    }
}
