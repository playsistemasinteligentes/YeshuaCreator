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
    public partial class EmissaoFiscalTransporteDocumentoReadRepository : IEmissaoFiscalTransporteDocumentoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEmissaoFiscalTransporteDocumentoQueryRead _query;

        public EmissaoFiscalTransporteDocumentoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEmissaoFiscalTransporteDocumentoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetEmissaoFiscalTransporteDocumentoCustom(Command.Read.EmissaoFiscalTransporteDocumentoReadCommand command, ref DataPagination<EmissaoFiscalTransporteDocumentoDTO> result, ref bool handled);

        public DataPagination<EmissaoFiscalTransporteDocumentoDTO> getEmissaoFiscalTransporteDocumento(ICommandRead command )
         {
            if (command is Command.Read.EmissaoFiscalTransporteDocumentoReadCommand c)
                return getEmissaoFiscalTransporteDocumento(c );
            throw new NotImplementedException();
        }
        private DataPagination<EmissaoFiscalTransporteDocumentoDTO> getEmissaoFiscalTransporteDocumento(Command.Read.EmissaoFiscalTransporteDocumentoReadCommand command )
        {
            var customResult = new DataPagination<EmissaoFiscalTransporteDocumentoDTO>();
            var customHandled = false;
            TryGetEmissaoFiscalTransporteDocumentoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.EmissaoFiscalTransporteDocumentoQuery(command );

                var itens = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters);
                return new DataPagination<EmissaoFiscalTransporteDocumentoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EmissaoFiscalTransporteDocumentoEmissaoFiscalTransporteIdDTO> getEmissaoFiscalTransporteDocumentoReadFKEmissaoFiscalTransporteId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.EmissaoFiscalTransporteDocumentoEmissaoFiscalTransporteIdQuery(command );

                var lista = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoEmissaoFiscalTransporteIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoEmissaoFiscalTransporteIdDTO> getEmissaoFiscalTransporteDocumentoReadFKEmissaoFiscalTransporteId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEmissaoFiscalTransporteDocumentoReadFKEmissaoFiscalTransporteId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EmissaoFiscalTransporteDocumentoDocumentoFiscalIdDTO> getEmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.EmissaoFiscalTransporteDocumentoDocumentoFiscalIdQuery(command );

                var lista = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDocumentoFiscalIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDocumentoFiscalIdDTO> getEmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EmissaoFiscalTransporteDocumentoDocumentoFiscalOriginarioIdDTO> getEmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalOriginarioId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.EmissaoFiscalTransporteDocumentoDocumentoFiscalOriginarioIdQuery(command );

                var lista = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDocumentoFiscalOriginarioIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDocumentoFiscalOriginarioIdDTO> getEmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalOriginarioId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalOriginarioId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EmissaoFiscalTransporteDocumentoNFeProdutoSnapshotIdDTO> getEmissaoFiscalTransporteDocumentoReadFKNFeProdutoSnapshotId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.EmissaoFiscalTransporteDocumentoNFeProdutoSnapshotIdQuery(command );

                var lista = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoNFeProdutoSnapshotIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoNFeProdutoSnapshotIdDTO> getEmissaoFiscalTransporteDocumentoReadFKNFeProdutoSnapshotId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEmissaoFiscalTransporteDocumentoReadFKNFeProdutoSnapshotId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EmissaoFiscalTransporteDocumentoTenantIDDTO> getEmissaoFiscalTransporteDocumentoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.EmissaoFiscalTransporteDocumentoTenantIDQuery(command );

                var lista = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoTenantIDDTO> getEmissaoFiscalTransporteDocumentoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEmissaoFiscalTransporteDocumentoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EmissaoFiscalTransporteDocumentoUserIdDTO> getEmissaoFiscalTransporteDocumentoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.EmissaoFiscalTransporteDocumentoUserIdQuery(command );

                var lista = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoUserIdDTO> getEmissaoFiscalTransporteDocumentoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEmissaoFiscalTransporteDocumentoReadFKUserId(c );
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

        public bool ExistsByDocumentoFiscalId(int value )
        {
            var query = _query.ExistsByDocumentoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.ExistsByDocumentoFiscalOriginarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNFeProdutoSnapshotId(int value )
        {
            var query = _query.ExistsByNFeProdutoSnapshotIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProdutoFiscal(int value )
        {
            var query = _query.ExistsByProdutoFiscalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPapel(int value )
        {
            var query = _query.ExistsByPapelQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipoEvento(string value )
        {
            var query = _query.ExistsByTipoEventoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChaveAcesso(string value )
        {
            var query = _query.ExistsByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByXmlStorageKey(string value )
        {
            var query = _query.ExistsByXmlStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPdfStorageKey(string value )
        {
            var query = _query.ExistsByPdfStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProtocolo(string value )
        {
            var query = _query.ExistsByProtocoloQuery(value );

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

        public bool ExistsByCriadoEmUtc(DateTime value )
        {
            var query = _query.ExistsByCriadoEmUtcQuery(value );

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

        public EmissaoFiscalTransporteDocumentoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByEmissaoFiscalTransporteId(int value )
        {
            var query = _query.FirstByEmissaoFiscalTransporteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByDocumentoFiscalId(int value )
        {
            var query = _query.FirstByDocumentoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.FirstByDocumentoFiscalOriginarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByNFeProdutoSnapshotId(int value )
        {
            var query = _query.FirstByNFeProdutoSnapshotIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByProdutoFiscal(int value )
        {
            var query = _query.FirstByProdutoFiscalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByPapel(int value )
        {
            var query = _query.FirstByPapelQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByTipoEvento(string value )
        {
            var query = _query.FirstByTipoEventoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByXmlStorageKey(string value )
        {
            var query = _query.FirstByXmlStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByPdfStorageKey(string value )
        {
            var query = _query.FirstByPdfStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByProtocolo(string value )
        {
            var query = _query.FirstByProtocoloQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByCriadoEmUtc(DateTime value )
        {
            var query = _query.FirstByCriadoEmUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EmissaoFiscalTransporteDocumentoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EmissaoFiscalTransporteDocumentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByEmissaoFiscalTransporteId(int value )
        {
            var query = _query.FirstByEmissaoFiscalTransporteIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByDocumentoFiscalId(int value )
        {
            var query = _query.FirstByDocumentoFiscalIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.FirstByDocumentoFiscalOriginarioIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByNFeProdutoSnapshotId(int value )
        {
            var query = _query.FirstByNFeProdutoSnapshotIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByProdutoFiscal(int value )
        {
            var query = _query.FirstByProdutoFiscalQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByPapel(int value )
        {
            var query = _query.FirstByPapelQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByTipoEvento(string value )
        {
            var query = _query.FirstByTipoEventoQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByXmlStorageKey(string value )
        {
            var query = _query.FirstByXmlStorageKeyQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByPdfStorageKey(string value )
        {
            var query = _query.FirstByPdfStorageKeyQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByProtocolo(string value )
        {
            var query = _query.FirstByProtocoloQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByCodigoRetorno(string value )
        {
            var query = _query.FirstByCodigoRetornoQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByMensagemRetorno(string value )
        {
            var query = _query.FirstByMensagemRetornoQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByCriadoEmUtc(DateTime value )
        {
            var query = _query.FirstByCriadoEmUtcQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EmissaoFiscalTransporteDocumentoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration