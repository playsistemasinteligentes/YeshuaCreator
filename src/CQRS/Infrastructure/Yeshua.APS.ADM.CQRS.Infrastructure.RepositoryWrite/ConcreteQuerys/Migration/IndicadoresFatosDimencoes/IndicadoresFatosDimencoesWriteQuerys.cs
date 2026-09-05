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
    public class IndicadoresFatosDimencoesQueryWrite : QueryBase, IIndicadoresFatosDimencoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public IndicadoresFatosDimencoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirIndicadoresFatosDimencoesQuery(IIndicadoresFatosDimencoesEntity IndicadoresFatosDimencoes)
        {
            this.Query = $@" INSERT INTO [IndicadoresFatosDimencoes] ([FAT_ID], [IND_ID], [DIM_ID], [FAT_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@FAT_ID, @IND_ID, @DIM_ID, @FAT_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                FAT_ID = IndicadoresFatosDimencoes.FAT_ID,
                IND_ID = IndicadoresFatosDimencoes.IND_ID,
                DIM_ID = IndicadoresFatosDimencoes.DIM_ID,
                FAT_DESCRICAO = IndicadoresFatosDimencoes.FAT_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIndicadoresFatosDimencoesQuery(IIndicadoresFatosDimencoesEntity IndicadoresFatosDimencoes)
        {
            this.Query = $@" UPDATE [IndicadoresFatosDimencoes] SET [FAT_ID] = @FAT_ID, [IND_ID] = @IND_ID, [DIM_ID] = @DIM_ID, [FAT_DESCRICAO] = @FAT_DESCRICAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                FAT_ID = IndicadoresFatosDimencoes.FAT_ID,
                IND_ID = IndicadoresFatosDimencoes.IND_ID,
                DIM_ID = IndicadoresFatosDimencoes.DIM_ID,
                FAT_DESCRICAO = IndicadoresFatosDimencoes.FAT_DESCRICAO,
                Changed = IndicadoresFatosDimencoes.Changed,
                UserId = _executionContext.UserId,
                Id = IndicadoresFatosDimencoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFAT_ID(int id, string value)
        {
            this.Query = $@" UPDATE [IndicadoresFatosDimencoes] SET [FAT_ID] = @FAT_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                FAT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_ID(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresFatosDimencoes] SET [IND_ID] = @IND_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                IND_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_ID(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresFatosDimencoes] SET [DIM_ID] = @DIM_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DIM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFAT_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [IndicadoresFatosDimencoes] SET [FAT_DESCRICAO] = @FAT_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                FAT_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresFatosDimencoes] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [IndicadoresFatosDimencoes] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [IndicadoresFatosDimencoes] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresFatosDimencoes] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteIndicadoresFatosDimencoesQuery(IIndicadoresFatosDimencoesEntity IndicadoresFatosDimencoes)
        {
            this.Query = $@" DELETE FROM [IndicadoresFatosDimencoes] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = IndicadoresFatosDimencoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration