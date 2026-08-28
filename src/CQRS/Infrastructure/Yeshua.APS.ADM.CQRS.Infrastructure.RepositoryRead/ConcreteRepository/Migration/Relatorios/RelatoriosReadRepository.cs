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
    public partial class RelatoriosReadRepository : IRelatoriosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRelatoriosQueryRead _query;

        public RelatoriosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRelatoriosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<RelatoriosDTO> getRelatorios(ICommandRead command )
         {
            if (command is Command.Read.RelatoriosReadCommand c)
                return getRelatorios(c );
            throw new NotImplementedException();
        }
        private DataPagination<RelatoriosDTO> getRelatorios(Command.Read.RelatoriosReadCommand command )
        {
            var query = _query.RelatoriosQuery(command );

                var itens = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters);
                return new DataPagination<RelatoriosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RelatoriosTenantIDDTO> getRelatoriosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RelatoriosTenantIDDTO> lista;
            var query = _query.RelatoriosTenantIDQuery(command );

                lista = _unitOfWork.Query<RelatoriosTenantIDDTO>(query.Query,query.Parameters) as List<RelatoriosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RelatoriosTenantIDDTO> getRelatoriosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRelatoriosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RelatoriosUserIdDTO> getRelatoriosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RelatoriosUserIdDTO> lista;
            var query = _query.RelatoriosUserIdQuery(command );

                lista = _unitOfWork.Query<RelatoriosUserIdDTO>(query.Query,query.Parameters) as List<RelatoriosUserIdDTO>;
            return lista;
        }

        public IEnumerable<RelatoriosUserIdDTO> getRelatoriosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRelatoriosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByREL_ID(int value )
        {
            var query = _query.ExistsByREL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREL_NOME_RELATORIO(string value )
        {
            var query = _query.ExistsByREL_NOME_RELATORIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREL_NOME_CAMPO(string value )
        {
            var query = _query.ExistsByREL_NOME_CAMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREL_TIPO_CAMPO(string value )
        {
            var query = _query.ExistsByREL_TIPO_CAMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREL_POS_X(int value )
        {
            var query = _query.ExistsByREL_POS_XQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREL_POS_Y(int value )
        {
            var query = _query.ExistsByREL_POS_YQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREL_TAMANHO_FONTE(int value )
        {
            var query = _query.ExistsByREL_TAMANHO_FONTEQuery(value );

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

        public RelatoriosDTO FirstByREL_ID(int value )
        {
            var query = _query.FirstByREL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByREL_NOME_RELATORIO(string value )
        {
            var query = _query.FirstByREL_NOME_RELATORIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByREL_NOME_CAMPO(string value )
        {
            var query = _query.FirstByREL_NOME_CAMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByREL_TIPO_CAMPO(string value )
        {
            var query = _query.FirstByREL_TIPO_CAMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByREL_POS_X(int value )
        {
            var query = _query.FirstByREL_POS_XQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByREL_POS_Y(int value )
        {
            var query = _query.FirstByREL_POS_YQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByREL_TAMANHO_FONTE(int value )
        {
            var query = _query.FirstByREL_TAMANHO_FONTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RelatoriosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RelatoriosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByREL_ID(int value )
        {
            var query = _query.FirstByREL_IDQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByREL_NOME_RELATORIO(string value )
        {
            var query = _query.FirstByREL_NOME_RELATORIOQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByREL_NOME_CAMPO(string value )
        {
            var query = _query.FirstByREL_NOME_CAMPOQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByREL_TIPO_CAMPO(string value )
        {
            var query = _query.FirstByREL_TIPO_CAMPOQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByREL_POS_X(int value )
        {
            var query = _query.FirstByREL_POS_XQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByREL_POS_Y(int value )
        {
            var query = _query.FirstByREL_POS_YQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByREL_TAMANHO_FONTE(int value )
        {
            var query = _query.FirstByREL_TAMANHO_FONTEQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

        public IEnumerable<RelatoriosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RelatoriosDTO>(query.Query,query.Parameters) as List<RelatoriosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration