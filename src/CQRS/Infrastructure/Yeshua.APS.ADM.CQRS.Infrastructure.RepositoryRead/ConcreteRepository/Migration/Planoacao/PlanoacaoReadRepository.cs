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
    public partial class PlanoacaoReadRepository : IPlanoacaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPlanoacaoQueryRead _query;

        public PlanoacaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPlanoacaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<PlanoacaoDTO> getPlanoacao(ICommandRead command )
         {
            if (command is Command.Read.PlanoacaoReadCommand c)
                return getPlanoacao(c );
            throw new NotImplementedException();
        }
        private DataPagination<PlanoacaoDTO> getPlanoacao(Command.Read.PlanoacaoReadCommand command )
        {
            var query = _query.PlanoacaoQuery(command );

                var itens = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters);
                return new DataPagination<PlanoacaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PlanoacaoMET_IDDTO> getPlanoacaoReadFKMET_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanoacaoMET_IDDTO> lista;
            var query = _query.PlanoacaoMET_IDQuery(command );

                lista = _unitOfWork.Query<PlanoacaoMET_IDDTO>(query.Query,query.Parameters) as List<PlanoacaoMET_IDDTO>;
            return lista;
        }

        public IEnumerable<PlanoacaoMET_IDDTO> getPlanoacaoReadFKMET_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanoacaoReadFKMET_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PlanoacaoUSE_IDDTO> getPlanoacaoReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanoacaoUSE_IDDTO> lista;
            var query = _query.PlanoacaoUSE_IDQuery(command );

                lista = _unitOfWork.Query<PlanoacaoUSE_IDDTO>(query.Query,query.Parameters) as List<PlanoacaoUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<PlanoacaoUSE_IDDTO> getPlanoacaoReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanoacaoReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PlanoacaoTenantIDDTO> getPlanoacaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanoacaoTenantIDDTO> lista;
            var query = _query.PlanoacaoTenantIDQuery(command );

                lista = _unitOfWork.Query<PlanoacaoTenantIDDTO>(query.Query,query.Parameters) as List<PlanoacaoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PlanoacaoTenantIDDTO> getPlanoacaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanoacaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PlanoacaoUserIdDTO> getPlanoacaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanoacaoUserIdDTO> lista;
            var query = _query.PlanoacaoUserIdQuery(command );

                lista = _unitOfWork.Query<PlanoacaoUserIdDTO>(query.Query,query.Parameters) as List<PlanoacaoUserIdDTO>;
            return lista;
        }

        public IEnumerable<PlanoacaoUserIdDTO> getPlanoacaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanoacaoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPLA_ID(int value )
        {
            var query = _query.ExistsByPLA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_DESCRICAO(string value )
        {
            var query = _query.ExistsByPLA_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMET_ID(int value )
        {
            var query = _query.ExistsByMET_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_STATUS(string value )
        {
            var query = _query.ExistsByPLA_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_DATA(DateTime value )
        {
            var query = _query.ExistsByPLA_DATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_METAPERIODO(string value )
        {
            var query = _query.ExistsByPLA_METAPERIODOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_VLRPERIODO(string value )
        {
            var query = _query.ExistsByPLA_VLRPERIODOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_METACULADO(string value )
        {
            var query = _query.ExistsByPLA_METACULADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_VLRACUMULADO(string value )
        {
            var query = _query.ExistsByPLA_VLRACUMULADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLA_REFERENCIA(string value )
        {
            var query = _query.ExistsByPLA_REFERENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

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

        public PlanoacaoDTO FirstByPLA_ID(int value )
        {
            var query = _query.FirstByPLA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByPLA_DESCRICAO(string value )
        {
            var query = _query.FirstByPLA_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByMET_ID(int value )
        {
            var query = _query.FirstByMET_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByPLA_STATUS(string value )
        {
            var query = _query.FirstByPLA_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByPLA_DATA(DateTime value )
        {
            var query = _query.FirstByPLA_DATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByPLA_METAPERIODO(string value )
        {
            var query = _query.FirstByPLA_METAPERIODOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByPLA_VLRPERIODO(string value )
        {
            var query = _query.FirstByPLA_VLRPERIODOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByPLA_METACULADO(string value )
        {
            var query = _query.FirstByPLA_METACULADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByPLA_VLRACUMULADO(string value )
        {
            var query = _query.FirstByPLA_VLRACUMULADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByPLA_REFERENCIA(string value )
        {
            var query = _query.FirstByPLA_REFERENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoacaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByPLA_ID(int value )
        {
            var query = _query.FirstByPLA_IDQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByPLA_DESCRICAO(string value )
        {
            var query = _query.FirstByPLA_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByMET_ID(int value )
        {
            var query = _query.FirstByMET_IDQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByPLA_STATUS(string value )
        {
            var query = _query.FirstByPLA_STATUSQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByPLA_DATA(DateTime value )
        {
            var query = _query.FirstByPLA_DATAQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByPLA_METAPERIODO(string value )
        {
            var query = _query.FirstByPLA_METAPERIODOQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByPLA_VLRPERIODO(string value )
        {
            var query = _query.FirstByPLA_VLRPERIODOQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByPLA_METACULADO(string value )
        {
            var query = _query.FirstByPLA_METACULADOQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByPLA_VLRACUMULADO(string value )
        {
            var query = _query.FirstByPLA_VLRACUMULADOQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByPLA_REFERENCIA(string value )
        {
            var query = _query.FirstByPLA_REFERENCIAQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

        public IEnumerable<PlanoacaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PlanoacaoDTO>(query.Query,query.Parameters) as List<PlanoacaoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration