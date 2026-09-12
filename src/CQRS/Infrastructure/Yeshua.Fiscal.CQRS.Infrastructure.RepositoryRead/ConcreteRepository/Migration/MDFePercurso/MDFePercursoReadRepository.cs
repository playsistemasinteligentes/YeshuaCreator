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
    public partial class MDFePercursoReadRepository : IMDFePercursoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMDFePercursoQueryRead _query;

        public MDFePercursoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMDFePercursoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMDFePercursoCustom(Command.Read.MDFePercursoReadCommand command, ref DataPagination<MDFePercursoDTO> result, ref bool handled);

        public DataPagination<MDFePercursoDTO> getMDFePercurso(ICommandRead command )
         {
            if (command is Command.Read.MDFePercursoReadCommand c)
                return getMDFePercurso(c );
            throw new NotImplementedException();
        }
        private DataPagination<MDFePercursoDTO> getMDFePercurso(Command.Read.MDFePercursoReadCommand command )
        {
            var customResult = new DataPagination<MDFePercursoDTO>();
            var customHandled = false;
            TryGetMDFePercursoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MDFePercursoQuery(command );

                var itens = _unitOfWork.Query<MDFePercursoDTO>(query.Query,query.Parameters);
                return new DataPagination<MDFePercursoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MDFePercursoMDFeSolicitacaoFiscalIdDTO> getMDFePercursoReadFKMDFeSolicitacaoFiscalId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MDFePercursoMDFeSolicitacaoFiscalIdQuery(command );

                var lista = _unitOfWork.Query<MDFePercursoMDFeSolicitacaoFiscalIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MDFePercursoMDFeSolicitacaoFiscalIdDTO> getMDFePercursoReadFKMDFeSolicitacaoFiscalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFePercursoReadFKMDFeSolicitacaoFiscalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFePercursoTenantIDDTO> getMDFePercursoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MDFePercursoTenantIDQuery(command );

                var lista = _unitOfWork.Query<MDFePercursoTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MDFePercursoTenantIDDTO> getMDFePercursoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFePercursoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MDFePercursoUserIdDTO> getMDFePercursoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MDFePercursoUserIdQuery(command );

                var lista = _unitOfWork.Query<MDFePercursoUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MDFePercursoUserIdDTO> getMDFePercursoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMDFePercursoReadFKUserId(c );
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

        public bool ExistsByUF(string value )
        {
            var query = _query.ExistsByUFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOrdem(int value )
        {
            var query = _query.ExistsByOrdemQuery(value );

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

        public MDFePercursoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFePercursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFePercursoDTO FirstByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFePercursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFePercursoDTO FirstByUF(string value )
        {
            var query = _query.FirstByUFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFePercursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFePercursoDTO FirstByOrdem(int value )
        {
            var query = _query.FirstByOrdemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFePercursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFePercursoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFePercursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFePercursoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFePercursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFePercursoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFePercursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MDFePercursoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MDFePercursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MDFePercursoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MDFePercursoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFePercursoDTO> GetAllByMDFeSolicitacaoFiscalId(int value )
        {
            var query = _query.FirstByMDFeSolicitacaoFiscalIdQuery(value );

                var result = _unitOfWork.Query<MDFePercursoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFePercursoDTO> GetAllByUF(string value )
        {
            var query = _query.FirstByUFQuery(value );

                var result = _unitOfWork.Query<MDFePercursoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFePercursoDTO> GetAllByOrdem(int value )
        {
            var query = _query.FirstByOrdemQuery(value );

                var result = _unitOfWork.Query<MDFePercursoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFePercursoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MDFePercursoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFePercursoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MDFePercursoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFePercursoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MDFePercursoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MDFePercursoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MDFePercursoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration