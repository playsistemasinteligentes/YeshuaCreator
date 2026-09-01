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
    public class LaudoTesteFisicoQueryWrite : QueryBase, ILaudoTesteFisicoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public LaudoTesteFisicoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirLaudoTesteFisicoQuery(ILaudoTesteFisicoEntity LaudoTesteFisico)
        {
            this.Query = $@" INSERT INTO LaudoTesteFisico (LTF_ID, LTF_EMISSAO, LTF_VALOR, LTF_OBS, LTF_STATUS, ORD_ID, ROT_PRO_ID, FPR_SEQ_REPETICAO, USE_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@LTF_ID, @LTF_EMISSAO, @LTF_VALOR, @LTF_OBS, @LTF_STATUS, @ORD_ID, @ROT_PRO_ID, @FPR_SEQ_REPETICAO, @USE_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                LTF_ID = LaudoTesteFisico.LTF_ID,
                LTF_EMISSAO = LaudoTesteFisico.LTF_EMISSAO,
                LTF_VALOR = LaudoTesteFisico.LTF_VALOR,
                LTF_OBS = LaudoTesteFisico.LTF_OBS,
                LTF_STATUS = LaudoTesteFisico.LTF_STATUS,
                ORD_ID = LaudoTesteFisico.ORD_ID,
                ROT_PRO_ID = LaudoTesteFisico.ROT_PRO_ID,
                FPR_SEQ_REPETICAO = LaudoTesteFisico.FPR_SEQ_REPETICAO,
                USE_ID = LaudoTesteFisico.USE_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLaudoTesteFisicoQuery(ILaudoTesteFisicoEntity LaudoTesteFisico)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET LTF_ID = @LTF_ID, LTF_EMISSAO = @LTF_EMISSAO, LTF_VALOR = @LTF_VALOR, LTF_OBS = @LTF_OBS, LTF_STATUS = @LTF_STATUS, ORD_ID = @ORD_ID, ROT_PRO_ID = @ROT_PRO_ID, FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO, USE_ID = @USE_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                LTF_ID = LaudoTesteFisico.LTF_ID,
                LTF_EMISSAO = LaudoTesteFisico.LTF_EMISSAO,
                LTF_VALOR = LaudoTesteFisico.LTF_VALOR,
                LTF_OBS = LaudoTesteFisico.LTF_OBS,
                LTF_STATUS = LaudoTesteFisico.LTF_STATUS,
                ORD_ID = LaudoTesteFisico.ORD_ID,
                ROT_PRO_ID = LaudoTesteFisico.ROT_PRO_ID,
                FPR_SEQ_REPETICAO = LaudoTesteFisico.FPR_SEQ_REPETICAO,
                USE_ID = LaudoTesteFisico.USE_ID,
                Changed = LaudoTesteFisico.Changed,
                UserId = _executionContext.UserId,
                Id = LaudoTesteFisico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLTF_ID(int id, int value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET LTF_ID = @LTF_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                LTF_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLTF_EMISSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET LTF_EMISSAO = @LTF_EMISSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                LTF_EMISSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLTF_VALOR(int id, Decimal value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET LTF_VALOR = @LTF_VALOR WHERE Id = @Id ";
            this.Parameters = new
            {
                LTF_VALOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLTF_OBS(int id, string value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET LTF_OBS = @LTF_OBS WHERE Id = @Id ";
            this.Parameters = new
            {
                LTF_OBS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLTF_STATUS(int id, string value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET LTF_STATUS = @LTF_STATUS WHERE Id = @Id ";
            this.Parameters = new
            {
                LTF_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int id, string value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET ORD_ID = @ORD_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ORD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_PRO_ID(int id, string value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET ROT_PRO_ID = @ROT_PRO_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_PRO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_REPETICAO(int id, int value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_SEQ_REPETICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int id, int value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET USE_ID = @USE_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                USE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE LaudoTesteFisico SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteLaudoTesteFisicoQuery(ILaudoTesteFisicoEntity LaudoTesteFisico)
        {
            this.Query = $@" DELETE FROM LaudoTesteFisico WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = LaudoTesteFisico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration