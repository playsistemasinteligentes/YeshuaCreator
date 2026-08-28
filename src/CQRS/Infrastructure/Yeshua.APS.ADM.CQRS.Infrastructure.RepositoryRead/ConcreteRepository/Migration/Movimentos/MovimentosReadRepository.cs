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
    public partial class MovimentosReadRepository : IMovimentosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMovimentosQueryRead _query;

        public MovimentosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMovimentosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MovimentosDTO> getMovimentos(ICommandRead command )
         {
            if (command is Command.Read.MovimentosReadCommand c)
                return getMovimentos(c );
            throw new NotImplementedException();
        }
        private DataPagination<MovimentosDTO> getMovimentos(Command.Read.MovimentosReadCommand command )
        {
            var query = _query.MovimentosQuery(command );

                var itens = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters);
                return new DataPagination<MovimentosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MovimentosMOV_PLAIDDTO> getMovimentosReadFKMOV_PLAID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentosMOV_PLAIDDTO> lista;
            var query = _query.MovimentosMOV_PLAIDQuery(command );

                lista = _unitOfWork.Query<MovimentosMOV_PLAIDDTO>(query.Query,query.Parameters) as List<MovimentosMOV_PLAIDDTO>;
            return lista;
        }

        public IEnumerable<MovimentosMOV_PLAIDDTO> getMovimentosReadFKMOV_PLAID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentosReadFKMOV_PLAID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentosTr_Unidade_UNI_IDDTO> getMovimentosReadFKTr_Unidade_UNI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentosTr_Unidade_UNI_IDDTO> lista;
            var query = _query.MovimentosTr_Unidade_UNI_IDQuery(command );

                lista = _unitOfWork.Query<MovimentosTr_Unidade_UNI_IDDTO>(query.Query,query.Parameters) as List<MovimentosTr_Unidade_UNI_IDDTO>;
            return lista;
        }

        public IEnumerable<MovimentosTr_Unidade_UNI_IDDTO> getMovimentosReadFKTr_Unidade_UNI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentosReadFKTr_Unidade_UNI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentosTenantIDDTO> getMovimentosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentosTenantIDDTO> lista;
            var query = _query.MovimentosTenantIDQuery(command );

                lista = _unitOfWork.Query<MovimentosTenantIDDTO>(query.Query,query.Parameters) as List<MovimentosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MovimentosTenantIDDTO> getMovimentosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentosUserIdDTO> getMovimentosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentosUserIdDTO> lista;
            var query = _query.MovimentosUserIdQuery(command );

                lista = _unitOfWork.Query<MovimentosUserIdDTO>(query.Query,query.Parameters) as List<MovimentosUserIdDTO>;
            return lista;
        }

        public IEnumerable<MovimentosUserIdDTO> getMovimentosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByMOV_ID(int value )
        {
            var query = _query.ExistsByMOV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_DATA(string value )
        {
            var query = _query.ExistsByMOV_DATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_VALOR(Decimal value )
        {
            var query = _query.ExistsByMOV_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_PLAID(int value )
        {
            var query = _query.ExistsByMOV_PLAIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMOV_UNID(int value )
        {
            var query = _query.ExistsByMOV_UNIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTr_Unidade_UNI_ID(int value )
        {
            var query = _query.ExistsByTr_Unidade_UNI_IDQuery(value );

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

        public MovimentosDTO FirstByMOV_ID(int value )
        {
            var query = _query.FirstByMOV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentosDTO FirstByMOV_DATA(string value )
        {
            var query = _query.FirstByMOV_DATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentosDTO FirstByMOV_VALOR(Decimal value )
        {
            var query = _query.FirstByMOV_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentosDTO FirstByMOV_PLAID(int value )
        {
            var query = _query.FirstByMOV_PLAIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentosDTO FirstByMOV_UNID(int value )
        {
            var query = _query.FirstByMOV_UNIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentosDTO FirstByTr_Unidade_UNI_ID(int value )
        {
            var query = _query.FirstByTr_Unidade_UNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByMOV_ID(int value )
        {
            var query = _query.FirstByMOV_IDQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByMOV_DATA(string value )
        {
            var query = _query.FirstByMOV_DATAQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByMOV_VALOR(Decimal value )
        {
            var query = _query.FirstByMOV_VALORQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByMOV_PLAID(int value )
        {
            var query = _query.FirstByMOV_PLAIDQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByMOV_UNID(int value )
        {
            var query = _query.FirstByMOV_UNIDQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByTr_Unidade_UNI_ID(int value )
        {
            var query = _query.FirstByTr_Unidade_UNI_IDQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

        public IEnumerable<MovimentosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MovimentosDTO>(query.Query,query.Parameters) as List<MovimentosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration