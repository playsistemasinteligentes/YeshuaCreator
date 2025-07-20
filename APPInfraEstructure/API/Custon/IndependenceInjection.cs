using Shered.Services;
using Aplication.Interfaces.Services;
namespace API.Migrations
{
    public static class IndependenceInjectionCuston
    {
        public static void MapIndependenceInjection(WebApplicationBuilder builder)
        {

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICurrentUser, CurrentUserHttp>();

        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIIndependenceInjectionMigration