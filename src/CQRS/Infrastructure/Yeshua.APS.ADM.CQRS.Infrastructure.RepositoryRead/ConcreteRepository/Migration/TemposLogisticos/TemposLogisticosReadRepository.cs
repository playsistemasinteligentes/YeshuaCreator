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
    public partial class TemposLogisticosReadRepository : ITemposLogisticosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITemposLogisticosQueryRead _query;

        public TemposLogisticosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITemposLogisticosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<TemposLogisticosDTO> getTemposLogisticos(ICommandRead command )
         {
            if (command is Command.Read.TemposLogisticosReadCommand c)
                return getTemposLogisticos(c );
            throw new NotImplementedException();
        }
        private DataPagination<TemposLogisticosDTO> getTemposLogisticos(Command.Read.TemposLogisticosReadCommand command )
        {
            var query = _query.TemposLogisticosQuery(command );

                var itens = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters);
                return new DataPagination<TemposLogisticosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TemposLogisticosTenantIDDTO> getTemposLogisticosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemposLogisticosTenantIDDTO> lista;
            var query = _query.TemposLogisticosTenantIDQuery(command );

                lista = _unitOfWork.Query<TemposLogisticosTenantIDDTO>(query.Query,query.Parameters) as List<TemposLogisticosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TemposLogisticosTenantIDDTO> getTemposLogisticosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemposLogisticosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TemposLogisticosUserIdDTO> getTemposLogisticosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemposLogisticosUserIdDTO> lista;
            var query = _query.TemposLogisticosUserIdQuery(command );

                lista = _unitOfWork.Query<TemposLogisticosUserIdDTO>(query.Query,query.Parameters) as List<TemposLogisticosUserIdDTO>;
            return lista;
        }

        public IEnumerable<TemposLogisticosUserIdDTO> getTemposLogisticosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemposLogisticosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTMP_TIPO_TEMPO(string value )
        {
            var query = _query.ExistsByTMP_TIPO_TEMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTMP_TIPO_CARGA(string value )
        {
            var query = _query.ExistsByTMP_TIPO_CARGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTMP_TEMPO_MEDIO_UNITARIO(Decimal value )
        {
            var query = _query.ExistsByTMP_TEMPO_MEDIO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

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

        public TemposLogisticosDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemposLogisticosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemposLogisticosDTO FirstByTMP_TIPO_TEMPO(string value )
        {
            var query = _query.FirstByTMP_TIPO_TEMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemposLogisticosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemposLogisticosDTO FirstByTMP_TIPO_CARGA(string value )
        {
            var query = _query.FirstByTMP_TIPO_CARGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemposLogisticosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemposLogisticosDTO FirstByTMP_TEMPO_MEDIO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByTMP_TEMPO_MEDIO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemposLogisticosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemposLogisticosDTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemposLogisticosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemposLogisticosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemposLogisticosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemposLogisticosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemposLogisticosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemposLogisticosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemposLogisticosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemposLogisticosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemposLogisticosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TemposLogisticosDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters) as List<TemposLogisticosDTO>;
                return result;
        }

        public IEnumerable<TemposLogisticosDTO> GetAllByTMP_TIPO_TEMPO(string value )
        {
            var query = _query.FirstByTMP_TIPO_TEMPOQuery(value );

                var result = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters) as List<TemposLogisticosDTO>;
                return result;
        }

        public IEnumerable<TemposLogisticosDTO> GetAllByTMP_TIPO_CARGA(string value )
        {
            var query = _query.FirstByTMP_TIPO_CARGAQuery(value );

                var result = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters) as List<TemposLogisticosDTO>;
                return result;
        }

        public IEnumerable<TemposLogisticosDTO> GetAllByTMP_TEMPO_MEDIO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByTMP_TEMPO_MEDIO_UNITARIOQuery(value );

                var result = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters) as List<TemposLogisticosDTO>;
                return result;
        }

        public IEnumerable<TemposLogisticosDTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters) as List<TemposLogisticosDTO>;
                return result;
        }

        public IEnumerable<TemposLogisticosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters) as List<TemposLogisticosDTO>;
                return result;
        }

        public IEnumerable<TemposLogisticosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters) as List<TemposLogisticosDTO>;
                return result;
        }

        public IEnumerable<TemposLogisticosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters) as List<TemposLogisticosDTO>;
                return result;
        }

        public IEnumerable<TemposLogisticosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TemposLogisticosDTO>(query.Query,query.Parameters) as List<TemposLogisticosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration