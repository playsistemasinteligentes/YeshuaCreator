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
    public partial class MunicipioReadRepository : IMunicipioReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMunicipioQueryRead _query;

        public MunicipioReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMunicipioQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<MunicipioDTO> getMunicipio(ICommandRead command )
         {
            if (command is Command.Read.MunicipioReadCommand c)
                return getMunicipio(c );
            throw new NotImplementedException();
        }
        private DataPagination<MunicipioDTO> getMunicipio(Command.Read.MunicipioReadCommand command )
        {
            var query = _query.MunicipioQuery(command );

                var itens = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters);
                return new DataPagination<MunicipioDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MunicipioTenantIDDTO> getMunicipioReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MunicipioTenantIDDTO> lista;
            var query = _query.MunicipioTenantIDQuery(command );

                lista = _unitOfWork.Query<MunicipioTenantIDDTO>(query.Query,query.Parameters) as List<MunicipioTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MunicipioTenantIDDTO> getMunicipioReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMunicipioReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MunicipioUserIdDTO> getMunicipioReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MunicipioUserIdDTO> lista;
            var query = _query.MunicipioUserIdQuery(command );

                lista = _unitOfWork.Query<MunicipioUserIdDTO>(query.Query,query.Parameters) as List<MunicipioUserIdDTO>;
            return lista;
        }

        public IEnumerable<MunicipioUserIdDTO> getMunicipioReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMunicipioReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByMUN_ID(string value )
        {
            var query = _query.ExistsByMUN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_NOME(string value )
        {
            var query = _query.ExistsByMUN_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUF_COD(string value )
        {
            var query = _query.ExistsByUF_CODQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_CODIGO_IBGE(string value )
        {
            var query = _query.ExistsByMUN_CODIGO_IBGEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_LATITUDE(Decimal value )
        {
            var query = _query.ExistsByMUN_LATITUDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_LONGITUDE(Decimal value )
        {
            var query = _query.ExistsByMUN_LONGITUDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByMUN_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_CODIGO_SIAFI(string value )
        {
            var query = _query.ExistsByMUN_CODIGO_SIAFIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_CODIGO_CNPJ(string value )
        {
            var query = _query.ExistsByMUN_CODIGO_CNPJQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_DISTANCIA_KM(Decimal value )
        {
            var query = _query.ExistsByMUN_DISTANCIA_KMQuery(value );

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

        public MunicipioDTO FirstByMUN_ID(string value )
        {
            var query = _query.FirstByMUN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByMUN_NOME(string value )
        {
            var query = _query.FirstByMUN_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByUF_COD(string value )
        {
            var query = _query.FirstByUF_CODQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByMUN_CODIGO_IBGE(string value )
        {
            var query = _query.FirstByMUN_CODIGO_IBGEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByMUN_LATITUDE(Decimal value )
        {
            var query = _query.FirstByMUN_LATITUDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByMUN_LONGITUDE(Decimal value )
        {
            var query = _query.FirstByMUN_LONGITUDEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByMUN_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByMUN_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByMUN_CODIGO_SIAFI(string value )
        {
            var query = _query.FirstByMUN_CODIGO_SIAFIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByMUN_CODIGO_CNPJ(string value )
        {
            var query = _query.FirstByMUN_CODIGO_CNPJQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByMUN_DISTANCIA_KM(Decimal value )
        {
            var query = _query.FirstByMUN_DISTANCIA_KMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public MunicipioDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MunicipioDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByMUN_ID(string value )
        {
            var query = _query.FirstByMUN_IDQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByMUN_NOME(string value )
        {
            var query = _query.FirstByMUN_NOMEQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByUF_COD(string value )
        {
            var query = _query.FirstByUF_CODQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByMUN_CODIGO_IBGE(string value )
        {
            var query = _query.FirstByMUN_CODIGO_IBGEQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByMUN_LATITUDE(Decimal value )
        {
            var query = _query.FirstByMUN_LATITUDEQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByMUN_LONGITUDE(Decimal value )
        {
            var query = _query.FirstByMUN_LONGITUDEQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByMUN_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByMUN_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByMUN_CODIGO_SIAFI(string value )
        {
            var query = _query.FirstByMUN_CODIGO_SIAFIQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByMUN_CODIGO_CNPJ(string value )
        {
            var query = _query.FirstByMUN_CODIGO_CNPJQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByMUN_DISTANCIA_KM(Decimal value )
        {
            var query = _query.FirstByMUN_DISTANCIA_KMQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

        public IEnumerable<MunicipioDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MunicipioDTO>(query.Query,query.Parameters) as List<MunicipioDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration