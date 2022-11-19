using Infrastructure.Contexts;
using Infrastructure.Models.Identity;
using MainSite.Helpers;
using MainSite.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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

        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<MainSiteContext>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddCors();
        services.AddControllersWithViews();
        services.AddRazorPages();
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

        //configure ContentHelper to use the correct URL for content
        var options = app.ApplicationServices.GetService<IOptions<CDNOptions>>();
        ContentHelper.Configure(options.Value.BaseUrl);

        //configure html helper
        var accessor = app.ApplicationServices.GetService<IHttpContextAccessor>();
        HtmlHelper.Configure(accessor);
            
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapRazorPages();
        });
    }
}
