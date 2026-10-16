// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
using Repositorio.Outputs;

namespace Read.Repository;

public partial class CanalStandardReadRepository
{
    public IReadOnlyList<CanalStandardDTO> ListarDisponiveis()
    {
        const string sql = """
            SELECT Id, CanalId, ConexaoYouTubeId, CredencialTenantId
              FROM dbo.CanalStandard
             WHERE Ativo = 1 AND ISNULL(Deleted, 0) = 0 AND CredencialTenantId > 0
               AND LEN(ConexaoYouTubeId) = 32 AND LEN(CanalId) > 0
            """;
        return _unitOfWork.Query<CanalStandardDTO>(sql).ToList();
    }
}
