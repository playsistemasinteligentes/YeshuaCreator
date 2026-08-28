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
    public partial class ItemTestavelReadRepository : IItemTestavelReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IItemTestavelQueryRead _query;

        public ItemTestavelReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IItemTestavelQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ItemTestavelDTO> getItemTestavel(ICommandRead command )
         {
            if (command is Command.Read.ItemTestavelReadCommand c)
                return getItemTestavel(c );
            throw new NotImplementedException();
        }
        private DataPagination<ItemTestavelDTO> getItemTestavel(Command.Read.ItemTestavelReadCommand command )
        {
            var query = _query.ItemTestavelQuery(command );

                var itens = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters);
                return new DataPagination<ItemTestavelDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ItemTestavelTenantIDDTO> getItemTestavelReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItemTestavelTenantIDDTO> lista;
            var query = _query.ItemTestavelTenantIDQuery(command );

                lista = _unitOfWork.Query<ItemTestavelTenantIDDTO>(query.Query,query.Parameters) as List<ItemTestavelTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ItemTestavelTenantIDDTO> getItemTestavelReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItemTestavelReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItemTestavelUserIdDTO> getItemTestavelReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItemTestavelUserIdDTO> lista;
            var query = _query.ItemTestavelUserIdQuery(command );

                lista = _unitOfWork.Query<ItemTestavelUserIdDTO>(query.Query,query.Parameters) as List<ItemTestavelUserIdDTO>;
            return lista;
        }

        public IEnumerable<ItemTestavelUserIdDTO> getItemTestavelReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItemTestavelReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITE_ID(int value )
        {
            var query = _query.ExistsByITE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITE_DESCRICAO(string value )
        {
            var query = _query.ExistsByITE_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITE_OBS(string value )
        {
            var query = _query.ExistsByITE_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITE_NUMERO_DE_TESTES(int value )
        {
            var query = _query.ExistsByITE_NUMERO_DE_TESTESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITE_CONDICIONAL_DE_AVALIACAO(string value )
        {
            var query = _query.ExistsByITE_CONDICIONAL_DE_AVALIACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITE_VALOR_DA_CONDICIONAL(Decimal value )
        {
            var query = _query.ExistsByITE_VALOR_DA_CONDICIONALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITE_VALOR_CALCULADO_DA_CONDICIONAL(string value )
        {
            var query = _query.ExistsByITE_VALOR_CALCULADO_DA_CONDICIONALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITE_TIPO_AVALIACAO_FINAL(string value )
        {
            var query = _query.ExistsByITE_TIPO_AVALIACAO_FINALQuery(value );

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

        public ItemTestavelDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByITE_ID(int value )
        {
            var query = _query.FirstByITE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByITE_DESCRICAO(string value )
        {
            var query = _query.FirstByITE_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByITE_OBS(string value )
        {
            var query = _query.FirstByITE_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByITE_NUMERO_DE_TESTES(int value )
        {
            var query = _query.FirstByITE_NUMERO_DE_TESTESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByITE_CONDICIONAL_DE_AVALIACAO(string value )
        {
            var query = _query.FirstByITE_CONDICIONAL_DE_AVALIACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByITE_VALOR_DA_CONDICIONAL(Decimal value )
        {
            var query = _query.FirstByITE_VALOR_DA_CONDICIONALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByITE_VALOR_CALCULADO_DA_CONDICIONAL(string value )
        {
            var query = _query.FirstByITE_VALOR_CALCULADO_DA_CONDICIONALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByITE_TIPO_AVALIACAO_FINAL(string value )
        {
            var query = _query.FirstByITE_TIPO_AVALIACAO_FINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItemTestavelDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItemTestavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByITE_ID(int value )
        {
            var query = _query.FirstByITE_IDQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByITE_DESCRICAO(string value )
        {
            var query = _query.FirstByITE_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByITE_OBS(string value )
        {
            var query = _query.FirstByITE_OBSQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByITE_NUMERO_DE_TESTES(int value )
        {
            var query = _query.FirstByITE_NUMERO_DE_TESTESQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByITE_CONDICIONAL_DE_AVALIACAO(string value )
        {
            var query = _query.FirstByITE_CONDICIONAL_DE_AVALIACAOQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByITE_VALOR_DA_CONDICIONAL(Decimal value )
        {
            var query = _query.FirstByITE_VALOR_DA_CONDICIONALQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByITE_VALOR_CALCULADO_DA_CONDICIONAL(string value )
        {
            var query = _query.FirstByITE_VALOR_CALCULADO_DA_CONDICIONALQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByITE_TIPO_AVALIACAO_FINAL(string value )
        {
            var query = _query.FirstByITE_TIPO_AVALIACAO_FINALQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

        public IEnumerable<ItemTestavelDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ItemTestavelDTO>(query.Query,query.Parameters) as List<ItemTestavelDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration