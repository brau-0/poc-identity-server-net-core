using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIdentityServer4.AppClients;
using TestIdentityServer4.Extensions;
using TestIdentityServer4.IdentityConfiguration;

namespace TestIdentityServer4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryApiResources(Config.GetApiResources())
            //    .AddInMemoryClients(Clients.Get());
            services.AddIdentityServer()
      .AddInMemoryClients(Clients.Get())
      .AddInMemoryIdentityResources(Resources.GetIdentityResources())
      .AddInMemoryApiResources(Resources.GetApiResources())
      .AddInMemoryApiScopes(Scopes.GetApiScopes())
      //.AddTestUsers(Users.Get())
      .AddDeveloperSigningCredential()
      .AddCustomUserStore();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
           services.AddTransient<IProfileService, ProfileService>();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());


           
    
        }
    }
}
