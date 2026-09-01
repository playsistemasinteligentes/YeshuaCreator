// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IConsultaPedidoReadRepository
    {
        public DataPagination<ConsultaPedidoDTO> getConsultaPedido(ICommandRead command );
        public IEnumerable<ConsultaPedidoProdutoIdDTO> getConsultaPedidoReadFKProdutoId(object command );
        public bool ExistsByPedidoId(string value );
        public bool ExistsByClienteId(string value );
        public bool ExistsByClienteNome(string value );
        public bool ExistsByRazaoSocial(string value );
        public bool ExistsByProdutoId(string value );
        public bool ExistsByProdutoDescricao(string value );
        public bool ExistsByStatus(string value );
        public bool ExistsByEstagio(string value );
        public bool ExistsByDataEntregaDe(DateTime value );
        public bool ExistsByDataEntregaAte(DateTime value );
        public bool ExistsByEmbarqueAlvo(DateTime value );
        public bool ExistsByQuantidade(Decimal value );
        public bool ExistsBySaldoAProduzir(Decimal value );
        public bool ExistsBySaldoAExpedir(Decimal value );
        public bool ExistsByCorFila(string value );
        public bool ExistsByPedidoCliente(string value );
        public ConsultaPedidoDTO FirstByPedidoId(string value );
        public ConsultaPedidoDTO FirstByClienteId(string value );
        public ConsultaPedidoDTO FirstByClienteNome(string value );
        public ConsultaPedidoDTO FirstByRazaoSocial(string value );
        public ConsultaPedidoDTO FirstByProdutoId(string value );
        public ConsultaPedidoDTO FirstByProdutoDescricao(string value );
        public ConsultaPedidoDTO FirstByStatus(string value );
        public ConsultaPedidoDTO FirstByEstagio(string value );
        public ConsultaPedidoDTO FirstByDataEntregaDe(DateTime value );
        public ConsultaPedidoDTO FirstByDataEntregaAte(DateTime value );
        public ConsultaPedidoDTO FirstByEmbarqueAlvo(DateTime value );
        public ConsultaPedidoDTO FirstByQuantidade(Decimal value );
        public ConsultaPedidoDTO FirstBySaldoAProduzir(Decimal value );
        public ConsultaPedidoDTO FirstBySaldoAExpedir(Decimal value );
        public ConsultaPedidoDTO FirstByCorFila(string value );
        public ConsultaPedidoDTO FirstByPedidoCliente(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByPedidoId(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByClienteId(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByClienteNome(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByRazaoSocial(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByProdutoId(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByProdutoDescricao(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByStatus(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByEstagio(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByDataEntregaDe(DateTime value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByDataEntregaAte(DateTime value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByEmbarqueAlvo(DateTime value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByQuantidade(Decimal value );
        public IEnumerable<ConsultaPedidoDTO> GetAllBySaldoAProduzir(Decimal value );
        public IEnumerable<ConsultaPedidoDTO> GetAllBySaldoAExpedir(Decimal value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByCorFila(string value );
        public IEnumerable<ConsultaPedidoDTO> GetAllByPedidoCliente(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration