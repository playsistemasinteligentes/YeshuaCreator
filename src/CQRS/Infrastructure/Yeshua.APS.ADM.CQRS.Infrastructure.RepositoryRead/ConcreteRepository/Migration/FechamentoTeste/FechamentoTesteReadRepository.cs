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
    public partial class FechamentoTesteReadRepository : IFechamentoTesteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IFechamentoTesteQueryRead _query;

        public FechamentoTesteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IFechamentoTesteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<FechamentoTesteDTO> getFechamentoTeste(ICommandRead command )
         {
            if (command is Command.Read.FechamentoTesteReadCommand c)
                return getFechamentoTeste(c );
            throw new NotImplementedException();
        }
        private DataPagination<FechamentoTesteDTO> getFechamentoTeste(Command.Read.FechamentoTesteReadCommand command )
        {
            var query = _query.FechamentoTesteQuery(command );

                var itens = _unitOfWork.Query<FechamentoTesteDTO>(query.Query,query.Parameters);
                return new DataPagination<FechamentoTesteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<FechamentoTesteTenantIDDTO> getFechamentoTesteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FechamentoTesteTenantIDDTO> lista;
            var query = _query.FechamentoTesteTenantIDQuery(command );

                lista = _unitOfWork.Query<FechamentoTesteTenantIDDTO>(query.Query,query.Parameters) as List<FechamentoTesteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<FechamentoTesteTenantIDDTO> getFechamentoTesteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFechamentoTesteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<FechamentoTesteUserIdDTO> getFechamentoTesteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<FechamentoTesteUserIdDTO> lista;
            var query = _query.FechamentoTesteUserIdQuery(command );

                lista = _unitOfWork.Query<FechamentoTesteUserIdDTO>(query.Query,query.Parameters) as List<FechamentoTesteUserIdDTO>;
            return lista;
        }

        public IEnumerable<FechamentoTesteUserIdDTO> getFechamentoTesteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getFechamentoTesteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFEC_ID(int value )
        {
            var query = _query.ExistsByFEC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFEC_QTD(int value )
        {
            var query = _query.ExistsByFEC_QTDQuery(value );

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

        public FechamentoTesteDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FechamentoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public FechamentoTesteDTO FirstByFEC_ID(int value )
        {
            var query = _query.FirstByFEC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FechamentoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public FechamentoTesteDTO FirstByFEC_QTD(int value )
        {
            var query = _query.FirstByFEC_QTDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FechamentoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public FechamentoTesteDTO FirstByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FechamentoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public FechamentoTesteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FechamentoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public FechamentoTesteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FechamentoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public FechamentoTesteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FechamentoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public FechamentoTesteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<FechamentoTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<FechamentoTesteDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<FechamentoTesteDTO>(query.Query,query.Parameters) as List<FechamentoTesteDTO>;
                return result;
        }

        public IEnumerable<FechamentoTesteDTO> GetAllByFEC_ID(int value )
        {
            var query = _query.FirstByFEC_IDQuery(value );

                var result = _unitOfWork.Query<FechamentoTesteDTO>(query.Query,query.Parameters) as List<FechamentoTesteDTO>;
                return result;
        }

        public IEnumerable<FechamentoTesteDTO> GetAllByFEC_QTD(int value )
        {
            var query = _query.FirstByFEC_QTDQuery(value );

                var result = _unitOfWork.Query<FechamentoTesteDTO>(query.Query,query.Parameters) as List<FechamentoTesteDTO>;
                return result;
        }

        public IEnumerable<FechamentoTesteDTO> GetAllByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.Query<FechamentoTesteDTO>(query.Query,query.Parameters) as List<FechamentoTesteDTO>;
                return result;
        }

        public IEnumerable<FechamentoTesteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<FechamentoTesteDTO>(query.Query,query.Parameters) as List<FechamentoTesteDTO>;
                return result;
        }

        public IEnumerable<FechamentoTesteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<FechamentoTesteDTO>(query.Query,query.Parameters) as List<FechamentoTesteDTO>;
                return result;
        }

        public IEnumerable<FechamentoTesteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<FechamentoTesteDTO>(query.Query,query.Parameters) as List<FechamentoTesteDTO>;
                return result;
        }

        public IEnumerable<FechamentoTesteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<FechamentoTesteDTO>(query.Query,query.Parameters) as List<FechamentoTesteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration