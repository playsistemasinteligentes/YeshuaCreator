// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
using Repositorio.Outputs;

namespace Input.Repository.CanalStandard;

public partial class CanalStandardWriteRepository
{
    public CanalStandardDTO? ReservarDisponivel(int[] canaisElegiveis)
    {
        if (canaisElegiveis.Length == 0) return null;
        // Selecao e reserva sao uma unica escrita, inclusive entre processos concorrentes.
        const string sql = """
            ;WITH candidato AS (
                SELECT TOP (1) *
                  FROM dbo.CanalStandard WITH (UPDLOCK, HOLDLOCK)
                 WHERE Ativo = 1 AND ISNULL(Deleted, 0) = 0 AND Id IN @CanaisElegiveis
                   AND CredencialTenantId > 0
                   AND LEN(ConexaoYouTubeId) = 32 AND LEN(CanalId) > 0
                 ORDER BY TotalReservas, UltimaReservaEmUtc, Id
            )
            UPDATE candidato
               SET TotalReservas = TotalReservas + 1,
                   UltimaReservaEmUtc = SYSUTCDATETIME(),
                   Changed = SYSUTCDATETIME()
            OUTPUT inserted.Id, inserted.CanalId, inserted.ConexaoYouTubeId,
                   inserted.CredencialTenantId;
            """;
        return _UnitOfWork.QueryFirstOrDefault<CanalStandardDTO>(sql, new { CanaisElegiveis = canaisElegiveis });
    }
}
