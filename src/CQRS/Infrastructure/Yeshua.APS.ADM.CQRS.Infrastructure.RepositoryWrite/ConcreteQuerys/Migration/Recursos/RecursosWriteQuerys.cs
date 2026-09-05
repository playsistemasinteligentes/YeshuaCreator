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
    public class RecursosQueryWrite : QueryBase, IRecursosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RecursosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRecursosQuery(IRecursosEntity Recursos)
        {
            this.Query = $@" INSERT INTO [Recursos] ([REC_ID], [REC_DESCRICAO], [CAL_ID], [REC_CONTROL_IP], [GRE_ID], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@REC_ID, @REC_DESCRICAO, @CAL_ID, @REC_CONTROL_IP, @GRE_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                REC_ID = Recursos.REC_ID,
                REC_DESCRICAO = Recursos.REC_DESCRICAO,
                CAL_ID = Recursos.CAL_ID,
                REC_CONTROL_IP = Recursos.REC_CONTROL_IP,
                GRE_ID = Recursos.GRE_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRecursosQuery(IRecursosEntity Recursos)
        {
            this.Query = $@" UPDATE [Recursos] SET [REC_DESCRICAO] = @REC_DESCRICAO, [CAL_ID] = @CAL_ID, [REC_CONTROL_IP] = @REC_CONTROL_IP, [GRE_ID] = @GRE_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                REC_DESCRICAO = Recursos.REC_DESCRICAO,
                CAL_ID = Recursos.CAL_ID,
                REC_CONTROL_IP = Recursos.REC_CONTROL_IP,
                GRE_ID = Recursos.GRE_ID,
                Changed = Recursos.Changed,
                UserId = _executionContext.UserId,
                REC_ID = Recursos.REC_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREC_DESCRICAO(string rec_id, string value)
        {
            this.Query = $@" UPDATE [Recursos] SET [REC_DESCRICAO] = @REC_DESCRICAO WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                REC_DESCRICAO = value,
                REC_ID = rec_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAL_ID(string rec_id, int value)
        {
            this.Query = $@" UPDATE [Recursos] SET [CAL_ID] = @CAL_ID WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                CAL_ID = value,
                REC_ID = rec_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREC_CONTROL_IP(string rec_id, string value)
        {
            this.Query = $@" UPDATE [Recursos] SET [REC_CONTROL_IP] = @REC_CONTROL_IP WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                REC_CONTROL_IP = value,
                REC_ID = rec_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRE_ID(string rec_id, string value)
        {
            this.Query = $@" UPDATE [Recursos] SET [GRE_ID] = @GRE_ID WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                GRE_ID = value,
                REC_ID = rec_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string rec_id, int value)
        {
            this.Query = $@" UPDATE [Recursos] SET [TenantID] = @TenantID WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                TenantID = value,
                REC_ID = rec_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string rec_id, bool value)
        {
            this.Query = $@" UPDATE [Recursos] SET [Deleted] = @Deleted WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                Deleted = value,
                REC_ID = rec_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string rec_id, DateTime value)
        {
            this.Query = $@" UPDATE [Recursos] SET [Changed] = @Changed WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                Changed = value,
                REC_ID = rec_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string rec_id, int value)
        {
            this.Query = $@" UPDATE [Recursos] SET [UserId] = @UserId WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                UserId = value,
                REC_ID = rec_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRecursosQuery(IRecursosEntity Recursos)
        {
            this.Query = $@" DELETE FROM [Recursos] WHERE [REC_ID] = @REC_ID ";
            this.Parameters = new
            {
                REC_ID = Recursos.REC_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration