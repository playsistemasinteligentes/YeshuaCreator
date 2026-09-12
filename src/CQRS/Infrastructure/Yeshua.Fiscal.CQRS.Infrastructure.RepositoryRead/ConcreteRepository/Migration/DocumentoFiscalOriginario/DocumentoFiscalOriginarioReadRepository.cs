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
    public partial class DocumentoFiscalOriginarioReadRepository : IDocumentoFiscalOriginarioReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IDocumentoFiscalOriginarioQueryRead _query;

        public DocumentoFiscalOriginarioReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IDocumentoFiscalOriginarioQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetDocumentoFiscalOriginarioCustom(Command.Read.DocumentoFiscalOriginarioReadCommand command, ref DataPagination<DocumentoFiscalOriginarioDTO> result, ref bool handled);

        public DataPagination<DocumentoFiscalOriginarioDTO> getDocumentoFiscalOriginario(ICommandRead command )
         {
            if (command is Command.Read.DocumentoFiscalOriginarioReadCommand c)
                return getDocumentoFiscalOriginario(c );
            throw new NotImplementedException();
        }
        private DataPagination<DocumentoFiscalOriginarioDTO> getDocumentoFiscalOriginario(Command.Read.DocumentoFiscalOriginarioReadCommand command )
        {
            var customResult = new DataPagination<DocumentoFiscalOriginarioDTO>();
            var customHandled = false;
            TryGetDocumentoFiscalOriginarioCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.DocumentoFiscalOriginarioQuery(command );

                var itens = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters);
                return new DataPagination<DocumentoFiscalOriginarioDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<DocumentoFiscalOriginarioDocumentoFiscalIdDTO> getDocumentoFiscalOriginarioReadFKDocumentoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.DocumentoFiscalOriginarioDocumentoFiscalIdQuery(command );

                var lista = _unitOfWork.Query<DocumentoFiscalOriginarioDocumentoFiscalIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<DocumentoFiscalOriginarioDocumentoFiscalIdDTO> getDocumentoFiscalOriginarioReadFKDocumentoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getDocumentoFiscalOriginarioReadFKDocumentoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<DocumentoFiscalOriginarioTenantIDDTO> getDocumentoFiscalOriginarioReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.DocumentoFiscalOriginarioTenantIDQuery(command );

                var lista = _unitOfWork.Query<DocumentoFiscalOriginarioTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<DocumentoFiscalOriginarioTenantIDDTO> getDocumentoFiscalOriginarioReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getDocumentoFiscalOriginarioReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<DocumentoFiscalOriginarioUserIdDTO> getDocumentoFiscalOriginarioReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.DocumentoFiscalOriginarioUserIdQuery(command );

                var lista = _unitOfWork.Query<DocumentoFiscalOriginarioUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<DocumentoFiscalOriginarioUserIdDTO> getDocumentoFiscalOriginarioReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getDocumentoFiscalOriginarioReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDocumentoFiscalId(int value )
        {
            var query = _query.ExistsByDocumentoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value )
        {
            var query = _query.ExistsByCorrelationIdQuery(value );

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

        public bool ExistsByTipoDocumento(string value )
        {
            var query = _query.ExistsByTipoDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChaveAcesso(string value )
        {
            var query = _query.ExistsByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNumero(string value )
        {
            var query = _query.ExistsByNumeroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySerie(string value )
        {
            var query = _query.ExistsBySerieQuery(value );

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

        public DocumentoFiscalOriginarioDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByDocumentoFiscalId(int value )
        {
            var query = _query.FirstByDocumentoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstBySourceApplication(string value )
        {
            var query = _query.FirstBySourceApplicationQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstBySourceModule(string value )
        {
            var query = _query.FirstBySourceModuleQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstBySourceMessageId(string value )
        {
            var query = _query.FirstBySourceMessageIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByTipoDocumento(string value )
        {
            var query = _query.FirstByTipoDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByNumero(string value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstBySerie(string value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByValorDocumento(Decimal value )
        {
            var query = _query.FirstByValorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public DocumentoFiscalOriginarioDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<DocumentoFiscalOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByDocumentoFiscalId(int value )
        {
            var query = _query.FirstByDocumentoFiscalIdQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySourceApplication(string value )
        {
            var query = _query.FirstBySourceApplicationQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySourceModule(string value )
        {
            var query = _query.FirstBySourceModuleQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySourceMessageId(string value )
        {
            var query = _query.FirstBySourceMessageIdQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByTipoDocumento(string value )
        {
            var query = _query.FirstByTipoDocumentoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByNumero(string value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySerie(string value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByValorDocumento(Decimal value )
        {
            var query = _query.FirstByValorDocumentoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByVolume(Decimal value )
        {
            var query = _query.FirstByVolumeQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<DocumentoFiscalOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration