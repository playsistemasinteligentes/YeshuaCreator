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
    public partial class MedidasTesteReadRepository : IMedidasTesteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMedidasTesteQueryRead _query;

        public MedidasTesteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMedidasTesteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMedidasTesteCustom(Command.Read.MedidasTesteReadCommand command, ref DataPagination<MedidasTesteDTO> result, ref bool handled);

        public DataPagination<MedidasTesteDTO> getMedidasTeste(ICommandRead command )
         {
            if (command is Command.Read.MedidasTesteReadCommand c)
                return getMedidasTeste(c );
            throw new NotImplementedException();
        }
        private DataPagination<MedidasTesteDTO> getMedidasTeste(Command.Read.MedidasTesteReadCommand command )
        {
            DataPagination<MedidasTesteDTO> customResult = null;
            var customHandled = false;
            TryGetMedidasTesteCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MedidasTesteQuery(command );

                var itens = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters);
                return new DataPagination<MedidasTesteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MedidasTesteTenantIDDTO> getMedidasTesteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MedidasTesteTenantIDDTO> lista;
            var query = _query.MedidasTesteTenantIDQuery(command );

                lista = _unitOfWork.Query<MedidasTesteTenantIDDTO>(query.Query,query.Parameters) as List<MedidasTesteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MedidasTesteTenantIDDTO> getMedidasTesteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMedidasTesteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MedidasTesteUserIdDTO> getMedidasTesteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MedidasTesteUserIdDTO> lista;
            var query = _query.MedidasTesteUserIdQuery(command );

                lista = _unitOfWork.Query<MedidasTesteUserIdDTO>(query.Query,query.Parameters) as List<MedidasTesteUserIdDTO>;
            return lista;
        }

        public IEnumerable<MedidasTesteUserIdDTO> getMedidasTesteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMedidasTesteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMDT_ID(int value )
        {
            var query = _query.ExistsByMDT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMDT_DESC(string value )
        {
            var query = _query.ExistsByMDT_DESCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMDT_VALOR_ESPERADO(Decimal value )
        {
            var query = _query.ExistsByMDT_VALOR_ESPERADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMDT_ENCONTRADO(Decimal value )
        {
            var query = _query.ExistsByMDT_ENCONTRADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_ID(string value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

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

        public MedidasTesteDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedidasTesteDTO FirstByMDT_ID(int value )
        {
            var query = _query.FirstByMDT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedidasTesteDTO FirstByMDT_DESC(string value )
        {
            var query = _query.FirstByMDT_DESCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedidasTesteDTO FirstByMDT_VALOR_ESPERADO(Decimal value )
        {
            var query = _query.FirstByMDT_VALOR_ESPERADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedidasTesteDTO FirstByMDT_ENCONTRADO(Decimal value )
        {
            var query = _query.FirstByMDT_ENCONTRADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedidasTesteDTO FirstByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedidasTesteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedidasTesteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedidasTesteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public MedidasTesteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MedidasTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllByMDT_ID(int value )
        {
            var query = _query.FirstByMDT_IDQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllByMDT_DESC(string value )
        {
            var query = _query.FirstByMDT_DESCQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllByMDT_VALOR_ESPERADO(Decimal value )
        {
            var query = _query.FirstByMDT_VALOR_ESPERADOQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllByMDT_ENCONTRADO(Decimal value )
        {
            var query = _query.FirstByMDT_ENCONTRADOQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllByUNI_ID(string value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

        public IEnumerable<MedidasTesteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MedidasTesteDTO>(query.Query,query.Parameters) as List<MedidasTesteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration