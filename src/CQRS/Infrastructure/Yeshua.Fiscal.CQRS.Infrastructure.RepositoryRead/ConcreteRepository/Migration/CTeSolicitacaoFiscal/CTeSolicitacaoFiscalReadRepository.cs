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
    public partial class CTeSolicitacaoFiscalReadRepository : ICTeSolicitacaoFiscalReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICTeSolicitacaoFiscalQueryRead _query;

        public CTeSolicitacaoFiscalReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICTeSolicitacaoFiscalQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCTeSolicitacaoFiscalCustom(Command.Read.CTeSolicitacaoFiscalReadCommand command, ref DataPagination<CTeSolicitacaoFiscalDTO> result, ref bool handled);

        public DataPagination<CTeSolicitacaoFiscalDTO> getCTeSolicitacaoFiscal(ICommandRead command )
         {
            if (command is Command.Read.CTeSolicitacaoFiscalReadCommand c)
                return getCTeSolicitacaoFiscal(c );
            throw new NotImplementedException();
        }
        private DataPagination<CTeSolicitacaoFiscalDTO> getCTeSolicitacaoFiscal(Command.Read.CTeSolicitacaoFiscalReadCommand command )
        {
            DataPagination<CTeSolicitacaoFiscalDTO> customResult = null;
            var customHandled = false;
            TryGetCTeSolicitacaoFiscalCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CTeSolicitacaoFiscalQuery(command );

                var itens = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters);
                return new DataPagination<CTeSolicitacaoFiscalDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CTeSolicitacaoFiscalEntradaOficialIdDTO> getCTeSolicitacaoFiscalReadFKEntradaOficialId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeSolicitacaoFiscalEntradaOficialIdDTO> lista;
            var query = _query.CTeSolicitacaoFiscalEntradaOficialIdQuery(command );

                lista = _unitOfWork.Query<CTeSolicitacaoFiscalEntradaOficialIdDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalEntradaOficialIdDTO>;
            return lista;
        }

        public IEnumerable<CTeSolicitacaoFiscalEntradaOficialIdDTO> getCTeSolicitacaoFiscalReadFKEntradaOficialId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeSolicitacaoFiscalReadFKEntradaOficialId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeSolicitacaoFiscalRomaneioConsolidadoIdDTO> getCTeSolicitacaoFiscalReadFKRomaneioConsolidadoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeSolicitacaoFiscalRomaneioConsolidadoIdDTO> lista;
            var query = _query.CTeSolicitacaoFiscalRomaneioConsolidadoIdQuery(command );

                lista = _unitOfWork.Query<CTeSolicitacaoFiscalRomaneioConsolidadoIdDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalRomaneioConsolidadoIdDTO>;
            return lista;
        }

        public IEnumerable<CTeSolicitacaoFiscalRomaneioConsolidadoIdDTO> getCTeSolicitacaoFiscalReadFKRomaneioConsolidadoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeSolicitacaoFiscalReadFKRomaneioConsolidadoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeSolicitacaoFiscalTenantIDDTO> getCTeSolicitacaoFiscalReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeSolicitacaoFiscalTenantIDDTO> lista;
            var query = _query.CTeSolicitacaoFiscalTenantIDQuery(command );

                lista = _unitOfWork.Query<CTeSolicitacaoFiscalTenantIDDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CTeSolicitacaoFiscalTenantIDDTO> getCTeSolicitacaoFiscalReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeSolicitacaoFiscalReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeSolicitacaoFiscalUserIdDTO> getCTeSolicitacaoFiscalReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CTeSolicitacaoFiscalUserIdDTO> lista;
            var query = _query.CTeSolicitacaoFiscalUserIdQuery(command );

                lista = _unitOfWork.Query<CTeSolicitacaoFiscalUserIdDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalUserIdDTO>;
            return lista;
        }

        public IEnumerable<CTeSolicitacaoFiscalUserIdDTO> getCTeSolicitacaoFiscalReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeSolicitacaoFiscalReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEntradaOficialId(int value )
        {
            var query = _query.ExistsByEntradaOficialIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRomaneioConsolidadoId(int value )
        {
            var query = _query.ExistsByRomaneioConsolidadoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value )
        {
            var query = _query.ExistsByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAmbiente(int value )
        {
            var query = _query.ExistsByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUFEmitente(string value )
        {
            var query = _query.ExistsByUFEmitenteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmitenteDocumento(string value )
        {
            var query = _query.ExistsByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProdutoFiscal(int value )
        {
            var query = _query.ExistsByProdutoFiscalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipoCTe(int value )
        {
            var query = _query.ExistsByTipoCTeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipoServico(int value )
        {
            var query = _query.ExistsByTipoServicoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByModal(int value )
        {
            var query = _query.ExistsByModalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGlobalizado(int value )
        {
            var query = _query.ExistsByGlobalizadoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUFInicio(string value )
        {
            var query = _query.ExistsByUFInicioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUFFim(string value )
        {
            var query = _query.ExistsByUFFimQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.ExistsByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.ExistsByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValorServico(Decimal value )
        {
            var query = _query.ExistsByValorServicoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValorCarga(Decimal value )
        {
            var query = _query.ExistsByValorCargaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPreferenciasManifestoJson(string value )
        {
            var query = _query.ExistsByPreferenciasManifestoJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

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

        public CTeSolicitacaoFiscalDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByEntradaOficialId(int value )
        {
            var query = _query.FirstByEntradaOficialIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByRomaneioConsolidadoId(int value )
        {
            var query = _query.FirstByRomaneioConsolidadoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByUFEmitente(string value )
        {
            var query = _query.FirstByUFEmitenteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByProdutoFiscal(int value )
        {
            var query = _query.FirstByProdutoFiscalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByTipoCTe(int value )
        {
            var query = _query.FirstByTipoCTeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByTipoServico(int value )
        {
            var query = _query.FirstByTipoServicoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByModal(int value )
        {
            var query = _query.FirstByModalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByGlobalizado(int value )
        {
            var query = _query.FirstByGlobalizadoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByUFInicio(string value )
        {
            var query = _query.FirstByUFInicioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByUFFim(string value )
        {
            var query = _query.FirstByUFFimQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByValorServico(Decimal value )
        {
            var query = _query.FirstByValorServicoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByValorCarga(Decimal value )
        {
            var query = _query.FirstByValorCargaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByPreferenciasManifestoJson(string value )
        {
            var query = _query.FirstByPreferenciasManifestoJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeSolicitacaoFiscalDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeSolicitacaoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByEntradaOficialId(int value )
        {
            var query = _query.FirstByEntradaOficialIdQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByRomaneioConsolidadoId(int value )
        {
            var query = _query.FirstByRomaneioConsolidadoIdQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByUFEmitente(string value )
        {
            var query = _query.FirstByUFEmitenteQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByProdutoFiscal(int value )
        {
            var query = _query.FirstByProdutoFiscalQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByTipoCTe(int value )
        {
            var query = _query.FirstByTipoCTeQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByTipoServico(int value )
        {
            var query = _query.FirstByTipoServicoQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByModal(int value )
        {
            var query = _query.FirstByModalQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByGlobalizado(int value )
        {
            var query = _query.FirstByGlobalizadoQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByUFInicio(string value )
        {
            var query = _query.FirstByUFInicioQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByUFFim(string value )
        {
            var query = _query.FirstByUFFimQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByValorServico(Decimal value )
        {
            var query = _query.FirstByValorServicoQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByValorCarga(Decimal value )
        {
            var query = _query.FirstByValorCargaQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByPreferenciasManifestoJson(string value )
        {
            var query = _query.FirstByPreferenciasManifestoJsonQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CTeSolicitacaoFiscalDTO>(query.Query,query.Parameters) as List<CTeSolicitacaoFiscalDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration