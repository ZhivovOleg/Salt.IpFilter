namespace Salt.IpFilter;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

/// <summary>
/// Middleware extension
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Add Salt.RequestHandler to middleware
    /// </summary>
    /// <param name="app">app</param>
    /// <param name="policy">what filter have to do</param>
    /// <param name="addresses"></param>
    /// <returns></returns>
    public static IApplicationBuilder AddIpFilter(
        this IApplicationBuilder app,
        IpFilterPolicy policy,
        IEnumerable<string> addresses = null)
    {
        IPAddress[] ipAddresses = addresses?.Select(IPAddress.Parse).ToArray();
        app.UseMiddleware<IpFilterMiddeware>(Options.Create(new IpFilterOptions { Policy = policy, Addresses = ipAddresses }));
        return app;
    }
}