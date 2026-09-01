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
    public partial class ObservacoesReadRepository : IObservacoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IObservacoesQueryRead _query;

        public ObservacoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IObservacoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetObservacoesCustom(Command.Read.ObservacoesReadCommand command, ref DataPagination<ObservacoesDTO> result, ref bool handled);

        public DataPagination<ObservacoesDTO> getObservacoes(ICommandRead command )
         {
            if (command is Command.Read.ObservacoesReadCommand c)
                return getObservacoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<ObservacoesDTO> getObservacoes(Command.Read.ObservacoesReadCommand command )
        {
            DataPagination<ObservacoesDTO> customResult = null;
            var customHandled = false;
            TryGetObservacoesCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ObservacoesQuery(command );

                var itens = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters);
                return new DataPagination<ObservacoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ObservacoesCLI_IDDTO> getObservacoesReadFKCLI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ObservacoesCLI_IDDTO> lista;
            var query = _query.ObservacoesCLI_IDQuery(command );

                lista = _unitOfWork.Query<ObservacoesCLI_IDDTO>(query.Query,query.Parameters) as List<ObservacoesCLI_IDDTO>;
            return lista;
        }

        public IEnumerable<ObservacoesCLI_IDDTO> getObservacoesReadFKCLI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getObservacoesReadFKCLI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ObservacoesTenantIDDTO> getObservacoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ObservacoesTenantIDDTO> lista;
            var query = _query.ObservacoesTenantIDQuery(command );

                lista = _unitOfWork.Query<ObservacoesTenantIDDTO>(query.Query,query.Parameters) as List<ObservacoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ObservacoesTenantIDDTO> getObservacoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getObservacoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ObservacoesUserIdDTO> getObservacoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ObservacoesUserIdDTO> lista;
            var query = _query.ObservacoesUserIdQuery(command );

                lista = _unitOfWork.Query<ObservacoesUserIdDTO>(query.Query,query.Parameters) as List<ObservacoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<ObservacoesUserIdDTO> getObservacoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getObservacoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByOBS_ID(int value )
        {
            var query = _query.ExistsByOBS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOBS_TIPO(string value )
        {
            var query = _query.ExistsByOBS_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOBS_DESCRICAO(string value )
        {
            var query = _query.ExistsByOBS_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.ExistsByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOBS_INTEGRACAO(string value )
        {
            var query = _query.ExistsByOBS_INTEGRACAOQuery(value );

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

        public ObservacoesDTO FirstByOBS_ID(int value )
        {
            var query = _query.FirstByOBS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByOBS_TIPO(string value )
        {
            var query = _query.FirstByOBS_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByOBS_DESCRICAO(string value )
        {
            var query = _query.FirstByOBS_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByOBS_INTEGRACAO(string value )
        {
            var query = _query.FirstByOBS_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObservacoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObservacoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByOBS_ID(int value )
        {
            var query = _query.FirstByOBS_IDQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByOBS_TIPO(string value )
        {
            var query = _query.FirstByOBS_TIPOQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByOBS_DESCRICAO(string value )
        {
            var query = _query.FirstByOBS_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByOBS_INTEGRACAO(string value )
        {
            var query = _query.FirstByOBS_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

        public IEnumerable<ObservacoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ObservacoesDTO>(query.Query,query.Parameters) as List<ObservacoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration