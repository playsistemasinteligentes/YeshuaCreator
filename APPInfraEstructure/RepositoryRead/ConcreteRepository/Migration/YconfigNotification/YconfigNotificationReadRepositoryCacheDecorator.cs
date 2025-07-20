using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using IRepository.Read;
using RepositoryInterfaces.Services;

namespace Read.Repository
{
    public class YconfigNotificationReadRepositoryCacheDecorator : IYconfigNotificationReadRepository
    {
    private readonly IYconfigNotificationReadRepository _inner;
    private readonly ICacheService<YconfigNotificationDTO> _cacheById;
    private readonly ICacheService<IEnumerable<YconfigNotificationDTO>> _cacheAll;
    private readonly ICacheService<IEnumerable<YconfigNotificationTenantIDDTO>> _cacheFKTenantID;

    public YconfigNotificationReadRepositoryCacheDecorator(
        IYconfigNotificationReadRepository inner,
        ICacheService<YconfigNotificationDTO> cacheById,
        ICacheService<IEnumerable<YconfigNotificationDTO>> cacheAll,
        ICacheService<IEnumerable<YconfigNotificationTenantIDDTO>> cacheFKTenantID
    )    {
        _inner = inner;
        _cacheById = cacheById;
        _cacheAll = cacheAll;
    _cacheFKTenantID=cacheFKTenantID;
    }

    public DataPagination<YconfigNotificationDTO> getYconfigNotification(ICommandRead command)
    {
        bool isFullQuery = true; // Ajuste conforme sua lógica de filtros
        var key = $"YconfigNotification:All:Page:{command.Paginacao.Page}:PageZize:{command.Paginacao.PageSize}";
        if (isFullQuery)
        {
            var cached = _cacheAll.Get(key);
            if (cached != null)
                return new DataPagination<YconfigNotificationDTO>(cached, command.Paginacao.Page, command.Paginacao.PageSize);

            var data = _inner.getYconfigNotification(command);
            _cacheAll.Set(key, data.Items, "YconfigNotification");
            return data;
        }
        return _inner.getYconfigNotification(command);
    }
        public IEnumerable<YconfigNotificationTenantIDDTO> getYconfigNotificationReadFKTenantID(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
                return getYconfigNotificationReadFKTenantID(c);
            throw new NotImplementedException();
        }
        private IEnumerable<YconfigNotificationTenantIDDTO> getYconfigNotificationReadFKTenantID(Command.Patterns.Command.SearchFKCommand command)
        {
            string key = $"YconfigNotification:FK:TenantID:{command.searchFK}";
            var cached = _cacheFKTenantID.Get(key);
            if (cached != null) return cached;
            var result = _inner.getYconfigNotificationReadFKTenantID(command);
            if (result != null) _cacheFKTenantID.Set(key, result,"YconfigNotification");
            return result;
        }
        public YconfigNotificationDTO getById()
        {
            throw new NotImplementedException();
        }
        public bool ExistsById(int value)
        {
                return _inner.ExistsById(value);
        }

        public bool ExistsByEmailAdress(string value)
        {
                return _inner.ExistsByEmailAdress(value);
        }

        public bool ExistsByEmailPassword(string value)
        {
                return _inner.ExistsByEmailPassword(value);
        }

        public bool ExistsByTenantID(int value)
        {
                return _inner.ExistsByTenantID(value);
        }

        public YconfigNotificationDTO FirstById(int value)
        {
                return _inner.FirstById(value);
        }

        public YconfigNotificationDTO FirstByEmailAdress(string value)
        {
                return _inner.FirstByEmailAdress(value);
        }

        public YconfigNotificationDTO FirstByEmailPassword(string value)
        {
                return _inner.FirstByEmailPassword(value);
        }

        public YconfigNotificationDTO FirstByTenantID(int value)
        {
                return _inner.FirstByTenantID(value);
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration