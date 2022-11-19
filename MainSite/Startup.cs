using Infrastructure.Contexts;
using MainSite.Options;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CDNOptions>(Configuration.GetSection(key: nameof(CDNOptions)));

        var connectionString = Configuration.GetConnectionString("MainSite");
        var mariaDbVersion = ServerVersion.AutoDetect(connectionString);
        services.AddDbContext<MainSiteContext>(options => options.UseMySql(connectionString, mariaDbVersion));

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddCors();
        services.AddControllersWithViews();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        else
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
            
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
}
