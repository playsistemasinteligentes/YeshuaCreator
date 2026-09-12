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
    public partial class MDFeCondutorReadRepository : IMDFeCondutorReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMDFeCondutorQueryRead _query;

        public MDFeCondutorReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMDFeCondutorQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMDFeCondutorCustom(Command.Read.MDFeCondutorReadCommand command, ref DataPagination<MDFeCondutorDTO> result, ref bool handled);

        public DataPagination<MDFeCondutorDTO> getMDFeCondutor(ICommandRead command )
         {
            if (command is Command.Read.MDFeCondutorReadCommand c)
                return getMDFeCondutor(c );
            throw new NotImplementedException();
        }
        private DataPagination<MDFeCondutorDTO> getMDFeCondutor(Command.Read.MDFeCondutorReadCommand command )
        {
            var customResult = new DataPagination<MDFeCondutorDTO>();
            var customHandled = false;
            TryGetMDFeCondutorCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MDFeCondutorQuery(command );

                var itens = _unitOfWork.Query<MDFeCondutorDTO>(query.Query,query.Parameters);
                return new DataPagination<MDFeCondutorDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MDFeCondutorMDFeSolicitacaoFiscalIdDTO> getMDFeCondutorReadFKMDFeSolicitacaoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MDFeCondutorMDFeSolicitacaoFiscalIdQuery(command );

                var lista = _unitOfWork.Query<MDFeCondutorMDFeSolicitacaoFiscalIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MDFeCondutorMDFeSolicitacaoFiscalIdDTO> getMDFeCondutorReadFKMDFeSolicitacaoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeCondutorReadFKMDFeSolicitacaoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeCondutorTenantIDDTO> getMDFeCondutorReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MDFeCondutorTenantIDQuery(command );

                var lista = _unitOfWork.Query<MDFeCondutorTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MDFeCondutorTenantIDDTO> getMDFeCondutorReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeCondutorReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFeCondutorUserIdDTO> getMDFeCondutorReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MDFeCondutorUserIdQuery(command );

                var lista = _unitOfWork.Query<MDFeCondutorUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MDFeCondutorUserIdDTO> getMDFeCondutorReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFeCondutorReadFKUserId(c );
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

        public bool ExistsByNome(string value )
        {
            var query = _query.ExistsByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDocumento(string value )
        {
            var query = _query.ExistsByDocumentoQuery(value );

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

        public MDFeCondutorDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeCondutorDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeCondutorDTO FirstByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeCondutorDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeCondutorDTO FirstByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeCondutorDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeCondutorDTO FirstByDocumento(string value )
        {
            var query = _query.FirstByDocumentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeCondutorDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeCondutorDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeCondutorDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeCondutorDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeCondutorDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeCondutorDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeCondutorDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFeCondutorDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFeCondutorDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MDFeCondutorDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MDFeCondutorDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeCondutorDTO> GetAllByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.Query<MDFeCondutorDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeCondutorDTO> GetAllByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.Query<MDFeCondutorDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeCondutorDTO> GetAllByDocumento(string value )
        {
            var query = _query.FirstByDocumentoQuery(value );

                var result = _unitOfWork.Query<MDFeCondutorDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeCondutorDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MDFeCondutorDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeCondutorDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MDFeCondutorDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeCondutorDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MDFeCondutorDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFeCondutorDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MDFeCondutorDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration