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
    public partial class GrupoSegmentoReadRepository : IGrupoSegmentoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IGrupoSegmentoQueryRead _query;

        public GrupoSegmentoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IGrupoSegmentoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetGrupoSegmentoCustom(Command.Read.GrupoSegmentoReadCommand command, ref DataPagination<GrupoSegmentoDTO> result, ref bool handled);

        public DataPagination<GrupoSegmentoDTO> getGrupoSegmento(ICommandRead command )
         {
            if (command is Command.Read.GrupoSegmentoReadCommand c)
                return getGrupoSegmento(c );
            throw new NotImplementedException();
        }
        private DataPagination<GrupoSegmentoDTO> getGrupoSegmento(Command.Read.GrupoSegmentoReadCommand command )
        {
            DataPagination<GrupoSegmentoDTO> customResult = null;
            var customHandled = false;
            TryGetGrupoSegmentoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.GrupoSegmentoQuery(command );

                var itens = _unitOfWork.Query<GrupoSegmentoDTO>(query.Query,query.Parameters);
                return new DataPagination<GrupoSegmentoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<GrupoSegmentoTenantIDDTO> getGrupoSegmentoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoSegmentoTenantIDDTO> lista;
            var query = _query.GrupoSegmentoTenantIDQuery(command );

                lista = _unitOfWork.Query<GrupoSegmentoTenantIDDTO>(query.Query,query.Parameters) as List<GrupoSegmentoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<GrupoSegmentoTenantIDDTO> getGrupoSegmentoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoSegmentoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoSegmentoUserIdDTO> getGrupoSegmentoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoSegmentoUserIdDTO> lista;
            var query = _query.GrupoSegmentoUserIdQuery(command );

                lista = _unitOfWork.Query<GrupoSegmentoUserIdDTO>(query.Query,query.Parameters) as List<GrupoSegmentoUserIdDTO>;
            return lista;
        }

        public IEnumerable<GrupoSegmentoUserIdDTO> getGrupoSegmentoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoSegmentoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRS_ID(string value )
        {
            var query = _query.ExistsByGRS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRS_DESCRICAO(string value )
        {
            var query = _query.ExistsByGRS_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRS_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByGRS_INTEGRACAO_ERPQuery(value );

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

        public GrupoSegmentoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoSegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoSegmentoDTO FirstByGRS_ID(string value )
        {
            var query = _query.FirstByGRS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoSegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoSegmentoDTO FirstByGRS_DESCRICAO(string value )
        {
            var query = _query.FirstByGRS_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoSegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoSegmentoDTO FirstByGRS_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByGRS_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoSegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoSegmentoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoSegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoSegmentoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoSegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoSegmentoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoSegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoSegmentoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoSegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<GrupoSegmentoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<GrupoSegmentoDTO>(query.Query,query.Parameters) as List<GrupoSegmentoDTO>;
                return result;
        }

        public IEnumerable<GrupoSegmentoDTO> GetAllByGRS_ID(string value )
        {
            var query = _query.FirstByGRS_IDQuery(value );

                var result = _unitOfWork.Query<GrupoSegmentoDTO>(query.Query,query.Parameters) as List<GrupoSegmentoDTO>;
                return result;
        }

        public IEnumerable<GrupoSegmentoDTO> GetAllByGRS_DESCRICAO(string value )
        {
            var query = _query.FirstByGRS_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<GrupoSegmentoDTO>(query.Query,query.Parameters) as List<GrupoSegmentoDTO>;
                return result;
        }

        public IEnumerable<GrupoSegmentoDTO> GetAllByGRS_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByGRS_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<GrupoSegmentoDTO>(query.Query,query.Parameters) as List<GrupoSegmentoDTO>;
                return result;
        }

        public IEnumerable<GrupoSegmentoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<GrupoSegmentoDTO>(query.Query,query.Parameters) as List<GrupoSegmentoDTO>;
                return result;
        }

        public IEnumerable<GrupoSegmentoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<GrupoSegmentoDTO>(query.Query,query.Parameters) as List<GrupoSegmentoDTO>;
                return result;
        }

        public IEnumerable<GrupoSegmentoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<GrupoSegmentoDTO>(query.Query,query.Parameters) as List<GrupoSegmentoDTO>;
                return result;
        }

        public IEnumerable<GrupoSegmentoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<GrupoSegmentoDTO>(query.Query,query.Parameters) as List<GrupoSegmentoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration