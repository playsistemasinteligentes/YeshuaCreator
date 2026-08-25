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
    public partial class RoteiroReadRepository : IRoteiroReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRoteiroQueryRead _query;

        public RoteiroReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRoteiroQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<RoteiroDTO> getRoteiro(ICommandRead command )
         {
            if (command is Command.Read.RoteiroReadCommand c)
                return getRoteiro(c );
            throw new NotImplementedException();
        }
        private DataPagination<RoteiroDTO> getRoteiro(Command.Read.RoteiroReadCommand command )
        {
            var query = _query.RoteiroQuery(command );

                var itens = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters);
                return new DataPagination<RoteiroDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RoteiroMAQ_IDDTO> getRoteiroReadFKMAQ_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroMAQ_IDDTO> lista;
            var query = _query.RoteiroMAQ_IDQuery(command );

                lista = _unitOfWork.Query<RoteiroMAQ_IDDTO>(query.Query,query.Parameters) as List<RoteiroMAQ_IDDTO>;
            return lista;
        }

        public IEnumerable<RoteiroMAQ_IDDTO> getRoteiroReadFKMAQ_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKMAQ_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroPRO_IDDTO> getRoteiroReadFKPRO_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroPRO_IDDTO> lista;
            var query = _query.RoteiroPRO_IDQuery(command );

                lista = _unitOfWork.Query<RoteiroPRO_IDDTO>(query.Query,query.Parameters) as List<RoteiroPRO_IDDTO>;
            return lista;
        }

        public IEnumerable<RoteiroPRO_IDDTO> getRoteiroReadFKPRO_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKPRO_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroGMA_IDDTO> getRoteiroReadFKGMA_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroGMA_IDDTO> lista;
            var query = _query.RoteiroGMA_IDQuery(command );

                lista = _unitOfWork.Query<RoteiroGMA_IDDTO>(query.Query,query.Parameters) as List<RoteiroGMA_IDDTO>;
            return lista;
        }

        public IEnumerable<RoteiroGMA_IDDTO> getRoteiroReadFKGMA_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKGMA_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroTEM_IDDTO> getRoteiroReadFKTEM_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroTEM_IDDTO> lista;
            var query = _query.RoteiroTEM_IDQuery(command );

                lista = _unitOfWork.Query<RoteiroTEM_IDDTO>(query.Query,query.Parameters) as List<RoteiroTEM_IDDTO>;
            return lista;
        }

        public IEnumerable<RoteiroTEM_IDDTO> getRoteiroReadFKTEM_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKTEM_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroTenantIDDTO> getRoteiroReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroTenantIDDTO> lista;
            var query = _query.RoteiroTenantIDQuery(command );

                lista = _unitOfWork.Query<RoteiroTenantIDDTO>(query.Query,query.Parameters) as List<RoteiroTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RoteiroTenantIDDTO> getRoteiroReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RoteiroUserIdDTO> getRoteiroReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RoteiroUserIdDTO> lista;
            var query = _query.RoteiroUserIdQuery(command );

                lista = _unitOfWork.Query<RoteiroUserIdDTO>(query.Query,query.Parameters) as List<RoteiroUserIdDTO>;
            return lista;
        }

        public IEnumerable<RoteiroUserIdDTO> getRoteiroReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRoteiroReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.ExistsByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGMA_ID(string value )
        {
            var query = _query.ExistsByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_PECAS_POR_PULSO(Decimal value )
        {
            var query = _query.ExistsByROT_PECAS_POR_PULSOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_PRIORIDADE_INFORMADA(Decimal value )
        {
            var query = _query.ExistsByROT_PRIORIDADE_INFORMADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_ACAO(string value )
        {
            var query = _query.ExistsByROT_ACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_PERFORMANCE(Decimal value )
        {
            var query = _query.ExistsByROT_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_TEMPO_SETUP(Decimal value )
        {
            var query = _query.ExistsByROT_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.ExistsByROT_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_VA_PARA_SEQ_TRANSFORMACAO(int value )
        {
            var query = _query.ExistsByROT_VA_PARA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_STATUS(string value )
        {
            var query = _query.ExistsByROT_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value )
        {
            var query = _query.ExistsByROT_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_AVALIA_CUSTO(int value )
        {
            var query = _query.ExistsByROT_AVALIA_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_OPERACOES(string value )
        {
            var query = _query.ExistsByROT_OPERACOESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_EXCECAO_OPERACOES(string value )
        {
            var query = _query.ExistsByROT_EXCECAO_OPERACOESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(Decimal value )
        {
            var query = _query.ExistsByROT_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROT_LINHA_DIRETA(string value )
        {
            var query = _query.ExistsByROT_LINHA_DIRETAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_ID(int value )
        {
            var query = _query.ExistsByTEM_IDQuery(value );

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

        public RoteiroDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_PECAS_POR_PULSO(Decimal value )
        {
            var query = _query.FirstByROT_PECAS_POR_PULSOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_PRIORIDADE_INFORMADA(Decimal value )
        {
            var query = _query.FirstByROT_PRIORIDADE_INFORMADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_ACAO(string value )
        {
            var query = _query.FirstByROT_ACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByROT_PERFORMANCEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_TEMPO_SETUP(Decimal value )
        {
            var query = _query.FirstByROT_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByROT_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_VA_PARA_SEQ_TRANSFORMACAO(int value )
        {
            var query = _query.FirstByROT_VA_PARA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_STATUS(string value )
        {
            var query = _query.FirstByROT_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value )
        {
            var query = _query.FirstByROT_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_AVALIA_CUSTO(int value )
        {
            var query = _query.FirstByROT_AVALIA_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_OPERACOES(string value )
        {
            var query = _query.FirstByROT_OPERACOESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_EXCECAO_OPERACOES(string value )
        {
            var query = _query.FirstByROT_EXCECAO_OPERACOESQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(Decimal value )
        {
            var query = _query.FirstByROT_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByROT_LINHA_DIRETA(string value )
        {
            var query = _query.FirstByROT_LINHA_DIRETAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public RoteiroDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RoteiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_SEQ_TRANFORMACAO(int value )
        {
            var query = _query.FirstByROT_SEQ_TRANFORMACAOQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_PECAS_POR_PULSO(Decimal value )
        {
            var query = _query.FirstByROT_PECAS_POR_PULSOQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_PRIORIDADE_INFORMADA(Decimal value )
        {
            var query = _query.FirstByROT_PRIORIDADE_INFORMADAQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_ACAO(string value )
        {
            var query = _query.FirstByROT_ACAOQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_PERFORMANCE(Decimal value )
        {
            var query = _query.FirstByROT_PERFORMANCEQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_TEMPO_SETUP(Decimal value )
        {
            var query = _query.FirstByROT_TEMPO_SETUPQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_TEMPO_SETUP_AJUSTE(Decimal value )
        {
            var query = _query.FirstByROT_TEMPO_SETUP_AJUSTEQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_VA_PARA_SEQ_TRANSFORMACAO(int value )
        {
            var query = _query.FirstByROT_VA_PARA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_STATUS(string value )
        {
            var query = _query.FirstByROT_STATUSQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value )
        {
            var query = _query.FirstByROT_HIERARQUIA_SEQ_TRANSFORMACAOQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_AVALIA_CUSTO(int value )
        {
            var query = _query.FirstByROT_AVALIA_CUSTOQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_OPERACOES(string value )
        {
            var query = _query.FirstByROT_OPERACOESQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_EXCECAO_OPERACOES(string value )
        {
            var query = _query.FirstByROT_EXCECAO_OPERACOESQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(Decimal value )
        {
            var query = _query.FirstByROT_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByROT_LINHA_DIRETA(string value )
        {
            var query = _query.FirstByROT_LINHA_DIRETAQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

        public IEnumerable<RoteiroDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RoteiroDTO>(query.Query,query.Parameters) as List<RoteiroDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration