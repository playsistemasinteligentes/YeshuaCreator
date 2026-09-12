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
    public partial class EmissaoFiscalTransporteReadRepository : IEmissaoFiscalTransporteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEmissaoFiscalTransporteQueryRead _query;

        public EmissaoFiscalTransporteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEmissaoFiscalTransporteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetEmissaoFiscalTransporteCustom(Command.Read.EmissaoFiscalTransporteReadCommand command, ref DataPagination<EmissaoFiscalTransporteDTO> result, ref bool handled);

        public DataPagination<EmissaoFiscalTransporteDTO> getEmissaoFiscalTransporte(ICommandRead command )
         {
            if (command is Command.Read.EmissaoFiscalTransporteReadCommand c)
                return getEmissaoFiscalTransporte(c );
            throw new NotImplementedException();
        }
        private DataPagination<EmissaoFiscalTransporteDTO> getEmissaoFiscalTransporte(Command.Read.EmissaoFiscalTransporteReadCommand command )
        {
            var customResult = new DataPagination<EmissaoFiscalTransporteDTO>();
            var customHandled = false;
            TryGetEmissaoFiscalTransporteCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.EmissaoFiscalTransporteQuery(command );

                var itens = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters);
                return new DataPagination<EmissaoFiscalTransporteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EmissaoFiscalTransporteTenantIDDTO> getEmissaoFiscalTransporteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.EmissaoFiscalTransporteTenantIDQuery(command );

                var lista = _unitOfWork.Query<EmissaoFiscalTransporteTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<EmissaoFiscalTransporteTenantIDDTO> getEmissaoFiscalTransporteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEmissaoFiscalTransporteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EmissaoFiscalTransporteUserIdDTO> getEmissaoFiscalTransporteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.EmissaoFiscalTransporteUserIdQuery(command );

                var lista = _unitOfWork.Query<EmissaoFiscalTransporteUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<EmissaoFiscalTransporteUserIdDTO> getEmissaoFiscalTransporteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEmissaoFiscalTransporteReadFKUserId(c );
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

        public bool ExistsByOrigemFluxo(int value )
        {
            var query = _query.ExistsByOrigemFluxoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCargaId(string value )
        {
            var query = _query.ExistsByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRomaneioId(string value )
        {
            var query = _query.ExistsByRomaneioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAmbiente(int value )
        {
            var query = _query.ExistsByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmitenteDocumento(string value )
        {
            var query = _query.ExistsByEmitenteDocumentoQuery(value );

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

        public bool ExistsByQuantidadeNFe(int value )
        {
            var query = _query.ExistsByQuantidadeNFeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidadeCTe(int value )
        {
            var query = _query.ExistsByQuantidadeCTeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidadeMDFe(int value )
        {
            var query = _query.ExistsByQuantidadeMDFeQuery(value );

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

        public bool ExistsByUltimaMensagem(string value )
        {
            var query = _query.ExistsByUltimaMensagemQuery(value );

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

        public bool ExistsByConcluidoEmUtc(DateTime value )
        {
            var query = _query.ExistsByConcluidoEmUtcQuery(value );

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

        public EmissaoFiscalTransporteDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByOrigemFluxo(int value )
        {
            var query = _query.FirstByOrigemFluxoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByRomaneioId(string value )
        {
            var query = _query.FirstByRomaneioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByTomadorDocumento(string value )
        {
            var query = _query.FirstByTomadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByTransportadorDocumento(string value )
        {
            var query = _query.FirstByTransportadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByUFInicio(string value )
        {
            var query = _query.FirstByUFInicioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByUFFim(string value )
        {
            var query = _query.FirstByUFFimQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByQuantidadeNFe(int value )
        {
            var query = _query.FirstByQuantidadeNFeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByQuantidadeCTe(int value )
        {
            var query = _query.FirstByQuantidadeCTeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByQuantidadeMDFe(int value )
        {
            var query = _query.FirstByQuantidadeMDFeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByValorCarga(Decimal value )
        {
            var query = _query.FirstByValorCargaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByUltimaMensagem(string value )
        {
            var query = _query.FirstByUltimaMensagemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByCriadoEmUtc(DateTime value )
        {
            var query = _query.FirstByCriadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByAtualizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAtualizadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByConcluidoEmUtc(DateTime value )
        {
            var query = _query.FirstByConcluidoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByOrigemFluxo(int value )
        {
            var query = _query.FirstByOrigemFluxoQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByRomaneioId(string value )
        {
            var query = _query.FirstByRomaneioIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByTomadorDocumento(string value )
        {
            var query = _query.FirstByTomadorDocumentoQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByTransportadorDocumento(string value )
        {
            var query = _query.FirstByTransportadorDocumentoQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByUFInicio(string value )
        {
            var query = _query.FirstByUFInicioQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByUFFim(string value )
        {
            var query = _query.FirstByUFFimQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByMunicipioInicioCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioInicioCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByMunicipioFimCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioFimCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByQuantidadeNFe(int value )
        {
            var query = _query.FirstByQuantidadeNFeQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByQuantidadeCTe(int value )
        {
            var query = _query.FirstByQuantidadeCTeQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByQuantidadeMDFe(int value )
        {
            var query = _query.FirstByQuantidadeMDFeQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByValorCarga(Decimal value )
        {
            var query = _query.FirstByValorCargaQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByUltimaMensagem(string value )
        {
            var query = _query.FirstByUltimaMensagemQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByCriadoEmUtc(DateTime value )
        {
            var query = _query.FirstByCriadoEmUtcQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByAtualizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAtualizadoEmUtcQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByConcluidoEmUtc(DateTime value )
        {
            var query = _query.FirstByConcluidoEmUtcQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration