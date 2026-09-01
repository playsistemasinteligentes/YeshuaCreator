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
    public partial class SegmentoReadRepository : ISegmentoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ISegmentoQueryRead _query;

        public SegmentoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ISegmentoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetSegmentoCustom(Command.Read.SegmentoReadCommand command, ref DataPagination<SegmentoDTO> result, ref bool handled);

        public DataPagination<SegmentoDTO> getSegmento(ICommandRead command )
         {
            if (command is Command.Read.SegmentoReadCommand c)
                return getSegmento(c );
            throw new NotImplementedException();
        }
        private DataPagination<SegmentoDTO> getSegmento(Command.Read.SegmentoReadCommand command )
        {
            DataPagination<SegmentoDTO> customResult = null;
            var customHandled = false;
            TryGetSegmentoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.SegmentoQuery(command );

                var itens = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters);
                return new DataPagination<SegmentoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<SegmentoTenantIDDTO> getSegmentoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SegmentoTenantIDDTO> lista;
            var query = _query.SegmentoTenantIDQuery(command );

                lista = _unitOfWork.Query<SegmentoTenantIDDTO>(query.Query,query.Parameters) as List<SegmentoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<SegmentoTenantIDDTO> getSegmentoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSegmentoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SegmentoUserIdDTO> getSegmentoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SegmentoUserIdDTO> lista;
            var query = _query.SegmentoUserIdQuery(command );

                lista = _unitOfWork.Query<SegmentoUserIdDTO>(query.Query,query.Parameters) as List<SegmentoUserIdDTO>;
            return lista;
        }

        public IEnumerable<SegmentoUserIdDTO> getSegmentoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSegmentoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEG_ID(string value )
        {
            var query = _query.ExistsBySEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEG_DESCRICAO(string value )
        {
            var query = _query.ExistsBySEG_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEG_ID_SEGUIMENTO_PAI(string value )
        {
            var query = _query.ExistsBySEG_ID_SEGUIMENTO_PAIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRS_ID(string value )
        {
            var query = _query.ExistsByGRS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEG_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsBySEG_INTEGRACAO_ERPQuery(value );

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

        public SegmentoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentoDTO FirstBySEG_ID(string value )
        {
            var query = _query.FirstBySEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentoDTO FirstBySEG_DESCRICAO(string value )
        {
            var query = _query.FirstBySEG_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentoDTO FirstBySEG_ID_SEGUIMENTO_PAI(string value )
        {
            var query = _query.FirstBySEG_ID_SEGUIMENTO_PAIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentoDTO FirstByGRS_ID(string value )
        {
            var query = _query.FirstByGRS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentoDTO FirstBySEG_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstBySEG_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SegmentoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SegmentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllBySEG_ID(string value )
        {
            var query = _query.FirstBySEG_IDQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllBySEG_DESCRICAO(string value )
        {
            var query = _query.FirstBySEG_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllBySEG_ID_SEGUIMENTO_PAI(string value )
        {
            var query = _query.FirstBySEG_ID_SEGUIMENTO_PAIQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllByGRS_ID(string value )
        {
            var query = _query.FirstByGRS_IDQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllBySEG_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstBySEG_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

        public IEnumerable<SegmentoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<SegmentoDTO>(query.Query,query.Parameters) as List<SegmentoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration