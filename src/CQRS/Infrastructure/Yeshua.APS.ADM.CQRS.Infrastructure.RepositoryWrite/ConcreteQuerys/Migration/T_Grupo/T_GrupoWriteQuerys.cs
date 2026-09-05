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
    public class T_GrupoQueryWrite : QueryBase, IT_GrupoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_GrupoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_GrupoQuery(IT_GrupoEntity T_Grupo)
        {
            this.Query = $@" INSERT INTO [T_Grupo] ([NOME], [EXIBELISTA], [GRU_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[GRU_ID] VALUES(@NOME, @EXIBELISTA, @GRU_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                NOME = T_Grupo.NOME,
                EXIBELISTA = T_Grupo.EXIBELISTA,
                GRU_DESCRICAO = T_Grupo.GRU_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_GrupoQuery(IT_GrupoEntity T_Grupo)
        {
            this.Query = $@" UPDATE [T_Grupo] SET [NOME] = @NOME, [EXIBELISTA] = @EXIBELISTA, [GRU_DESCRICAO] = @GRU_DESCRICAO, [Changed] = @Changed, [UserId] = @UserId WHERE [GRU_ID] = @GRU_ID ";
            this.Parameters = new
            {
                NOME = T_Grupo.NOME,
                EXIBELISTA = T_Grupo.EXIBELISTA,
                GRU_DESCRICAO = T_Grupo.GRU_DESCRICAO,
                Changed = T_Grupo.Changed,
                UserId = _executionContext.UserId,
                GRU_ID = T_Grupo.GRU_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNOME(int gru_id, string value)
        {
            this.Query = $@" UPDATE [T_Grupo] SET [NOME] = @NOME WHERE [GRU_ID] = @GRU_ID ";
            this.Parameters = new
            {
                NOME = value,
                GRU_ID = gru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEXIBELISTA(int gru_id, int value)
        {
            this.Query = $@" UPDATE [T_Grupo] SET [EXIBELISTA] = @EXIBELISTA WHERE [GRU_ID] = @GRU_ID ";
            this.Parameters = new
            {
                EXIBELISTA = value,
                GRU_ID = gru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRU_DESCRICAO(int gru_id, string value)
        {
            this.Query = $@" UPDATE [T_Grupo] SET [GRU_DESCRICAO] = @GRU_DESCRICAO WHERE [GRU_ID] = @GRU_ID ";
            this.Parameters = new
            {
                GRU_DESCRICAO = value,
                GRU_ID = gru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int gru_id, int value)
        {
            this.Query = $@" UPDATE [T_Grupo] SET [TenantID] = @TenantID WHERE [GRU_ID] = @GRU_ID ";
            this.Parameters = new
            {
                TenantID = value,
                GRU_ID = gru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int gru_id, bool value)
        {
            this.Query = $@" UPDATE [T_Grupo] SET [Deleted] = @Deleted WHERE [GRU_ID] = @GRU_ID ";
            this.Parameters = new
            {
                Deleted = value,
                GRU_ID = gru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int gru_id, DateTime value)
        {
            this.Query = $@" UPDATE [T_Grupo] SET [Changed] = @Changed WHERE [GRU_ID] = @GRU_ID ";
            this.Parameters = new
            {
                Changed = value,
                GRU_ID = gru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int gru_id, int value)
        {
            this.Query = $@" UPDATE [T_Grupo] SET [UserId] = @UserId WHERE [GRU_ID] = @GRU_ID ";
            this.Parameters = new
            {
                UserId = value,
                GRU_ID = gru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_GrupoQuery(IT_GrupoEntity T_Grupo)
        {
            this.Query = $@" DELETE FROM [T_Grupo] WHERE [GRU_ID] = @GRU_ID ";
            this.Parameters = new
            {
                GRU_ID = T_Grupo.GRU_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration