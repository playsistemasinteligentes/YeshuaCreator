using Dominio.Migration;

namespace Interfaces.Schemas
{
    public interface IMigrationProjectionSchema : ISchema
    {
        void ApplyMigrations(IEnumerable<MigrationBase> migrations);
    }
}
