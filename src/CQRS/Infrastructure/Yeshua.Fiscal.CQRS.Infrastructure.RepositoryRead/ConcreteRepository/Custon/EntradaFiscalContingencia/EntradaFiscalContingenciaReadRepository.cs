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

using Query.Read;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Repository;
using System.Linq;

namespace Read.Repository
{
    public partial class EntradaFiscalContingenciaReadRepository
    {
        partial void TryGetEntradaFiscalContingenciaCustom(
            Command.Read.EntradaFiscalContingenciaReadCommand command,
            ref DataPagination<EntradaFiscalContingenciaDTO> result,
            ref bool handled)
        {
            var pageQuery = EntradaFiscalContingenciaCaseSearchQuery.Page(command, _executionContext.TenantID);
            var items = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(pageQuery.Query, pageQuery.Parameters).ToList();

            int? totalItems = null;
            if (command.Paginacao?.PageWhithCount ?? false)
            {
                var countQuery = EntradaFiscalContingenciaCaseSearchQuery.Count(command, _executionContext.TenantID);
                totalItems = _unitOfWork.QueryFirstOrDefault<int>(countQuery.Query, countQuery.Parameters);
            }

            result = new DataPagination<EntradaFiscalContingenciaDTO>(
                items,
                command.Paginacao?.Page ?? 1,
                command.Paginacao?.PageSize ?? 8,
                totalItems);
            handled = true;
        }
    }
}
