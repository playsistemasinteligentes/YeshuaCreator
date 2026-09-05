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
    public partial class DocumentoFiscalReadRepository : IDocumentoFiscalReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IDocumentoFiscalQueryRead _query;

        public DocumentoFiscalReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IDocumentoFiscalQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetDocumentoFiscalCustom(Command.Read.DocumentoFiscalReadCommand command, ref DataPagination<DocumentoFiscalDTO> result, ref bool handled);

        public DataPagination<DocumentoFiscalDTO> getDocumentoFiscal(ICommandRead command )
         {
            if (command is Command.Read.DocumentoFiscalReadCommand c)
                return getDocumentoFiscal(c );
            throw new NotImplementedException();
        }
        private DataPagination<DocumentoFiscalDTO> getDocumentoFiscal(Command.Read.DocumentoFiscalReadCommand command )
        {
            DataPagination<DocumentoFiscalDTO> customResult = null;
            var customHandled = false;
            TryGetDocumentoFiscalCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.DocumentoFiscalQuery(command );

                var itens = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters);
                return new DataPagination<DocumentoFiscalDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<DocumentoFiscalTenantIDDTO> getDocumentoFiscalReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<DocumentoFiscalTenantIDDTO> lista;
            var query = _query.DocumentoFiscalTenantIDQuery(command );

                lista = _unitOfWork.Query<DocumentoFiscalTenantIDDTO>(query.Query,query.Parameters) as List<DocumentoFiscalTenantIDDTO>;
            return lista;
        }

        public IEnumerable<DocumentoFiscalTenantIDDTO> getDocumentoFiscalReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getDocumentoFiscalReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<DocumentoFiscalUserIdDTO> getDocumentoFiscalReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<DocumentoFiscalUserIdDTO> lista;
            var query = _query.DocumentoFiscalUserIdQuery(command );

                lista = _unitOfWork.Query<DocumentoFiscalUserIdDTO>(query.Query,query.Parameters) as List<DocumentoFiscalUserIdDTO>;
            return lista;
        }

        public IEnumerable<DocumentoFiscalUserIdDTO> getDocumentoFiscalReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getDocumentoFiscalReadFKUserId(c );
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

        public bool ExistsByProdutoFiscal(int value )
        {
            var query = _query.ExistsByProdutoFiscalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChaveAcesso(string value )
        {
            var query = _query.ExistsByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySerie(int value )
        {
            var query = _query.ExistsBySerieQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNumero(int value )
        {
            var query = _query.ExistsByNumeroQuery(value );

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

        public bool ExistsByDestinatarioDocumento(string value )
        {
            var query = _query.ExistsByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByXmlStorageKey(string value )
        {
            var query = _query.ExistsByXmlStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByXmlHash(string value )
        {
            var query = _query.ExistsByXmlHashQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProtocoloAutorizacao(string value )
        {
            var query = _query.ExistsByProtocoloAutorizacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCodigoRetorno(string value )
        {
            var query = _query.ExistsByCodigoRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMensagemRetorno(string value )
        {
            var query = _query.ExistsByMensagemRetornoQuery(value );

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

        public DocumentoFiscalDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByProdutoFiscal(int value )
        {
            var query = _query.FirstByProdutoFiscalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstBySerie(int value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByNumero(int value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByUFEmitente(string value )
        {
            var query = _query.FirstByUFEmitenteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByXmlStorageKey(string value )
        {
            var query = _query.FirstByXmlStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByXmlHash(string value )
        {
            var query = _query.FirstByXmlHashQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByProtocoloAutorizacao(string value )
        {
            var query = _query.FirstByProtocoloAutorizacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByProdutoFiscal(int value )
        {
            var query = _query.FirstByProdutoFiscalQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllBySerie(int value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByNumero(int value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByUFEmitente(string value )
        {
            var query = _query.FirstByUFEmitenteQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByXmlStorageKey(string value )
        {
            var query = _query.FirstByXmlStorageKeyQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByXmlHash(string value )
        {
            var query = _query.FirstByXmlHashQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByProtocoloAutorizacao(string value )
        {
            var query = _query.FirstByProtocoloAutorizacaoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

        public IEnumerable<DocumentoFiscalDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalDTO>(query.Query,query.Parameters) as List<DocumentoFiscalDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration