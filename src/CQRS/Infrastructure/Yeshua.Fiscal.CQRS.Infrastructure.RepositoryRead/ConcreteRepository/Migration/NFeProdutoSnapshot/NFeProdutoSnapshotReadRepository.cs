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
    public partial class NFeProdutoSnapshotReadRepository : INFeProdutoSnapshotReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly INFeProdutoSnapshotQueryRead _query;

        public NFeProdutoSnapshotReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,INFeProdutoSnapshotQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetNFeProdutoSnapshotCustom(Command.Read.NFeProdutoSnapshotReadCommand command, ref DataPagination<NFeProdutoSnapshotDTO> result, ref bool handled);

        public DataPagination<NFeProdutoSnapshotDTO> getNFeProdutoSnapshot(ICommandRead command )
         {
            if (command is Command.Read.NFeProdutoSnapshotReadCommand c)
                return getNFeProdutoSnapshot(c );
            throw new NotImplementedException();
        }
        private DataPagination<NFeProdutoSnapshotDTO> getNFeProdutoSnapshot(Command.Read.NFeProdutoSnapshotReadCommand command )
        {
            var customResult = new DataPagination<NFeProdutoSnapshotDTO>();
            var customHandled = false;
            TryGetNFeProdutoSnapshotCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.NFeProdutoSnapshotQuery(command );

                var itens = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters);
                return new DataPagination<NFeProdutoSnapshotDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<NFeProdutoSnapshotDocumentoFiscalOriginarioIdDTO> getNFeProdutoSnapshotReadFKDocumentoFiscalOriginarioId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.NFeProdutoSnapshotDocumentoFiscalOriginarioIdQuery(command );

                var lista = _unitOfWork.Query<NFeProdutoSnapshotDocumentoFiscalOriginarioIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<NFeProdutoSnapshotDocumentoFiscalOriginarioIdDTO> getNFeProdutoSnapshotReadFKDocumentoFiscalOriginarioId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getNFeProdutoSnapshotReadFKDocumentoFiscalOriginarioId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<NFeProdutoSnapshotTenantIDDTO> getNFeProdutoSnapshotReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.NFeProdutoSnapshotTenantIDQuery(command );

                var lista = _unitOfWork.Query<NFeProdutoSnapshotTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<NFeProdutoSnapshotTenantIDDTO> getNFeProdutoSnapshotReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getNFeProdutoSnapshotReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<NFeProdutoSnapshotUserIdDTO> getNFeProdutoSnapshotReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.NFeProdutoSnapshotUserIdQuery(command );

                var lista = _unitOfWork.Query<NFeProdutoSnapshotUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<NFeProdutoSnapshotUserIdDTO> getNFeProdutoSnapshotReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getNFeProdutoSnapshotReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.ExistsByDocumentoFiscalOriginarioIdQuery(value );

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

        public bool ExistsByPedidoId(string value )
        {
            var query = _query.ExistsByPedidoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChaveAcesso(string value )
        {
            var query = _query.ExistsByChaveAcessoQuery(value );

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

        public bool ExistsByUFOrigem(string value )
        {
            var query = _query.ExistsByUFOrigemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUFDestino(string value )
        {
            var query = _query.ExistsByUFDestinoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMunicipioOrigemCodigoIbge(string value )
        {
            var query = _query.ExistsByMunicipioOrigemCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMunicipioDestinoCodigoIbge(string value )
        {
            var query = _query.ExistsByMunicipioDestinoCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValorDocumento(Decimal value )
        {
            var query = _query.ExistsByValorDocumentoQuery(value );

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

        public bool ExistsByXmlStorageKey(string value )
        {
            var query = _query.ExistsByXmlStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySnapshotJson(string value )
        {
            var query = _query.ExistsBySnapshotJsonQuery(value );

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

        public NFeProdutoSnapshotDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.FirstByDocumentoFiscalOriginarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByUFOrigem(string value )
        {
            var query = _query.FirstByUFOrigemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByUFDestino(string value )
        {
            var query = _query.FirstByUFDestinoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByMunicipioOrigemCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioOrigemCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByMunicipioDestinoCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioDestinoCodigoIbgeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByValorDocumento(Decimal value )
        {
            var query = _query.FirstByValorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByXmlStorageKey(string value )
        {
            var query = _query.FirstByXmlStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public NFeProdutoSnapshotDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<NFeProdutoSnapshotDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.FirstByDocumentoFiscalOriginarioIdQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByCargaId(string value )
        {
            var query = _query.FirstByCargaIdQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByUFOrigem(string value )
        {
            var query = _query.FirstByUFOrigemQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByUFDestino(string value )
        {
            var query = _query.FirstByUFDestinoQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByMunicipioOrigemCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioOrigemCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByMunicipioDestinoCodigoIbge(string value )
        {
            var query = _query.FirstByMunicipioDestinoCodigoIbgeQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByValorDocumento(Decimal value )
        {
            var query = _query.FirstByValorDocumentoQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByXmlStorageKey(string value )
        {
            var query = _query.FirstByXmlStorageKeyQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<NFeProdutoSnapshotDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration