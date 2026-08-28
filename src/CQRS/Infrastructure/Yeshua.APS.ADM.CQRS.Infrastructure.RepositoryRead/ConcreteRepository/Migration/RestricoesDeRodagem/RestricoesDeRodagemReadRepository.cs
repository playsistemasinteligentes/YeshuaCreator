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
    public partial class RestricoesDeRodagemReadRepository : IRestricoesDeRodagemReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRestricoesDeRodagemQueryRead _query;

        public RestricoesDeRodagemReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRestricoesDeRodagemQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<RestricoesDeRodagemDTO> getRestricoesDeRodagem(ICommandRead command )
         {
            if (command is Command.Read.RestricoesDeRodagemReadCommand c)
                return getRestricoesDeRodagem(c );
            throw new NotImplementedException();
        }
        private DataPagination<RestricoesDeRodagemDTO> getRestricoesDeRodagem(Command.Read.RestricoesDeRodagemReadCommand command )
        {
            var query = _query.RestricoesDeRodagemQuery(command );

                var itens = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters);
                return new DataPagination<RestricoesDeRodagemDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RestricoesDeRodagemTenantIDDTO> getRestricoesDeRodagemReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RestricoesDeRodagemTenantIDDTO> lista;
            var query = _query.RestricoesDeRodagemTenantIDQuery(command );

                lista = _unitOfWork.Query<RestricoesDeRodagemTenantIDDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RestricoesDeRodagemTenantIDDTO> getRestricoesDeRodagemReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRestricoesDeRodagemReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RestricoesDeRodagemUserIdDTO> getRestricoesDeRodagemReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RestricoesDeRodagemUserIdDTO> lista;
            var query = _query.RestricoesDeRodagemUserIdQuery(command );

                lista = _unitOfWork.Query<RestricoesDeRodagemUserIdDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemUserIdDTO>;
            return lista;
        }

        public IEnumerable<RestricoesDeRodagemUserIdDTO> getRestricoesDeRodagemReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRestricoesDeRodagemReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRES_ID(int value )
        {
            var query = _query.ExistsByRES_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRES_TIPO(string value )
        {
            var query = _query.ExistsByRES_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRES_HORA_INI(string value )
        {
            var query = _query.ExistsByRES_HORA_INIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRES_HORA_FIM(string value )
        {
            var query = _query.ExistsByRES_HORA_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRES_VELOCIDADE_HORA_RUSH(Decimal value )
        {
            var query = _query.ExistsByRES_VELOCIDADE_HORA_RUSHQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTVE_ID(int value )
        {
            var query = _query.ExistsByTVE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAP_ID(int value )
        {
            var query = _query.ExistsByMAP_IDQuery(value );

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

        public RestricoesDeRodagemDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByRES_ID(int value )
        {
            var query = _query.FirstByRES_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByRES_TIPO(string value )
        {
            var query = _query.FirstByRES_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByRES_HORA_INI(string value )
        {
            var query = _query.FirstByRES_HORA_INIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByRES_HORA_FIM(string value )
        {
            var query = _query.FirstByRES_HORA_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByRES_VELOCIDADE_HORA_RUSH(Decimal value )
        {
            var query = _query.FirstByRES_VELOCIDADE_HORA_RUSHQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByTVE_ID(int value )
        {
            var query = _query.FirstByTVE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByMAP_ID(int value )
        {
            var query = _query.FirstByMAP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public RestricoesDeRodagemDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RestricoesDeRodagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_ID(int value )
        {
            var query = _query.FirstByRES_IDQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_TIPO(string value )
        {
            var query = _query.FirstByRES_TIPOQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_HORA_INI(string value )
        {
            var query = _query.FirstByRES_HORA_INIQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_HORA_FIM(string value )
        {
            var query = _query.FirstByRES_HORA_FIMQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_VELOCIDADE_HORA_RUSH(Decimal value )
        {
            var query = _query.FirstByRES_VELOCIDADE_HORA_RUSHQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByTVE_ID(int value )
        {
            var query = _query.FirstByTVE_IDQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByMAP_ID(int value )
        {
            var query = _query.FirstByMAP_IDQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

        public IEnumerable<RestricoesDeRodagemDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RestricoesDeRodagemDTO>(query.Query,query.Parameters) as List<RestricoesDeRodagemDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration