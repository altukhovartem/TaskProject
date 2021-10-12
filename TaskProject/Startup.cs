using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models;
using TaskProject.Models.EF;
using TaskProject.Security;

namespace TaskProject
{
	public class Startup
	{
		private readonly IConfiguration configuration;

		public Startup(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDBContext>(opt =>
			opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped<ITaskRepository, TaskRepository>();
			services.AddScoped<ITaskTypeRepository, TaskTypeRepository>();
			services.AddHttpContextAccessor();
			services.AddSession();

			services.AddControllersWithViews();

			services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));
			services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
			services.ConfigureApplicationCookie(opt =>
			{
				opt.LoginPath = "/Security/SignIn";
				opt.AccessDeniedPath = "/Security/AccessDenied";
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{Controller=Task}/{Action=List}/{Id?}");
			});
		}
	}
}
