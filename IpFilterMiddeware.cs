namespace Salt.IpFilter;

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

/// <summary>
/// IP filter Middleware
/// </summary>
public class IpFilterMiddeware
{
    private readonly RequestDelegate _next;
    private ILogger<IpFilterMiddeware> _logger;
    private readonly IpFilterOptions _options;


    /// <summary>
    /// DI ctor
    /// </summary>
    public IpFilterMiddeware(RequestDelegate next, ILogger<IpFilterMiddeware> logger, IOptions<IpFilterOptions> options)
    {
        _next = next;
        _logger = logger;
        _options = options.Value;
    }

    /// <summary>
    /// Basic middleware method
    /// </summary>
    public async Task Invoke(HttpContext context)
    {
        IPAddress requestIpAddress = context.Connection.RemoteIpAddress;
        switch (_options.Policy)
        {
            case IpFilterPolicy.NOTHING:
                await _next.Invoke(context);
                break;
            case IpFilterPolicy.DENY:
                if (_options.Addresses.Contains(requestIpAddress))
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                else
                    await _next.Invoke(context);
                break;
            case IpFilterPolicy.ALLOW:
                if (_options.Addresses.Contains(requestIpAddress))
                    await _next.Invoke(context);
                else
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}