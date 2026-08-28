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
    public partial class EtiquetaReadRepository : IEtiquetaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEtiquetaQueryRead _query;

        public EtiquetaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEtiquetaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<EtiquetaDTO> getEtiqueta(ICommandRead command )
         {
            if (command is Command.Read.EtiquetaReadCommand c)
                return getEtiqueta(c );
            throw new NotImplementedException();
        }
        private DataPagination<EtiquetaDTO> getEtiqueta(Command.Read.EtiquetaReadCommand command )
        {
            var query = _query.EtiquetaQuery(command );

                var itens = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters);
                return new DataPagination<EtiquetaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EtiquetaUSE_IDDTO> getEtiquetaReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EtiquetaUSE_IDDTO> lista;
            var query = _query.EtiquetaUSE_IDQuery(command );

                lista = _unitOfWork.Query<EtiquetaUSE_IDDTO>(query.Query,query.Parameters) as List<EtiquetaUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<EtiquetaUSE_IDDTO> getEtiquetaReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEtiquetaReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EtiquetaORD_IDDTO> getEtiquetaReadFKORD_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EtiquetaORD_IDDTO> lista;
            var query = _query.EtiquetaORD_IDQuery(command );

                lista = _unitOfWork.Query<EtiquetaORD_IDDTO>(query.Query,query.Parameters) as List<EtiquetaORD_IDDTO>;
            return lista;
        }

        public IEnumerable<EtiquetaORD_IDDTO> getEtiquetaReadFKORD_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEtiquetaReadFKORD_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EtiquetaTenantIDDTO> getEtiquetaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EtiquetaTenantIDDTO> lista;
            var query = _query.EtiquetaTenantIDQuery(command );

                lista = _unitOfWork.Query<EtiquetaTenantIDDTO>(query.Query,query.Parameters) as List<EtiquetaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<EtiquetaTenantIDDTO> getEtiquetaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEtiquetaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EtiquetaUserIdDTO> getEtiquetaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EtiquetaUserIdDTO> lista;
            var query = _query.EtiquetaUserIdQuery(command );

                lista = _unitOfWork.Query<EtiquetaUserIdDTO>(query.Query,query.Parameters) as List<EtiquetaUserIdDTO>;
            return lista;
        }

        public IEnumerable<EtiquetaUserIdDTO> getEtiquetaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEtiquetaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByETI_ID(int value )
        {
            var query = _query.ExistsByETI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByETI_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_CODIGO_BARRAS(string value )
        {
            var query = _query.ExistsByETI_CODIGO_BARRASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_SEQUENCIA(int value )
        {
            var query = _query.ExistsByETI_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_NUMERO_COPIAS(int value )
        {
            var query = _query.ExistsByETI_NUMERO_COPIASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_STATUS(string value )
        {
            var query = _query.ExistsByETI_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_DATA_FABRICACAO(DateTime value )
        {
            var query = _query.ExistsByETI_DATA_FABRICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_COD_BARRAS_ORIGINAL(string value )
        {
            var query = _query.ExistsByETI_COD_BARRAS_ORIGINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_OP_ORIGINAL(string value )
        {
            var query = _query.ExistsByETI_OP_ORIGINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIMP_ID(int value )
        {
            var query = _query.ExistsByIMP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_PRO_ID(string value )
        {
            var query = _query.ExistsByROT_PRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.ExistsByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.ExistsByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_QUANTIDADE_PALETE(Decimal value )
        {
            var query = _query.ExistsByETI_QUANTIDADE_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_LOTE(string value )
        {
            var query = _query.ExistsByETI_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_SUB_LOTE(string value )
        {
            var query = _query.ExistsByETI_SUB_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_IMPRIMIR_DE(int value )
        {
            var query = _query.ExistsByETI_IMPRIMIR_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByETI_IMPRIMIR_ATE(int value )
        {
            var query = _query.ExistsByETI_IMPRIMIR_ATEQuery(value );

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

        public EtiquetaDTO FirstByETI_ID(int value )
        {
            var query = _query.FirstByETI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_EMISSAO(DateTime value )
        {
            var query = _query.FirstByETI_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_CODIGO_BARRAS(string value )
        {
            var query = _query.FirstByETI_CODIGO_BARRASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_SEQUENCIA(int value )
        {
            var query = _query.FirstByETI_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_NUMERO_COPIAS(int value )
        {
            var query = _query.FirstByETI_NUMERO_COPIASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_STATUS(string value )
        {
            var query = _query.FirstByETI_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_DATA_FABRICACAO(DateTime value )
        {
            var query = _query.FirstByETI_DATA_FABRICACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_COD_BARRAS_ORIGINAL(string value )
        {
            var query = _query.FirstByETI_COD_BARRAS_ORIGINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_OP_ORIGINAL(string value )
        {
            var query = _query.FirstByETI_OP_ORIGINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByIMP_ID(int value )
        {
            var query = _query.FirstByIMP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByROT_PRO_ID(string value )
        {
            var query = _query.FirstByROT_PRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_QUANTIDADE_PALETE(Decimal value )
        {
            var query = _query.FirstByETI_QUANTIDADE_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_LOTE(string value )
        {
            var query = _query.FirstByETI_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_SUB_LOTE(string value )
        {
            var query = _query.FirstByETI_SUB_LOTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_IMPRIMIR_DE(int value )
        {
            var query = _query.FirstByETI_IMPRIMIR_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByETI_IMPRIMIR_ATE(int value )
        {
            var query = _query.FirstByETI_IMPRIMIR_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EtiquetaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EtiquetaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_ID(int value )
        {
            var query = _query.FirstByETI_IDQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_EMISSAO(DateTime value )
        {
            var query = _query.FirstByETI_EMISSAOQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_CODIGO_BARRAS(string value )
        {
            var query = _query.FirstByETI_CODIGO_BARRASQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_SEQUENCIA(int value )
        {
            var query = _query.FirstByETI_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_NUMERO_COPIAS(int value )
        {
            var query = _query.FirstByETI_NUMERO_COPIASQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_STATUS(string value )
        {
            var query = _query.FirstByETI_STATUSQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_DATA_FABRICACAO(DateTime value )
        {
            var query = _query.FirstByETI_DATA_FABRICACAOQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_COD_BARRAS_ORIGINAL(string value )
        {
            var query = _query.FirstByETI_COD_BARRAS_ORIGINALQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_OP_ORIGINAL(string value )
        {
            var query = _query.FirstByETI_OP_ORIGINALQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByIMP_ID(int value )
        {
            var query = _query.FirstByIMP_IDQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByROT_PRO_ID(string value )
        {
            var query = _query.FirstByROT_PRO_IDQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_QUANTIDADE_PALETE(Decimal value )
        {
            var query = _query.FirstByETI_QUANTIDADE_PALETEQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_LOTE(string value )
        {
            var query = _query.FirstByETI_LOTEQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_SUB_LOTE(string value )
        {
            var query = _query.FirstByETI_SUB_LOTEQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_IMPRIMIR_DE(int value )
        {
            var query = _query.FirstByETI_IMPRIMIR_DEQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByETI_IMPRIMIR_ATE(int value )
        {
            var query = _query.FirstByETI_IMPRIMIR_ATEQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByBOL_ID(string value )
        {
            var query = _query.FirstByBOL_IDQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByCOR_SEQUENCIA(int value )
        {
            var query = _query.FirstByCOR_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

        public IEnumerable<EtiquetaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EtiquetaDTO>(query.Query,query.Parameters) as List<EtiquetaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration