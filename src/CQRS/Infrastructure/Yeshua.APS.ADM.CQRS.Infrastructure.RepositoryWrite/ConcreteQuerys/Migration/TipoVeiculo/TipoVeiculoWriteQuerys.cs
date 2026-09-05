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
    public class TipoVeiculoQueryWrite : QueryBase, ITipoVeiculoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoVeiculoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoVeiculoQuery(ITipoVeiculoEntity TipoVeiculo)
        {
            this.Query = $@" INSERT INTO [TipoVeiculo] ([TIP_ID], [TIP_DESCRICAO], [TIP_QTD_DISPONIVEL], [TIP_VALOR_KM], [TIP_VALOR_DIARIA], [TIP_VALOR_AJUDANTE], [TIP_QTD_EIXOS], [TIP_VELOCIDADE_MEDIA], [TIP_CAPACIDADE_ALTURA], [TIP_CAPACIDADE_COMPRIMENTO], [TIP_CAPACIDADE_LARGURA], [TIP_CAPACIDADE_ALTURA_PESCOCO_E], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E], [TIP_CAPACIDADE_LARGURA_PESCOCO_E], [TIP_CAPACIDADE_ALTURA_PESCOCO_D], [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D], [TIP_CAPACIDADE_LARGURA_PESCOCO_D], [TIP_CAPACIDADE_M3], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@TIP_ID, @TIP_DESCRICAO, @TIP_QTD_DISPONIVEL, @TIP_VALOR_KM, @TIP_VALOR_DIARIA, @TIP_VALOR_AJUDANTE, @TIP_QTD_EIXOS, @TIP_VELOCIDADE_MEDIA, @TIP_CAPACIDADE_ALTURA, @TIP_CAPACIDADE_COMPRIMENTO, @TIP_CAPACIDADE_LARGURA, @TIP_CAPACIDADE_ALTURA_PESCOCO_E, @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E, @TIP_CAPACIDADE_LARGURA_PESCOCO_E, @TIP_CAPACIDADE_ALTURA_PESCOCO_D, @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D, @TIP_CAPACIDADE_LARGURA_PESCOCO_D, @TIP_CAPACIDADE_M3, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TIP_ID = TipoVeiculo.TIP_ID,
                TIP_DESCRICAO = TipoVeiculo.TIP_DESCRICAO,
                TIP_QTD_DISPONIVEL = TipoVeiculo.TIP_QTD_DISPONIVEL,
                TIP_VALOR_KM = TipoVeiculo.TIP_VALOR_KM,
                TIP_VALOR_DIARIA = TipoVeiculo.TIP_VALOR_DIARIA,
                TIP_VALOR_AJUDANTE = TipoVeiculo.TIP_VALOR_AJUDANTE,
                TIP_QTD_EIXOS = TipoVeiculo.TIP_QTD_EIXOS,
                TIP_VELOCIDADE_MEDIA = TipoVeiculo.TIP_VELOCIDADE_MEDIA,
                TIP_CAPACIDADE_ALTURA = TipoVeiculo.TIP_CAPACIDADE_ALTURA,
                TIP_CAPACIDADE_COMPRIMENTO = TipoVeiculo.TIP_CAPACIDADE_COMPRIMENTO,
                TIP_CAPACIDADE_LARGURA = TipoVeiculo.TIP_CAPACIDADE_LARGURA,
                TIP_CAPACIDADE_ALTURA_PESCOCO_E = TipoVeiculo.TIP_CAPACIDADE_ALTURA_PESCOCO_E,
                TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E = TipoVeiculo.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E,
                TIP_CAPACIDADE_LARGURA_PESCOCO_E = TipoVeiculo.TIP_CAPACIDADE_LARGURA_PESCOCO_E,
                TIP_CAPACIDADE_ALTURA_PESCOCO_D = TipoVeiculo.TIP_CAPACIDADE_ALTURA_PESCOCO_D,
                TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D = TipoVeiculo.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D,
                TIP_CAPACIDADE_LARGURA_PESCOCO_D = TipoVeiculo.TIP_CAPACIDADE_LARGURA_PESCOCO_D,
                TIP_CAPACIDADE_M3 = TipoVeiculo.TIP_CAPACIDADE_M3,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoVeiculoQuery(ITipoVeiculoEntity TipoVeiculo)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_ID] = @TIP_ID, [TIP_DESCRICAO] = @TIP_DESCRICAO, [TIP_QTD_DISPONIVEL] = @TIP_QTD_DISPONIVEL, [TIP_VALOR_KM] = @TIP_VALOR_KM, [TIP_VALOR_DIARIA] = @TIP_VALOR_DIARIA, [TIP_VALOR_AJUDANTE] = @TIP_VALOR_AJUDANTE, [TIP_QTD_EIXOS] = @TIP_QTD_EIXOS, [TIP_VELOCIDADE_MEDIA] = @TIP_VELOCIDADE_MEDIA, [TIP_CAPACIDADE_ALTURA] = @TIP_CAPACIDADE_ALTURA, [TIP_CAPACIDADE_COMPRIMENTO] = @TIP_CAPACIDADE_COMPRIMENTO, [TIP_CAPACIDADE_LARGURA] = @TIP_CAPACIDADE_LARGURA, [TIP_CAPACIDADE_ALTURA_PESCOCO_E] = @TIP_CAPACIDADE_ALTURA_PESCOCO_E, [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E] = @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E, [TIP_CAPACIDADE_LARGURA_PESCOCO_E] = @TIP_CAPACIDADE_LARGURA_PESCOCO_E, [TIP_CAPACIDADE_ALTURA_PESCOCO_D] = @TIP_CAPACIDADE_ALTURA_PESCOCO_D, [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D] = @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D, [TIP_CAPACIDADE_LARGURA_PESCOCO_D] = @TIP_CAPACIDADE_LARGURA_PESCOCO_D, [TIP_CAPACIDADE_M3] = @TIP_CAPACIDADE_M3, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_ID = TipoVeiculo.TIP_ID,
                TIP_DESCRICAO = TipoVeiculo.TIP_DESCRICAO,
                TIP_QTD_DISPONIVEL = TipoVeiculo.TIP_QTD_DISPONIVEL,
                TIP_VALOR_KM = TipoVeiculo.TIP_VALOR_KM,
                TIP_VALOR_DIARIA = TipoVeiculo.TIP_VALOR_DIARIA,
                TIP_VALOR_AJUDANTE = TipoVeiculo.TIP_VALOR_AJUDANTE,
                TIP_QTD_EIXOS = TipoVeiculo.TIP_QTD_EIXOS,
                TIP_VELOCIDADE_MEDIA = TipoVeiculo.TIP_VELOCIDADE_MEDIA,
                TIP_CAPACIDADE_ALTURA = TipoVeiculo.TIP_CAPACIDADE_ALTURA,
                TIP_CAPACIDADE_COMPRIMENTO = TipoVeiculo.TIP_CAPACIDADE_COMPRIMENTO,
                TIP_CAPACIDADE_LARGURA = TipoVeiculo.TIP_CAPACIDADE_LARGURA,
                TIP_CAPACIDADE_ALTURA_PESCOCO_E = TipoVeiculo.TIP_CAPACIDADE_ALTURA_PESCOCO_E,
                TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E = TipoVeiculo.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E,
                TIP_CAPACIDADE_LARGURA_PESCOCO_E = TipoVeiculo.TIP_CAPACIDADE_LARGURA_PESCOCO_E,
                TIP_CAPACIDADE_ALTURA_PESCOCO_D = TipoVeiculo.TIP_CAPACIDADE_ALTURA_PESCOCO_D,
                TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D = TipoVeiculo.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D,
                TIP_CAPACIDADE_LARGURA_PESCOCO_D = TipoVeiculo.TIP_CAPACIDADE_LARGURA_PESCOCO_D,
                TIP_CAPACIDADE_M3 = TipoVeiculo.TIP_CAPACIDADE_M3,
                Changed = TipoVeiculo.Changed,
                UserId = _executionContext.UserId,
                Id = TipoVeiculo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_ID(int id, int value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_ID] = @TIP_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_DESCRICAO] = @TIP_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_QTD_DISPONIVEL(int id, int value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_QTD_DISPONIVEL] = @TIP_QTD_DISPONIVEL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_QTD_DISPONIVEL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_VALOR_KM(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_VALOR_KM] = @TIP_VALOR_KM WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_VALOR_KM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_VALOR_DIARIA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_VALOR_DIARIA] = @TIP_VALOR_DIARIA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_VALOR_DIARIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_VALOR_AJUDANTE(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_VALOR_AJUDANTE] = @TIP_VALOR_AJUDANTE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_VALOR_AJUDANTE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_QTD_EIXOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_QTD_EIXOS] = @TIP_QTD_EIXOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_QTD_EIXOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_VELOCIDADE_MEDIA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_VELOCIDADE_MEDIA] = @TIP_VELOCIDADE_MEDIA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_VELOCIDADE_MEDIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_ALTURA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_ALTURA] = @TIP_CAPACIDADE_ALTURA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_ALTURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_COMPRIMENTO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_COMPRIMENTO] = @TIP_CAPACIDADE_COMPRIMENTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_COMPRIMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_LARGURA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_LARGURA] = @TIP_CAPACIDADE_LARGURA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_LARGURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_E(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_ALTURA_PESCOCO_E] = @TIP_CAPACIDADE_ALTURA_PESCOCO_E WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_ALTURA_PESCOCO_E = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E] = @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_E(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_LARGURA_PESCOCO_E] = @TIP_CAPACIDADE_LARGURA_PESCOCO_E WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_LARGURA_PESCOCO_E = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_D(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_ALTURA_PESCOCO_D] = @TIP_CAPACIDADE_ALTURA_PESCOCO_D WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_ALTURA_PESCOCO_D = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D] = @TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_D(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_LARGURA_PESCOCO_D] = @TIP_CAPACIDADE_LARGURA_PESCOCO_D WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_LARGURA_PESCOCO_D = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_CAPACIDADE_M3(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TIP_CAPACIDADE_M3] = @TIP_CAPACIDADE_M3 WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_CAPACIDADE_M3 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [TipoVeiculo] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoVeiculoQuery(ITipoVeiculoEntity TipoVeiculo)
        {
            this.Query = $@" DELETE FROM [TipoVeiculo] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = TipoVeiculo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration