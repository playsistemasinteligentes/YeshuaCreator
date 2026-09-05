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
    public partial class SefazEndpointReadRepository : ISefazEndpointReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ISefazEndpointQueryRead _query;

        public SefazEndpointReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ISefazEndpointQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetSefazEndpointCustom(Command.Read.SefazEndpointReadCommand command, ref DataPagination<SefazEndpointDTO> result, ref bool handled);

        public DataPagination<SefazEndpointDTO> getSefazEndpoint(ICommandRead command )
         {
            if (command is Command.Read.SefazEndpointReadCommand c)
                return getSefazEndpoint(c );
            throw new NotImplementedException();
        }
        private DataPagination<SefazEndpointDTO> getSefazEndpoint(Command.Read.SefazEndpointReadCommand command )
        {
            DataPagination<SefazEndpointDTO> customResult = null;
            var customHandled = false;
            TryGetSefazEndpointCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.SefazEndpointQuery(command );

                var itens = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters);
                return new DataPagination<SefazEndpointDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<SefazEndpointTenantIDDTO> getSefazEndpointReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SefazEndpointTenantIDDTO> lista;
            var query = _query.SefazEndpointTenantIDQuery(command );

                lista = _unitOfWork.Query<SefazEndpointTenantIDDTO>(query.Query,query.Parameters) as List<SefazEndpointTenantIDDTO>;
            return lista;
        }

        public IEnumerable<SefazEndpointTenantIDDTO> getSefazEndpointReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSefazEndpointReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SefazEndpointUserIdDTO> getSefazEndpointReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<SefazEndpointUserIdDTO> lista;
            var query = _query.SefazEndpointUserIdQuery(command );

                lista = _unitOfWork.Query<SefazEndpointUserIdDTO>(query.Query,query.Parameters) as List<SefazEndpointUserIdDTO>;
            return lista;
        }

        public IEnumerable<SefazEndpointUserIdDTO> getSefazEndpointReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSefazEndpointReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProdutoFiscal(int value )
        {
            var query = _query.ExistsByProdutoFiscalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUF(string value )
        {
            var query = _query.ExistsByUFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAmbiente(int value )
        {
            var query = _query.ExistsByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByServico(string value )
        {
            var query = _query.ExistsByServicoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVersao(string value )
        {
            var query = _query.ExistsByVersaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUrl(string value )
        {
            var query = _query.ExistsByUrlQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAtivo(int value )
        {
            var query = _query.ExistsByAtivoQuery(value );

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

        public SefazEndpointDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByProdutoFiscal(int value )
        {
            var query = _query.FirstByProdutoFiscalQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByUF(string value )
        {
            var query = _query.FirstByUFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByServico(string value )
        {
            var query = _query.FirstByServicoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByVersao(string value )
        {
            var query = _query.FirstByVersaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByUrl(string value )
        {
            var query = _query.FirstByUrlQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByAtivo(int value )
        {
            var query = _query.FirstByAtivoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public SefazEndpointDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<SefazEndpointDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByProdutoFiscal(int value )
        {
            var query = _query.FirstByProdutoFiscalQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByUF(string value )
        {
            var query = _query.FirstByUFQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByAmbiente(int value )
        {
            var query = _query.FirstByAmbienteQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByServico(string value )
        {
            var query = _query.FirstByServicoQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByVersao(string value )
        {
            var query = _query.FirstByVersaoQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByUrl(string value )
        {
            var query = _query.FirstByUrlQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByAtivo(int value )
        {
            var query = _query.FirstByAtivoQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

        public IEnumerable<SefazEndpointDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<SefazEndpointDTO>(query.Query,query.Parameters) as List<SefazEndpointDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration