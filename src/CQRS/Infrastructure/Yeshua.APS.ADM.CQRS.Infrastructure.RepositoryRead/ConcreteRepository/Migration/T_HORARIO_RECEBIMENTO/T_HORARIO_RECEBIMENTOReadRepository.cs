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
    public partial class T_HORARIO_RECEBIMENTOReadRepository : IT_HORARIO_RECEBIMENTOReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_HORARIO_RECEBIMENTOQueryRead _query;

        public T_HORARIO_RECEBIMENTOReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_HORARIO_RECEBIMENTOQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetT_HORARIO_RECEBIMENTOCustom(Command.Read.T_HORARIO_RECEBIMENTOReadCommand command, ref DataPagination<T_HORARIO_RECEBIMENTODTO> result, ref bool handled);

        public DataPagination<T_HORARIO_RECEBIMENTODTO> getT_HORARIO_RECEBIMENTO(ICommandRead command )
         {
            if (command is Command.Read.T_HORARIO_RECEBIMENTOReadCommand c)
                return getT_HORARIO_RECEBIMENTO(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_HORARIO_RECEBIMENTODTO> getT_HORARIO_RECEBIMENTO(Command.Read.T_HORARIO_RECEBIMENTOReadCommand command )
        {
            DataPagination<T_HORARIO_RECEBIMENTODTO> customResult = null;
            var customHandled = false;
            TryGetT_HORARIO_RECEBIMENTOCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.T_HORARIO_RECEBIMENTOQuery(command );

                var itens = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters);
                return new DataPagination<T_HORARIO_RECEBIMENTODTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_HORARIO_RECEBIMENTOCLI_IDDTO> getT_HORARIO_RECEBIMENTOReadFKCLI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_HORARIO_RECEBIMENTOCLI_IDDTO> lista;
            var query = _query.T_HORARIO_RECEBIMENTOCLI_IDQuery(command );

                lista = _unitOfWork.Query<T_HORARIO_RECEBIMENTOCLI_IDDTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTOCLI_IDDTO>;
            return lista;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTOCLI_IDDTO> getT_HORARIO_RECEBIMENTOReadFKCLI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_HORARIO_RECEBIMENTOReadFKCLI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_HORARIO_RECEBIMENTOTenantIDDTO> getT_HORARIO_RECEBIMENTOReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_HORARIO_RECEBIMENTOTenantIDDTO> lista;
            var query = _query.T_HORARIO_RECEBIMENTOTenantIDQuery(command );

                lista = _unitOfWork.Query<T_HORARIO_RECEBIMENTOTenantIDDTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTOTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTOTenantIDDTO> getT_HORARIO_RECEBIMENTOReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_HORARIO_RECEBIMENTOReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_HORARIO_RECEBIMENTOUserIdDTO> getT_HORARIO_RECEBIMENTOReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_HORARIO_RECEBIMENTOUserIdDTO> lista;
            var query = _query.T_HORARIO_RECEBIMENTOUserIdQuery(command );

                lista = _unitOfWork.Query<T_HORARIO_RECEBIMENTOUserIdDTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTOUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTOUserIdDTO> getT_HORARIO_RECEBIMENTOReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_HORARIO_RECEBIMENTOReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByHRE_DIA_DA_SEMANA(int value )
        {
            var query = _query.ExistsByHRE_DIA_DA_SEMANAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByHRE_HORA_INICIAL(DateTime value )
        {
            var query = _query.ExistsByHRE_HORA_INICIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByHRE_HORA_FINAL(DateTime value )
        {
            var query = _query.ExistsByHRE_HORA_FINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByHRE_ID(int value )
        {
            var query = _query.ExistsByHRE_IDQuery(value );

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

        public T_HORARIO_RECEBIMENTODTO FirstByHRE_DIA_DA_SEMANA(int value )
        {
            var query = _query.FirstByHRE_DIA_DA_SEMANAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_HORARIO_RECEBIMENTODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_HORARIO_RECEBIMENTODTO FirstByHRE_HORA_INICIAL(DateTime value )
        {
            var query = _query.FirstByHRE_HORA_INICIALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_HORARIO_RECEBIMENTODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_HORARIO_RECEBIMENTODTO FirstByHRE_HORA_FINAL(DateTime value )
        {
            var query = _query.FirstByHRE_HORA_FINALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_HORARIO_RECEBIMENTODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_HORARIO_RECEBIMENTODTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_HORARIO_RECEBIMENTODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_HORARIO_RECEBIMENTODTO FirstByHRE_ID(int value )
        {
            var query = _query.FirstByHRE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_HORARIO_RECEBIMENTODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_HORARIO_RECEBIMENTODTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_HORARIO_RECEBIMENTODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_HORARIO_RECEBIMENTODTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_HORARIO_RECEBIMENTODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_HORARIO_RECEBIMENTODTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_HORARIO_RECEBIMENTODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_HORARIO_RECEBIMENTODTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_HORARIO_RECEBIMENTODTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByHRE_DIA_DA_SEMANA(int value )
        {
            var query = _query.FirstByHRE_DIA_DA_SEMANAQuery(value );

                var result = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTODTO>;
                return result;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByHRE_HORA_INICIAL(DateTime value )
        {
            var query = _query.FirstByHRE_HORA_INICIALQuery(value );

                var result = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTODTO>;
                return result;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByHRE_HORA_FINAL(DateTime value )
        {
            var query = _query.FirstByHRE_HORA_FINALQuery(value );

                var result = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTODTO>;
                return result;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTODTO>;
                return result;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByHRE_ID(int value )
        {
            var query = _query.FirstByHRE_IDQuery(value );

                var result = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTODTO>;
                return result;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTODTO>;
                return result;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTODTO>;
                return result;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTODTO>;
                return result;
        }

        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_HORARIO_RECEBIMENTODTO>(query.Query,query.Parameters) as List<T_HORARIO_RECEBIMENTODTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration