using System.Net.Http.Json;
using System.Text.Json;

namespace Yeshua.CQRS.Tests.Integration.Api.TestKit;

public static class HttpClientJsonExtensions
{
    public static Task<HttpResponseMessage> SendJsonAsync<T>(
        this HttpClient client,
        HttpMethod method,
        string requestUri,
        T value,
        JsonSerializerOptions options,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(method, requestUri)
        {
            Content = JsonContent.Create(value, options: options)
        };

        return client.SendAsync(request, cancellationToken);
    }
}
