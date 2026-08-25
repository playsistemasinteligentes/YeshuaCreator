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
    public partial class ConsultaPedidoReadRepository : IConsultaPedidoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IConsultaPedidoQueryRead _query;

        public ConsultaPedidoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IConsultaPedidoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ConsultaPedidoDTO> getConsultaPedido(ICommandRead command )
         {
            if (command is Command.Read.ConsultaPedidoReadCommand c)
                return getConsultaPedido(c );
            throw new NotImplementedException();
        }
        private DataPagination<ConsultaPedidoDTO> getConsultaPedido(Command.Read.ConsultaPedidoReadCommand command )
        {
            var query = _query.ConsultaPedidoQuery(command );

                var itens = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters);
                return new DataPagination<ConsultaPedidoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ConsultaPedidoProdutoIdDTO> getConsultaPedidoReadFKProdutoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ConsultaPedidoProdutoIdDTO> lista;
            var query = _query.ConsultaPedidoProdutoIdQuery(command );

                lista = _unitOfWork.Query<ConsultaPedidoProdutoIdDTO>(query.Query,query.Parameters) as List<ConsultaPedidoProdutoIdDTO>;
            return lista;
        }

        public IEnumerable<ConsultaPedidoProdutoIdDTO> getConsultaPedidoReadFKProdutoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getConsultaPedidoReadFKProdutoId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPedidoId(string value )
        {
            var query = _query.ExistsByPedidoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByClienteId(string value )
        {
            var query = _query.ExistsByClienteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByClienteNome(string value )
        {
            var query = _query.ExistsByClienteNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRazaoSocial(string value )
        {
            var query = _query.ExistsByRazaoSocialQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProdutoId(string value )
        {
            var query = _query.ExistsByProdutoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProdutoDescricao(string value )
        {
            var query = _query.ExistsByProdutoDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(string value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEstagio(string value )
        {
            var query = _query.ExistsByEstagioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataEntregaDe(DateTime value )
        {
            var query = _query.ExistsByDataEntregaDeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataEntregaAte(DateTime value )
        {
            var query = _query.ExistsByDataEntregaAteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEmbarqueAlvo(DateTime value )
        {
            var query = _query.ExistsByEmbarqueAlvoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByQuantidade(Decimal value )
        {
            var query = _query.ExistsByQuantidadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySaldoAProduzir(Decimal value )
        {
            var query = _query.ExistsBySaldoAProduzirQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySaldoAExpedir(Decimal value )
        {
            var query = _query.ExistsBySaldoAExpedirQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorFila(string value )
        {
            var query = _query.ExistsByCorFilaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPedidoCliente(string value )
        {
            var query = _query.ExistsByPedidoClienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public ConsultaPedidoDTO FirstByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByClienteId(string value )
        {
            var query = _query.FirstByClienteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByClienteNome(string value )
        {
            var query = _query.FirstByClienteNomeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByRazaoSocial(string value )
        {
            var query = _query.FirstByRazaoSocialQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByProdutoDescricao(string value )
        {
            var query = _query.FirstByProdutoDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByEstagio(string value )
        {
            var query = _query.FirstByEstagioQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByDataEntregaDe(DateTime value )
        {
            var query = _query.FirstByDataEntregaDeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByDataEntregaAte(DateTime value )
        {
            var query = _query.FirstByDataEntregaAteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByEmbarqueAlvo(DateTime value )
        {
            var query = _query.FirstByEmbarqueAlvoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByQuantidade(Decimal value )
        {
            var query = _query.FirstByQuantidadeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstBySaldoAProduzir(Decimal value )
        {
            var query = _query.FirstBySaldoAProduzirQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstBySaldoAExpedir(Decimal value )
        {
            var query = _query.FirstBySaldoAExpedirQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByCorFila(string value )
        {
            var query = _query.FirstByCorFilaQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultaPedidoDTO FirstByPedidoCliente(string value )
        {
            var query = _query.FirstByPedidoClienteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultaPedidoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByPedidoId(string value )
        {
            var query = _query.FirstByPedidoIdQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByClienteId(string value )
        {
            var query = _query.FirstByClienteIdQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByClienteNome(string value )
        {
            var query = _query.FirstByClienteNomeQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByRazaoSocial(string value )
        {
            var query = _query.FirstByRazaoSocialQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByProdutoId(string value )
        {
            var query = _query.FirstByProdutoIdQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByProdutoDescricao(string value )
        {
            var query = _query.FirstByProdutoDescricaoQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByEstagio(string value )
        {
            var query = _query.FirstByEstagioQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByDataEntregaDe(DateTime value )
        {
            var query = _query.FirstByDataEntregaDeQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByDataEntregaAte(DateTime value )
        {
            var query = _query.FirstByDataEntregaAteQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByEmbarqueAlvo(DateTime value )
        {
            var query = _query.FirstByEmbarqueAlvoQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByQuantidade(Decimal value )
        {
            var query = _query.FirstByQuantidadeQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllBySaldoAProduzir(Decimal value )
        {
            var query = _query.FirstBySaldoAProduzirQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllBySaldoAExpedir(Decimal value )
        {
            var query = _query.FirstBySaldoAExpedirQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByCorFila(string value )
        {
            var query = _query.FirstByCorFilaQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

        public IEnumerable<ConsultaPedidoDTO> GetAllByPedidoCliente(string value )
        {
            var query = _query.FirstByPedidoClienteQuery(value );

                var result = _unitOfWork.Query<ConsultaPedidoDTO>(query.Query,query.Parameters) as List<ConsultaPedidoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration