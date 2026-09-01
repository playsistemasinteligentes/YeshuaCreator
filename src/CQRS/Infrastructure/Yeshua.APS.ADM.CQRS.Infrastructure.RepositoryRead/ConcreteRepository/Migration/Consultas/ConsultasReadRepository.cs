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
    public partial class ConsultasReadRepository : IConsultasReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IConsultasQueryRead _query;

        public ConsultasReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IConsultasQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetConsultasCustom(Command.Read.ConsultasReadCommand command, ref DataPagination<ConsultasDTO> result, ref bool handled);

        public DataPagination<ConsultasDTO> getConsultas(ICommandRead command )
         {
            if (command is Command.Read.ConsultasReadCommand c)
                return getConsultas(c );
            throw new NotImplementedException();
        }
        private DataPagination<ConsultasDTO> getConsultas(Command.Read.ConsultasReadCommand command )
        {
            DataPagination<ConsultasDTO> customResult = null;
            var customHandled = false;
            TryGetConsultasCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ConsultasQuery(command );

                var itens = _unitOfWork.Query<ConsultasDTO>(query.Query,query.Parameters);
                return new DataPagination<ConsultasDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ConsultasTenantIDDTO> getConsultasReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ConsultasTenantIDDTO> lista;
            var query = _query.ConsultasTenantIDQuery(command );

                lista = _unitOfWork.Query<ConsultasTenantIDDTO>(query.Query,query.Parameters) as List<ConsultasTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ConsultasTenantIDDTO> getConsultasReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getConsultasReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ConsultasUserIdDTO> getConsultasReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ConsultasUserIdDTO> lista;
            var query = _query.ConsultasUserIdQuery(command );

                lista = _unitOfWork.Query<ConsultasUserIdDTO>(query.Query,query.Parameters) as List<ConsultasUserIdDTO>;
            return lista;
        }

        public IEnumerable<ConsultasUserIdDTO> getConsultasReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getConsultasReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_CASAS_DECIMAIS(string value )
        {
            var query = _query.ExistsByCON_CASAS_DECIMAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_CONEXAO(string value )
        {
            var query = _query.ExistsByCON_CONEXAOQuery(value );

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

        public ConsultasDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasDTO FirstByCON_CASAS_DECIMAIS(string value )
        {
            var query = _query.FirstByCON_CASAS_DECIMAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasDTO FirstByCON_CONEXAO(string value )
        {
            var query = _query.FirstByCON_CONEXAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ConsultasDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ConsultasDTO>(query.Query,query.Parameters) as List<ConsultasDTO>;
                return result;
        }

        public IEnumerable<ConsultasDTO> GetAllByCON_CASAS_DECIMAIS(string value )
        {
            var query = _query.FirstByCON_CASAS_DECIMAISQuery(value );

                var result = _unitOfWork.Query<ConsultasDTO>(query.Query,query.Parameters) as List<ConsultasDTO>;
                return result;
        }

        public IEnumerable<ConsultasDTO> GetAllByCON_CONEXAO(string value )
        {
            var query = _query.FirstByCON_CONEXAOQuery(value );

                var result = _unitOfWork.Query<ConsultasDTO>(query.Query,query.Parameters) as List<ConsultasDTO>;
                return result;
        }

        public IEnumerable<ConsultasDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ConsultasDTO>(query.Query,query.Parameters) as List<ConsultasDTO>;
                return result;
        }

        public IEnumerable<ConsultasDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ConsultasDTO>(query.Query,query.Parameters) as List<ConsultasDTO>;
                return result;
        }

        public IEnumerable<ConsultasDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ConsultasDTO>(query.Query,query.Parameters) as List<ConsultasDTO>;
                return result;
        }

        public IEnumerable<ConsultasDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ConsultasDTO>(query.Query,query.Parameters) as List<ConsultasDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration