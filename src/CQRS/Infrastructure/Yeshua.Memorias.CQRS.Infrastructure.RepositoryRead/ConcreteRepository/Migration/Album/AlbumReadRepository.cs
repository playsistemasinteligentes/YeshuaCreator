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
    public partial class AlbumReadRepository : IAlbumReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IAlbumQueryRead _query;

        public AlbumReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IAlbumQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetAlbumCustom(Command.Read.AlbumReadCommand command, ref DataPagination<AlbumDTO> result, ref bool handled);

        public DataPagination<AlbumDTO> getAlbum(ICommandRead command )
         {
            if (command is Command.Read.AlbumReadCommand c)
                return getAlbum(c );
            throw new NotImplementedException();
        }
        private DataPagination<AlbumDTO> getAlbum(Command.Read.AlbumReadCommand command )
        {
            var customResult = new DataPagination<AlbumDTO>();
            var customHandled = false;
            TryGetAlbumCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.AlbumQuery(command );

                var itens = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters);
                return new DataPagination<AlbumDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<AlbumTenantIDDTO> getAlbumReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.AlbumTenantIDQuery(command );

                var lista = _unitOfWork.Query<AlbumTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<AlbumTenantIDDTO> getAlbumReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getAlbumReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<AlbumUserIdDTO> getAlbumReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.AlbumUserIdQuery(command );

                var lista = _unitOfWork.Query<AlbumUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<AlbumUserIdDTO> getAlbumReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getAlbumReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTitulo(string value )
        {
            var query = _query.ExistsByTituloQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescricao(string value )
        {
            var query = _query.ExistsByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPrivacidade(int value )
        {
            var query = _query.ExistsByPrivacidadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySegundosPorFoto(int value )
        {
            var query = _query.ExistsBySegundosPorFotoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

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

        public AlbumDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstByTitulo(string value )
        {
            var query = _query.FirstByTituloQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstByPrivacidade(int value )
        {
            var query = _query.FirstByPrivacidadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstBySegundosPorFoto(int value )
        {
            var query = _query.FirstBySegundosPorFotoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public AlbumDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<AlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllByTitulo(string value )
        {
            var query = _query.FirstByTituloQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllByPrivacidade(int value )
        {
            var query = _query.FirstByPrivacidadeQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllBySegundosPorFoto(int value )
        {
            var query = _query.FirstBySegundosPorFotoQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<AlbumDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<AlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration