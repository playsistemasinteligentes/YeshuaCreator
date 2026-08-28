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
    public partial class PendenciasInterfaceReadRepository : IPendenciasInterfaceReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPendenciasInterfaceQueryRead _query;

        public PendenciasInterfaceReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPendenciasInterfaceQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<PendenciasInterfaceDTO> getPendenciasInterface(ICommandRead command )
         {
            if (command is Command.Read.PendenciasInterfaceReadCommand c)
                return getPendenciasInterface(c );
            throw new NotImplementedException();
        }
        private DataPagination<PendenciasInterfaceDTO> getPendenciasInterface(Command.Read.PendenciasInterfaceReadCommand command )
        {
            var query = _query.PendenciasInterfaceQuery(command );

                var itens = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters);
                return new DataPagination<PendenciasInterfaceDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PendenciasInterfaceTenantIDDTO> getPendenciasInterfaceReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PendenciasInterfaceTenantIDDTO> lista;
            var query = _query.PendenciasInterfaceTenantIDQuery(command );

                lista = _unitOfWork.Query<PendenciasInterfaceTenantIDDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PendenciasInterfaceTenantIDDTO> getPendenciasInterfaceReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPendenciasInterfaceReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PendenciasInterfaceUserIdDTO> getPendenciasInterfaceReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PendenciasInterfaceUserIdDTO> lista;
            var query = _query.PendenciasInterfaceUserIdQuery(command );

                lista = _unitOfWork.Query<PendenciasInterfaceUserIdDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceUserIdDTO>;
            return lista;
        }

        public IEnumerable<PendenciasInterfaceUserIdDTO> getPendenciasInterfaceReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPendenciasInterfaceReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPEN_STATUS_OUT(string value )
        {
            var query = _query.ExistsByPEN_STATUS_OUTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPEN_PROTOCOLO_OUT(string value )
        {
            var query = _query.ExistsByPEN_PROTOCOLO_OUTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPEN_ID_PROTOCOLO_OUT(string value )
        {
            var query = _query.ExistsByPEN_ID_PROTOCOLO_OUTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPEN_STATUS_IN(string value )
        {
            var query = _query.ExistsByPEN_STATUS_INQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPEN_PROTOCOLO_IN(string value )
        {
            var query = _query.ExistsByPEN_PROTOCOLO_INQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPEN_ID_PROTOCOLO_IN(string value )
        {
            var query = _query.ExistsByPEN_ID_PROTOCOLO_INQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDATA_ENTRADA(DateTime value )
        {
            var query = _query.ExistsByDATA_ENTRADAQuery(value );

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

        public bool ExistsByPEN_ID(int value )
        {
            var query = _query.ExistsByPEN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public PendenciasInterfaceDTO FirstByPEN_STATUS_OUT(string value )
        {
            var query = _query.FirstByPEN_STATUS_OUTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByPEN_PROTOCOLO_OUT(string value )
        {
            var query = _query.FirstByPEN_PROTOCOLO_OUTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByPEN_ID_PROTOCOLO_OUT(string value )
        {
            var query = _query.FirstByPEN_ID_PROTOCOLO_OUTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByPEN_STATUS_IN(string value )
        {
            var query = _query.FirstByPEN_STATUS_INQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByPEN_PROTOCOLO_IN(string value )
        {
            var query = _query.FirstByPEN_PROTOCOLO_INQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByPEN_ID_PROTOCOLO_IN(string value )
        {
            var query = _query.FirstByPEN_ID_PROTOCOLO_INQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByDATA_ENTRADA(DateTime value )
        {
            var query = _query.FirstByDATA_ENTRADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public PendenciasInterfaceDTO FirstByPEN_ID(int value )
        {
            var query = _query.FirstByPEN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PendenciasInterfaceDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_STATUS_OUT(string value )
        {
            var query = _query.FirstByPEN_STATUS_OUTQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_PROTOCOLO_OUT(string value )
        {
            var query = _query.FirstByPEN_PROTOCOLO_OUTQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_ID_PROTOCOLO_OUT(string value )
        {
            var query = _query.FirstByPEN_ID_PROTOCOLO_OUTQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_STATUS_IN(string value )
        {
            var query = _query.FirstByPEN_STATUS_INQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_PROTOCOLO_IN(string value )
        {
            var query = _query.FirstByPEN_PROTOCOLO_INQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_ID_PROTOCOLO_IN(string value )
        {
            var query = _query.FirstByPEN_ID_PROTOCOLO_INQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByDATA_ENTRADA(DateTime value )
        {
            var query = _query.FirstByDATA_ENTRADAQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_ID(int value )
        {
            var query = _query.FirstByPEN_IDQuery(value );

                var result = _unitOfWork.Query<PendenciasInterfaceDTO>(query.Query,query.Parameters) as List<PendenciasInterfaceDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration