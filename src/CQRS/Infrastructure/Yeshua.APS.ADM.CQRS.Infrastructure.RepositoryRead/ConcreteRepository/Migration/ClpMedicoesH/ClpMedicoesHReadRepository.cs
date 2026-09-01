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
    public partial class ClpMedicoesHReadRepository : IClpMedicoesHReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IClpMedicoesHQueryRead _query;

        public ClpMedicoesHReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IClpMedicoesHQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetClpMedicoesHCustom(Command.Read.ClpMedicoesHReadCommand command, ref DataPagination<ClpMedicoesHDTO> result, ref bool handled);

        public DataPagination<ClpMedicoesHDTO> getClpMedicoesH(ICommandRead command )
         {
            if (command is Command.Read.ClpMedicoesHReadCommand c)
                return getClpMedicoesH(c );
            throw new NotImplementedException();
        }
        private DataPagination<ClpMedicoesHDTO> getClpMedicoesH(Command.Read.ClpMedicoesHReadCommand command )
        {
            DataPagination<ClpMedicoesHDTO> customResult = null;
            var customHandled = false;
            TryGetClpMedicoesHCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ClpMedicoesHQuery(command );

                var itens = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters);
                return new DataPagination<ClpMedicoesHDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ClpMedicoesHTenantIDDTO> getClpMedicoesHReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ClpMedicoesHTenantIDDTO> lista;
            var query = _query.ClpMedicoesHTenantIDQuery(command );

                lista = _unitOfWork.Query<ClpMedicoesHTenantIDDTO>(query.Query,query.Parameters) as List<ClpMedicoesHTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ClpMedicoesHTenantIDDTO> getClpMedicoesHReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getClpMedicoesHReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ClpMedicoesHUserIdDTO> getClpMedicoesHReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ClpMedicoesHUserIdDTO> lista;
            var query = _query.ClpMedicoesHUserIdQuery(command );

                lista = _unitOfWork.Query<ClpMedicoesHUserIdDTO>(query.Query,query.Parameters) as List<ClpMedicoesHUserIdDTO>;
            return lista;
        }

        public IEnumerable<ClpMedicoesHUserIdDTO> getClpMedicoesHReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getClpMedicoesHReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByID(int value )
        {
            var query = _query.ExistsByIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQUINA_ID(string value )
        {
            var query = _query.ExistsByMAQUINA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDATA_INI(DateTime value )
        {
            var query = _query.ExistsByDATA_INIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDATA_FIM(DateTime value )
        {
            var query = _query.ExistsByDATA_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLP_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByCLP_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQTD(Decimal value )
        {
            var query = _query.ExistsByQTDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRUPO(Decimal value )
        {
            var query = _query.ExistsByGRUPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySTATUS(int value )
        {
            var query = _query.ExistsBySTATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByURN_ID(string value )
        {
            var query = _query.ExistsByURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByURM_ID(string value )
        {
            var query = _query.ExistsByURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByID_LOTE_CLP(int value )
        {
            var query = _query.ExistsByID_LOTE_CLPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_ID(string value )
        {
            var query = _query.ExistsByOCO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFASE(int value )
        {
            var query = _query.ExistsByFASEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLP_ORIGEM(string value )
        {
            var query = _query.ExistsByCLP_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLP_LOTE(int value )
        {
            var query = _query.ExistsByCLP_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOMPACTA(int value )
        {
            var query = _query.ExistsByCOMPACTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByBOL_ID(string value )
        {
            var query = _query.ExistsByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOR_SEQUENCIA(int value )
        {
            var query = _query.ExistsByCOR_SEQUENCIAQuery(value );

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

        public ClpMedicoesHDTO FirstByID(int value )
        {
            var query = _query.FirstByIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByMAQUINA_ID(string value )
        {
            var query = _query.FirstByMAQUINA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByDATA_INI(DateTime value )
        {
            var query = _query.FirstByDATA_INIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByDATA_FIM(DateTime value )
        {
            var query = _query.FirstByDATA_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByCLP_EMISSAO(DateTime value )
        {
            var query = _query.FirstByCLP_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByQTD(Decimal value )
        {
            var query = _query.FirstByQTDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByGRUPO(Decimal value )
        {
            var query = _query.FirstByGRUPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstBySTATUS(int value )
        {
            var query = _query.FirstBySTATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByURN_ID(string value )
        {
            var query = _query.FirstByURN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByURM_ID(string value )
        {
            var query = _query.FirstByURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByID_LOTE_CLP(int value )
        {
            var query = _query.FirstByID_LOTE_CLPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByFASE(int value )
        {
            var query = _query.FirstByFASEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByCLP_ORIGEM(string value )
        {
            var query = _query.FirstByCLP_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByCLP_LOTE(int value )
        {
            var query = _query.FirstByCLP_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByCOMPACTA(int value )
        {
            var query = _query.FirstByCOMPACTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClpMedicoesHDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ClpMedicoesHDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByID(int value )
        {
            var query = _query.FirstByIDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByMAQUINA_ID(string value )
        {
            var query = _query.FirstByMAQUINA_IDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByDATA_INI(DateTime value )
        {
            var query = _query.FirstByDATA_INIQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByDATA_FIM(DateTime value )
        {
            var query = _query.FirstByDATA_FIMQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByCLP_EMISSAO(DateTime value )
        {
            var query = _query.FirstByCLP_EMISSAOQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByQTD(Decimal value )
        {
            var query = _query.FirstByQTDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByGRUPO(Decimal value )
        {
            var query = _query.FirstByGRUPOQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllBySTATUS(int value )
        {
            var query = _query.FirstBySTATUSQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByURN_ID(string value )
        {
            var query = _query.FirstByURN_IDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByURM_ID(string value )
        {
            var query = _query.FirstByURM_IDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByID_LOTE_CLP(int value )
        {
            var query = _query.FirstByID_LOTE_CLPQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByFASE(int value )
        {
            var query = _query.FirstByFASEQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByCLP_ORIGEM(string value )
        {
            var query = _query.FirstByCLP_ORIGEMQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByCLP_LOTE(int value )
        {
            var query = _query.FirstByCLP_LOTEQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByCOMPACTA(int value )
        {
            var query = _query.FirstByCOMPACTAQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

        public IEnumerable<ClpMedicoesHDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ClpMedicoesHDTO>(query.Query,query.Parameters) as List<ClpMedicoesHDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration