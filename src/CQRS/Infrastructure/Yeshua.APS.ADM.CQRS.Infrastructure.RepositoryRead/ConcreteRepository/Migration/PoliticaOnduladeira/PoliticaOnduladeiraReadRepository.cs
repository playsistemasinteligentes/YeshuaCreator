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
    public partial class PoliticaOnduladeiraReadRepository : IPoliticaOnduladeiraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPoliticaOnduladeiraQueryRead _query;

        public PoliticaOnduladeiraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPoliticaOnduladeiraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<PoliticaOnduladeiraDTO> getPoliticaOnduladeira(ICommandRead command )
         {
            if (command is Command.Read.PoliticaOnduladeiraReadCommand c)
                return getPoliticaOnduladeira(c );
            throw new NotImplementedException();
        }
        private DataPagination<PoliticaOnduladeiraDTO> getPoliticaOnduladeira(Command.Read.PoliticaOnduladeiraReadCommand command )
        {
            var query = _query.PoliticaOnduladeiraQuery(command );

                var itens = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters);
                return new DataPagination<PoliticaOnduladeiraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PoliticaOnduladeiraTenantIDDTO> getPoliticaOnduladeiraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PoliticaOnduladeiraTenantIDDTO> lista;
            var query = _query.PoliticaOnduladeiraTenantIDQuery(command );

                lista = _unitOfWork.Query<PoliticaOnduladeiraTenantIDDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PoliticaOnduladeiraTenantIDDTO> getPoliticaOnduladeiraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPoliticaOnduladeiraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PoliticaOnduladeiraUserIdDTO> getPoliticaOnduladeiraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PoliticaOnduladeiraUserIdDTO> lista;
            var query = _query.PoliticaOnduladeiraUserIdQuery(command );

                lista = _unitOfWork.Query<PoliticaOnduladeiraUserIdDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraUserIdDTO>;
            return lista;
        }

        public IEnumerable<PoliticaOnduladeiraUserIdDTO> getPoliticaOnduladeiraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPoliticaOnduladeiraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPOL_ID(int value )
        {
            var query = _query.ExistsByPOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPOL_NIVEL(int value )
        {
            var query = _query.ExistsByPOL_NIVELQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPOL_PROMOCAO(int value )
        {
            var query = _query.ExistsByPOL_PROMOCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPOL_DIAS_ANTECIPACAO(int value )
        {
            var query = _query.ExistsByPOL_DIAS_ANTECIPACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPOL_METROS_LINEARES(int value )
        {
            var query = _query.ExistsByPOL_METROS_LINEARESQuery(value );

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

        public PoliticaOnduladeiraDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public PoliticaOnduladeiraDTO FirstByPOL_ID(int value )
        {
            var query = _query.FirstByPOL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public PoliticaOnduladeiraDTO FirstByPOL_NIVEL(int value )
        {
            var query = _query.FirstByPOL_NIVELQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public PoliticaOnduladeiraDTO FirstByPOL_PROMOCAO(int value )
        {
            var query = _query.FirstByPOL_PROMOCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public PoliticaOnduladeiraDTO FirstByPOL_DIAS_ANTECIPACAO(int value )
        {
            var query = _query.FirstByPOL_DIAS_ANTECIPACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public PoliticaOnduladeiraDTO FirstByPOL_METROS_LINEARES(int value )
        {
            var query = _query.FirstByPOL_METROS_LINEARESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public PoliticaOnduladeiraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public PoliticaOnduladeiraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public PoliticaOnduladeiraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public PoliticaOnduladeiraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PoliticaOnduladeiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_ID(int value )
        {
            var query = _query.FirstByPOL_IDQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_NIVEL(int value )
        {
            var query = _query.FirstByPOL_NIVELQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_PROMOCAO(int value )
        {
            var query = _query.FirstByPOL_PROMOCAOQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_DIAS_ANTECIPACAO(int value )
        {
            var query = _query.FirstByPOL_DIAS_ANTECIPACAOQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_METROS_LINEARES(int value )
        {
            var query = _query.FirstByPOL_METROS_LINEARESQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PoliticaOnduladeiraDTO>(query.Query,query.Parameters) as List<PoliticaOnduladeiraDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration