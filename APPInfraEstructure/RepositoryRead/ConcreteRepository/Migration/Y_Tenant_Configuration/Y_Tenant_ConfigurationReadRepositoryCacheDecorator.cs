using Output.Querys.Y_Tenant_Configuration;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.RepositoryInterfaces;
using RepositoryInterfaces.Services;

namespace Read.Repository
{
    public class Y_Tenant_ConfigurationReadRepositoryCacheDecorator : IY_Tenant_ConfigurationReadRepository
    {
    private readonly IY_Tenant_ConfigurationReadRepository _inner;
    private readonly ICacheService<Y_Tenant_ConfigurationDTO> _cacheById;
    private readonly ICacheService<IEnumerable<Y_Tenant_ConfigurationDTO>> _cacheAll;
    private readonly ICacheService<IEnumerable<Y_Tenant_ConfigurationTenantIDDTO>> _cacheFKTenantID;

    public Y_Tenant_ConfigurationReadRepositoryCacheDecorator(
        IY_Tenant_ConfigurationReadRepository inner,
        ICacheService<Y_Tenant_ConfigurationDTO> cacheById,
        ICacheService<IEnumerable<Y_Tenant_ConfigurationDTO>> cacheAll,
        ICacheService<IEnumerable<Y_Tenant_ConfigurationTenantIDDTO>> cacheFKTenantID
    )    {
        _inner = inner;
        _cacheById = cacheById;
        _cacheAll = cacheAll;
    _cacheFKTenantID=cacheFKTenantID;
    }

    public DataPagination<Y_Tenant_ConfigurationDTO> getY_Tenant_Configuration(ICommandRead command)
    {
        bool isFullQuery = true; // Ajuste conforme sua lógica de filtros
        var key = $"Y_Tenant_Configuration:All:Page:{command.Paginacao.Page}:PageZize:{command.Paginacao.PageSize}";
        if (isFullQuery)
        {
            var cached = _cacheAll.Get(key);
            if (cached != null)
                return new DataPagination<Y_Tenant_ConfigurationDTO>(cached, command.Paginacao.Page, command.Paginacao.PageSize);

            var data = _inner.getY_Tenant_Configuration(command);
            _cacheAll.Set(key, data.Items, "Y_Tenant_Configuration");
            return data;
        }
        return _inner.getY_Tenant_Configuration(command);
    }
        public IEnumerable<Y_Tenant_ConfigurationTenantIDDTO> getY_Tenant_ConfigurationReadFKTenantID(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
                return getY_Tenant_ConfigurationReadFKTenantID(c);
            throw new NotImplementedException();
        }
        private IEnumerable<Y_Tenant_ConfigurationTenantIDDTO> getY_Tenant_ConfigurationReadFKTenantID(Command.Patterns.Command.SearchFKCommand command)
        {
            string key = $"Y_Tenant_Configuration:FK:TenantID:{command.searchFK}";
            var cached = _cacheFKTenantID.Get(key);
            if (cached != null) return cached;
            var result = _inner.getY_Tenant_ConfigurationReadFKTenantID(command);
            if (result != null) _cacheFKTenantID.Set(key, result,"Y_Tenant_Configuration");
            return result;
        }
        public Y_Tenant_ConfigurationDTO getById()
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

        public bool ExistsByTenantID(int value)
        {
                return _inner.ExistsByTenantID(value);
        }

        public Y_Tenant_ConfigurationDTO FirstById(int value)
        {
                return _inner.FirstById(value);
        }

        public Y_Tenant_ConfigurationDTO FirstByAuditTrackerActived(int value)
        {
                return _inner.FirstByAuditTrackerActived(value);
        }

        public Y_Tenant_ConfigurationDTO FirstByAuditCRUDActived(int value)
        {
                return _inner.FirstByAuditCRUDActived(value);
        }

        public Y_Tenant_ConfigurationDTO FirstByTenantID(int value)
        {
                return _inner.FirstByTenantID(value);
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration