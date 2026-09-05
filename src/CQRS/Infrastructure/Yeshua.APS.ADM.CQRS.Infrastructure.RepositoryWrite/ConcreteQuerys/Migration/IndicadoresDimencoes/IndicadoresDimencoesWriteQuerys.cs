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
    public class IndicadoresDimencoesQueryWrite : QueryBase, IIndicadoresDimencoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public IndicadoresDimencoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirIndicadoresDimencoesQuery(IIndicadoresDimencoesEntity IndicadoresDimencoes)
        {
            this.Query = $@" INSERT INTO [IndicadoresDimencoes] ([DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@DIM_ID, @IND_ID, @DIM_DESCRICAO, @DIM_SQL, @DIM_CONEXAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                DIM_ID = IndicadoresDimencoes.DIM_ID,
                IND_ID = IndicadoresDimencoes.IND_ID,
                DIM_DESCRICAO = IndicadoresDimencoes.DIM_DESCRICAO,
                DIM_SQL = IndicadoresDimencoes.DIM_SQL,
                DIM_CONEXAO = IndicadoresDimencoes.DIM_CONEXAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIndicadoresDimencoesQuery(IIndicadoresDimencoesEntity IndicadoresDimencoes)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [DIM_ID] = @DIM_ID, [IND_ID] = @IND_ID, [DIM_DESCRICAO] = @DIM_DESCRICAO, [DIM_SQL] = @DIM_SQL, [DIM_CONEXAO] = @DIM_CONEXAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DIM_ID = IndicadoresDimencoes.DIM_ID,
                IND_ID = IndicadoresDimencoes.IND_ID,
                DIM_DESCRICAO = IndicadoresDimencoes.DIM_DESCRICAO,
                DIM_SQL = IndicadoresDimencoes.DIM_SQL,
                DIM_CONEXAO = IndicadoresDimencoes.DIM_CONEXAO,
                Changed = IndicadoresDimencoes.Changed,
                UserId = _executionContext.UserId,
                Id = IndicadoresDimencoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_ID(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [DIM_ID] = @DIM_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DIM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_ID(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [IND_ID] = @IND_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                IND_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [DIM_DESCRICAO] = @DIM_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DIM_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_SQL(int id, string value)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [DIM_SQL] = @DIM_SQL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DIM_SQL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_CONEXAO(int id, string value)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [DIM_CONEXAO] = @DIM_CONEXAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DIM_CONEXAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresDimencoes] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteIndicadoresDimencoesQuery(IIndicadoresDimencoesEntity IndicadoresDimencoes)
        {
            this.Query = $@" DELETE FROM [IndicadoresDimencoes] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = IndicadoresDimencoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration