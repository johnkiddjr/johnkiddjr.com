using Infrastructure.Contexts;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace MainSite.Middleware
{
    public class ServerSideAnalyticsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ServerSideAnalyticsMiddleware> _logger;
        private readonly ServerSideAnalyticsOptions _options;

        public ServerSideAnalyticsMiddleware(RequestDelegate next, ILogger<ServerSideAnalyticsMiddleware> logger, ServerSideAnalyticsOptions options)
        {
            _next = next;
            _logger = logger;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext httpContext, AnalyticsContext dbContext)
        {
            try
            {
                if (_options.EnableLoggerLogging)
                {
                    var logInfo = new StringBuilder();
                    logInfo.Append($"---------- New Request ----------{Environment.NewLine}");
                    logInfo.Append($"  IP: {httpContext.Connection.RemoteIpAddress}{Environment.NewLine}");
                    logInfo.Append($"  Path: {httpContext.Request.Path}{Environment.NewLine}");
                    logInfo.Append($"  Query String: {httpContext.Request.QueryString}{Environment.NewLine}");
                    logInfo.Append($"  User Agent: {httpContext.Request.Headers[HeaderNames.UserAgent]}{Environment.NewLine}");
                    logInfo.Append($"  Referer: {httpContext.Request.Headers[HeaderNames.Referer]}{Environment.NewLine}");
                    logInfo.Append($"---------------------------------{Environment.NewLine}");

                    _logger.LogInformation(logInfo.ToString());
                }

                if (_options.EnableDbLogging)
                {
                    dbContext.AnalyticsLogs.Add(new AnalyticsLogEntry()
                    {
                        ApplicationName = "johnkiddjr.com",
                        VisitDate = DateTime.Now,
                        VisitorIpAddress = httpContext.Request.Headers["ProxyForwarded"],
                        RequestPath = httpContext.Request.Path,
                        QueryStringValue = httpContext.Request.QueryString.ToString(),
                        UserAgentValue = httpContext.Request.Headers[HeaderNames.UserAgent],
                        ReferrerValue = httpContext.Request.Headers[HeaderNames.Referer]
                    });

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in ServerSideAnalytics Middleware{Environment.NewLine}{ex.GetType()} : {ex.Message}");
            }

            await _next(httpContext);
        }
    }

    public static class ServerSideAnalyticsMiddlewareExtensions
    {
        public static IApplicationBuilder UseServerSideAnalytics(this IApplicationBuilder builder, ServerSideAnalyticsOptions options)
        {
            return builder.UseMiddleware<ServerSideAnalyticsMiddleware>(options);
        }

        public static IApplicationBuilder UseServerSideAnalytics(this IApplicationBuilder builder, Action<ServerSideAnalyticsOptions> configuredOptions)
        {
            var options = new ServerSideAnalyticsOptions();
            configuredOptions(options);

            return builder.UseMiddleware<ServerSideAnalyticsMiddleware>(options);
        }
    }

    public record ServerSideAnalyticsOptions
    {
        public bool EnableLoggerLogging { get; set; }
        public bool EnableDbLogging { get; set; }
    }
}
