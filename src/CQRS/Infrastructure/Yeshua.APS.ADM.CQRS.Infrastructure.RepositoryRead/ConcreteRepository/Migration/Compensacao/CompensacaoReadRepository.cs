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
    public partial class CompensacaoReadRepository : ICompensacaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICompensacaoQueryRead _query;

        public CompensacaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICompensacaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCompensacaoCustom(Command.Read.CompensacaoReadCommand command, ref DataPagination<CompensacaoDTO> result, ref bool handled);

        public DataPagination<CompensacaoDTO> getCompensacao(ICommandRead command )
         {
            if (command is Command.Read.CompensacaoReadCommand c)
                return getCompensacao(c );
            throw new NotImplementedException();
        }
        private DataPagination<CompensacaoDTO> getCompensacao(Command.Read.CompensacaoReadCommand command )
        {
            DataPagination<CompensacaoDTO> customResult = null;
            var customHandled = false;
            TryGetCompensacaoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CompensacaoQuery(command );

                var itens = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters);
                return new DataPagination<CompensacaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CompensacaoGRP_IDDTO> getCompensacaoReadFKGRP_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CompensacaoGRP_IDDTO> lista;
            var query = _query.CompensacaoGRP_IDQuery(command );

                lista = _unitOfWork.Query<CompensacaoGRP_IDDTO>(query.Query,query.Parameters) as List<CompensacaoGRP_IDDTO>;
            return lista;
        }

        public IEnumerable<CompensacaoGRP_IDDTO> getCompensacaoReadFKGRP_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCompensacaoReadFKGRP_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CompensacaoOND_IDDTO> getCompensacaoReadFKOND_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CompensacaoOND_IDDTO> lista;
            var query = _query.CompensacaoOND_IDQuery(command );

                lista = _unitOfWork.Query<CompensacaoOND_IDDTO>(query.Query,query.Parameters) as List<CompensacaoOND_IDDTO>;
            return lista;
        }

        public IEnumerable<CompensacaoOND_IDDTO> getCompensacaoReadFKOND_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCompensacaoReadFKOND_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CompensacaoTenantIDDTO> getCompensacaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CompensacaoTenantIDDTO> lista;
            var query = _query.CompensacaoTenantIDQuery(command );

                lista = _unitOfWork.Query<CompensacaoTenantIDDTO>(query.Query,query.Parameters) as List<CompensacaoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CompensacaoTenantIDDTO> getCompensacaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCompensacaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CompensacaoUserIdDTO> getCompensacaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CompensacaoUserIdDTO> lista;
            var query = _query.CompensacaoUserIdQuery(command );

                lista = _unitOfWork.Query<CompensacaoUserIdDTO>(query.Query,query.Parameters) as List<CompensacaoUserIdDTO>;
            return lista;
        }

        public IEnumerable<CompensacaoUserIdDTO> getCompensacaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCompensacaoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_ID(int value )
        {
            var query = _query.ExistsByCOM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ID(string value )
        {
            var query = _query.ExistsByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOND_ID(string value )
        {
            var query = _query.ExistsByOND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO1_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO1_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO2_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO2_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO3_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO3_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO4_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO4_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO5_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO5_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO6_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO6_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO7_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO7_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO8_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO8_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO9_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO9_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO10_OND(int value )
        {
            var query = _query.ExistsByCOM_VINCO10_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO1_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO1_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO2_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO2_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO3_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO3_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO4_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO4_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO5_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO5_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO6_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO6_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO7_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO7_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO8_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO8_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO9_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO9_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCOM_VINCO10_CONVERSAO(int value )
        {
            var query = _query.ExistsByCOM_VINCO10_CONVERSAOQuery(value );

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

        public CompensacaoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_ID(int value )
        {
            var query = _query.FirstByCOM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByOND_ID(string value )
        {
            var query = _query.FirstByOND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO1_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO1_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO2_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO2_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO3_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO3_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO4_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO4_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO5_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO5_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO6_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO6_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO7_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO7_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO8_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO8_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO9_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO9_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO10_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO10_ONDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO1_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO1_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO2_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO2_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO3_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO3_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO4_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO4_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO5_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO5_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO6_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO6_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO7_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO7_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO8_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO8_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO9_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO9_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByCOM_VINCO10_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO10_CONVERSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CompensacaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CompensacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_ID(int value )
        {
            var query = _query.FirstByCOM_IDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByOND_ID(string value )
        {
            var query = _query.FirstByOND_IDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO1_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO1_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO2_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO2_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO3_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO3_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO4_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO4_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO5_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO5_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO6_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO6_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO7_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO7_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO8_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO8_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO9_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO9_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO10_OND(int value )
        {
            var query = _query.FirstByCOM_VINCO10_ONDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO1_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO1_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO2_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO2_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO3_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO3_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO4_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO4_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO5_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO5_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO6_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO6_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO7_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO7_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO8_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO8_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO9_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO9_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO10_CONVERSAO(int value )
        {
            var query = _query.FirstByCOM_VINCO10_CONVERSAOQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

        public IEnumerable<CompensacaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CompensacaoDTO>(query.Query,query.Parameters) as List<CompensacaoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration