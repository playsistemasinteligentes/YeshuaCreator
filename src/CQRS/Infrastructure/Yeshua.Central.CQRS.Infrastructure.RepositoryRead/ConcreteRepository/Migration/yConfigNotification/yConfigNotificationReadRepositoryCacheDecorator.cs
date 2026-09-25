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
    public partial class yConfigNotificationReadRepositoryCacheDecorator : IyConfigNotificationReadRepository
    {
    private readonly IyConfigNotificationReadRepository _inner;
    private readonly ICacheService<yConfigNotificationDTO> _cacheById;
    private readonly ICacheService<IEnumerable<yConfigNotificationDTO>> _cacheAll;
    private readonly ICacheService<IEnumerable<yConfigNotificationTenantIDDTO>> _cacheFKTenantID;
    private readonly ICacheService<IEnumerable<yConfigNotificationUserIdDTO>> _cacheFKUserId;

    public yConfigNotificationReadRepositoryCacheDecorator(
        IyConfigNotificationReadRepository inner,
        ICacheService<yConfigNotificationDTO> cacheById,
        ICacheService<IEnumerable<yConfigNotificationDTO>> cacheAll,
        ICacheService<IEnumerable<yConfigNotificationTenantIDDTO>> cacheFKTenantID,
        ICacheService<IEnumerable<yConfigNotificationUserIdDTO>> cacheFKUserId
    )    {
        _inner = inner;
        _cacheById = cacheById;
        _cacheAll = cacheAll;
    _cacheFKTenantID=cacheFKTenantID;
    _cacheFKUserId=cacheFKUserId;
    }

    public DataPagination<yConfigNotificationDTO> getyConfigNotification(ICommandRead command )
    {
        bool isFullQuery = true; // Ajuste conforme sua lógica de filtros
        var key = $"yConfigNotification:All:Page:{command.Paginacao.Page}:PageZize:{command.Paginacao.PageSize}";
        if (isFullQuery)
        {
            var cached = _cacheAll.Get(key );
            if (cached != null)
                return new DataPagination<yConfigNotificationDTO>(cached, command.Paginacao.Page, command.Paginacao.PageSize);

            var data = _inner.getyConfigNotification(command );
            _cacheAll.Set(key, data.Items, "yConfigNotification");
            return data;
        }
        return _inner.getyConfigNotification(command);
    }
        public IEnumerable<yConfigNotificationTenantIDDTO> getyConfigNotificationReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
                return getyConfigNotificationReadFKTenantID(c );
            throw new NotImplementedException();
        }
        private IEnumerable<yConfigNotificationTenantIDDTO> getyConfigNotificationReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            string key = $"yConfigNotification:FK:TenantID:{command.searchFK}";
            var cached = _cacheFKTenantID.Get(key );
            if (cached != null) return cached;
            var result = _inner.getyConfigNotificationReadFKTenantID(command );
            if (result != null) _cacheFKTenantID.Set(key, result,"yConfigNotification");
            return result ?? System.Array.Empty<yConfigNotificationTenantIDDTO>();
        }
        public IEnumerable<yConfigNotificationUserIdDTO> getyConfigNotificationReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
                return getyConfigNotificationReadFKUserId(c );
            throw new NotImplementedException();
        }
        private IEnumerable<yConfigNotificationUserIdDTO> getyConfigNotificationReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            string key = $"yConfigNotification:FK:UserId:{command.searchFK}";
            var cached = _cacheFKUserId.Get(key );
            if (cached != null) return cached;
            var result = _inner.getyConfigNotificationReadFKUserId(command );
            if (result != null) _cacheFKUserId.Set(key, result,"yConfigNotification");
            return result ?? System.Array.Empty<yConfigNotificationUserIdDTO>();
        }
        public bool ExistsById(int value )
        {
                return _inner.ExistsById(value );
        }

        public bool ExistsByTenantID(int value )
        {
                return _inner.ExistsByTenantID(value );
        }

        public bool ExistsByEmailSmtpClient(string value )
        {
                return _inner.ExistsByEmailSmtpClient(value );
        }

        public bool ExistsByEmailPort(int value )
        {
                return _inner.ExistsByEmailPort(value );
        }

        public bool ExistsByEmailUserName(string value )
        {
                return _inner.ExistsByEmailUserName(value );
        }

        public bool ExistsByEmailPassword(string value )
        {
                return _inner.ExistsByEmailPassword(value );
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

        public yConfigNotificationDTO FirstById(int value )
        {
                return _inner.FirstById(value );
        }

        public yConfigNotificationDTO FirstByTenantID(int value )
        {
                return _inner.FirstByTenantID(value );
        }

        public yConfigNotificationDTO FirstByEmailSmtpClient(string value )
        {
                return _inner.FirstByEmailSmtpClient(value );
        }

        public yConfigNotificationDTO FirstByEmailPort(int value )
        {
                return _inner.FirstByEmailPort(value );
        }

        public yConfigNotificationDTO FirstByEmailUserName(string value )
        {
                return _inner.FirstByEmailUserName(value );
        }

        public yConfigNotificationDTO FirstByEmailPassword(string value )
        {
                return _inner.FirstByEmailPassword(value );
        }

        public yConfigNotificationDTO FirstByDeleted(bool value )
        {
                return _inner.FirstByDeleted(value );
        }

        public yConfigNotificationDTO FirstByChanged(DateTime value )
        {
                return _inner.FirstByChanged(value );
        }

        public yConfigNotificationDTO FirstByUserId(int value )
        {
                return _inner.FirstByUserId(value );
        }

        public IEnumerable<yConfigNotificationDTO> GetAllById(int value )
        {
                return _inner.GetAllById(value );
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByTenantID(int value )
        {
                return _inner.GetAllByTenantID(value );
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByEmailSmtpClient(string value )
        {
                return _inner.GetAllByEmailSmtpClient(value );
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByEmailPort(int value )
        {
                return _inner.GetAllByEmailPort(value );
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByEmailUserName(string value )
        {
                return _inner.GetAllByEmailUserName(value );
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByEmailPassword(string value )
        {
                return _inner.GetAllByEmailPassword(value );
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByDeleted(bool value )
        {
                return _inner.GetAllByDeleted(value );
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByChanged(DateTime value )
        {
                return _inner.GetAllByChanged(value );
        }

        public IEnumerable<yConfigNotificationDTO> GetAllByUserId(int value )
        {
                return _inner.GetAllByUserId(value );
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration