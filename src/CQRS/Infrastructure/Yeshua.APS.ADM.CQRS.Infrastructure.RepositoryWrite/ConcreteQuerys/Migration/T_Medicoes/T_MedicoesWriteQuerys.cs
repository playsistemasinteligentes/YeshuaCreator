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
    public class T_MedicoesQueryWrite : QueryBase, IT_MedicoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_MedicoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_MedicoesQuery(IT_MedicoesEntity T_Medicoes)
        {
            this.Query = $@" INSERT INTO T_Medicoes (IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@IND_ID, @MET_ID, @UNI_ID, @MED_DATA, @MED_VALOR, @MED_AC_ANO, @MED_DATAMEDICAO, @MED_PONDERACAO, @DIM_ID, @DIM_DESCRICAO, @DIM_SUBDIMENSAO_ID, @DIM_SUB_DESCRICAO, @PER_ID, @PER_DESCRICAO, @FAT_ID, @FAT_DESCRICAO, @MED_SQL, @DOM_EMPRESA, @DOM_FILIAL, @MED_VALOR_DISPER, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                IND_ID = T_Medicoes.IND_ID,
                MET_ID = T_Medicoes.MET_ID,
                UNI_ID = T_Medicoes.UNI_ID,
                MED_DATA = T_Medicoes.MED_DATA,
                MED_VALOR = T_Medicoes.MED_VALOR,
                MED_AC_ANO = T_Medicoes.MED_AC_ANO,
                MED_DATAMEDICAO = T_Medicoes.MED_DATAMEDICAO,
                MED_PONDERACAO = T_Medicoes.MED_PONDERACAO,
                DIM_ID = T_Medicoes.DIM_ID,
                DIM_DESCRICAO = T_Medicoes.DIM_DESCRICAO,
                DIM_SUBDIMENSAO_ID = T_Medicoes.DIM_SUBDIMENSAO_ID,
                DIM_SUB_DESCRICAO = T_Medicoes.DIM_SUB_DESCRICAO,
                PER_ID = T_Medicoes.PER_ID,
                PER_DESCRICAO = T_Medicoes.PER_DESCRICAO,
                FAT_ID = T_Medicoes.FAT_ID,
                FAT_DESCRICAO = T_Medicoes.FAT_DESCRICAO,
                MED_SQL = T_Medicoes.MED_SQL,
                DOM_EMPRESA = T_Medicoes.DOM_EMPRESA,
                DOM_FILIAL = T_Medicoes.DOM_FILIAL,
                MED_VALOR_DISPER = T_Medicoes.MED_VALOR_DISPER,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_MedicoesQuery(IT_MedicoesEntity T_Medicoes)
        {
            this.Query = $@" UPDATE T_Medicoes SET MED_ID = @MED_ID, IND_ID = @IND_ID, MET_ID = @MET_ID, UNI_ID = @UNI_ID, MED_DATA = @MED_DATA, MED_VALOR = @MED_VALOR, MED_AC_ANO = @MED_AC_ANO, MED_DATAMEDICAO = @MED_DATAMEDICAO, MED_PONDERACAO = @MED_PONDERACAO, DIM_ID = @DIM_ID, DIM_DESCRICAO = @DIM_DESCRICAO, DIM_SUBDIMENSAO_ID = @DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO = @DIM_SUB_DESCRICAO, PER_ID = @PER_ID, PER_DESCRICAO = @PER_DESCRICAO, FAT_ID = @FAT_ID, FAT_DESCRICAO = @FAT_DESCRICAO, MED_SQL = @MED_SQL, DOM_EMPRESA = @DOM_EMPRESA, DOM_FILIAL = @DOM_FILIAL, MED_VALOR_DISPER = @MED_VALOR_DISPER, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                MED_ID = T_Medicoes.MED_ID,
                IND_ID = T_Medicoes.IND_ID,
                MET_ID = T_Medicoes.MET_ID,
                UNI_ID = T_Medicoes.UNI_ID,
                MED_DATA = T_Medicoes.MED_DATA,
                MED_VALOR = T_Medicoes.MED_VALOR,
                MED_AC_ANO = T_Medicoes.MED_AC_ANO,
                MED_DATAMEDICAO = T_Medicoes.MED_DATAMEDICAO,
                MED_PONDERACAO = T_Medicoes.MED_PONDERACAO,
                DIM_ID = T_Medicoes.DIM_ID,
                DIM_DESCRICAO = T_Medicoes.DIM_DESCRICAO,
                DIM_SUBDIMENSAO_ID = T_Medicoes.DIM_SUBDIMENSAO_ID,
                DIM_SUB_DESCRICAO = T_Medicoes.DIM_SUB_DESCRICAO,
                PER_ID = T_Medicoes.PER_ID,
                PER_DESCRICAO = T_Medicoes.PER_DESCRICAO,
                FAT_ID = T_Medicoes.FAT_ID,
                FAT_DESCRICAO = T_Medicoes.FAT_DESCRICAO,
                MED_SQL = T_Medicoes.MED_SQL,
                DOM_EMPRESA = T_Medicoes.DOM_EMPRESA,
                DOM_FILIAL = T_Medicoes.DOM_FILIAL,
                MED_VALOR_DISPER = T_Medicoes.MED_VALOR_DISPER,
                Changed = T_Medicoes.Changed,
                UserId = _executionContext.UserId,
                Id = T_Medicoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMED_ID(int id, int value)
        {
            this.Query = $@" UPDATE T_Medicoes SET MED_ID = @MED_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                MED_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_ID(int id, int value)
        {
            this.Query = $@" UPDATE T_Medicoes SET IND_ID = @IND_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                IND_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_ID(int id, int value)
        {
            this.Query = $@" UPDATE T_Medicoes SET MET_ID = @MET_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                MET_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_ID(int id, int value)
        {
            this.Query = $@" UPDATE T_Medicoes SET UNI_ID = @UNI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                UNI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMED_DATA(int id, DateTime value)
        {
            this.Query = $@" UPDATE T_Medicoes SET MED_DATA = @MED_DATA WHERE Id = @Id ";
            this.Parameters = new
            {
                MED_DATA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMED_VALOR(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET MED_VALOR = @MED_VALOR WHERE Id = @Id ";
            this.Parameters = new
            {
                MED_VALOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMED_AC_ANO(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET MED_AC_ANO = @MED_AC_ANO WHERE Id = @Id ";
            this.Parameters = new
            {
                MED_AC_ANO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMED_DATAMEDICAO(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET MED_DATAMEDICAO = @MED_DATAMEDICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MED_DATAMEDICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMED_PONDERACAO(int id, Decimal value)
        {
            this.Query = $@" UPDATE T_Medicoes SET MED_PONDERACAO = @MED_PONDERACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MED_PONDERACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_ID(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET DIM_ID = @DIM_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                DIM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET DIM_DESCRICAO = @DIM_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                DIM_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_SUBDIMENSAO_ID(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET DIM_SUBDIMENSAO_ID = @DIM_SUBDIMENSAO_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                DIM_SUBDIMENSAO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_SUB_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET DIM_SUB_DESCRICAO = @DIM_SUB_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                DIM_SUB_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_ID(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET PER_ID = @PER_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET PER_DESCRICAO = @PER_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PER_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFAT_ID(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET FAT_ID = @FAT_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                FAT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFAT_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET FAT_DESCRICAO = @FAT_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FAT_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMED_SQL(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET MED_SQL = @MED_SQL WHERE Id = @Id ";
            this.Parameters = new
            {
                MED_SQL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDOM_EMPRESA(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET DOM_EMPRESA = @DOM_EMPRESA WHERE Id = @Id ";
            this.Parameters = new
            {
                DOM_EMPRESA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDOM_FILIAL(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET DOM_FILIAL = @DOM_FILIAL WHERE Id = @Id ";
            this.Parameters = new
            {
                DOM_FILIAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMED_VALOR_DISPER(int id, string value)
        {
            this.Query = $@" UPDATE T_Medicoes SET MED_VALOR_DISPER = @MED_VALOR_DISPER WHERE Id = @Id ";
            this.Parameters = new
            {
                MED_VALOR_DISPER = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE T_Medicoes SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE T_Medicoes SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE T_Medicoes SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE T_Medicoes SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_MedicoesQuery(IT_MedicoesEntity T_Medicoes)
        {
            this.Query = $@" DELETE FROM T_Medicoes WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = T_Medicoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration