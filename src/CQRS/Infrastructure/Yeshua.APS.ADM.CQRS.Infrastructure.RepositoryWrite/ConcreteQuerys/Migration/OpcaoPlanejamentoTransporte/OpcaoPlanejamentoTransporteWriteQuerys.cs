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
    public class OpcaoPlanejamentoTransporteQueryWrite : QueryBase, IOpcaoPlanejamentoTransporteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public OpcaoPlanejamentoTransporteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirOpcaoPlanejamentoTransporteQuery(IOpcaoPlanejamentoTransporteEntity OpcaoPlanejamentoTransporte)
        {
            this.Query = $@" INSERT INTO OpcaoPlanejamentoTransporte (OpcaoId, GrupoDecisaoId, Peso, Volume, CustoEstimado, AderenciaCubagem, AderenciaJanelaEntrega, RiscoResumo, PedidosResumo, OpcoesConflitantesResumo) VALUES(@OpcaoId, @GrupoDecisaoId, @Peso, @Volume, @CustoEstimado, @AderenciaCubagem, @AderenciaJanelaEntrega, @RiscoResumo, @PedidosResumo, @OpcoesConflitantesResumo) ";
            this.Parameters = new
            {
                OpcaoId = OpcaoPlanejamentoTransporte.OpcaoId,
                GrupoDecisaoId = OpcaoPlanejamentoTransporte.GrupoDecisaoId,
                Peso = OpcaoPlanejamentoTransporte.Peso,
                Volume = OpcaoPlanejamentoTransporte.Volume,
                CustoEstimado = OpcaoPlanejamentoTransporte.CustoEstimado,
                AderenciaCubagem = OpcaoPlanejamentoTransporte.AderenciaCubagem,
                AderenciaJanelaEntrega = OpcaoPlanejamentoTransporte.AderenciaJanelaEntrega,
                RiscoResumo = OpcaoPlanejamentoTransporte.RiscoResumo,
                PedidosResumo = OpcaoPlanejamentoTransporte.PedidosResumo,
                OpcoesConflitantesResumo = OpcaoPlanejamentoTransporte.OpcoesConflitantesResumo,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOpcaoPlanejamentoTransporteQuery(IOpcaoPlanejamentoTransporteEntity OpcaoPlanejamentoTransporte)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET GrupoDecisaoId = @GrupoDecisaoId, Peso = @Peso, Volume = @Volume, CustoEstimado = @CustoEstimado, AderenciaCubagem = @AderenciaCubagem, AderenciaJanelaEntrega = @AderenciaJanelaEntrega, RiscoResumo = @RiscoResumo, PedidosResumo = @PedidosResumo, OpcoesConflitantesResumo = @OpcoesConflitantesResumo WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                GrupoDecisaoId = OpcaoPlanejamentoTransporte.GrupoDecisaoId,
                Peso = OpcaoPlanejamentoTransporte.Peso,
                Volume = OpcaoPlanejamentoTransporte.Volume,
                CustoEstimado = OpcaoPlanejamentoTransporte.CustoEstimado,
                AderenciaCubagem = OpcaoPlanejamentoTransporte.AderenciaCubagem,
                AderenciaJanelaEntrega = OpcaoPlanejamentoTransporte.AderenciaJanelaEntrega,
                RiscoResumo = OpcaoPlanejamentoTransporte.RiscoResumo,
                PedidosResumo = OpcaoPlanejamentoTransporte.PedidosResumo,
                OpcoesConflitantesResumo = OpcaoPlanejamentoTransporte.OpcoesConflitantesResumo,
                OpcaoId = OpcaoPlanejamentoTransporte.OpcaoId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoDecisaoId(string opcaoid, string value)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET GrupoDecisaoId = @GrupoDecisaoId WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                GrupoDecisaoId = value,
                OpcaoId = opcaoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePeso(string opcaoid, Decimal value)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET Peso = @Peso WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                Peso = value,
                OpcaoId = opcaoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVolume(string opcaoid, Decimal value)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET Volume = @Volume WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                Volume = value,
                OpcaoId = opcaoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCustoEstimado(string opcaoid, Decimal value)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET CustoEstimado = @CustoEstimado WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                CustoEstimado = value,
                OpcaoId = opcaoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAderenciaCubagem(string opcaoid, Decimal value)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET AderenciaCubagem = @AderenciaCubagem WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                AderenciaCubagem = value,
                OpcaoId = opcaoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAderenciaJanelaEntrega(string opcaoid, Decimal value)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET AderenciaJanelaEntrega = @AderenciaJanelaEntrega WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                AderenciaJanelaEntrega = value,
                OpcaoId = opcaoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRiscoResumo(string opcaoid, string value)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET RiscoResumo = @RiscoResumo WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                RiscoResumo = value,
                OpcaoId = opcaoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePedidosResumo(string opcaoid, string value)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET PedidosResumo = @PedidosResumo WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                PedidosResumo = value,
                OpcaoId = opcaoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOpcoesConflitantesResumo(string opcaoid, string value)
        {
            this.Query = $@" UPDATE OpcaoPlanejamentoTransporte SET OpcoesConflitantesResumo = @OpcoesConflitantesResumo WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                OpcoesConflitantesResumo = value,
                OpcaoId = opcaoid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteOpcaoPlanejamentoTransporteQuery(IOpcaoPlanejamentoTransporteEntity OpcaoPlanejamentoTransporte)
        {
            this.Query = $@" DELETE FROM OpcaoPlanejamentoTransporte WHERE OpcaoId = @OpcaoId ";
            this.Parameters = new
            {
                OpcaoId = OpcaoPlanejamentoTransporte.OpcaoId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration