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
    public class ExperienciaPlanejamentoTransporteQueryWrite : QueryBase, IExperienciaPlanejamentoTransporteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ExperienciaPlanejamentoTransporteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirExperienciaPlanejamentoTransporteQuery(IExperienciaPlanejamentoTransporteEntity ExperienciaPlanejamentoTransporte)
        {
            this.Query = $@" INSERT INTO ExperienciaPlanejamentoTransporte (Tipo, Referencia, PedidoId, ClienteId, Municipio, Regiao, RotaId, Peso, Volume, Observacao, CriadoEm, CriadoPor, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Tipo, @Referencia, @PedidoId, @ClienteId, @Municipio, @Regiao, @RotaId, @Peso, @Volume, @Observacao, @CriadoEm, @CriadoPor, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Tipo = ExperienciaPlanejamentoTransporte.Tipo,
                Referencia = ExperienciaPlanejamentoTransporte.Referencia,
                PedidoId = ExperienciaPlanejamentoTransporte.PedidoId,
                ClienteId = ExperienciaPlanejamentoTransporte.ClienteId,
                Municipio = ExperienciaPlanejamentoTransporte.Municipio,
                Regiao = ExperienciaPlanejamentoTransporte.Regiao,
                RotaId = ExperienciaPlanejamentoTransporte.RotaId,
                Peso = ExperienciaPlanejamentoTransporte.Peso,
                Volume = ExperienciaPlanejamentoTransporte.Volume,
                Observacao = ExperienciaPlanejamentoTransporte.Observacao,
                CriadoEm = ExperienciaPlanejamentoTransporte.CriadoEm,
                CriadoPor = ExperienciaPlanejamentoTransporte.CriadoPor,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateExperienciaPlanejamentoTransporteQuery(IExperienciaPlanejamentoTransporteEntity ExperienciaPlanejamentoTransporte)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Tipo = @Tipo, Referencia = @Referencia, PedidoId = @PedidoId, ClienteId = @ClienteId, Municipio = @Municipio, Regiao = @Regiao, RotaId = @RotaId, Peso = @Peso, Volume = @Volume, Observacao = @Observacao, CriadoEm = @CriadoEm, CriadoPor = @CriadoPor, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Tipo = ExperienciaPlanejamentoTransporte.Tipo,
                Referencia = ExperienciaPlanejamentoTransporte.Referencia,
                PedidoId = ExperienciaPlanejamentoTransporte.PedidoId,
                ClienteId = ExperienciaPlanejamentoTransporte.ClienteId,
                Municipio = ExperienciaPlanejamentoTransporte.Municipio,
                Regiao = ExperienciaPlanejamentoTransporte.Regiao,
                RotaId = ExperienciaPlanejamentoTransporte.RotaId,
                Peso = ExperienciaPlanejamentoTransporte.Peso,
                Volume = ExperienciaPlanejamentoTransporte.Volume,
                Observacao = ExperienciaPlanejamentoTransporte.Observacao,
                CriadoEm = ExperienciaPlanejamentoTransporte.CriadoEm,
                CriadoPor = ExperienciaPlanejamentoTransporte.CriadoPor,
                Changed = ExperienciaPlanejamentoTransporte.Changed,
                UserId = _executionContext.UserId,
                Id = ExperienciaPlanejamentoTransporte.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipo(int id, int value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Tipo = @Tipo WHERE Id = @Id ";
            this.Parameters = new
            {
                Tipo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateReferencia(int id, string value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Referencia = @Referencia WHERE Id = @Id ";
            this.Parameters = new
            {
                Referencia = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePedidoId(int id, string value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET PedidoId = @PedidoId WHERE Id = @Id ";
            this.Parameters = new
            {
                PedidoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClienteId(int id, string value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET ClienteId = @ClienteId WHERE Id = @Id ";
            this.Parameters = new
            {
                ClienteId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipio(int id, string value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Municipio = @Municipio WHERE Id = @Id ";
            this.Parameters = new
            {
                Municipio = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRegiao(int id, string value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Regiao = @Regiao WHERE Id = @Id ";
            this.Parameters = new
            {
                Regiao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRotaId(int id, string value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET RotaId = @RotaId WHERE Id = @Id ";
            this.Parameters = new
            {
                RotaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePeso(int id, Decimal value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Peso = @Peso WHERE Id = @Id ";
            this.Parameters = new
            {
                Peso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVolume(int id, Decimal value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Volume = @Volume WHERE Id = @Id ";
            this.Parameters = new
            {
                Volume = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObservacao(int id, string value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Observacao = @Observacao WHERE Id = @Id ";
            this.Parameters = new
            {
                Observacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCriadoEm(int id, DateTime value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET CriadoEm = @CriadoEm WHERE Id = @Id ";
            this.Parameters = new
            {
                CriadoEm = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCriadoPor(int id, string value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET CriadoPor = @CriadoPor WHERE Id = @Id ";
            this.Parameters = new
            {
                CriadoPor = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE ExperienciaPlanejamentoTransporte SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteExperienciaPlanejamentoTransporteQuery(IExperienciaPlanejamentoTransporteEntity ExperienciaPlanejamentoTransporte)
        {
            this.Query = $@" DELETE FROM ExperienciaPlanejamentoTransporte WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = ExperienciaPlanejamentoTransporte.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration