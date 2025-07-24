using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using IRepository.Read;
using RepositoryInterfaces.Services;

namespace Read.Repository
{
    public class YconfigArctetureReadRepositoryCacheDecorator : IYconfigArctetureReadRepository
    {
    private readonly IYconfigArctetureReadRepository _inner;
    private readonly ICacheService<YconfigArctetureDTO> _cacheById;
    private readonly ICacheService<IEnumerable<YconfigArctetureDTO>> _cacheAll;

    public YconfigArctetureReadRepositoryCacheDecorator(
        IYconfigArctetureReadRepository inner,
        ICacheService<YconfigArctetureDTO> cacheById,
        ICacheService<IEnumerable<YconfigArctetureDTO>> cacheAll
    )    {
        _inner = inner;
        _cacheById = cacheById;
        _cacheAll = cacheAll;
    }

    public DataPagination<YconfigArctetureDTO> getYconfigArcteture(ICommandRead command)
    {
        bool isFullQuery = true; // Ajuste conforme sua lógica de filtros
        var key = $"YconfigArcteture:All:Page:{command.Paginacao.Page}:PageZize:{command.Paginacao.PageSize}";
        if (isFullQuery)
        {
            var cached = _cacheAll.Get(key);
            if (cached != null)
                return new DataPagination<YconfigArctetureDTO>(cached, command.Paginacao.Page, command.Paginacao.PageSize);

            var data = _inner.getYconfigArcteture(command);
            _cacheAll.Set(key, data.Items, "YconfigArcteture");
            return data;
        }
        return _inner.getYconfigArcteture(command);
    }
        public YconfigArctetureDTO getById()
        {
            throw new NotImplementedException();
        }
        public bool ExistsById(int value)
        {
                return _inner.ExistsById(value);
        }

        public bool ExistsByAuditTrackerActived(int value)
        {
                return _inner.ExistsByAuditTrackerActived(value);
        }

        public bool ExistsByAuditCRUDActived(int value)
        {
                return _inner.ExistsByAuditCRUDActived(value);
        }

        public YconfigArctetureDTO FirstById(int value)
        {
                return _inner.FirstById(value);
        }

        public YconfigArctetureDTO FirstByAuditTrackerActived(int value)
        {
                return _inner.FirstByAuditTrackerActived(value);
        }

        public YconfigArctetureDTO FirstByAuditCRUDActived(int value)
        {
                return _inner.FirstByAuditCRUDActived(value);
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration