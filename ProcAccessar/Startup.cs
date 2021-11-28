﻿using Microsoft.EntityFrameworkCore;
using ProcAccessar.Context;
using ProcAccessar.Repositories;
using ReflectionIT.Mvc.Paging;

namespace ProcAccessar;

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
        services.AddControllersWithViews();
        services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(Configuration.
          GetConnectionString("DefaultConnection")));
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IProcessoRepository, ProcessoRepository>();
        services.AddControllersWithViews();
        services.AddPaging(options => {
            options.ViewName = "Bootstrap4";
            options.PageParameterName = "pageindex";
        });;
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
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
        });
    }

}


