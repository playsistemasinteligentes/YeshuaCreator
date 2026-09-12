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
    public partial class CTeDocumentoOriginarioReadRepository : ICTeDocumentoOriginarioReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICTeDocumentoOriginarioQueryRead _query;

        public CTeDocumentoOriginarioReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICTeDocumentoOriginarioQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCTeDocumentoOriginarioCustom(Command.Read.CTeDocumentoOriginarioReadCommand command, ref DataPagination<CTeDocumentoOriginarioDTO> result, ref bool handled);

        public DataPagination<CTeDocumentoOriginarioDTO> getCTeDocumentoOriginario(ICommandRead command )
         {
            if (command is Command.Read.CTeDocumentoOriginarioReadCommand c)
                return getCTeDocumentoOriginario(c );
            throw new NotImplementedException();
        }
        private DataPagination<CTeDocumentoOriginarioDTO> getCTeDocumentoOriginario(Command.Read.CTeDocumentoOriginarioReadCommand command )
        {
            var customResult = new DataPagination<CTeDocumentoOriginarioDTO>();
            var customHandled = false;
            TryGetCTeDocumentoOriginarioCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CTeDocumentoOriginarioQuery(command );

                var itens = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters);
                return new DataPagination<CTeDocumentoOriginarioDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CTeDocumentoOriginarioCTeSolicitacaoFiscalIdDTO> getCTeDocumentoOriginarioReadFKCTeSolicitacaoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeDocumentoOriginarioCTeSolicitacaoFiscalIdQuery(command );

                var lista = _unitOfWork.Query<CTeDocumentoOriginarioCTeSolicitacaoFiscalIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeDocumentoOriginarioCTeSolicitacaoFiscalIdDTO> getCTeDocumentoOriginarioReadFKCTeSolicitacaoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeDocumentoOriginarioReadFKCTeSolicitacaoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeDocumentoOriginarioDocumentoFiscalOriginarioIdDTO> getCTeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeDocumentoOriginarioDocumentoFiscalOriginarioIdQuery(command );

                var lista = _unitOfWork.Query<CTeDocumentoOriginarioDocumentoFiscalOriginarioIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeDocumentoOriginarioDocumentoFiscalOriginarioIdDTO> getCTeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeDocumentoOriginarioTenantIDDTO> getCTeDocumentoOriginarioReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeDocumentoOriginarioTenantIDQuery(command );

                var lista = _unitOfWork.Query<CTeDocumentoOriginarioTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeDocumentoOriginarioTenantIDDTO> getCTeDocumentoOriginarioReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeDocumentoOriginarioReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeDocumentoOriginarioUserIdDTO> getCTeDocumentoOriginarioReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeDocumentoOriginarioUserIdQuery(command );

                var lista = _unitOfWork.Query<CTeDocumentoOriginarioUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeDocumentoOriginarioUserIdDTO> getCTeDocumentoOriginarioReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeDocumentoOriginarioReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.ExistsByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.ExistsByDocumentoFiscalOriginarioIdQuery(value );

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

        public bool ExistsBySnapshotJson(string value )
        {
            var query = _query.ExistsBySnapshotJsonQuery(value );

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

        public CTeDocumentoOriginarioDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.FirstByDocumentoFiscalOriginarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByTipoDocumento(string value )
        {
            var query = _query.FirstByTipoDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByNumero(string value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstBySerie(string value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByValorDocumento(Decimal value )
        {
            var query = _query.FirstByValorDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeDocumentoOriginarioDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByCTeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByCTeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.FirstByDocumentoFiscalOriginarioIdQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByTipoDocumento(string value )
        {
            var query = _query.FirstByTipoDocumentoQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByNumero(string value )
        {
            var query = _query.FirstByNumeroQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllBySerie(string value )
        {
            var query = _query.FirstBySerieQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByEmitenteDocumento(string value )
        {
            var query = _query.FirstByEmitenteDocumentoQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByDestinatarioDocumento(string value )
        {
            var query = _query.FirstByDestinatarioDocumentoQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByValorDocumento(Decimal value )
        {
            var query = _query.FirstByValorDocumentoQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByPesoBruto(Decimal value )
        {
            var query = _query.FirstByPesoBrutoQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CTeDocumentoOriginarioDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration