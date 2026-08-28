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
    public partial class OperacoesReadRepository : IOperacoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IOperacoesQueryRead _query;

        public OperacoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IOperacoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<OperacoesDTO> getOperacoes(ICommandRead command )
         {
            if (command is Command.Read.OperacoesReadCommand c)
                return getOperacoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<OperacoesDTO> getOperacoes(Command.Read.OperacoesReadCommand command )
        {
            var query = _query.OperacoesQuery(command );

                var itens = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters);
                return new DataPagination<OperacoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<OperacoesTenantIDDTO> getOperacoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OperacoesTenantIDDTO> lista;
            var query = _query.OperacoesTenantIDQuery(command );

                lista = _unitOfWork.Query<OperacoesTenantIDDTO>(query.Query,query.Parameters) as List<OperacoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<OperacoesTenantIDDTO> getOperacoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOperacoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OperacoesUserIdDTO> getOperacoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OperacoesUserIdDTO> lista;
            var query = _query.OperacoesUserIdQuery(command );

                lista = _unitOfWork.Query<OperacoesUserIdDTO>(query.Query,query.Parameters) as List<OperacoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<OperacoesUserIdDTO> getOperacoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOperacoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOPE_TIPO_REGISTRO(string value )
        {
            var query = _query.ExistsByOPE_TIPO_REGISTROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOPE_ID(string value )
        {
            var query = _query.ExistsByOPE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGMA_ID(string value )
        {
            var query = _query.ExistsByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOPE_EXCECAO(string value )
        {
            var query = _query.ExistsByOPE_EXCECAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.ExistsByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.ExistsByFPR_SEQ_REPETICAOQuery(value );

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

        public OperacoesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByOPE_TIPO_REGISTRO(string value )
        {
            var query = _query.FirstByOPE_TIPO_REGISTROQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByOPE_ID(string value )
        {
            var query = _query.FirstByOPE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByOPE_EXCECAO(string value )
        {
            var query = _query.FirstByOPE_EXCECAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OperacoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OperacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByOPE_TIPO_REGISTRO(string value )
        {
            var query = _query.FirstByOPE_TIPO_REGISTROQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByOPE_ID(string value )
        {
            var query = _query.FirstByOPE_IDQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByOPE_EXCECAO(string value )
        {
            var query = _query.FirstByOPE_EXCECAOQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

        public IEnumerable<OperacoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<OperacoesDTO>(query.Query,query.Parameters) as List<OperacoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration