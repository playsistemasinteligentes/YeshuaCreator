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
    public partial class TempoSetupOnduladeiraReadRepository : ITempoSetupOnduladeiraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITempoSetupOnduladeiraQueryRead _query;

        public TempoSetupOnduladeiraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITempoSetupOnduladeiraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<TempoSetupOnduladeiraDTO> getTempoSetupOnduladeira(ICommandRead command )
         {
            if (command is Command.Read.TempoSetupOnduladeiraReadCommand c)
                return getTempoSetupOnduladeira(c );
            throw new NotImplementedException();
        }
        private DataPagination<TempoSetupOnduladeiraDTO> getTempoSetupOnduladeira(Command.Read.TempoSetupOnduladeiraReadCommand command )
        {
            var query = _query.TempoSetupOnduladeiraQuery(command );

                var itens = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters);
                return new DataPagination<TempoSetupOnduladeiraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TempoSetupOnduladeiraOND_ID_DEDTO> getTempoSetupOnduladeiraReadFKOND_ID_DE(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TempoSetupOnduladeiraOND_ID_DEDTO> lista;
            var query = _query.TempoSetupOnduladeiraOND_ID_DEQuery(command );

                lista = _unitOfWork.Query<TempoSetupOnduladeiraOND_ID_DEDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraOND_ID_DEDTO>;
            return lista;
        }

        public IEnumerable<TempoSetupOnduladeiraOND_ID_DEDTO> getTempoSetupOnduladeiraReadFKOND_ID_DE(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTempoSetupOnduladeiraReadFKOND_ID_DE(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TempoSetupOnduladeiraTenantIDDTO> getTempoSetupOnduladeiraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TempoSetupOnduladeiraTenantIDDTO> lista;
            var query = _query.TempoSetupOnduladeiraTenantIDQuery(command );

                lista = _unitOfWork.Query<TempoSetupOnduladeiraTenantIDDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TempoSetupOnduladeiraTenantIDDTO> getTempoSetupOnduladeiraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTempoSetupOnduladeiraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TempoSetupOnduladeiraUserIdDTO> getTempoSetupOnduladeiraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TempoSetupOnduladeiraUserIdDTO> lista;
            var query = _query.TempoSetupOnduladeiraUserIdQuery(command );

                lista = _unitOfWork.Query<TempoSetupOnduladeiraUserIdDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraUserIdDTO>;
            return lista;
        }

        public IEnumerable<TempoSetupOnduladeiraUserIdDTO> getTempoSetupOnduladeiraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTempoSetupOnduladeiraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByTEM_ID(int value )
        {
            var query = _query.ExistsByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOND_ID_DE(string value )
        {
            var query = _query.ExistsByOND_ID_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOND_ID_PARA(string value )
        {
            var query = _query.ExistsByOND_ID_PARAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_RESINA_DE(string value )
        {
            var query = _query.ExistsByTEM_RESINA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_RESINA_PARA(string value )
        {
            var query = _query.ExistsByTEM_RESINA_PARAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_TEMPO(int value )
        {
            var query = _query.ExistsByTEM_TEMPOQuery(value );

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

        public TempoSetupOnduladeiraDTO FirstByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TempoSetupOnduladeiraDTO FirstByOND_ID_DE(string value )
        {
            var query = _query.FirstByOND_ID_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TempoSetupOnduladeiraDTO FirstByOND_ID_PARA(string value )
        {
            var query = _query.FirstByOND_ID_PARAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TempoSetupOnduladeiraDTO FirstByTEM_RESINA_DE(string value )
        {
            var query = _query.FirstByTEM_RESINA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TempoSetupOnduladeiraDTO FirstByTEM_RESINA_PARA(string value )
        {
            var query = _query.FirstByTEM_RESINA_PARAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TempoSetupOnduladeiraDTO FirstByTEM_TEMPO(int value )
        {
            var query = _query.FirstByTEM_TEMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TempoSetupOnduladeiraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TempoSetupOnduladeiraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TempoSetupOnduladeiraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public TempoSetupOnduladeiraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TempoSetupOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByOND_ID_DE(string value )
        {
            var query = _query.FirstByOND_ID_DEQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByOND_ID_PARA(string value )
        {
            var query = _query.FirstByOND_ID_PARAQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTEM_RESINA_DE(string value )
        {
            var query = _query.FirstByTEM_RESINA_DEQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTEM_RESINA_PARA(string value )
        {
            var query = _query.FirstByTEM_RESINA_PARAQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTEM_TEMPO(int value )
        {
            var query = _query.FirstByTEM_TEMPOQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TempoSetupOnduladeiraDTO>(query.Query,query.Parameters) as List<TempoSetupOnduladeiraDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration