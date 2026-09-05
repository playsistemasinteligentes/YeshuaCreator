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
    public class ItenCalendarioDisponibilidadeVeiculosQueryWrite : QueryBase, IItenCalendarioDisponibilidadeVeiculosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ItenCalendarioDisponibilidadeVeiculosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirItenCalendarioDisponibilidadeVeiculosQuery(IItenCalendarioDisponibilidadeVeiculosEntity ItenCalendarioDisponibilidadeVeiculos)
        {
            this.Query = $@" INSERT INTO [ItenCalendarioDisponibilidadeVeiculos] ([CDV_ID], [TIP_ID], [IDV_QTD], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CDV_ID, @TIP_ID, @IDV_QTD, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CDV_ID = ItenCalendarioDisponibilidadeVeiculos.CDV_ID,
                TIP_ID = ItenCalendarioDisponibilidadeVeiculos.TIP_ID,
                IDV_QTD = ItenCalendarioDisponibilidadeVeiculos.IDV_QTD,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateItenCalendarioDisponibilidadeVeiculosQuery(IItenCalendarioDisponibilidadeVeiculosEntity ItenCalendarioDisponibilidadeVeiculos)
        {
            this.Query = $@" UPDATE [ItenCalendarioDisponibilidadeVeiculos] SET [CDV_ID] = @CDV_ID, [TIP_ID] = @TIP_ID, [IDV_QTD] = @IDV_QTD, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CDV_ID = ItenCalendarioDisponibilidadeVeiculos.CDV_ID,
                TIP_ID = ItenCalendarioDisponibilidadeVeiculos.TIP_ID,
                IDV_QTD = ItenCalendarioDisponibilidadeVeiculos.IDV_QTD,
                Changed = ItenCalendarioDisponibilidadeVeiculos.Changed,
                UserId = _executionContext.UserId,
                Id = ItenCalendarioDisponibilidadeVeiculos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCDV_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ItenCalendarioDisponibilidadeVeiculos] SET [CDV_ID] = @CDV_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CDV_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ItenCalendarioDisponibilidadeVeiculos] SET [TIP_ID] = @TIP_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIDV_QTD(int id, int value)
        {
            this.Query = $@" UPDATE [ItenCalendarioDisponibilidadeVeiculos] SET [IDV_QTD] = @IDV_QTD WHERE [Id] = @Id ";
            this.Parameters = new
            {
                IDV_QTD = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ItenCalendarioDisponibilidadeVeiculos] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ItenCalendarioDisponibilidadeVeiculos] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ItenCalendarioDisponibilidadeVeiculos] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ItenCalendarioDisponibilidadeVeiculos] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteItenCalendarioDisponibilidadeVeiculosQuery(IItenCalendarioDisponibilidadeVeiculosEntity ItenCalendarioDisponibilidadeVeiculos)
        {
            this.Query = $@" DELETE FROM [ItenCalendarioDisponibilidadeVeiculos] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ItenCalendarioDisponibilidadeVeiculos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration