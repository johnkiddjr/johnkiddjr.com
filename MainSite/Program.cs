var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

builder.WebHost.UseKestrel(options => options.ListenAnyIP(5000));

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();