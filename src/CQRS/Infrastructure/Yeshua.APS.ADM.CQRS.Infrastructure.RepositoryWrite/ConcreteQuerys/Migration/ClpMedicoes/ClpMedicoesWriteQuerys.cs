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
    public class ClpMedicoesQueryWrite : QueryBase, IClpMedicoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ClpMedicoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirClpMedicoesQuery(IClpMedicoesEntity ClpMedicoes)
        {
            this.Query = $@" INSERT INTO ClpMedicoes (Id2, MaquinaId, DataInicio, DataFim, Emissao, Quantidade, Grupo, Status, TurnoId, TurmaId, IdLoteClp, OcorrenciaId, Fase, ClpOrigem, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Id2, @MaquinaId, @DataInicio, @DataFim, @Emissao, @Quantidade, @Grupo, @Status, @TurnoId, @TurmaId, @IdLoteClp, @OcorrenciaId, @Fase, @ClpOrigem, @CLP_LOTE, @COMPACTA, @BOL_ID, @COR_SEQUENCIA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id2 = ClpMedicoes.Id2,
                MaquinaId = ClpMedicoes.MaquinaId,
                DataInicio = ClpMedicoes.DataInicio,
                DataFim = ClpMedicoes.DataFim,
                Emissao = ClpMedicoes.Emissao,
                Quantidade = ClpMedicoes.Quantidade,
                Grupo = ClpMedicoes.Grupo,
                Status = ClpMedicoes.Status,
                TurnoId = ClpMedicoes.TurnoId,
                TurmaId = ClpMedicoes.TurmaId,
                IdLoteClp = ClpMedicoes.IdLoteClp,
                OcorrenciaId = ClpMedicoes.OcorrenciaId,
                Fase = ClpMedicoes.Fase,
                ClpOrigem = ClpMedicoes.ClpOrigem,
                CLP_LOTE = ClpMedicoes.CLP_LOTE,
                COMPACTA = ClpMedicoes.COMPACTA,
                BOL_ID = ClpMedicoes.BOL_ID,
                COR_SEQUENCIA = ClpMedicoes.COR_SEQUENCIA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClpMedicoesQuery(IClpMedicoesEntity ClpMedicoes)
        {
            this.Query = $@" UPDATE ClpMedicoes SET Id2 = @Id2, MaquinaId = @MaquinaId, DataInicio = @DataInicio, DataFim = @DataFim, Emissao = @Emissao, Quantidade = @Quantidade, Grupo = @Grupo, Status = @Status, TurnoId = @TurnoId, TurmaId = @TurmaId, IdLoteClp = @IdLoteClp, OcorrenciaId = @OcorrenciaId, Fase = @Fase, ClpOrigem = @ClpOrigem, CLP_LOTE = @CLP_LOTE, COMPACTA = @COMPACTA, BOL_ID = @BOL_ID, COR_SEQUENCIA = @COR_SEQUENCIA, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Id2 = ClpMedicoes.Id2,
                MaquinaId = ClpMedicoes.MaquinaId,
                DataInicio = ClpMedicoes.DataInicio,
                DataFim = ClpMedicoes.DataFim,
                Emissao = ClpMedicoes.Emissao,
                Quantidade = ClpMedicoes.Quantidade,
                Grupo = ClpMedicoes.Grupo,
                Status = ClpMedicoes.Status,
                TurnoId = ClpMedicoes.TurnoId,
                TurmaId = ClpMedicoes.TurmaId,
                IdLoteClp = ClpMedicoes.IdLoteClp,
                OcorrenciaId = ClpMedicoes.OcorrenciaId,
                Fase = ClpMedicoes.Fase,
                ClpOrigem = ClpMedicoes.ClpOrigem,
                CLP_LOTE = ClpMedicoes.CLP_LOTE,
                COMPACTA = ClpMedicoes.COMPACTA,
                BOL_ID = ClpMedicoes.BOL_ID,
                COR_SEQUENCIA = ClpMedicoes.COR_SEQUENCIA,
                Changed = ClpMedicoes.Changed,
                UserId = _executionContext.UserId,
                Id = ClpMedicoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateId2(int id, int value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET Id2 = @Id2 WHERE Id = @Id ";
            this.Parameters = new
            {
                Id2 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMaquinaId(int id, string value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET MaquinaId = @MaquinaId WHERE Id = @Id ";
            this.Parameters = new
            {
                MaquinaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataInicio(int id, DateTime value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET DataInicio = @DataInicio WHERE Id = @Id ";
            this.Parameters = new
            {
                DataInicio = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataFim(int id, DateTime value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET DataFim = @DataFim WHERE Id = @Id ";
            this.Parameters = new
            {
                DataFim = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmissao(int id, DateTime value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET Emissao = @Emissao WHERE Id = @Id ";
            this.Parameters = new
            {
                Emissao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidade(int id, Decimal value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET Quantidade = @Quantidade WHERE Id = @Id ";
            this.Parameters = new
            {
                Quantidade = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupo(int id, Decimal value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET Grupo = @Grupo WHERE Id = @Id ";
            this.Parameters = new
            {
                Grupo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTurnoId(int id, string value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET TurnoId = @TurnoId WHERE Id = @Id ";
            this.Parameters = new
            {
                TurnoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTurmaId(int id, string value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET TurmaId = @TurmaId WHERE Id = @Id ";
            this.Parameters = new
            {
                TurmaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIdLoteClp(int id, int value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET IdLoteClp = @IdLoteClp WHERE Id = @Id ";
            this.Parameters = new
            {
                IdLoteClp = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOcorrenciaId(int id, string value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET OcorrenciaId = @OcorrenciaId WHERE Id = @Id ";
            this.Parameters = new
            {
                OcorrenciaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFase(int id, int value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET Fase = @Fase WHERE Id = @Id ";
            this.Parameters = new
            {
                Fase = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClpOrigem(int id, string value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET ClpOrigem = @ClpOrigem WHERE Id = @Id ";
            this.Parameters = new
            {
                ClpOrigem = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLP_LOTE(int id, int value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET CLP_LOTE = @CLP_LOTE WHERE Id = @Id ";
            this.Parameters = new
            {
                CLP_LOTE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOMPACTA(int id, int value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET COMPACTA = @COMPACTA WHERE Id = @Id ";
            this.Parameters = new
            {
                COMPACTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID(int id, string value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET BOL_ID = @BOL_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_SEQUENCIA(int id, int value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET COR_SEQUENCIA = @COR_SEQUENCIA WHERE Id = @Id ";
            this.Parameters = new
            {
                COR_SEQUENCIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE ClpMedicoes SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteClpMedicoesQuery(IClpMedicoesEntity ClpMedicoes)
        {
            this.Query = $@" DELETE FROM ClpMedicoes WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = ClpMedicoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration