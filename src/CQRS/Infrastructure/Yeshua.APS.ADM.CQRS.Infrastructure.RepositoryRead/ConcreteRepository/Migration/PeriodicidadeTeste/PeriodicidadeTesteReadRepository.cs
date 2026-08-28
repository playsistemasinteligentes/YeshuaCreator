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
    public partial class PeriodicidadeTesteReadRepository : IPeriodicidadeTesteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPeriodicidadeTesteQueryRead _query;

        public PeriodicidadeTesteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPeriodicidadeTesteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<PeriodicidadeTesteDTO> getPeriodicidadeTeste(ICommandRead command )
         {
            if (command is Command.Read.PeriodicidadeTesteReadCommand c)
                return getPeriodicidadeTeste(c );
            throw new NotImplementedException();
        }
        private DataPagination<PeriodicidadeTesteDTO> getPeriodicidadeTeste(Command.Read.PeriodicidadeTesteReadCommand command )
        {
            var query = _query.PeriodicidadeTesteQuery(command );

                var itens = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters);
                return new DataPagination<PeriodicidadeTesteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PeriodicidadeTesteTenantIDDTO> getPeriodicidadeTesteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PeriodicidadeTesteTenantIDDTO> lista;
            var query = _query.PeriodicidadeTesteTenantIDQuery(command );

                lista = _unitOfWork.Query<PeriodicidadeTesteTenantIDDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PeriodicidadeTesteTenantIDDTO> getPeriodicidadeTesteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPeriodicidadeTesteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PeriodicidadeTesteUserIdDTO> getPeriodicidadeTesteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PeriodicidadeTesteUserIdDTO> lista;
            var query = _query.PeriodicidadeTesteUserIdQuery(command );

                lista = _unitOfWork.Query<PeriodicidadeTesteUserIdDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteUserIdDTO>;
            return lista;
        }

        public IEnumerable<PeriodicidadeTesteUserIdDTO> getPeriodicidadeTesteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPeriodicidadeTesteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_ID(int value )
        {
            var query = _query.ExistsByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_QTD(string value )
        {
            var query = _query.ExistsByPER_QTDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_ID(string value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ID(string value )
        {
            var query = _query.ExistsByGRP_IDQuery(value );

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

        public PeriodicidadeTesteDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PeriodicidadeTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PeriodicidadeTesteDTO FirstByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PeriodicidadeTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PeriodicidadeTesteDTO FirstByPER_QTD(string value )
        {
            var query = _query.FirstByPER_QTDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PeriodicidadeTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PeriodicidadeTesteDTO FirstByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PeriodicidadeTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PeriodicidadeTesteDTO FirstByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PeriodicidadeTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PeriodicidadeTesteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PeriodicidadeTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PeriodicidadeTesteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PeriodicidadeTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PeriodicidadeTesteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PeriodicidadeTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PeriodicidadeTesteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PeriodicidadeTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PeriodicidadeTesteDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteDTO>;
                return result;
        }

        public IEnumerable<PeriodicidadeTesteDTO> GetAllByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteDTO>;
                return result;
        }

        public IEnumerable<PeriodicidadeTesteDTO> GetAllByPER_QTD(string value )
        {
            var query = _query.FirstByPER_QTDQuery(value );

                var result = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteDTO>;
                return result;
        }

        public IEnumerable<PeriodicidadeTesteDTO> GetAllByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteDTO>;
                return result;
        }

        public IEnumerable<PeriodicidadeTesteDTO> GetAllByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteDTO>;
                return result;
        }

        public IEnumerable<PeriodicidadeTesteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteDTO>;
                return result;
        }

        public IEnumerable<PeriodicidadeTesteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteDTO>;
                return result;
        }

        public IEnumerable<PeriodicidadeTesteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteDTO>;
                return result;
        }

        public IEnumerable<PeriodicidadeTesteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PeriodicidadeTesteDTO>(query.Query,query.Parameters) as List<PeriodicidadeTesteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration