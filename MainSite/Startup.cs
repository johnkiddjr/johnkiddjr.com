using Infrastructure.Contexts;
using Infrastructure.Models.Identity;
using MainSite.Helpers;
using MainSite.Middleware;
using MainSite.Options;
using MainSite.Services;
using Microsoft.AspNetCore.HttpOverrides;
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
        services.AddDbContext<AnalyticsContext>(options => options.UseMySql(Configuration.GetConnectionString("Analytics"), mariaDbVersion));

        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<MainSiteContext>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IRestService, RestService>();
        services.AddSingleton<IMarkdownService, MarkdownService>();

        services.AddCors();
        services.AddControllersWithViews();
        services.AddRazorPages();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        // Configure the HTTP request pipeline.
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");

            app.UseServerSideAnalytics(options =>
            {
                options.EnableDbLogging = true;
                options.EnableLoggerLogging = true;
            });
        }
        else
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseServerSideAnalytics(options =>
            {
                options.EnableDbLogging = true;
                options.EnableLoggerLogging = true;
            });
        }

        //configure ContentHelper to use the correct URL for content
        var options = app.ApplicationServices.GetService<IOptions<CDNOptions>>();
        ContentHelper.Configure(options.Value.BaseUrl);

        //configure html helper
        var accessor = app.ApplicationServices.GetService<IHttpContextAccessor>();
        HtmlHelper.Configure(accessor);
            
        app.UseStaticFiles();

        app.UseStatusCodePages();

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
