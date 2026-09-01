// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using IRepository.Read;
using RepositoryInterfaces.Services;

namespace Read.Repository
{
    public partial class yConfigArctetureReadRepositoryCacheDecorator : IyConfigArctetureReadRepository
    {
    private readonly IyConfigArctetureReadRepository _inner;
    private readonly ICacheService<yConfigArctetureDTO> _cacheById;
    private readonly ICacheService<IEnumerable<yConfigArctetureDTO>> _cacheAll;
    private readonly ICacheService<IEnumerable<yConfigArctetureTenantIDDTO>> _cacheFKTenantID;
    private readonly ICacheService<IEnumerable<yConfigArctetureUserIdDTO>> _cacheFKUserId;

    public yConfigArctetureReadRepositoryCacheDecorator(
        IyConfigArctetureReadRepository inner,
        ICacheService<yConfigArctetureDTO> cacheById,
        ICacheService<IEnumerable<yConfigArctetureDTO>> cacheAll,
        ICacheService<IEnumerable<yConfigArctetureTenantIDDTO>> cacheFKTenantID,
        ICacheService<IEnumerable<yConfigArctetureUserIdDTO>> cacheFKUserId
    )    {
        _inner = inner;
        _cacheById = cacheById;
        _cacheAll = cacheAll;
    _cacheFKTenantID=cacheFKTenantID;
    _cacheFKUserId=cacheFKUserId;
    }

    public DataPagination<yConfigArctetureDTO> getyConfigArcteture(ICommandRead command )
    {
        bool isFullQuery = true; // Ajuste conforme sua lógica de filtros
        var key = $"yConfigArcteture:All:Page:{command.Paginacao.Page}:PageZize:{command.Paginacao.PageSize}";
        if (isFullQuery)
        {
            var cached = _cacheAll.Get(key );
            if (cached != null)
                return new DataPagination<yConfigArctetureDTO>(cached, command.Paginacao.Page, command.Paginacao.PageSize);

            var data = _inner.getyConfigArcteture(command );
            _cacheAll.Set(key, data.Items, "yConfigArcteture");
            return data;
        }
        return _inner.getyConfigArcteture(command);
    }
        public IEnumerable<yConfigArctetureTenantIDDTO> getyConfigArctetureReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
                return getyConfigArctetureReadFKTenantID(c );
            throw new NotImplementedException();
        }
        private IEnumerable<yConfigArctetureTenantIDDTO> getyConfigArctetureReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            string key = $"yConfigArcteture:FK:TenantID:{command.searchFK}";
            var cached = _cacheFKTenantID.Get(key );
            if (cached != null) return cached;
            var result = _inner.getyConfigArctetureReadFKTenantID(command );
            if (result != null) _cacheFKTenantID.Set(key, result,"yConfigArcteture");
            return result;
        }
        public IEnumerable<yConfigArctetureUserIdDTO> getyConfigArctetureReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
                return getyConfigArctetureReadFKUserId(c );
            throw new NotImplementedException();
        }
        private IEnumerable<yConfigArctetureUserIdDTO> getyConfigArctetureReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            string key = $"yConfigArcteture:FK:UserId:{command.searchFK}";
            var cached = _cacheFKUserId.Get(key );
            if (cached != null) return cached;
            var result = _inner.getyConfigArctetureReadFKUserId(command );
            if (result != null) _cacheFKUserId.Set(key, result,"yConfigArcteture");
            return result;
        }
        public bool ExistsById(int value )
        {
                return _inner.ExistsById(value );
        }

        public bool ExistsByAuditTrackerActived(int value )
        {
                return _inner.ExistsByAuditTrackerActived(value );
        }

        public bool ExistsByAuditCRUDActived(int value )
        {
                return _inner.ExistsByAuditCRUDActived(value );
        }

        public bool ExistsByTenantID(int value )
        {
                return _inner.ExistsByTenantID(value );
        }

        public bool ExistsByDeleted(bool value )
        {
                return _inner.ExistsByDeleted(value );
        }

        public bool ExistsByChanged(DateTime value )
        {
                return _inner.ExistsByChanged(value );
        }

        public bool ExistsByUserId(int value )
        {
                return _inner.ExistsByUserId(value );
        }

        public yConfigArctetureDTO FirstById(int value )
        {
                return _inner.FirstById(value );
        }

        public yConfigArctetureDTO FirstByAuditTrackerActived(int value )
        {
                return _inner.FirstByAuditTrackerActived(value );
        }

        public yConfigArctetureDTO FirstByAuditCRUDActived(int value )
        {
                return _inner.FirstByAuditCRUDActived(value );
        }

        public yConfigArctetureDTO FirstByTenantID(int value )
        {
                return _inner.FirstByTenantID(value );
        }

        public yConfigArctetureDTO FirstByDeleted(bool value )
        {
                return _inner.FirstByDeleted(value );
        }

        public yConfigArctetureDTO FirstByChanged(DateTime value )
        {
                return _inner.FirstByChanged(value );
        }

        public yConfigArctetureDTO FirstByUserId(int value )
        {
                return _inner.FirstByUserId(value );
        }

        public IEnumerable<yConfigArctetureDTO> GetAllById(int value )
        {
                return _inner.GetAllById(value );
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByAuditTrackerActived(int value )
        {
                return _inner.GetAllByAuditTrackerActived(value );
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByAuditCRUDActived(int value )
        {
                return _inner.GetAllByAuditCRUDActived(value );
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByTenantID(int value )
        {
                return _inner.GetAllByTenantID(value );
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByDeleted(bool value )
        {
                return _inner.GetAllByDeleted(value );
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByChanged(DateTime value )
        {
                return _inner.GetAllByChanged(value );
        }

        public IEnumerable<yConfigArctetureDTO> GetAllByUserId(int value )
        {
                return _inner.GetAllByUserId(value );
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration