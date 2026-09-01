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
    public partial class TesteFisicoReadRepository : ITesteFisicoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITesteFisicoQueryRead _query;

        public TesteFisicoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITesteFisicoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTesteFisicoCustom(Command.Read.TesteFisicoReadCommand command, ref DataPagination<TesteFisicoDTO> result, ref bool handled);

        public DataPagination<TesteFisicoDTO> getTesteFisico(ICommandRead command )
         {
            if (command is Command.Read.TesteFisicoReadCommand c)
                return getTesteFisico(c );
            throw new NotImplementedException();
        }
        private DataPagination<TesteFisicoDTO> getTesteFisico(Command.Read.TesteFisicoReadCommand command )
        {
            DataPagination<TesteFisicoDTO> customResult = null;
            var customHandled = false;
            TryGetTesteFisicoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TesteFisicoQuery(command );

                var itens = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters);
                return new DataPagination<TesteFisicoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TesteFisicoUSR_IDDTO> getTesteFisicoReadFKUSR_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TesteFisicoUSR_IDDTO> lista;
            var query = _query.TesteFisicoUSR_IDQuery(command );

                lista = _unitOfWork.Query<TesteFisicoUSR_IDDTO>(query.Query,query.Parameters) as List<TesteFisicoUSR_IDDTO>;
            return lista;
        }

        public IEnumerable<TesteFisicoUSR_IDDTO> getTesteFisicoReadFKUSR_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTesteFisicoReadFKUSR_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TesteFisicoORD_IDDTO> getTesteFisicoReadFKORD_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TesteFisicoORD_IDDTO> lista;
            var query = _query.TesteFisicoORD_IDQuery(command );

                lista = _unitOfWork.Query<TesteFisicoORD_IDDTO>(query.Query,query.Parameters) as List<TesteFisicoORD_IDDTO>;
            return lista;
        }

        public IEnumerable<TesteFisicoORD_IDDTO> getTesteFisicoReadFKORD_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTesteFisicoReadFKORD_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TesteFisicoTenantIDDTO> getTesteFisicoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TesteFisicoTenantIDDTO> lista;
            var query = _query.TesteFisicoTenantIDQuery(command );

                lista = _unitOfWork.Query<TesteFisicoTenantIDDTO>(query.Query,query.Parameters) as List<TesteFisicoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TesteFisicoTenantIDDTO> getTesteFisicoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTesteFisicoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TesteFisicoUserIdDTO> getTesteFisicoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TesteFisicoUserIdDTO> lista;
            var query = _query.TesteFisicoUserIdQuery(command );

                lista = _unitOfWork.Query<TesteFisicoUserIdDTO>(query.Query,query.Parameters) as List<TesteFisicoUserIdDTO>;
            return lista;
        }

        public IEnumerable<TesteFisicoUserIdDTO> getTesteFisicoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTesteFisicoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTES_ID(int value )
        {
            var query = _query.ExistsByTES_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITE_ID(int value )
        {
            var query = _query.ExistsByITE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSR_ID(int value )
        {
            var query = _query.ExistsByUSR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTES_NOME_TECNICO(string value )
        {
            var query = _query.ExistsByTES_NOME_TECNICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTES_AMOSTRA(int value )
        {
            var query = _query.ExistsByTES_AMOSTRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTES_OP(string value )
        {
            var query = _query.ExistsByTES_OPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTES_VALOR_NUMERICO(Decimal value )
        {
            var query = _query.ExistsByTES_VALOR_NUMERICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTES_VALOR_DATA(DateTime value )
        {
            var query = _query.ExistsByTES_VALOR_DATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTES_VALOR_TEXTO(string value )
        {
            var query = _query.ExistsByTES_VALOR_TEXTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTES_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByTES_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.ExistsByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.ExistsByFPR_SEQ_TRANFORMACAOQuery(value );

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

        public TesteFisicoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByTES_ID(int value )
        {
            var query = _query.FirstByTES_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByITE_ID(int value )
        {
            var query = _query.FirstByITE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByUSR_ID(int value )
        {
            var query = _query.FirstByUSR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByTES_NOME_TECNICO(string value )
        {
            var query = _query.FirstByTES_NOME_TECNICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByTES_AMOSTRA(int value )
        {
            var query = _query.FirstByTES_AMOSTRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByTES_OP(string value )
        {
            var query = _query.FirstByTES_OPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByTES_VALOR_NUMERICO(Decimal value )
        {
            var query = _query.FirstByTES_VALOR_NUMERICOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByTES_VALOR_DATA(DateTime value )
        {
            var query = _query.FirstByTES_VALOR_DATAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByTES_VALOR_TEXTO(string value )
        {
            var query = _query.FirstByTES_VALOR_TEXTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByTES_EMISSAO(DateTime value )
        {
            var query = _query.FirstByTES_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByFPR_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TesteFisicoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TesteFisicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByTES_ID(int value )
        {
            var query = _query.FirstByTES_IDQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByITE_ID(int value )
        {
            var query = _query.FirstByITE_IDQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByUSR_ID(int value )
        {
            var query = _query.FirstByUSR_IDQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByTES_NOME_TECNICO(string value )
        {
            var query = _query.FirstByTES_NOME_TECNICOQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByTES_AMOSTRA(int value )
        {
            var query = _query.FirstByTES_AMOSTRAQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByTES_OP(string value )
        {
            var query = _query.FirstByTES_OPQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByTES_VALOR_NUMERICO(Decimal value )
        {
            var query = _query.FirstByTES_VALOR_NUMERICOQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByTES_VALOR_DATA(DateTime value )
        {
            var query = _query.FirstByTES_VALOR_DATAQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByTES_VALOR_TEXTO(string value )
        {
            var query = _query.FirstByTES_VALOR_TEXTOQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByTES_EMISSAO(DateTime value )
        {
            var query = _query.FirstByTES_EMISSAOQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByFPR_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

        public IEnumerable<TesteFisicoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TesteFisicoDTO>(query.Query,query.Parameters) as List<TesteFisicoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration