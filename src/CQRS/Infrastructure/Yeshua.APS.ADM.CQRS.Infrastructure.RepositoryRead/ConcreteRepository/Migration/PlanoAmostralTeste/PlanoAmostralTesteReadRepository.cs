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
    public partial class PlanoAmostralTesteReadRepository : IPlanoAmostralTesteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPlanoAmostralTesteQueryRead _query;

        public PlanoAmostralTesteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPlanoAmostralTesteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetPlanoAmostralTesteCustom(Command.Read.PlanoAmostralTesteReadCommand command, ref DataPagination<PlanoAmostralTesteDTO> result, ref bool handled);

        public DataPagination<PlanoAmostralTesteDTO> getPlanoAmostralTeste(ICommandRead command )
         {
            if (command is Command.Read.PlanoAmostralTesteReadCommand c)
                return getPlanoAmostralTeste(c );
            throw new NotImplementedException();
        }
        private DataPagination<PlanoAmostralTesteDTO> getPlanoAmostralTeste(Command.Read.PlanoAmostralTesteReadCommand command )
        {
            DataPagination<PlanoAmostralTesteDTO> customResult = null;
            var customHandled = false;
            TryGetPlanoAmostralTesteCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.PlanoAmostralTesteQuery(command );

                var itens = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters);
                return new DataPagination<PlanoAmostralTesteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PlanoAmostralTesteTenantIDDTO> getPlanoAmostralTesteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanoAmostralTesteTenantIDDTO> lista;
            var query = _query.PlanoAmostralTesteTenantIDQuery(command );

                lista = _unitOfWork.Query<PlanoAmostralTesteTenantIDDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PlanoAmostralTesteTenantIDDTO> getPlanoAmostralTesteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanoAmostralTesteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PlanoAmostralTesteUserIdDTO> getPlanoAmostralTesteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PlanoAmostralTesteUserIdDTO> lista;
            var query = _query.PlanoAmostralTesteUserIdQuery(command );

                lista = _unitOfWork.Query<PlanoAmostralTesteUserIdDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteUserIdDTO>;
            return lista;
        }

        public IEnumerable<PlanoAmostralTesteUserIdDTO> getPlanoAmostralTesteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPlanoAmostralTesteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByGRP_TIPO(Decimal value )
        {
            var query = _query.ExistsByGRP_TIPOQuery(value );

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

        public bool ExistsByPAT_ID(int value )
        {
            var query = _query.ExistsByPAT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAT_QTD_CAIXAS_DE(int value )
        {
            var query = _query.ExistsByPAT_QTD_CAIXAS_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAT_QTD_CAIXAS_ATE(int value )
        {
            var query = _query.ExistsByPAT_QTD_CAIXAS_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAT_N_AMOSTRAGEM(int value )
        {
            var query = _query.ExistsByPAT_N_AMOSTRAGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAT_PERCENT_ESPECIF(Decimal value )
        {
            var query = _query.ExistsByPAT_PERCENT_ESPECIFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public PlanoAmostralTesteDTO FirstByGRP_TIPO(Decimal value )
        {
            var query = _query.FirstByGRP_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoAmostralTesteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoAmostralTesteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoAmostralTesteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoAmostralTesteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoAmostralTesteDTO FirstByPAT_ID(int value )
        {
            var query = _query.FirstByPAT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoAmostralTesteDTO FirstByPAT_QTD_CAIXAS_DE(int value )
        {
            var query = _query.FirstByPAT_QTD_CAIXAS_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoAmostralTesteDTO FirstByPAT_QTD_CAIXAS_ATE(int value )
        {
            var query = _query.FirstByPAT_QTD_CAIXAS_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoAmostralTesteDTO FirstByPAT_N_AMOSTRAGEM(int value )
        {
            var query = _query.FirstByPAT_N_AMOSTRAGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PlanoAmostralTesteDTO FirstByPAT_PERCENT_ESPECIF(Decimal value )
        {
            var query = _query.FirstByPAT_PERCENT_ESPECIFQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PlanoAmostralTesteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByGRP_TIPO(Decimal value )
        {
            var query = _query.FirstByGRP_TIPOQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_ID(int value )
        {
            var query = _query.FirstByPAT_IDQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_QTD_CAIXAS_DE(int value )
        {
            var query = _query.FirstByPAT_QTD_CAIXAS_DEQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_QTD_CAIXAS_ATE(int value )
        {
            var query = _query.FirstByPAT_QTD_CAIXAS_ATEQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_N_AMOSTRAGEM(int value )
        {
            var query = _query.FirstByPAT_N_AMOSTRAGEMQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

        public IEnumerable<PlanoAmostralTesteDTO> GetAllByPAT_PERCENT_ESPECIF(Decimal value )
        {
            var query = _query.FirstByPAT_PERCENT_ESPECIFQuery(value );

                var result = _unitOfWork.Query<PlanoAmostralTesteDTO>(query.Query,query.Parameters) as List<PlanoAmostralTesteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration