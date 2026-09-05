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
    public class T_MetasQueryWrite : QueryBase, IT_MetasQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_MetasQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_MetasQuery(IT_MetasEntity T_Metas)
        {
            this.Query = $@" INSERT INTO [T_Metas] ([MET_DTINICIO], [MET_DTFIM], [MET_ALVO], [MET_TIPOALVO], [IND_ID], [MET_RANGE01], [MET_RANGE02], [MET_RANGE03], [DIM_ID], [FAT_ID], [DIM_SUBDIMENSAO_ID], [PER_ID], [DOM_EMPRESA], [DOM_FILIAL], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[MET_ID] VALUES(@MET_DTINICIO, @MET_DTFIM, @MET_ALVO, @MET_TIPOALVO, @IND_ID, @MET_RANGE01, @MET_RANGE02, @MET_RANGE03, @DIM_ID, @FAT_ID, @DIM_SUBDIMENSAO_ID, @PER_ID, @DOM_EMPRESA, @DOM_FILIAL, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MET_DTINICIO = T_Metas.MET_DTINICIO,
                MET_DTFIM = T_Metas.MET_DTFIM,
                MET_ALVO = T_Metas.MET_ALVO,
                MET_TIPOALVO = T_Metas.MET_TIPOALVO,
                IND_ID = T_Metas.IND_ID,
                MET_RANGE01 = T_Metas.MET_RANGE01,
                MET_RANGE02 = T_Metas.MET_RANGE02,
                MET_RANGE03 = T_Metas.MET_RANGE03,
                DIM_ID = T_Metas.DIM_ID,
                FAT_ID = T_Metas.FAT_ID,
                DIM_SUBDIMENSAO_ID = T_Metas.DIM_SUBDIMENSAO_ID,
                PER_ID = T_Metas.PER_ID,
                DOM_EMPRESA = T_Metas.DOM_EMPRESA,
                DOM_FILIAL = T_Metas.DOM_FILIAL,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_MetasQuery(IT_MetasEntity T_Metas)
        {
            this.Query = $@" UPDATE [T_Metas] SET [MET_DTINICIO] = @MET_DTINICIO, [MET_DTFIM] = @MET_DTFIM, [MET_ALVO] = @MET_ALVO, [MET_TIPOALVO] = @MET_TIPOALVO, [IND_ID] = @IND_ID, [MET_RANGE01] = @MET_RANGE01, [MET_RANGE02] = @MET_RANGE02, [MET_RANGE03] = @MET_RANGE03, [DIM_ID] = @DIM_ID, [FAT_ID] = @FAT_ID, [DIM_SUBDIMENSAO_ID] = @DIM_SUBDIMENSAO_ID, [PER_ID] = @PER_ID, [DOM_EMPRESA] = @DOM_EMPRESA, [DOM_FILIAL] = @DOM_FILIAL, [Changed] = @Changed, [UserId] = @UserId WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                MET_DTINICIO = T_Metas.MET_DTINICIO,
                MET_DTFIM = T_Metas.MET_DTFIM,
                MET_ALVO = T_Metas.MET_ALVO,
                MET_TIPOALVO = T_Metas.MET_TIPOALVO,
                IND_ID = T_Metas.IND_ID,
                MET_RANGE01 = T_Metas.MET_RANGE01,
                MET_RANGE02 = T_Metas.MET_RANGE02,
                MET_RANGE03 = T_Metas.MET_RANGE03,
                DIM_ID = T_Metas.DIM_ID,
                FAT_ID = T_Metas.FAT_ID,
                DIM_SUBDIMENSAO_ID = T_Metas.DIM_SUBDIMENSAO_ID,
                PER_ID = T_Metas.PER_ID,
                DOM_EMPRESA = T_Metas.DOM_EMPRESA,
                DOM_FILIAL = T_Metas.DOM_FILIAL,
                Changed = T_Metas.Changed,
                UserId = _executionContext.UserId,
                MET_ID = T_Metas.MET_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_DTINICIO(int met_id, string value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [MET_DTINICIO] = @MET_DTINICIO WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                MET_DTINICIO = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_DTFIM(int met_id, string value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [MET_DTFIM] = @MET_DTFIM WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                MET_DTFIM = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_ALVO(int met_id, string value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [MET_ALVO] = @MET_ALVO WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                MET_ALVO = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_TIPOALVO(int met_id, int value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [MET_TIPOALVO] = @MET_TIPOALVO WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                MET_TIPOALVO = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_ID(int met_id, int value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [IND_ID] = @IND_ID WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                IND_ID = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_RANGE01(int met_id, Decimal value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [MET_RANGE01] = @MET_RANGE01 WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                MET_RANGE01 = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_RANGE02(int met_id, Decimal value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [MET_RANGE02] = @MET_RANGE02 WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                MET_RANGE02 = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_RANGE03(int met_id, Decimal value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [MET_RANGE03] = @MET_RANGE03 WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                MET_RANGE03 = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_ID(int met_id, int value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [DIM_ID] = @DIM_ID WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                DIM_ID = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFAT_ID(int met_id, string value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [FAT_ID] = @FAT_ID WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                FAT_ID = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_SUBDIMENSAO_ID(int met_id, string value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [DIM_SUBDIMENSAO_ID] = @DIM_SUBDIMENSAO_ID WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                DIM_SUBDIMENSAO_ID = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_ID(int met_id, string value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [PER_ID] = @PER_ID WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                PER_ID = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDOM_EMPRESA(int met_id, string value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [DOM_EMPRESA] = @DOM_EMPRESA WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                DOM_EMPRESA = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDOM_FILIAL(int met_id, string value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [DOM_FILIAL] = @DOM_FILIAL WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                DOM_FILIAL = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int met_id, int value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [TenantID] = @TenantID WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                TenantID = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int met_id, bool value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [Deleted] = @Deleted WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                Deleted = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int met_id, DateTime value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [Changed] = @Changed WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                Changed = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int met_id, int value)
        {
            this.Query = $@" UPDATE [T_Metas] SET [UserId] = @UserId WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                UserId = value,
                MET_ID = met_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_MetasQuery(IT_MetasEntity T_Metas)
        {
            this.Query = $@" DELETE FROM [T_Metas] WHERE [MET_ID] = @MET_ID ";
            this.Parameters = new
            {
                MET_ID = T_Metas.MET_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration