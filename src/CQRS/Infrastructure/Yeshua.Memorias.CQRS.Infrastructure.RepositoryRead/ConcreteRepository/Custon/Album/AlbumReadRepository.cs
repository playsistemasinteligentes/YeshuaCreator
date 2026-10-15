// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

namespace Read.Repository
{
    public partial class AlbumReadRepository
    {
        partial void TryGetAlbumCustom(Command.Read.AlbumReadCommand command,
            ref RepositoryInterfaces.Patterns.Repository.DataPagination<Repositorio.Outputs.AlbumDTO> result, ref bool handled)
        {
            command.UserId = _executionContext.UserId;
            var query = _query.AlbumQuery(command);
            var items = _unitOfWork.Query<Repositorio.Outputs.AlbumDTO>(query.Query, query.Parameters);
            result = new(items, command.Paginacao?.Page ?? 0, command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount == true ? items.Count() : 0);
            handled = true;
        }
    }
}
