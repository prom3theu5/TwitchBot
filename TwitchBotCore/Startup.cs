using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitchBotInfrastructure;
using TwitchBotLib;


namespace TwitchBotCore
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
            services.AddMvc().AddRazorPagesOptions(options=> {
              
                options.Conventions.AddPageRoute("/BossFight", "BossFight/{bossHealth?}");



            });
            //IMPORTANT: STILL IN BETA.. WHEN 2.1 is released use that version.
            // This is for learning purposes
           
            services.AddSingleton<IBotConfiguration,TwitchBotConfiguration>();
            services.AddScoped<AddedCommandsRepository>();
            //Singleton since it's gonna be used throughout the app
            services.AddSingleton<Bot>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            
            app.UseStaticFiles();
           

            app.UseMvc();
            
           

        }
    }
}
