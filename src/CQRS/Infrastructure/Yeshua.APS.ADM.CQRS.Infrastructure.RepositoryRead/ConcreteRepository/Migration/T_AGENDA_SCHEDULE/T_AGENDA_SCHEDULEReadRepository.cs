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
    public partial class T_AGENDA_SCHEDULEReadRepository : IT_AGENDA_SCHEDULEReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_AGENDA_SCHEDULEQueryRead _query;

        public T_AGENDA_SCHEDULEReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_AGENDA_SCHEDULEQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetT_AGENDA_SCHEDULECustom(Command.Read.T_AGENDA_SCHEDULEReadCommand command, ref DataPagination<T_AGENDA_SCHEDULEDTO> result, ref bool handled);

        public DataPagination<T_AGENDA_SCHEDULEDTO> getT_AGENDA_SCHEDULE(ICommandRead command )
         {
            if (command is Command.Read.T_AGENDA_SCHEDULEReadCommand c)
                return getT_AGENDA_SCHEDULE(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_AGENDA_SCHEDULEDTO> getT_AGENDA_SCHEDULE(Command.Read.T_AGENDA_SCHEDULEReadCommand command )
        {
            DataPagination<T_AGENDA_SCHEDULEDTO> customResult = null;
            var customHandled = false;
            TryGetT_AGENDA_SCHEDULECustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.T_AGENDA_SCHEDULEQuery(command );

                var itens = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters);
                return new DataPagination<T_AGENDA_SCHEDULEDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_AGENDA_SCHEDULETenantIDDTO> getT_AGENDA_SCHEDULEReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_AGENDA_SCHEDULETenantIDDTO> lista;
            var query = _query.T_AGENDA_SCHEDULETenantIDQuery(command );

                lista = _unitOfWork.Query<T_AGENDA_SCHEDULETenantIDDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULETenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_AGENDA_SCHEDULETenantIDDTO> getT_AGENDA_SCHEDULEReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_AGENDA_SCHEDULEReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_AGENDA_SCHEDULEUserIdDTO> getT_AGENDA_SCHEDULEReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_AGENDA_SCHEDULEUserIdDTO> lista;
            var query = _query.T_AGENDA_SCHEDULEUserIdQuery(command );

                lista = _unitOfWork.Query<T_AGENDA_SCHEDULEUserIdDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_AGENDA_SCHEDULEUserIdDTO> getT_AGENDA_SCHEDULEReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_AGENDA_SCHEDULEReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_ID(int value )
        {
            var query = _query.ExistsByAGE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_DATA_ESPECIFICA(DateTime value )
        {
            var query = _query.ExistsByAGE_DATA_ESPECIFICAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_HORARIO_INICIO(string value )
        {
            var query = _query.ExistsByAGE_HORARIO_INICIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_HORARIO_FIM(string value )
        {
            var query = _query.ExistsByAGE_HORARIO_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_SEGUNDA(string value )
        {
            var query = _query.ExistsByAGE_SEGUNDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_TERCA(string value )
        {
            var query = _query.ExistsByAGE_TERCAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_QUARTA(string value )
        {
            var query = _query.ExistsByAGE_QUARTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_QUINTA(string value )
        {
            var query = _query.ExistsByAGE_QUINTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_SEXTA(string value )
        {
            var query = _query.ExistsByAGE_SEXTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_SABADO(string value )
        {
            var query = _query.ExistsByAGE_SABADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_DOMINGO(string value )
        {
            var query = _query.ExistsByAGE_DOMINGOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_INTERVALO(Decimal value )
        {
            var query = _query.ExistsByAGE_INTERVALOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_ORDEM_EXECUCAO(string value )
        {
            var query = _query.ExistsByAGE_ORDEM_EXECUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_PARAMETROS(string value )
        {
            var query = _query.ExistsByAGE_PARAMETROSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_EXCECAO(string value )
        {
            var query = _query.ExistsByAGE_EXCECAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByAGE_DESCRICAO(string value )
        {
            var query = _query.ExistsByAGE_DESCRICAOQuery(value );

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

        public T_AGENDA_SCHEDULEDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_ID(int value )
        {
            var query = _query.FirstByAGE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_DATA_ESPECIFICA(DateTime value )
        {
            var query = _query.FirstByAGE_DATA_ESPECIFICAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_HORARIO_INICIO(string value )
        {
            var query = _query.FirstByAGE_HORARIO_INICIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_HORARIO_FIM(string value )
        {
            var query = _query.FirstByAGE_HORARIO_FIMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_SEGUNDA(string value )
        {
            var query = _query.FirstByAGE_SEGUNDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_TERCA(string value )
        {
            var query = _query.FirstByAGE_TERCAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_QUARTA(string value )
        {
            var query = _query.FirstByAGE_QUARTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_QUINTA(string value )
        {
            var query = _query.FirstByAGE_QUINTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_SEXTA(string value )
        {
            var query = _query.FirstByAGE_SEXTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_SABADO(string value )
        {
            var query = _query.FirstByAGE_SABADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_DOMINGO(string value )
        {
            var query = _query.FirstByAGE_DOMINGOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_INTERVALO(Decimal value )
        {
            var query = _query.FirstByAGE_INTERVALOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_ORDEM_EXECUCAO(string value )
        {
            var query = _query.FirstByAGE_ORDEM_EXECUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_PARAMETROS(string value )
        {
            var query = _query.FirstByAGE_PARAMETROSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_EXCECAO(string value )
        {
            var query = _query.FirstByAGE_EXCECAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByAGE_DESCRICAO(string value )
        {
            var query = _query.FirstByAGE_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_AGENDA_SCHEDULEDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_AGENDA_SCHEDULEDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_ID(int value )
        {
            var query = _query.FirstByAGE_IDQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_DATA_ESPECIFICA(DateTime value )
        {
            var query = _query.FirstByAGE_DATA_ESPECIFICAQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_HORARIO_INICIO(string value )
        {
            var query = _query.FirstByAGE_HORARIO_INICIOQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_HORARIO_FIM(string value )
        {
            var query = _query.FirstByAGE_HORARIO_FIMQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_SEGUNDA(string value )
        {
            var query = _query.FirstByAGE_SEGUNDAQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_TERCA(string value )
        {
            var query = _query.FirstByAGE_TERCAQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_QUARTA(string value )
        {
            var query = _query.FirstByAGE_QUARTAQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_QUINTA(string value )
        {
            var query = _query.FirstByAGE_QUINTAQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_SEXTA(string value )
        {
            var query = _query.FirstByAGE_SEXTAQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_SABADO(string value )
        {
            var query = _query.FirstByAGE_SABADOQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_DOMINGO(string value )
        {
            var query = _query.FirstByAGE_DOMINGOQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_INTERVALO(Decimal value )
        {
            var query = _query.FirstByAGE_INTERVALOQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_ORDEM_EXECUCAO(string value )
        {
            var query = _query.FirstByAGE_ORDEM_EXECUCAOQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_PARAMETROS(string value )
        {
            var query = _query.FirstByAGE_PARAMETROSQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_EXCECAO(string value )
        {
            var query = _query.FirstByAGE_EXCECAOQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_DESCRICAO(string value )
        {
            var query = _query.FirstByAGE_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_AGENDA_SCHEDULEDTO>(query.Query,query.Parameters) as List<T_AGENDA_SCHEDULEDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration