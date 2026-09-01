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
    public partial class OrcamentoReadRepository : IOrcamentoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IOrcamentoQueryRead _query;

        public OrcamentoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IOrcamentoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetOrcamentoCustom(Command.Read.OrcamentoReadCommand command, ref DataPagination<OrcamentoDTO> result, ref bool handled);

        public DataPagination<OrcamentoDTO> getOrcamento(ICommandRead command )
         {
            if (command is Command.Read.OrcamentoReadCommand c)
                return getOrcamento(c );
            throw new NotImplementedException();
        }
        private DataPagination<OrcamentoDTO> getOrcamento(Command.Read.OrcamentoReadCommand command )
        {
            DataPagination<OrcamentoDTO> customResult = null;
            var customHandled = false;
            TryGetOrcamentoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.OrcamentoQuery(command );

                var itens = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters);
                return new DataPagination<OrcamentoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<OrcamentoCLI_IDDTO> getOrcamentoReadFKCLI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrcamentoCLI_IDDTO> lista;
            var query = _query.OrcamentoCLI_IDQuery(command );

                lista = _unitOfWork.Query<OrcamentoCLI_IDDTO>(query.Query,query.Parameters) as List<OrcamentoCLI_IDDTO>;
            return lista;
        }

        public IEnumerable<OrcamentoCLI_IDDTO> getOrcamentoReadFKCLI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrcamentoReadFKCLI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OrcamentoTenantIDDTO> getOrcamentoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrcamentoTenantIDDTO> lista;
            var query = _query.OrcamentoTenantIDQuery(command );

                lista = _unitOfWork.Query<OrcamentoTenantIDDTO>(query.Query,query.Parameters) as List<OrcamentoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<OrcamentoTenantIDDTO> getOrcamentoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrcamentoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OrcamentoUserIdDTO> getOrcamentoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrcamentoUserIdDTO> lista;
            var query = _query.OrcamentoUserIdQuery(command );

                lista = _unitOfWork.Query<OrcamentoUserIdDTO>(query.Query,query.Parameters) as List<OrcamentoUserIdDTO>;
            return lista;
        }

        public IEnumerable<OrcamentoUserIdDTO> getOrcamentoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrcamentoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORC_ID(int value )
        {
            var query = _query.ExistsByORC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREP_ID(string value )
        {
            var query = _query.ExistsByREP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_ID(string value )
        {
            var query = _query.ExistsByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORC_TIPO_FRETE(string value )
        {
            var query = _query.ExistsByORC_TIPO_FRETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORC_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByORC_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVER_ID(int value )
        {
            var query = _query.ExistsByVER_IDQuery(value );

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

        public OrcamentoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByORC_ID(int value )
        {
            var query = _query.FirstByORC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByREP_ID(string value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByCON_ID(string value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByORC_TIPO_FRETE(string value )
        {
            var query = _query.FirstByORC_TIPO_FRETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByORC_EMISSAO(DateTime value )
        {
            var query = _query.FirstByORC_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByVER_ID(int value )
        {
            var query = _query.FirstByVER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrcamentoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByORC_ID(int value )
        {
            var query = _query.FirstByORC_IDQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByREP_ID(string value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByCON_ID(string value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByORC_TIPO_FRETE(string value )
        {
            var query = _query.FirstByORC_TIPO_FRETEQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByORC_EMISSAO(DateTime value )
        {
            var query = _query.FirstByORC_EMISSAOQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByVER_ID(int value )
        {
            var query = _query.FirstByVER_IDQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

        public IEnumerable<OrcamentoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<OrcamentoDTO>(query.Query,query.Parameters) as List<OrcamentoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration