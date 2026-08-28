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
    public partial class MedicoesOnduladeiraReadRepository : IMedicoesOnduladeiraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMedicoesOnduladeiraQueryRead _query;

        public MedicoesOnduladeiraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMedicoesOnduladeiraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MedicoesOnduladeiraDTO> getMedicoesOnduladeira(ICommandRead command )
         {
            if (command is Command.Read.MedicoesOnduladeiraReadCommand c)
                return getMedicoesOnduladeira(c );
            throw new NotImplementedException();
        }
        private DataPagination<MedicoesOnduladeiraDTO> getMedicoesOnduladeira(Command.Read.MedicoesOnduladeiraReadCommand command )
        {
            var query = _query.MedicoesOnduladeiraQuery(command );

                var itens = _unitOfWork.Query<MedicoesOnduladeiraDTO>(query.Query,query.Parameters);
                return new DataPagination<MedicoesOnduladeiraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MedicoesOnduladeiraTenantIDDTO> getMedicoesOnduladeiraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MedicoesOnduladeiraTenantIDDTO> lista;
            var query = _query.MedicoesOnduladeiraTenantIDQuery(command );

                lista = _unitOfWork.Query<MedicoesOnduladeiraTenantIDDTO>(query.Query,query.Parameters) as List<MedicoesOnduladeiraTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MedicoesOnduladeiraTenantIDDTO> getMedicoesOnduladeiraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMedicoesOnduladeiraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MedicoesOnduladeiraUserIdDTO> getMedicoesOnduladeiraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MedicoesOnduladeiraUserIdDTO> lista;
            var query = _query.MedicoesOnduladeiraUserIdQuery(command );

                lista = _unitOfWork.Query<MedicoesOnduladeiraUserIdDTO>(query.Query,query.Parameters) as List<MedicoesOnduladeiraUserIdDTO>;
            return lista;
        }

        public IEnumerable<MedicoesOnduladeiraUserIdDTO> getMedicoesOnduladeiraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMedicoesOnduladeiraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

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

        public MedicoesOnduladeiraDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedicoesOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedicoesOnduladeiraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedicoesOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedicoesOnduladeiraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedicoesOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedicoesOnduladeiraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedicoesOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedicoesOnduladeiraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedicoesOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MedicoesOnduladeiraDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MedicoesOnduladeiraDTO>(query.Query,query.Parameters) as List<MedicoesOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<MedicoesOnduladeiraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MedicoesOnduladeiraDTO>(query.Query,query.Parameters) as List<MedicoesOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<MedicoesOnduladeiraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MedicoesOnduladeiraDTO>(query.Query,query.Parameters) as List<MedicoesOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<MedicoesOnduladeiraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MedicoesOnduladeiraDTO>(query.Query,query.Parameters) as List<MedicoesOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<MedicoesOnduladeiraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MedicoesOnduladeiraDTO>(query.Query,query.Parameters) as List<MedicoesOnduladeiraDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration