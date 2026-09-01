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
    public partial class OcorrenciaReadRepository : IOcorrenciaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IOcorrenciaQueryRead _query;

        public OcorrenciaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IOcorrenciaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetOcorrenciaCustom(Command.Read.OcorrenciaReadCommand command, ref DataPagination<OcorrenciaDTO> result, ref bool handled);

        public DataPagination<OcorrenciaDTO> getOcorrencia(ICommandRead command )
         {
            if (command is Command.Read.OcorrenciaReadCommand c)
                return getOcorrencia(c );
            throw new NotImplementedException();
        }
        private DataPagination<OcorrenciaDTO> getOcorrencia(Command.Read.OcorrenciaReadCommand command )
        {
            DataPagination<OcorrenciaDTO> customResult = null;
            var customHandled = false;
            TryGetOcorrenciaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.OcorrenciaQuery(command );

                var itens = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters);
                return new DataPagination<OcorrenciaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<OcorrenciaTIP_IDDTO> getOcorrenciaReadFKTIP_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OcorrenciaTIP_IDDTO> lista;
            var query = _query.OcorrenciaTIP_IDQuery(command );

                lista = _unitOfWork.Query<OcorrenciaTIP_IDDTO>(query.Query,query.Parameters) as List<OcorrenciaTIP_IDDTO>;
            return lista;
        }

        public IEnumerable<OcorrenciaTIP_IDDTO> getOcorrenciaReadFKTIP_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOcorrenciaReadFKTIP_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OcorrenciaTenantIDDTO> getOcorrenciaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OcorrenciaTenantIDDTO> lista;
            var query = _query.OcorrenciaTenantIDQuery(command );

                lista = _unitOfWork.Query<OcorrenciaTenantIDDTO>(query.Query,query.Parameters) as List<OcorrenciaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<OcorrenciaTenantIDDTO> getOcorrenciaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOcorrenciaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OcorrenciaUserIdDTO> getOcorrenciaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OcorrenciaUserIdDTO> lista;
            var query = _query.OcorrenciaUserIdQuery(command );

                lista = _unitOfWork.Query<OcorrenciaUserIdDTO>(query.Query,query.Parameters) as List<OcorrenciaUserIdDTO>;
            return lista;
        }

        public IEnumerable<OcorrenciaUserIdDTO> getOcorrenciaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOcorrenciaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByOCO_ID(string value )
        {
            var query = _query.ExistsByOCO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_DESCRICAO(string value )
        {
            var query = _query.ExistsByOCO_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_ID(int value )
        {
            var query = _query.ExistsByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGMA_ID(string value )
        {
            var query = _query.ExistsByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySPR(int value )
        {
            var query = _query.ExistsBySPRQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_SUB_TIPO(string value )
        {
            var query = _query.ExistsByOCO_SUB_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySUB_ID(string value )
        {
            var query = _query.ExistsBySUB_IDQuery(value );

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

        public OcorrenciaDTO FirstByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstByOCO_DESCRICAO(string value )
        {
            var query = _query.FirstByOCO_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstBySPR(int value )
        {
            var query = _query.FirstBySPRQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstByOCO_SUB_TIPO(string value )
        {
            var query = _query.FirstByOCO_SUB_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstBySUB_ID(string value )
        {
            var query = _query.FirstBySUB_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public OcorrenciaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OcorrenciaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByOCO_ID(string value )
        {
            var query = _query.FirstByOCO_IDQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByOCO_DESCRICAO(string value )
        {
            var query = _query.FirstByOCO_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllBySPR(int value )
        {
            var query = _query.FirstBySPRQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByOCO_SUB_TIPO(string value )
        {
            var query = _query.FirstByOCO_SUB_TIPOQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllBySUB_ID(string value )
        {
            var query = _query.FirstBySUB_IDQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

        public IEnumerable<OcorrenciaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<OcorrenciaDTO>(query.Query,query.Parameters) as List<OcorrenciaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration