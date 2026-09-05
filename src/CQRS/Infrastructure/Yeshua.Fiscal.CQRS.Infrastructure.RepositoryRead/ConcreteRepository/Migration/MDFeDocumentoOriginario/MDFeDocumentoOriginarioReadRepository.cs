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
    public partial class MDFeDocumentoOriginarioReadRepository : IMDFeDocumentoOriginarioReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMDFeDocumentoOriginarioQueryRead _query;

        public MDFeDocumentoOriginarioReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMDFeDocumentoOriginarioQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMDFeDocumentoOriginarioCustom(Command.Read.MDFeDocumentoOriginarioReadCommand command, ref DataPagination<MDFeDocumentoOriginarioDTO> result, ref bool handled);

        public DataPagination<MDFeDocumentoOriginarioDTO> getMDFeDocumentoOriginario(ICommandRead command )
         {
            if (command is Command.Read.MDFeDocumentoOriginarioReadCommand c)
                return getMDFeDocumentoOriginario(c );
            throw new NotImplementedException();
        }
        private DataPagination<MDFeDocumentoOriginarioDTO> getMDFeDocumentoOriginario(Command.Read.MDFeDocumentoOriginarioReadCommand command )
        {
            DataPagination<MDFeDocumentoOriginarioDTO> customResult = null;
            var customHandled = false;
            TryGetMDFeDocumentoOriginarioCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MDFeDocumentoOriginarioQuery(command );

                var itens = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters);
                return new DataPagination<MDFeDocumentoOriginarioDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MDFeDocumentoOriginarioMDFeSolicitacaoFiscalIdDTO> getMDFeDocumentoOriginarioReadFKMDFeSolicitacaoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeDocumentoOriginarioMDFeSolicitacaoFiscalIdDTO> lista;
            var query = _query.MDFeDocumentoOriginarioMDFeSolicitacaoFiscalIdQuery(command );

                lista = _unitOfWork.Query<MDFeDocumentoOriginarioMDFeSolicitacaoFiscalIdDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioMDFeSolicitacaoFiscalIdDTO>;
            return lista;
        }

        public IEnumerable<MDFeDocumentoOriginarioMDFeSolicitacaoFiscalIdDTO> getMDFeDocumentoOriginarioReadFKMDFeSolicitacaoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeDocumentoOriginarioReadFKMDFeSolicitacaoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeDocumentoOriginarioDocumentoFiscalOriginarioIdDTO> getMDFeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeDocumentoOriginarioDocumentoFiscalOriginarioIdDTO> lista;
            var query = _query.MDFeDocumentoOriginarioDocumentoFiscalOriginarioIdQuery(command );

                lista = _unitOfWork.Query<MDFeDocumentoOriginarioDocumentoFiscalOriginarioIdDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDocumentoFiscalOriginarioIdDTO>;
            return lista;
        }

        public IEnumerable<MDFeDocumentoOriginarioDocumentoFiscalOriginarioIdDTO> getMDFeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeDocumentoOriginarioTenantIDDTO> getMDFeDocumentoOriginarioReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeDocumentoOriginarioTenantIDDTO> lista;
            var query = _query.MDFeDocumentoOriginarioTenantIDQuery(command );

                lista = _unitOfWork.Query<MDFeDocumentoOriginarioTenantIDDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MDFeDocumentoOriginarioTenantIDDTO> getMDFeDocumentoOriginarioReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeDocumentoOriginarioReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeDocumentoOriginarioUserIdDTO> getMDFeDocumentoOriginarioReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MDFeDocumentoOriginarioUserIdDTO> lista;
            var query = _query.MDFeDocumentoOriginarioUserIdQuery(command );

                lista = _unitOfWork.Query<MDFeDocumentoOriginarioUserIdDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioUserIdDTO>;
            return lista;
        }

        public IEnumerable<MDFeDocumentoOriginarioUserIdDTO> getMDFeDocumentoOriginarioReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeDocumentoOriginarioReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.ExistsByMDFeSolicitacaoFiscalIdQuery(value );

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

        public MDFeDocumentoOriginarioDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDocumentoOriginarioDTO FirstByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDocumentoOriginarioDTO FirstByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.FirstByDocumentoFiscalOriginarioIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDocumentoOriginarioDTO FirstByTipoDocumento(string value )
        {
            var query = _query.FirstByTipoDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDocumentoOriginarioDTO FirstByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDocumentoOriginarioDTO FirstBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDocumentoOriginarioDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDocumentoOriginarioDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDocumentoOriginarioDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeDocumentoOriginarioDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeDocumentoOriginarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByDocumentoFiscalOriginarioId(int value )
        {
            var query = _query.FirstByDocumentoFiscalOriginarioIdQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByTipoDocumento(string value )
        {
            var query = _query.FirstByTipoDocumentoQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByChaveAcesso(string value )
        {
            var query = _query.FirstByChaveAcessoQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllBySnapshotJson(string value )
        {
            var query = _query.FirstBySnapshotJsonQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MDFeDocumentoOriginarioDTO>(query.Query,query.Parameters) as List<MDFeDocumentoOriginarioDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration