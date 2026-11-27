using Command.Authentication;
using Command.Receivers.UseCase;
using Command.UseCase;

namespace Central.AgentOAuth;

public interface ICentralAgentIdentity
{
    Task<LoginOutputCommand?> LoginAsync(string username, string password, CancellationToken ct);
    Task<LoginOutputCommand?> ResolveAsync(int owner, int tenant, CancellationToken ct);
}
public sealed class CentralAgentIdentity(LoginHandler login, CentralLoginSessionReader sessions) : ICentralAgentIdentity
{
    public async Task<LoginOutputCommand?> LoginAsync(string username, string password, CancellationToken ct)
    {
        try
        {
            var result = await login.ExecuteAsync(new LoginInputCommand { email = username, password = password }, ct);
            return result.StatusCode == 200 ? result.Data : null;
        }
        catch (RepositoryInterfaces.Patterns.Command.ReceiverException<LoginOutputCommand>) { return null; }
    }
    public Task<LoginOutputCommand?> ResolveAsync(int owner, int tenant, CancellationToken ct) => Task.FromResult(sessions.Resolve(owner, tenant));
}
