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
    public partial class PublicacaoAlbumReadRepository : IPublicacaoAlbumReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPublicacaoAlbumQueryRead _query;

        public PublicacaoAlbumReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPublicacaoAlbumQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetPublicacaoAlbumCustom(Command.Read.PublicacaoAlbumReadCommand command, ref DataPagination<PublicacaoAlbumDTO> result, ref bool handled);

        public DataPagination<PublicacaoAlbumDTO> getPublicacaoAlbum(ICommandRead command )
         {
            if (command is Command.Read.PublicacaoAlbumReadCommand c)
                return getPublicacaoAlbum(c );
            throw new NotImplementedException();
        }
        private DataPagination<PublicacaoAlbumDTO> getPublicacaoAlbum(Command.Read.PublicacaoAlbumReadCommand command )
        {
            var customResult = new DataPagination<PublicacaoAlbumDTO>();
            var customHandled = false;
            TryGetPublicacaoAlbumCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.PublicacaoAlbumQuery(command );

                var itens = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters);
                return new DataPagination<PublicacaoAlbumDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PublicacaoAlbumAlbumIdDTO> getPublicacaoAlbumReadFKAlbumId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.PublicacaoAlbumAlbumIdQuery(command );

                var lista = _unitOfWork.Query<PublicacaoAlbumAlbumIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<PublicacaoAlbumAlbumIdDTO> getPublicacaoAlbumReadFKAlbumId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPublicacaoAlbumReadFKAlbumId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PublicacaoAlbumTenantIDDTO> getPublicacaoAlbumReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.PublicacaoAlbumTenantIDQuery(command );

                var lista = _unitOfWork.Query<PublicacaoAlbumTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<PublicacaoAlbumTenantIDDTO> getPublicacaoAlbumReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPublicacaoAlbumReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PublicacaoAlbumUserIdDTO> getPublicacaoAlbumReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.PublicacaoAlbumUserIdQuery(command );

                var lista = _unitOfWork.Query<PublicacaoAlbumUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<PublicacaoAlbumUserIdDTO> getPublicacaoAlbumReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPublicacaoAlbumReadFKUserId(c );
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

        public bool ExistsByCorrelationId(string value )
        {
            var query = _query.ExistsByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByManifestStorageKey(string value )
        {
            var query = _query.ExistsByManifestStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVideoStorageKey(string value )
        {
            var query = _query.ExistsByVideoStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByYouTubeVideoId(string value )
        {
            var query = _query.ExistsByYouTubeVideoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByYouTubeUrl(string value )
        {
            var query = _query.ExistsByYouTubeUrlQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMensagem(string value )
        {
            var query = _query.ExistsByMensagemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySolicitadaEmUtc(DateTime value )
        {
            var query = _query.ExistsBySolicitadaEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPublicadaEmUtc(DateTime value )
        {
            var query = _query.ExistsByPublicadaEmUtcQuery(value );

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

        public PublicacaoAlbumDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByAlbumId(int value )
        {
            var query = _query.FirstByAlbumIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByManifestStorageKey(string value )
        {
            var query = _query.FirstByManifestStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByVideoStorageKey(string value )
        {
            var query = _query.FirstByVideoStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByYouTubeVideoId(string value )
        {
            var query = _query.FirstByYouTubeVideoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByYouTubeUrl(string value )
        {
            var query = _query.FirstByYouTubeUrlQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByMensagem(string value )
        {
            var query = _query.FirstByMensagemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstBySolicitadaEmUtc(DateTime value )
        {
            var query = _query.FirstBySolicitadaEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByPublicadaEmUtc(DateTime value )
        {
            var query = _query.FirstByPublicadaEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public PublicacaoAlbumDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PublicacaoAlbumDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByAlbumId(int value )
        {
            var query = _query.FirstByAlbumIdQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByManifestStorageKey(string value )
        {
            var query = _query.FirstByManifestStorageKeyQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByVideoStorageKey(string value )
        {
            var query = _query.FirstByVideoStorageKeyQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByYouTubeVideoId(string value )
        {
            var query = _query.FirstByYouTubeVideoIdQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByYouTubeUrl(string value )
        {
            var query = _query.FirstByYouTubeUrlQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByMensagem(string value )
        {
            var query = _query.FirstByMensagemQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllBySolicitadaEmUtc(DateTime value )
        {
            var query = _query.FirstBySolicitadaEmUtcQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByPublicadaEmUtc(DateTime value )
        {
            var query = _query.FirstByPublicadaEmUtcQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<PublicacaoAlbumDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PublicacaoAlbumDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration