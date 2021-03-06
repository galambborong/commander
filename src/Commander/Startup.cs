using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Commander.Data;
using Commander.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Commander.Models;

namespace Commander;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private readonly IConfiguration _configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var con = _configuration.GetConnectionString("DB_CONNECTION");

        services.AddDbContext<CommanderContext>(opt => opt.UseNpgsql(con));

        services.AddControllers()
            .AddNewtonsoftJson(s =>
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<ICommandsRepo, PsqlCommandsRepo>();
        services.AddScoped<IPlatformsRepo, PsqlPlatformsRepo>();
        services.AddScoped<IAliasesRepo, PsqlAliasesRepo>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // PrepDB.PrepPopulation(app);

        app.UseExceptionHandler("/error");

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}