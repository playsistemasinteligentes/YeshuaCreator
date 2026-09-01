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
    public partial class TipoOcorrenciaReadRepository : ITipoOcorrenciaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoOcorrenciaQueryRead _query;

        public TipoOcorrenciaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoOcorrenciaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTipoOcorrenciaCustom(Command.Read.TipoOcorrenciaReadCommand command, ref DataPagination<TipoOcorrenciaDTO> result, ref bool handled);

        public DataPagination<TipoOcorrenciaDTO> getTipoOcorrencia(ICommandRead command )
         {
            if (command is Command.Read.TipoOcorrenciaReadCommand c)
                return getTipoOcorrencia(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoOcorrenciaDTO> getTipoOcorrencia(Command.Read.TipoOcorrenciaReadCommand command )
        {
            DataPagination<TipoOcorrenciaDTO> customResult = null;
            var customHandled = false;
            TryGetTipoOcorrenciaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TipoOcorrenciaQuery(command );

                var itens = _unitOfWork.Query<TipoOcorrenciaDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoOcorrenciaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoOcorrenciaTenantIDDTO> getTipoOcorrenciaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoOcorrenciaTenantIDDTO> lista;
            var query = _query.TipoOcorrenciaTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoOcorrenciaTenantIDDTO>(query.Query,query.Parameters) as List<TipoOcorrenciaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoOcorrenciaTenantIDDTO> getTipoOcorrenciaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoOcorrenciaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoOcorrenciaUserIdDTO> getTipoOcorrenciaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoOcorrenciaUserIdDTO> lista;
            var query = _query.TipoOcorrenciaUserIdQuery(command );

                lista = _unitOfWork.Query<TipoOcorrenciaUserIdDTO>(query.Query,query.Parameters) as List<TipoOcorrenciaUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoOcorrenciaUserIdDTO> getTipoOcorrenciaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoOcorrenciaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescricao(string value )
        {
            var query = _query.ExistsByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySpr(int value )
        {
            var query = _query.ExistsBySprQuery(value );

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

        public TipoOcorrenciaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoOcorrenciaDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoOcorrenciaDTO FirstBySpr(int value )
        {
            var query = _query.FirstBySprQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoOcorrenciaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoOcorrenciaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoOcorrenciaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoOcorrenciaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoOcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoOcorrenciaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TipoOcorrenciaDTO>(query.Query,query.Parameters) as List<TipoOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<TipoOcorrenciaDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<TipoOcorrenciaDTO>(query.Query,query.Parameters) as List<TipoOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<TipoOcorrenciaDTO> GetAllBySpr(int value )
        {
            var query = _query.FirstBySprQuery(value );

                var result = _unitOfWork.Query<TipoOcorrenciaDTO>(query.Query,query.Parameters) as List<TipoOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<TipoOcorrenciaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoOcorrenciaDTO>(query.Query,query.Parameters) as List<TipoOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<TipoOcorrenciaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoOcorrenciaDTO>(query.Query,query.Parameters) as List<TipoOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<TipoOcorrenciaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoOcorrenciaDTO>(query.Query,query.Parameters) as List<TipoOcorrenciaDTO>;
                return result;
        }

        public IEnumerable<TipoOcorrenciaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoOcorrenciaDTO>(query.Query,query.Parameters) as List<TipoOcorrenciaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration