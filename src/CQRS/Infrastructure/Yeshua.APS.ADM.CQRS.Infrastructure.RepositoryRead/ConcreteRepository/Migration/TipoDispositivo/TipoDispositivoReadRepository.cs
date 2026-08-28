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
    public partial class TipoDispositivoReadRepository : ITipoDispositivoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoDispositivoQueryRead _query;

        public TipoDispositivoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoDispositivoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<TipoDispositivoDTO> getTipoDispositivo(ICommandRead command )
         {
            if (command is Command.Read.TipoDispositivoReadCommand c)
                return getTipoDispositivo(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoDispositivoDTO> getTipoDispositivo(Command.Read.TipoDispositivoReadCommand command )
        {
            var query = _query.TipoDispositivoQuery(command );

                var itens = _unitOfWork.Query<TipoDispositivoDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoDispositivoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoDispositivoTenantIDDTO> getTipoDispositivoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoDispositivoTenantIDDTO> lista;
            var query = _query.TipoDispositivoTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoDispositivoTenantIDDTO>(query.Query,query.Parameters) as List<TipoDispositivoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoDispositivoTenantIDDTO> getTipoDispositivoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoDispositivoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoDispositivoUserIdDTO> getTipoDispositivoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoDispositivoUserIdDTO> lista;
            var query = _query.TipoDispositivoUserIdQuery(command );

                lista = _unitOfWork.Query<TipoDispositivoUserIdDTO>(query.Query,query.Parameters) as List<TipoDispositivoUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoDispositivoUserIdDTO> getTipoDispositivoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoDispositivoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTDI_ID(string value )
        {
            var query = _query.ExistsByTDI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTDI_DESCRICAO(string value )
        {
            var query = _query.ExistsByTDI_DESCRICAOQuery(value );

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

        public TipoDispositivoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoDTO FirstByTDI_ID(string value )
        {
            var query = _query.FirstByTDI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoDTO FirstByTDI_DESCRICAO(string value )
        {
            var query = _query.FirstByTDI_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoDispositivoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoDTO>(query.Query,query.Parameters) as List<TipoDispositivoDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoDTO> GetAllByTDI_ID(string value )
        {
            var query = _query.FirstByTDI_IDQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoDTO>(query.Query,query.Parameters) as List<TipoDispositivoDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoDTO> GetAllByTDI_DESCRICAO(string value )
        {
            var query = _query.FirstByTDI_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoDTO>(query.Query,query.Parameters) as List<TipoDispositivoDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoDTO>(query.Query,query.Parameters) as List<TipoDispositivoDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoDTO>(query.Query,query.Parameters) as List<TipoDispositivoDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoDTO>(query.Query,query.Parameters) as List<TipoDispositivoDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoDTO>(query.Query,query.Parameters) as List<TipoDispositivoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration