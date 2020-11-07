using BlazorWithFirestore.Server.DataAccess;
using FoodLog.Interfaces;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FoodLog
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetFirestoreProjectId() =>
        Configuration["FIRESTORE_PROJECT_ID"];

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //better way to do this
            string filepath = "C:\\FirestoreAPIKey\\FoodLog-e2f9f940bc8a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);

            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddSingleton(provider =>
             FirestoreDb.Create(GetFirestoreProjectId()));

            services.AddScoped<IFoodDataAccessLayer, FoodDataAccessLayer>();
            services.AddScoped<IMealDataAccessLayer, MealDataAccessLayer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           //TODO: change this
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
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
