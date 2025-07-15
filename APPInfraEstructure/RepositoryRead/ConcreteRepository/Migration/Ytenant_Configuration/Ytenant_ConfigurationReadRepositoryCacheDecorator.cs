using Output.Querys.Ytenant_Configuration;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.RepositoryInterfaces;
using RepositoryInterfaces.Services;

namespace Read.Repository
{
    public class Ytenant_ConfigurationReadRepositoryCacheDecorator : IYtenant_ConfigurationReadRepository
    {
    private readonly IYtenant_ConfigurationReadRepository _inner;
    private readonly ICacheService<Ytenant_ConfigurationDTO> _cacheById;
    private readonly ICacheService<IEnumerable<Ytenant_ConfigurationDTO>> _cacheAll;
    private readonly ICacheService<IEnumerable<Ytenant_ConfigurationTenantIDDTO>> _cacheFKTenantID;

    public Ytenant_ConfigurationReadRepositoryCacheDecorator(
        IYtenant_ConfigurationReadRepository inner,
        ICacheService<Ytenant_ConfigurationDTO> cacheById,
        ICacheService<IEnumerable<Ytenant_ConfigurationDTO>> cacheAll,
        ICacheService<IEnumerable<Ytenant_ConfigurationTenantIDDTO>> cacheFKTenantID
    )    {
        _inner = inner;
        _cacheById = cacheById;
        _cacheAll = cacheAll;
    _cacheFKTenantID=cacheFKTenantID;
    }

    public DataPagination<Ytenant_ConfigurationDTO> getYtenant_Configuration(ICommandRead command)
    {
        bool isFullQuery = true; // Ajuste conforme sua lógica de filtros
        var key = $"Ytenant_Configuration:All:Page:{command.Paginacao.Page}:PageZize:{command.Paginacao.PageSize}";
        if (isFullQuery)
        {
            var cached = _cacheAll.Get(key);
            if (cached != null)
                return new DataPagination<Ytenant_ConfigurationDTO>(cached, command.Paginacao.Page, command.Paginacao.PageSize);

            var data = _inner.getYtenant_Configuration(command);
            _cacheAll.Set(key, data.Items, "Ytenant_Configuration");
            return data;
        }
        return _inner.getYtenant_Configuration(command);
    }
        public IEnumerable<Ytenant_ConfigurationTenantIDDTO> getYtenant_ConfigurationReadFKTenantID(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
                return getYtenant_ConfigurationReadFKTenantID(c);
            throw new NotImplementedException();
        }
        private IEnumerable<Ytenant_ConfigurationTenantIDDTO> getYtenant_ConfigurationReadFKTenantID(Command.Patterns.Command.SearchFKCommand command)
        {
            string key = $"Ytenant_Configuration:FK:TenantID:{command.searchFK}";
            var cached = _cacheFKTenantID.Get(key);
            if (cached != null) return cached;
            var result = _inner.getYtenant_ConfigurationReadFKTenantID(command);
            if (result != null) _cacheFKTenantID.Set(key, result,"Ytenant_Configuration");
            return result;
        }
        public Ytenant_ConfigurationDTO getById()
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

        public Ytenant_ConfigurationDTO FirstById(int value)
        {
                return _inner.FirstById(value);
        }

        public Ytenant_ConfigurationDTO FirstByAuditTrackerActived(int value)
        {
                return _inner.FirstByAuditTrackerActived(value);
        }

        public Ytenant_ConfigurationDTO FirstByAuditCRUDActived(int value)
        {
                return _inner.FirstByAuditCRUDActived(value);
        }

        public Ytenant_ConfigurationDTO FirstByTenantID(int value)
        {
                return _inner.FirstByTenantID(value);
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration