using System.Net;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed class McpAccessPolicy(
    IHttpContextAccessor httpContextAccessor,
    IOptions<McpOptions> options)
{
    public bool HasPrivateAccess
    {
        get
        {
            var connection = httpContextAccessor.HttpContext?.Connection;
            return connection is not null &&
                   connection.LocalPort == options.Value.PrivatePort &&
                   connection.LocalIpAddress is not null &&
                   connection.RemoteIpAddress is not null &&
                   IPAddress.IsLoopback(connection.LocalIpAddress) &&
                   IPAddress.IsLoopback(connection.RemoteIpAddress);
        }
    }
}
