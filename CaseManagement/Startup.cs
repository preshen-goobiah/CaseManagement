using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LibraryServices;
using CaseManagementServices;
using CaseManagementData.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace CaseManagement
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            options =>
            {
                options.LoginPath = new PathString("/auth/login");
                options.AccessDeniedPath = new PathString("/auth/denied");
            });

            services.AddMvc();
            services.AddSingleton(Configuration);
            
            // dependecy injection to inject services? Ask tom 
           
            // binding between the classes and interface
            services.AddScoped<IApplicant, ApplicantService>();
            services.AddScoped<ICase, CaseService>();
            services.AddScoped<IUser, UserService>();
            services.AddScoped<IStatus, StatusService>();
            services.AddScoped<IBank, BankService>();
            services.AddScoped<ISubmission, SubmissionService>();
            services.AddDbContext<CaseManagementContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("CaseConnection")));
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Auth}/{action=Index}");
            });
        }
    }
}
