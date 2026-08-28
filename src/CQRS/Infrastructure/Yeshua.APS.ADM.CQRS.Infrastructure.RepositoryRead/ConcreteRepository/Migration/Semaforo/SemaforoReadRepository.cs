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
    public partial class SemaforoReadRepository : ISemaforoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ISemaforoQueryRead _query;

        public SemaforoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ISemaforoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<SemaforoDTO> getSemaforo(ICommandRead command )
         {
            if (command is Command.Read.SemaforoReadCommand c)
                return getSemaforo(c );
            throw new NotImplementedException();
        }
        private DataPagination<SemaforoDTO> getSemaforo(Command.Read.SemaforoReadCommand command )
        {
            var query = _query.SemaforoQuery(command );

                var itens = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters);
                return new DataPagination<SemaforoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<SemaforoTenantIDDTO> getSemaforoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SemaforoTenantIDDTO> lista;
            var query = _query.SemaforoTenantIDQuery(command );

                lista = _unitOfWork.Query<SemaforoTenantIDDTO>(query.Query,query.Parameters) as List<SemaforoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<SemaforoTenantIDDTO> getSemaforoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSemaforoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SemaforoUserIdDTO> getSemaforoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SemaforoUserIdDTO> lista;
            var query = _query.SemaforoUserIdQuery(command );

                lista = _unitOfWork.Query<SemaforoUserIdDTO>(query.Query,query.Parameters) as List<SemaforoUserIdDTO>;
            return lista;
        }

        public IEnumerable<SemaforoUserIdDTO> getSemaforoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSemaforoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEM_ID(string value )
        {
            var query = _query.ExistsBySEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEM_STATUS(string value )
        {
            var query = _query.ExistsBySEM_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEM_ORIGEM(string value )
        {
            var query = _query.ExistsBySEM_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEM_EMISSAO(DateTime value )
        {
            var query = _query.ExistsBySEM_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySEM_ID_CONEXAO(string value )
        {
            var query = _query.ExistsBySEM_ID_CONEXAOQuery(value );

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

        public SemaforoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SemaforoDTO FirstBySEM_ID(string value )
        {
            var query = _query.FirstBySEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SemaforoDTO FirstBySEM_STATUS(string value )
        {
            var query = _query.FirstBySEM_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SemaforoDTO FirstBySEM_ORIGEM(string value )
        {
            var query = _query.FirstBySEM_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SemaforoDTO FirstBySEM_EMISSAO(DateTime value )
        {
            var query = _query.FirstBySEM_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SemaforoDTO FirstBySEM_ID_CONEXAO(string value )
        {
            var query = _query.FirstBySEM_ID_CONEXAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SemaforoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SemaforoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SemaforoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public SemaforoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SemaforoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllBySEM_ID(string value )
        {
            var query = _query.FirstBySEM_IDQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllBySEM_STATUS(string value )
        {
            var query = _query.FirstBySEM_STATUSQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllBySEM_ORIGEM(string value )
        {
            var query = _query.FirstBySEM_ORIGEMQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllBySEM_EMISSAO(DateTime value )
        {
            var query = _query.FirstBySEM_EMISSAOQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllBySEM_ID_CONEXAO(string value )
        {
            var query = _query.FirstBySEM_ID_CONEXAOQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

        public IEnumerable<SemaforoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<SemaforoDTO>(query.Query,query.Parameters) as List<SemaforoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration