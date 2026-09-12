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
    public partial class ContingenciaFiscalReadRepository : IContingenciaFiscalReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IContingenciaFiscalQueryRead _query;

        public ContingenciaFiscalReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IContingenciaFiscalQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetContingenciaFiscalCustom(Command.Read.ContingenciaFiscalReadCommand command, ref DataPagination<ContingenciaFiscalDTO> result, ref bool handled);

        public DataPagination<ContingenciaFiscalDTO> getContingenciaFiscal(ICommandRead command )
         {
            if (command is Command.Read.ContingenciaFiscalReadCommand c)
                return getContingenciaFiscal(c );
            throw new NotImplementedException();
        }
        private DataPagination<ContingenciaFiscalDTO> getContingenciaFiscal(Command.Read.ContingenciaFiscalReadCommand command )
        {
            var customResult = new DataPagination<ContingenciaFiscalDTO>();
            var customHandled = false;
            TryGetContingenciaFiscalCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ContingenciaFiscalQuery(command );

                var itens = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters);
                return new DataPagination<ContingenciaFiscalDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ContingenciaFiscalEmissaoFiscalTransporteIdDTO> getContingenciaFiscalReadFKEmissaoFiscalTransporteId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.ContingenciaFiscalEmissaoFiscalTransporteIdQuery(command );

                var lista = _unitOfWork.Query<ContingenciaFiscalEmissaoFiscalTransporteIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<ContingenciaFiscalEmissaoFiscalTransporteIdDTO> getContingenciaFiscalReadFKEmissaoFiscalTransporteId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getContingenciaFiscalReadFKEmissaoFiscalTransporteId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ContingenciaFiscalEntradaFiscalContingenciaIdDTO> getContingenciaFiscalReadFKEntradaFiscalContingenciaId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.ContingenciaFiscalEntradaFiscalContingenciaIdQuery(command );

                var lista = _unitOfWork.Query<ContingenciaFiscalEntradaFiscalContingenciaIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<ContingenciaFiscalEntradaFiscalContingenciaIdDTO> getContingenciaFiscalReadFKEntradaFiscalContingenciaId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getContingenciaFiscalReadFKEntradaFiscalContingenciaId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ContingenciaFiscalTenantIDDTO> getContingenciaFiscalReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.ContingenciaFiscalTenantIDQuery(command );

                var lista = _unitOfWork.Query<ContingenciaFiscalTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<ContingenciaFiscalTenantIDDTO> getContingenciaFiscalReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getContingenciaFiscalReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ContingenciaFiscalUserIdDTO> getContingenciaFiscalReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.ContingenciaFiscalUserIdQuery(command );

                var lista = _unitOfWork.Query<ContingenciaFiscalUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<ContingenciaFiscalUserIdDTO> getContingenciaFiscalReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getContingenciaFiscalReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmissaoFiscalTransporteId(int value )
        {
            var query = _query.ExistsByEmissaoFiscalTransporteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEntradaFiscalContingenciaId(int value )
        {
            var query = _query.ExistsByEntradaFiscalContingenciaIdQuery(value );

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

        public bool ExistsByQuantidadeDocumentos(int value )
        {
            var query = _query.ExistsByQuantidadeDocumentosQuery(value );

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

        public ContingenciaFiscalDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByEmissaoFiscalTransporteId(int value )
        {
            var query = _query.FirstByEmissaoFiscalTransporteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByEntradaFiscalContingenciaId(int value )
        {
            var query = _query.FirstByEntradaFiscalContingenciaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByTipoSolicitante(int value )
        {
            var query = _query.FirstByTipoSolicitanteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByTomadorDocumento(string value )
        {
            var query = _query.FirstByTomadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByTransportadorDocumento(string value )
        {
            var query = _query.FirstByTransportadorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByQuantidadeDocumentos(int value )
        {
            var query = _query.FirstByQuantidadeDocumentosQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByQuantidadeCTe(int value )
        {
            var query = _query.FirstByQuantidadeCTeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByQuantidadeMDFe(int value )
        {
            var query = _query.FirstByQuantidadeMDFeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByValorCarga(Decimal value )
        {
            var query = _query.FirstByValorCargaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByUltimaMensagem(string value )
        {
            var query = _query.FirstByUltimaMensagemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByCriadoEmUtc(DateTime value )
        {
            var query = _query.FirstByCriadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByAtualizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAtualizadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByConcluidoEmUtc(DateTime value )
        {
            var query = _query.FirstByConcluidoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ContingenciaFiscalDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ContingenciaFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByEmissaoFiscalTransporteId(int value )
        {
            var query = _query.FirstByEmissaoFiscalTransporteIdQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByEntradaFiscalContingenciaId(int value )
        {
            var query = _query.FirstByEntradaFiscalContingenciaIdQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByTipoSolicitante(int value )
        {
            var query = _query.FirstByTipoSolicitanteQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByTomadorDocumento(string value )
        {
            var query = _query.FirstByTomadorDocumentoQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByTransportadorDocumento(string value )
        {
            var query = _query.FirstByTransportadorDocumentoQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByQuantidadeDocumentos(int value )
        {
            var query = _query.FirstByQuantidadeDocumentosQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByQuantidadeCTe(int value )
        {
            var query = _query.FirstByQuantidadeCTeQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByQuantidadeMDFe(int value )
        {
            var query = _query.FirstByQuantidadeMDFeQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByValorCarga(Decimal value )
        {
            var query = _query.FirstByValorCargaQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByUltimaMensagem(string value )
        {
            var query = _query.FirstByUltimaMensagemQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByCriadoEmUtc(DateTime value )
        {
            var query = _query.FirstByCriadoEmUtcQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByAtualizadoEmUtc(DateTime value )
        {
            var query = _query.FirstByAtualizadoEmUtcQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByConcluidoEmUtc(DateTime value )
        {
            var query = _query.FirstByConcluidoEmUtcQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<ContingenciaFiscalDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ContingenciaFiscalDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration