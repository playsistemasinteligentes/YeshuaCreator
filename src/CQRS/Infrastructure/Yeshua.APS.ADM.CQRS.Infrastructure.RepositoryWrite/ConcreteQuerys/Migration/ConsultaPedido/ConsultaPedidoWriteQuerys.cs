// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class ConsultaPedidoQueryWrite : QueryBase, IConsultaPedidoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ConsultaPedidoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirConsultaPedidoQuery(IConsultaPedidoEntity ConsultaPedido)
        {
            this.Query = $@" INSERT INTO [ConsultaPedido] ([PedidoId], [ClienteId], [ClienteNome], [RazaoSocial], [ProdutoId], [ProdutoDescricao], [Status], [Estagio], [DataEntregaDe], [DataEntregaAte], [EmbarqueAlvo], [Quantidade], [SaldoAProduzir], [SaldoAExpedir], [CorFila], [PedidoCliente]) VALUES(@PedidoId, @ClienteId, @ClienteNome, @RazaoSocial, @ProdutoId, @ProdutoDescricao, @Status, @Estagio, @DataEntregaDe, @DataEntregaAte, @EmbarqueAlvo, @Quantidade, @SaldoAProduzir, @SaldoAExpedir, @CorFila, @PedidoCliente) ";
            this.Parameters = new
            {
                PedidoId = ConsultaPedido.PedidoId,
                ClienteId = ConsultaPedido.ClienteId,
                ClienteNome = ConsultaPedido.ClienteNome,
                RazaoSocial = ConsultaPedido.RazaoSocial,
                ProdutoId = ConsultaPedido.ProdutoId,
                ProdutoDescricao = ConsultaPedido.ProdutoDescricao,
                Status = ConsultaPedido.Status,
                Estagio = ConsultaPedido.Estagio,
                DataEntregaDe = ConsultaPedido.DataEntregaDe,
                DataEntregaAte = ConsultaPedido.DataEntregaAte,
                EmbarqueAlvo = ConsultaPedido.EmbarqueAlvo,
                Quantidade = ConsultaPedido.Quantidade,
                SaldoAProduzir = ConsultaPedido.SaldoAProduzir,
                SaldoAExpedir = ConsultaPedido.SaldoAExpedir,
                CorFila = ConsultaPedido.CorFila,
                PedidoCliente = ConsultaPedido.PedidoCliente,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateConsultaPedidoQuery(IConsultaPedidoEntity ConsultaPedido)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [ClienteId] = @ClienteId, [ClienteNome] = @ClienteNome, [RazaoSocial] = @RazaoSocial, [ProdutoId] = @ProdutoId, [ProdutoDescricao] = @ProdutoDescricao, [Status] = @Status, [Estagio] = @Estagio, [DataEntregaDe] = @DataEntregaDe, [DataEntregaAte] = @DataEntregaAte, [EmbarqueAlvo] = @EmbarqueAlvo, [Quantidade] = @Quantidade, [SaldoAProduzir] = @SaldoAProduzir, [SaldoAExpedir] = @SaldoAExpedir, [CorFila] = @CorFila, [PedidoCliente] = @PedidoCliente WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                ClienteId = ConsultaPedido.ClienteId,
                ClienteNome = ConsultaPedido.ClienteNome,
                RazaoSocial = ConsultaPedido.RazaoSocial,
                ProdutoId = ConsultaPedido.ProdutoId,
                ProdutoDescricao = ConsultaPedido.ProdutoDescricao,
                Status = ConsultaPedido.Status,
                Estagio = ConsultaPedido.Estagio,
                DataEntregaDe = ConsultaPedido.DataEntregaDe,
                DataEntregaAte = ConsultaPedido.DataEntregaAte,
                EmbarqueAlvo = ConsultaPedido.EmbarqueAlvo,
                Quantidade = ConsultaPedido.Quantidade,
                SaldoAProduzir = ConsultaPedido.SaldoAProduzir,
                SaldoAExpedir = ConsultaPedido.SaldoAExpedir,
                CorFila = ConsultaPedido.CorFila,
                PedidoCliente = ConsultaPedido.PedidoCliente,
                PedidoId = ConsultaPedido.PedidoId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClienteId(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [ClienteId] = @ClienteId WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                ClienteId = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClienteNome(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [ClienteNome] = @ClienteNome WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                ClienteNome = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRazaoSocial(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [RazaoSocial] = @RazaoSocial WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                RazaoSocial = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoId(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [ProdutoId] = @ProdutoId WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                ProdutoId = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoDescricao(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [ProdutoDescricao] = @ProdutoDescricao WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                ProdutoDescricao = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [Status] = @Status WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Status = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEstagio(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [Estagio] = @Estagio WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Estagio = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataEntregaDe(string pedidoid, DateTime value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [DataEntregaDe] = @DataEntregaDe WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                DataEntregaDe = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataEntregaAte(string pedidoid, DateTime value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [DataEntregaAte] = @DataEntregaAte WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                DataEntregaAte = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmbarqueAlvo(string pedidoid, DateTime value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [EmbarqueAlvo] = @EmbarqueAlvo WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                EmbarqueAlvo = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidade(string pedidoid, Decimal value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [Quantidade] = @Quantidade WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                Quantidade = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSaldoAProduzir(string pedidoid, Decimal value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [SaldoAProduzir] = @SaldoAProduzir WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                SaldoAProduzir = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSaldoAExpedir(string pedidoid, Decimal value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [SaldoAExpedir] = @SaldoAExpedir WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                SaldoAExpedir = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorFila(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [CorFila] = @CorFila WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                CorFila = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePedidoCliente(string pedidoid, string value)
        {
            this.Query = $@" UPDATE [ConsultaPedido] SET [PedidoCliente] = @PedidoCliente WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                PedidoCliente = value,
                PedidoId = pedidoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteConsultaPedidoQuery(IConsultaPedidoEntity ConsultaPedido)
        {
            this.Query = $@" DELETE FROM [ConsultaPedido] WHERE [PedidoId] = @PedidoId ";
            this.Parameters = new
            {
                PedidoId = ConsultaPedido.PedidoId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration