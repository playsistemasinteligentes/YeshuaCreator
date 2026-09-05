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
    public class CenarioPlanejamentoTransporteQueryWrite : QueryBase, ICenarioPlanejamentoTransporteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CenarioPlanejamentoTransporteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCenarioPlanejamentoTransporteQuery(ICenarioPlanejamentoTransporteEntity CenarioPlanejamentoTransporte)
        {
            this.Query = $@" INSERT INTO [CenarioPlanejamentoTransporte] ([CenarioId], [Descricao], [Objetivo], [QuantidadeCargas], [QuantidadePedidosNaoAtendidos], [CustoTotal], [AderenciaCubagem], [AtrasoPrevisto], [AlertasResumo]) VALUES(@CenarioId, @Descricao, @Objetivo, @QuantidadeCargas, @QuantidadePedidosNaoAtendidos, @CustoTotal, @AderenciaCubagem, @AtrasoPrevisto, @AlertasResumo) ";
            this.Parameters = new
            {
                CenarioId = CenarioPlanejamentoTransporte.CenarioId,
                Descricao = CenarioPlanejamentoTransporte.Descricao,
                Objetivo = CenarioPlanejamentoTransporte.Objetivo,
                QuantidadeCargas = CenarioPlanejamentoTransporte.QuantidadeCargas,
                QuantidadePedidosNaoAtendidos = CenarioPlanejamentoTransporte.QuantidadePedidosNaoAtendidos,
                CustoTotal = CenarioPlanejamentoTransporte.CustoTotal,
                AderenciaCubagem = CenarioPlanejamentoTransporte.AderenciaCubagem,
                AtrasoPrevisto = CenarioPlanejamentoTransporte.AtrasoPrevisto,
                AlertasResumo = CenarioPlanejamentoTransporte.AlertasResumo,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCenarioPlanejamentoTransporteQuery(ICenarioPlanejamentoTransporteEntity CenarioPlanejamentoTransporte)
        {
            this.Query = $@" UPDATE [CenarioPlanejamentoTransporte] SET [Descricao] = @Descricao, [Objetivo] = @Objetivo, [QuantidadeCargas] = @QuantidadeCargas, [QuantidadePedidosNaoAtendidos] = @QuantidadePedidosNaoAtendidos, [CustoTotal] = @CustoTotal, [AderenciaCubagem] = @AderenciaCubagem, [AtrasoPrevisto] = @AtrasoPrevisto, [AlertasResumo] = @AlertasResumo WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                Descricao = CenarioPlanejamentoTransporte.Descricao,
                Objetivo = CenarioPlanejamentoTransporte.Objetivo,
                QuantidadeCargas = CenarioPlanejamentoTransporte.QuantidadeCargas,
                QuantidadePedidosNaoAtendidos = CenarioPlanejamentoTransporte.QuantidadePedidosNaoAtendidos,
                CustoTotal = CenarioPlanejamentoTransporte.CustoTotal,
                AderenciaCubagem = CenarioPlanejamentoTransporte.AderenciaCubagem,
                AtrasoPrevisto = CenarioPlanejamentoTransporte.AtrasoPrevisto,
                AlertasResumo = CenarioPlanejamentoTransporte.AlertasResumo,
                CenarioId = CenarioPlanejamentoTransporte.CenarioId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(string cenarioid, string value)
        {
            this.Query = $@" UPDATE [CenarioPlanejamentoTransporte] SET [Descricao] = @Descricao WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                Descricao = value,
                CenarioId = cenarioid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObjetivo(string cenarioid, string value)
        {
            this.Query = $@" UPDATE [CenarioPlanejamentoTransporte] SET [Objetivo] = @Objetivo WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                Objetivo = value,
                CenarioId = cenarioid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadeCargas(string cenarioid, int value)
        {
            this.Query = $@" UPDATE [CenarioPlanejamentoTransporte] SET [QuantidadeCargas] = @QuantidadeCargas WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                QuantidadeCargas = value,
                CenarioId = cenarioid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadePedidosNaoAtendidos(string cenarioid, int value)
        {
            this.Query = $@" UPDATE [CenarioPlanejamentoTransporte] SET [QuantidadePedidosNaoAtendidos] = @QuantidadePedidosNaoAtendidos WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                QuantidadePedidosNaoAtendidos = value,
                CenarioId = cenarioid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCustoTotal(string cenarioid, Decimal value)
        {
            this.Query = $@" UPDATE [CenarioPlanejamentoTransporte] SET [CustoTotal] = @CustoTotal WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                CustoTotal = value,
                CenarioId = cenarioid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAderenciaCubagem(string cenarioid, Decimal value)
        {
            this.Query = $@" UPDATE [CenarioPlanejamentoTransporte] SET [AderenciaCubagem] = @AderenciaCubagem WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                AderenciaCubagem = value,
                CenarioId = cenarioid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAtrasoPrevisto(string cenarioid, Decimal value)
        {
            this.Query = $@" UPDATE [CenarioPlanejamentoTransporte] SET [AtrasoPrevisto] = @AtrasoPrevisto WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                AtrasoPrevisto = value,
                CenarioId = cenarioid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAlertasResumo(string cenarioid, string value)
        {
            this.Query = $@" UPDATE [CenarioPlanejamentoTransporte] SET [AlertasResumo] = @AlertasResumo WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                AlertasResumo = value,
                CenarioId = cenarioid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCenarioPlanejamentoTransporteQuery(ICenarioPlanejamentoTransporteEntity CenarioPlanejamentoTransporte)
        {
            this.Query = $@" DELETE FROM [CenarioPlanejamentoTransporte] WHERE [CenarioId] = @CenarioId ";
            this.Parameters = new
            {
                CenarioId = CenarioPlanejamentoTransporte.CenarioId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration