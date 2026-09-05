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
    public class CargosQueryWrite : QueryBase, ICargosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CargosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCargosQuery(ICargosEntity Cargos)
        {
            this.Query = $@" INSERT INTO [Cargos] ([RGO_ID], [RGO_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@RGO_ID, @RGO_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                RGO_ID = Cargos.RGO_ID,
                RGO_DESCRICAO = Cargos.RGO_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargosQuery(ICargosEntity Cargos)
        {
            this.Query = $@" UPDATE [Cargos] SET [RGO_ID] = @RGO_ID, [RGO_DESCRICAO] = @RGO_DESCRICAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RGO_ID = Cargos.RGO_ID,
                RGO_DESCRICAO = Cargos.RGO_DESCRICAO,
                Changed = Cargos.Changed,
                UserId = _executionContext.UserId,
                Id = Cargos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRGO_ID(int id, string value)
        {
            this.Query = $@" UPDATE [Cargos] SET [RGO_ID] = @RGO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RGO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRGO_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [Cargos] SET [RGO_DESCRICAO] = @RGO_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RGO_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Cargos] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Cargos] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Cargos] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Cargos] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCargosQuery(ICargosEntity Cargos)
        {
            this.Query = $@" DELETE FROM [Cargos] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Cargos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration