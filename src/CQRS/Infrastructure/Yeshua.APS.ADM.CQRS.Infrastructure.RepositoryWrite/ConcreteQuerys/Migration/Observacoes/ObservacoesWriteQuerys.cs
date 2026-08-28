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
    public class ObservacoesQueryWrite : QueryBase, IObservacoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ObservacoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirObservacoesQuery(IObservacoesEntity Observacoes)
        {
            this.Query = $@" INSERT INTO Observacoes (OBS_TIPO, OBS_DESCRICAO, CLI_ID, MAQ_ID, PRO_ID, ROT_SEQ_TRANFORMACAO, OBS_INTEGRACAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.OBS_ID VALUES(@OBS_TIPO, @OBS_DESCRICAO, @CLI_ID, @MAQ_ID, @PRO_ID, @ROT_SEQ_TRANFORMACAO, @OBS_INTEGRACAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                OBS_TIPO = Observacoes.OBS_TIPO,
                OBS_DESCRICAO = Observacoes.OBS_DESCRICAO,
                CLI_ID = Observacoes.CLI_ID,
                MAQ_ID = Observacoes.MAQ_ID,
                PRO_ID = Observacoes.PRO_ID,
                ROT_SEQ_TRANFORMACAO = Observacoes.ROT_SEQ_TRANFORMACAO,
                OBS_INTEGRACAO = Observacoes.OBS_INTEGRACAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObservacoesQuery(IObservacoesEntity Observacoes)
        {
            this.Query = $@" UPDATE Observacoes SET OBS_TIPO = @OBS_TIPO, OBS_DESCRICAO = @OBS_DESCRICAO, CLI_ID = @CLI_ID, MAQ_ID = @MAQ_ID, PRO_ID = @PRO_ID, ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO, OBS_INTEGRACAO = @OBS_INTEGRACAO, Changed = @Changed, UserId = @UserId WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                OBS_TIPO = Observacoes.OBS_TIPO,
                OBS_DESCRICAO = Observacoes.OBS_DESCRICAO,
                CLI_ID = Observacoes.CLI_ID,
                MAQ_ID = Observacoes.MAQ_ID,
                PRO_ID = Observacoes.PRO_ID,
                ROT_SEQ_TRANFORMACAO = Observacoes.ROT_SEQ_TRANFORMACAO,
                OBS_INTEGRACAO = Observacoes.OBS_INTEGRACAO,
                Changed = Observacoes.Changed,
                UserId = _executionContext.UserId,
                OBS_ID = Observacoes.OBS_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOBS_TIPO(int obs_id, string value)
        {
            this.Query = $@" UPDATE Observacoes SET OBS_TIPO = @OBS_TIPO WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                OBS_TIPO = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOBS_DESCRICAO(int obs_id, string value)
        {
            this.Query = $@" UPDATE Observacoes SET OBS_DESCRICAO = @OBS_DESCRICAO WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                OBS_DESCRICAO = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ID(int obs_id, string value)
        {
            this.Query = $@" UPDATE Observacoes SET CLI_ID = @CLI_ID WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                CLI_ID = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int obs_id, string value)
        {
            this.Query = $@" UPDATE Observacoes SET MAQ_ID = @MAQ_ID WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                MAQ_ID = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int obs_id, string value)
        {
            this.Query = $@" UPDATE Observacoes SET PRO_ID = @PRO_ID WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                PRO_ID = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_SEQ_TRANFORMACAO(int obs_id, int value)
        {
            this.Query = $@" UPDATE Observacoes SET ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                ROT_SEQ_TRANFORMACAO = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOBS_INTEGRACAO(int obs_id, string value)
        {
            this.Query = $@" UPDATE Observacoes SET OBS_INTEGRACAO = @OBS_INTEGRACAO WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                OBS_INTEGRACAO = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int obs_id, int value)
        {
            this.Query = $@" UPDATE Observacoes SET TenantID = @TenantID WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                TenantID = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int obs_id, bool value)
        {
            this.Query = $@" UPDATE Observacoes SET Deleted = @Deleted WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                Deleted = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int obs_id, DateTime value)
        {
            this.Query = $@" UPDATE Observacoes SET Changed = @Changed WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                Changed = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int obs_id, int value)
        {
            this.Query = $@" UPDATE Observacoes SET UserId = @UserId WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                UserId = value,
                OBS_ID = obs_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteObservacoesQuery(IObservacoesEntity Observacoes)
        {
            this.Query = $@" DELETE FROM Observacoes WHERE OBS_ID = @OBS_ID ";
            this.Parameters = new
            {
                OBS_ID = Observacoes.OBS_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration