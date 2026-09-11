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
    public partial class EntradaFiscalContingenciaReadRepository : IEntradaFiscalContingenciaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEntradaFiscalContingenciaQueryRead _query;

        public EntradaFiscalContingenciaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEntradaFiscalContingenciaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetEntradaFiscalContingenciaCustom(Command.Read.EntradaFiscalContingenciaReadCommand command, ref DataPagination<EntradaFiscalContingenciaDTO> result, ref bool handled);

        public DataPagination<EntradaFiscalContingenciaDTO> getEntradaFiscalContingencia(ICommandRead command )
         {
            if (command is Command.Read.EntradaFiscalContingenciaReadCommand c)
                return getEntradaFiscalContingencia(c );
            throw new NotImplementedException();
        }
        private DataPagination<EntradaFiscalContingenciaDTO> getEntradaFiscalContingencia(Command.Read.EntradaFiscalContingenciaReadCommand command )
        {
            DataPagination<EntradaFiscalContingenciaDTO> customResult = null;
            var customHandled = false;
            TryGetEntradaFiscalContingenciaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.EntradaFiscalContingenciaQuery(command );

                var itens = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters);
                return new DataPagination<EntradaFiscalContingenciaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EntradaFiscalContingenciaTenantIDDTO> getEntradaFiscalContingenciaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EntradaFiscalContingenciaTenantIDDTO> lista;
            var query = _query.EntradaFiscalContingenciaTenantIDQuery(command );

                lista = _unitOfWork.Query<EntradaFiscalContingenciaTenantIDDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<EntradaFiscalContingenciaTenantIDDTO> getEntradaFiscalContingenciaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEntradaFiscalContingenciaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EntradaFiscalContingenciaUserIdDTO> getEntradaFiscalContingenciaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EntradaFiscalContingenciaUserIdDTO> lista;
            var query = _query.EntradaFiscalContingenciaUserIdQuery(command );

                lista = _unitOfWork.Query<EntradaFiscalContingenciaUserIdDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaUserIdDTO>;
            return lista;
        }

        public IEnumerable<EntradaFiscalContingenciaUserIdDTO> getEntradaFiscalContingenciaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEntradaFiscalContingenciaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value )
        {
            var query = _query.ExistsByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCargaId(string value )
        {
            var query = _query.ExistsByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipoSolicitante(int value )
        {
            var query = _query.ExistsByTipoSolicitanteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAmbiente(int value )
        {
            var query = _query.ExistsByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySourceApplication(string value )
        {
            var query = _query.ExistsBySourceApplicationQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySourceModule(string value )
        {
            var query = _query.ExistsBySourceModuleQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySourceMessageId(string value )
        {
            var query = _query.ExistsBySourceMessageIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmitenteFiscalDocumento(string value )
        {
            var query = _query.ExistsByEmitenteFiscalDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTomadorDocumento(string value )
        {
            var query = _query.ExistsByTomadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTransportadorDocumento(string value )
        {
            var query = _query.ExistsByTransportadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRemetenteDocumento(string value )
        {
            var query = _query.ExistsByRemetenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDestinatarioDocumento(string value )
        {
            var query = _query.ExistsByDestinatarioDocumentoQuery(value );

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

        public bool ExistsByRNTRC(string value )
        {
            var query = _query.ExistsByRNTRCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPlacaVeiculo(string value )
        {
            var query = _query.ExistsByPlacaVeiculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUFVeiculo(string value )
        {
            var query = _query.ExistsByUFVeiculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCondutorDocumento(string value )
        {
            var query = _query.ExistsByCondutorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCondutorNome(string value )
        {
            var query = _query.ExistsByCondutorNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidadeDocumentos(int value )
        {
            var query = _query.ExistsByQuantidadeDocumentosQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValorCarga(Decimal value )
        {
            var query = _query.ExistsByValorCargaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPesoBruto(Decimal value )
        {
            var query = _query.ExistsByPesoBrutoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVolume(Decimal value )
        {
            var query = _query.ExistsByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPendenciasJson(string value )
        {
            var query = _query.ExistsByPendenciasJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySnapshotJson(string value )
        {
            var query = _query.ExistsBySnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmissaoFiscalCorrelationId(string value )
        {
            var query = _query.ExistsByEmissaoFiscalCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmissaoFiscalSagaId(int value )
        {
            var query = _query.ExistsByEmissaoFiscalSagaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCriadoEmUtc(DateTime value )
        {
            var query = _query.ExistsByCriadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAtualizadoEmUtc(DateTime value )
        {
            var query = _query.ExistsByAtualizadoEmUtcQuery(value );

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

        public EntradaFiscalContingenciaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByTipoSolicitante(int value )
        {
            var query = _query.FirstByTipoSolicitanteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstBySourceApplication(string value )
        {
            var query = _query.FirstBySourceApplicationQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstBySourceModule(string value )
        {
            var query = _query.FirstBySourceModuleQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstBySourceMessageId(string value )
        {
            var query = _query.FirstBySourceMessageIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByEmitenteFiscalDocumento(string value )
        {
            var query = _query.FirstByEmitenteFiscalDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByTomadorDocumento(string value )
        {
            var query = _query.FirstByTomadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByTransportadorDocumento(string value )
        {
            var query = _query.FirstByTransportadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByRemetenteDocumento(string value )
        {
            var query = _query.FirstByRemetenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByUFInicio(string value )
        {
            var query = _query.FirstByUFInicioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByUFFim(string value )
        {
            var query = _query.FirstByUFFimQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByRNTRC(string value )
        {
            var query = _query.FirstByRNTRCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByPlacaVeiculo(string value )
        {
            var query = _query.FirstByPlacaVeiculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByUFVeiculo(string value )
        {
            var query = _query.FirstByUFVeiculoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByCondutorDocumento(string value )
        {
            var query = _query.FirstByCondutorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByCondutorNome(string value )
        {
            var query = _query.FirstByCondutorNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByQuantidadeDocumentos(int value )
        {
            var query = _query.FirstByQuantidadeDocumentosQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByValorCarga(Decimal value )
        {
            var query = _query.FirstByValorCargaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByPendenciasJson(string value )
        {
            var query = _query.FirstByPendenciasJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByEmissaoFiscalCorrelationId(string value )
        {
            var query = _query.FirstByEmissaoFiscalCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByEmissaoFiscalSagaId(int value )
        {
            var query = _query.FirstByEmissaoFiscalSagaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByCriadoEmUtc(DateTime value )
        {
            var query = _query.FirstByCriadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByAtualizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAtualizadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public EntradaFiscalContingenciaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EntradaFiscalContingenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByTipoSolicitante(int value )
        {
            var query = _query.FirstByTipoSolicitanteQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllBySourceApplication(string value )
        {
            var query = _query.FirstBySourceApplicationQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllBySourceModule(string value )
        {
            var query = _query.FirstBySourceModuleQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllBySourceMessageId(string value )
        {
            var query = _query.FirstBySourceMessageIdQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByEmitenteFiscalDocumento(string value )
        {
            var query = _query.FirstByEmitenteFiscalDocumentoQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByTomadorDocumento(string value )
        {
            var query = _query.FirstByTomadorDocumentoQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByTransportadorDocumento(string value )
        {
            var query = _query.FirstByTransportadorDocumentoQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByRemetenteDocumento(string value )
        {
            var query = _query.FirstByRemetenteDocumentoQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByUFInicio(string value )
        {
            var query = _query.FirstByUFInicioQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByUFFim(string value )
        {
            var query = _query.FirstByUFFimQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByRNTRC(string value )
        {
            var query = _query.FirstByRNTRCQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByPlacaVeiculo(string value )
        {
            var query = _query.FirstByPlacaVeiculoQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByUFVeiculo(string value )
        {
            var query = _query.FirstByUFVeiculoQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCondutorDocumento(string value )
        {
            var query = _query.FirstByCondutorDocumentoQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCondutorNome(string value )
        {
            var query = _query.FirstByCondutorNomeQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByQuantidadeDocumentos(int value )
        {
            var query = _query.FirstByQuantidadeDocumentosQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByValorCarga(Decimal value )
        {
            var query = _query.FirstByValorCargaQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByPendenciasJson(string value )
        {
            var query = _query.FirstByPendenciasJsonQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByEmissaoFiscalCorrelationId(string value )
        {
            var query = _query.FirstByEmissaoFiscalCorrelationIdQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByEmissaoFiscalSagaId(int value )
        {
            var query = _query.FirstByEmissaoFiscalSagaIdQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCriadoEmUtc(DateTime value )
        {
            var query = _query.FirstByCriadoEmUtcQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByAtualizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAtualizadoEmUtcQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EntradaFiscalContingenciaDTO>(query.Query,query.Parameters) as List<EntradaFiscalContingenciaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration