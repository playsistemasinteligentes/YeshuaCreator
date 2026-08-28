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
    public partial class MemoriaDeCalculoReadRepository : IMemoriaDeCalculoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMemoriaDeCalculoQueryRead _query;

        public MemoriaDeCalculoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMemoriaDeCalculoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MemoriaDeCalculoDTO> getMemoriaDeCalculo(ICommandRead command )
         {
            if (command is Command.Read.MemoriaDeCalculoReadCommand c)
                return getMemoriaDeCalculo(c );
            throw new NotImplementedException();
        }
        private DataPagination<MemoriaDeCalculoDTO> getMemoriaDeCalculo(Command.Read.MemoriaDeCalculoReadCommand command )
        {
            var query = _query.MemoriaDeCalculoQuery(command );

                var itens = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters);
                return new DataPagination<MemoriaDeCalculoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MemoriaDeCalculoTenantIDDTO> getMemoriaDeCalculoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MemoriaDeCalculoTenantIDDTO> lista;
            var query = _query.MemoriaDeCalculoTenantIDQuery(command );

                lista = _unitOfWork.Query<MemoriaDeCalculoTenantIDDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MemoriaDeCalculoTenantIDDTO> getMemoriaDeCalculoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMemoriaDeCalculoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MemoriaDeCalculoUserIdDTO> getMemoriaDeCalculoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MemoriaDeCalculoUserIdDTO> lista;
            var query = _query.MemoriaDeCalculoUserIdQuery(command );

                lista = _unitOfWork.Query<MemoriaDeCalculoUserIdDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoUserIdDTO>;
            return lista;
        }

        public IEnumerable<MemoriaDeCalculoUserIdDTO> getMemoriaDeCalculoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMemoriaDeCalculoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEM_ID(int value )
        {
            var query = _query.ExistsByMEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORC_ID(int value )
        {
            var query = _query.ExistsByORC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEM_VALOR(Decimal value )
        {
            var query = _query.ExistsByMEM_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMEM_DESCRICAO(string value )
        {
            var query = _query.ExistsByMEM_DESCRICAOQuery(value );

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

        public MemoriaDeCalculoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MemoriaDeCalculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MemoriaDeCalculoDTO FirstByMEM_ID(int value )
        {
            var query = _query.FirstByMEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MemoriaDeCalculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MemoriaDeCalculoDTO FirstByORC_ID(int value )
        {
            var query = _query.FirstByORC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MemoriaDeCalculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MemoriaDeCalculoDTO FirstByMEM_VALOR(Decimal value )
        {
            var query = _query.FirstByMEM_VALORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MemoriaDeCalculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MemoriaDeCalculoDTO FirstByMEM_DESCRICAO(string value )
        {
            var query = _query.FirstByMEM_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MemoriaDeCalculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MemoriaDeCalculoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MemoriaDeCalculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MemoriaDeCalculoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MemoriaDeCalculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MemoriaDeCalculoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MemoriaDeCalculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public MemoriaDeCalculoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MemoriaDeCalculoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MemoriaDeCalculoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoDTO>;
                return result;
        }

        public IEnumerable<MemoriaDeCalculoDTO> GetAllByMEM_ID(int value )
        {
            var query = _query.FirstByMEM_IDQuery(value );

                var result = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoDTO>;
                return result;
        }

        public IEnumerable<MemoriaDeCalculoDTO> GetAllByORC_ID(int value )
        {
            var query = _query.FirstByORC_IDQuery(value );

                var result = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoDTO>;
                return result;
        }

        public IEnumerable<MemoriaDeCalculoDTO> GetAllByMEM_VALOR(Decimal value )
        {
            var query = _query.FirstByMEM_VALORQuery(value );

                var result = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoDTO>;
                return result;
        }

        public IEnumerable<MemoriaDeCalculoDTO> GetAllByMEM_DESCRICAO(string value )
        {
            var query = _query.FirstByMEM_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoDTO>;
                return result;
        }

        public IEnumerable<MemoriaDeCalculoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoDTO>;
                return result;
        }

        public IEnumerable<MemoriaDeCalculoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoDTO>;
                return result;
        }

        public IEnumerable<MemoriaDeCalculoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoDTO>;
                return result;
        }

        public IEnumerable<MemoriaDeCalculoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MemoriaDeCalculoDTO>(query.Query,query.Parameters) as List<MemoriaDeCalculoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration