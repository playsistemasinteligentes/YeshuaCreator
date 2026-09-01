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
    public partial class ColaboradorReadRepository : IColaboradorReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IColaboradorQueryRead _query;

        public ColaboradorReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IColaboradorQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetColaboradorCustom(Command.Read.ColaboradorReadCommand command, ref DataPagination<ColaboradorDTO> result, ref bool handled);

        public DataPagination<ColaboradorDTO> getColaborador(ICommandRead command )
         {
            if (command is Command.Read.ColaboradorReadCommand c)
                return getColaborador(c );
            throw new NotImplementedException();
        }
        private DataPagination<ColaboradorDTO> getColaborador(Command.Read.ColaboradorReadCommand command )
        {
            DataPagination<ColaboradorDTO> customResult = null;
            var customHandled = false;
            TryGetColaboradorCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ColaboradorQuery(command );

                var itens = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters);
                return new DataPagination<ColaboradorDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ColaboradorTURM_idDTO> getColaboradorReadFKTURM_id(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ColaboradorTURM_idDTO> lista;
            var query = _query.ColaboradorTURM_idQuery(command );

                lista = _unitOfWork.Query<ColaboradorTURM_idDTO>(query.Query,query.Parameters) as List<ColaboradorTURM_idDTO>;
            return lista;
        }

        public IEnumerable<ColaboradorTURM_idDTO> getColaboradorReadFKTURM_id(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getColaboradorReadFKTURM_id(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ColaboradorTenantIDDTO> getColaboradorReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ColaboradorTenantIDDTO> lista;
            var query = _query.ColaboradorTenantIDQuery(command );

                lista = _unitOfWork.Query<ColaboradorTenantIDDTO>(query.Query,query.Parameters) as List<ColaboradorTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ColaboradorTenantIDDTO> getColaboradorReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getColaboradorReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ColaboradorUserIdDTO> getColaboradorReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ColaboradorUserIdDTO> lista;
            var query = _query.ColaboradorUserIdQuery(command );

                lista = _unitOfWork.Query<ColaboradorUserIdDTO>(query.Query,query.Parameters) as List<ColaboradorUserIdDTO>;
            return lista;
        }

        public IEnumerable<ColaboradorUserIdDTO> getColaboradorReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getColaboradorReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByCOL_CPF(string value )
        {
            var query = _query.ExistsByCOL_CPFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOL_NOME(string value )
        {
            var query = _query.ExistsByCOL_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOL_NASCIMENTO(DateTime value )
        {
            var query = _query.ExistsByCOL_NASCIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOL_EMAIL(string value )
        {
            var query = _query.ExistsByCOL_EMAILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOL_MATRICULA(string value )
        {
            var query = _query.ExistsByCOL_MATRICULAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_id(string value )
        {
            var query = _query.ExistsByTURM_idQuery(value );

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

        public ColaboradorDTO FirstByCOL_CPF(string value )
        {
            var query = _query.FirstByCOL_CPFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public ColaboradorDTO FirstByCOL_NOME(string value )
        {
            var query = _query.FirstByCOL_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public ColaboradorDTO FirstByCOL_NASCIMENTO(DateTime value )
        {
            var query = _query.FirstByCOL_NASCIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public ColaboradorDTO FirstByCOL_EMAIL(string value )
        {
            var query = _query.FirstByCOL_EMAILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public ColaboradorDTO FirstByCOL_MATRICULA(string value )
        {
            var query = _query.FirstByCOL_MATRICULAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public ColaboradorDTO FirstByTURM_id(string value )
        {
            var query = _query.FirstByTURM_idQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public ColaboradorDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public ColaboradorDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public ColaboradorDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public ColaboradorDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ColaboradorDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByCOL_CPF(string value )
        {
            var query = _query.FirstByCOL_CPFQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByCOL_NOME(string value )
        {
            var query = _query.FirstByCOL_NOMEQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByCOL_NASCIMENTO(DateTime value )
        {
            var query = _query.FirstByCOL_NASCIMENTOQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByCOL_EMAIL(string value )
        {
            var query = _query.FirstByCOL_EMAILQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByCOL_MATRICULA(string value )
        {
            var query = _query.FirstByCOL_MATRICULAQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByTURM_id(string value )
        {
            var query = _query.FirstByTURM_idQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

        public IEnumerable<ColaboradorDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ColaboradorDTO>(query.Query,query.Parameters) as List<ColaboradorDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration