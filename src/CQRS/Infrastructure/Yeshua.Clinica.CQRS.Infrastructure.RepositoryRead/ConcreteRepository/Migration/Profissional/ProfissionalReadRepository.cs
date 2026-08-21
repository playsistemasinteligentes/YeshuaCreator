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
    public partial class ProfissionalReadRepository : IProfissionalReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IProfissionalQueryRead _query;

        public ProfissionalReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IProfissionalQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ProfissionalDTO> getProfissional(ICommandRead command )
         {
            if (command is Command.Read.ProfissionalReadCommand c)
                return getProfissional(c );
            throw new NotImplementedException();
        }
        private DataPagination<ProfissionalDTO> getProfissional(Command.Read.ProfissionalReadCommand command )
        {
            var query = _query.ProfissionalQuery(command );

                var itens = _unitOfWork.Query<ProfissionalDTO>(query.Query,query.Parameters);
                return new DataPagination<ProfissionalDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ProfissionalEspecialidadeIdDTO> getProfissionalReadFKEspecialidadeId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProfissionalEspecialidadeIdDTO> lista;
            var query = _query.ProfissionalEspecialidadeIdQuery(command );

                lista = _unitOfWork.Query<ProfissionalEspecialidadeIdDTO>(query.Query,query.Parameters) as List<ProfissionalEspecialidadeIdDTO>;
            return lista;
        }

        public IEnumerable<ProfissionalEspecialidadeIdDTO> getProfissionalReadFKEspecialidadeId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProfissionalReadFKEspecialidadeId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ProfissionalTenantIDDTO> getProfissionalReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProfissionalTenantIDDTO> lista;
            var query = _query.ProfissionalTenantIDQuery(command );

                lista = _unitOfWork.Query<ProfissionalTenantIDDTO>(query.Query,query.Parameters) as List<ProfissionalTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ProfissionalTenantIDDTO> getProfissionalReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProfissionalReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ProfissionalUserIdDTO> getProfissionalReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProfissionalUserIdDTO> lista;
            var query = _query.ProfissionalUserIdQuery(command );

                lista = _unitOfWork.Query<ProfissionalUserIdDTO>(query.Query,query.Parameters) as List<ProfissionalUserIdDTO>;
            return lista;
        }

        public IEnumerable<ProfissionalUserIdDTO> getProfissionalReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProfissionalReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value )
        {
            var query = _query.ExistsByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEspecialidadeId(int value )
        {
            var query = _query.ExistsByEspecialidadeIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefone(string value )
        {
            var query = _query.ExistsByTelefoneQuery(value );

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

        public ProfissionalDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByEspecialidadeId(int value )
        {
            var query = _query.FirstByEspecialidadeIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByTelefone(string value )
        {
            var query = _query.FirstByTelefoneQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ProfissionalDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ProfissionalDTO>(query.Query,query.Parameters) as List<ProfissionalDTO>;
                return result;
        }

        public IEnumerable<ProfissionalDTO> GetAllByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _unitOfWork.Query<ProfissionalDTO>(query.Query,query.Parameters) as List<ProfissionalDTO>;
                return result;
        }

        public IEnumerable<ProfissionalDTO> GetAllByEspecialidadeId(int value )
        {
            var query = _query.FirstByEspecialidadeIdQuery(value );

                var result = _unitOfWork.Query<ProfissionalDTO>(query.Query,query.Parameters) as List<ProfissionalDTO>;
                return result;
        }

        public IEnumerable<ProfissionalDTO> GetAllByTelefone(string value )
        {
            var query = _query.FirstByTelefoneQuery(value );

                var result = _unitOfWork.Query<ProfissionalDTO>(query.Query,query.Parameters) as List<ProfissionalDTO>;
                return result;
        }

        public IEnumerable<ProfissionalDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ProfissionalDTO>(query.Query,query.Parameters) as List<ProfissionalDTO>;
                return result;
        }

        public IEnumerable<ProfissionalDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ProfissionalDTO>(query.Query,query.Parameters) as List<ProfissionalDTO>;
                return result;
        }

        public IEnumerable<ProfissionalDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ProfissionalDTO>(query.Query,query.Parameters) as List<ProfissionalDTO>;
                return result;
        }

        public IEnumerable<ProfissionalDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ProfissionalDTO>(query.Query,query.Parameters) as List<ProfissionalDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration