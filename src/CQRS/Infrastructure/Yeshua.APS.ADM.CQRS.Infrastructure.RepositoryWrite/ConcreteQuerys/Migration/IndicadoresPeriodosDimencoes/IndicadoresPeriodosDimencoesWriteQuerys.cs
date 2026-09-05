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
    public class IndicadoresPeriodosDimencoesQueryWrite : QueryBase, IIndicadoresPeriodosDimencoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public IndicadoresPeriodosDimencoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirIndicadoresPeriodosDimencoesQuery(IIndicadoresPeriodosDimencoesEntity IndicadoresPeriodosDimencoes)
        {
            this.Query = $@" INSERT INTO [IndicadoresPeriodosDimencoes] ([PER_ID], [IND_ID], [DIM_ID], [PER_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@PER_ID, @IND_ID, @DIM_ID, @PER_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PER_ID = IndicadoresPeriodosDimencoes.PER_ID,
                IND_ID = IndicadoresPeriodosDimencoes.IND_ID,
                DIM_ID = IndicadoresPeriodosDimencoes.DIM_ID,
                PER_DESCRICAO = IndicadoresPeriodosDimencoes.PER_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIndicadoresPeriodosDimencoesQuery(IIndicadoresPeriodosDimencoesEntity IndicadoresPeriodosDimencoes)
        {
            this.Query = $@" UPDATE [IndicadoresPeriodosDimencoes] SET [PER_ID] = @PER_ID, [IND_ID] = @IND_ID, [DIM_ID] = @DIM_ID, [PER_DESCRICAO] = @PER_DESCRICAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PER_ID = IndicadoresPeriodosDimencoes.PER_ID,
                IND_ID = IndicadoresPeriodosDimencoes.IND_ID,
                DIM_ID = IndicadoresPeriodosDimencoes.DIM_ID,
                PER_DESCRICAO = IndicadoresPeriodosDimencoes.PER_DESCRICAO,
                Changed = IndicadoresPeriodosDimencoes.Changed,
                UserId = _executionContext.UserId,
                Id = IndicadoresPeriodosDimencoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_ID(int id, string value)
        {
            this.Query = $@" UPDATE [IndicadoresPeriodosDimencoes] SET [PER_ID] = @PER_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_ID(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresPeriodosDimencoes] SET [IND_ID] = @IND_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                IND_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDIM_ID(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresPeriodosDimencoes] SET [DIM_ID] = @DIM_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DIM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [IndicadoresPeriodosDimencoes] SET [PER_DESCRICAO] = @PER_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PER_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresPeriodosDimencoes] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [IndicadoresPeriodosDimencoes] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [IndicadoresPeriodosDimencoes] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [IndicadoresPeriodosDimencoes] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteIndicadoresPeriodosDimencoesQuery(IIndicadoresPeriodosDimencoesEntity IndicadoresPeriodosDimencoes)
        {
            this.Query = $@" DELETE FROM [IndicadoresPeriodosDimencoes] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = IndicadoresPeriodosDimencoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration