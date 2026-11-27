using Microsoft.EntityFrameworkCore;

namespace Central.Repository.AgentOAuth;

// Protocol artifacts only. Business users, tenants, profiles, grants and usage
// rights remain in the existing Central repositories. No ASP.NET Identity store.
public sealed class AgentOAuthDbContext(DbContextOptions<AgentOAuthDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseOpenIddict();
    }
}
