// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public partial class AlbumFotoReadRepository : IAlbumFotoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IAlbumFotoQueryRead _query;

        public AlbumFotoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IAlbumFotoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetAlbumFotoCustom(Command.Read.AlbumFotoReadCommand command, ref DataPagination<AlbumFotoDTO> result, ref bool handled);

        public DataPagination<AlbumFotoDTO> getAlbumFoto(ICommandRead command )
         {
            if (command is Command.Read.AlbumFotoReadCommand c)
                return getAlbumFoto(c );
            throw new NotImplementedException();
        }
        private DataPagination<AlbumFotoDTO> getAlbumFoto(Command.Read.AlbumFotoReadCommand command )
        {
            var customResult = new DataPagination<AlbumFotoDTO>();
            var customHandled = false;
            TryGetAlbumFotoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.AlbumFotoQuery(command );

                var itens = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters);
                return new DataPagination<AlbumFotoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<AlbumFotoAlbumIdDTO> getAlbumFotoReadFKAlbumId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.AlbumFotoAlbumIdQuery(command );

                var lista = _unitOfWork.Query<AlbumFotoAlbumIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<AlbumFotoAlbumIdDTO> getAlbumFotoReadFKAlbumId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getAlbumFotoReadFKAlbumId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<AlbumFotoFotoIdDTO> getAlbumFotoReadFKFotoId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.AlbumFotoFotoIdQuery(command );

                var lista = _unitOfWork.Query<AlbumFotoFotoIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<AlbumFotoFotoIdDTO> getAlbumFotoReadFKFotoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getAlbumFotoReadFKFotoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<AlbumFotoTenantIDDTO> getAlbumFotoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.AlbumFotoTenantIDQuery(command );

                var lista = _unitOfWork.Query<AlbumFotoTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<AlbumFotoTenantIDDTO> getAlbumFotoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getAlbumFotoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<AlbumFotoUserIdDTO> getAlbumFotoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.AlbumFotoUserIdQuery(command );

                var lista = _unitOfWork.Query<AlbumFotoUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<AlbumFotoUserIdDTO> getAlbumFotoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getAlbumFotoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAlbumId(int value )
        {
            var query = _query.ExistsByAlbumIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFotoId(int value )
        {
            var query = _query.ExistsByFotoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOrdem(int value )
        {
            var query = _query.ExistsByOrdemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLegenda(string value )
        {
            var query = _query.ExistsByLegendaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOperationalEntityId(string value )
        {
            var query = _query.ExistsByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public AlbumFotoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumFotoDTO FirstByAlbumId(int value )
        {
            var query = _query.FirstByAlbumIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumFotoDTO FirstByFotoId(int value )
        {
            var query = _query.FirstByFotoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumFotoDTO FirstByOrdem(int value )
        {
            var query = _query.FirstByOrdemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumFotoDTO FirstByLegenda(string value )
        {
            var query = _query.FirstByLegendaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumFotoDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumFotoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumFotoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumFotoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumFotoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumFotoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllByAlbumId(int value )
        {
            var query = _query.FirstByAlbumIdQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllByFotoId(int value )
        {
            var query = _query.FirstByFotoIdQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllByOrdem(int value )
        {
            var query = _query.FirstByOrdemQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllByLegenda(string value )
        {
            var query = _query.FirstByLegendaQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumFotoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<AlbumFotoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration