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
    public class ItenCargaQueryWrite : QueryBase, IItenCargaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ItenCargaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirItenCargaQuery(IItenCargaEntity ItenCarga)
        {
            this.Query = $@" INSERT INTO [ItenCarga] ([CAR_ID], [ORD_ID], [ITC_ENTREGA_PLANEJADA], [ITC_ENTREGA_REALIZADA], [ITC_ORDEM_ENTREGA], [ITC_QTD_PLANEJADA], [ITC_QTD_REALIZADA], [ORD_HASH_KEY], [NOT_ID], [NOT_EMISSAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CAR_ID, @ORD_ID, @ITC_ENTREGA_PLANEJADA, @ITC_ENTREGA_REALIZADA, @ITC_ORDEM_ENTREGA, @ITC_QTD_PLANEJADA, @ITC_QTD_REALIZADA, @ORD_HASH_KEY, @NOT_ID, @NOT_EMISSAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CAR_ID = ItenCarga.CAR_ID,
                ORD_ID = ItenCarga.ORD_ID,
                ITC_ENTREGA_PLANEJADA = ItenCarga.ITC_ENTREGA_PLANEJADA,
                ITC_ENTREGA_REALIZADA = ItenCarga.ITC_ENTREGA_REALIZADA,
                ITC_ORDEM_ENTREGA = ItenCarga.ITC_ORDEM_ENTREGA,
                ITC_QTD_PLANEJADA = ItenCarga.ITC_QTD_PLANEJADA,
                ITC_QTD_REALIZADA = ItenCarga.ITC_QTD_REALIZADA,
                ORD_HASH_KEY = ItenCarga.ORD_HASH_KEY,
                NOT_ID = ItenCarga.NOT_ID,
                NOT_EMISSAO = ItenCarga.NOT_EMISSAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateItenCargaQuery(IItenCargaEntity ItenCarga)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [CAR_ID] = @CAR_ID, [ORD_ID] = @ORD_ID, [ITC_ENTREGA_PLANEJADA] = @ITC_ENTREGA_PLANEJADA, [ITC_ENTREGA_REALIZADA] = @ITC_ENTREGA_REALIZADA, [ITC_ORDEM_ENTREGA] = @ITC_ORDEM_ENTREGA, [ITC_QTD_PLANEJADA] = @ITC_QTD_PLANEJADA, [ITC_QTD_REALIZADA] = @ITC_QTD_REALIZADA, [ORD_HASH_KEY] = @ORD_HASH_KEY, [NOT_ID] = @NOT_ID, [NOT_EMISSAO] = @NOT_EMISSAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_ID = ItenCarga.CAR_ID,
                ORD_ID = ItenCarga.ORD_ID,
                ITC_ENTREGA_PLANEJADA = ItenCarga.ITC_ENTREGA_PLANEJADA,
                ITC_ENTREGA_REALIZADA = ItenCarga.ITC_ENTREGA_REALIZADA,
                ITC_ORDEM_ENTREGA = ItenCarga.ITC_ORDEM_ENTREGA,
                ITC_QTD_PLANEJADA = ItenCarga.ITC_QTD_PLANEJADA,
                ITC_QTD_REALIZADA = ItenCarga.ITC_QTD_REALIZADA,
                ORD_HASH_KEY = ItenCarga.ORD_HASH_KEY,
                NOT_ID = ItenCarga.NOT_ID,
                NOT_EMISSAO = ItenCarga.NOT_EMISSAO,
                Changed = ItenCarga.Changed,
                UserId = _executionContext.UserId,
                Id = ItenCarga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [CAR_ID] = @CAR_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [ORD_ID] = @ORD_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ORD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITC_ENTREGA_PLANEJADA(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [ITC_ENTREGA_PLANEJADA] = @ITC_ENTREGA_PLANEJADA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITC_ENTREGA_PLANEJADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITC_ENTREGA_REALIZADA(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [ITC_ENTREGA_REALIZADA] = @ITC_ENTREGA_REALIZADA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITC_ENTREGA_REALIZADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITC_ORDEM_ENTREGA(int id, int value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [ITC_ORDEM_ENTREGA] = @ITC_ORDEM_ENTREGA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITC_ORDEM_ENTREGA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITC_QTD_PLANEJADA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [ITC_QTD_PLANEJADA] = @ITC_QTD_PLANEJADA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITC_QTD_PLANEJADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITC_QTD_REALIZADA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [ITC_QTD_REALIZADA] = @ITC_QTD_REALIZADA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITC_QTD_REALIZADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_HASH_KEY(int id, string value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [ORD_HASH_KEY] = @ORD_HASH_KEY WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ORD_HASH_KEY = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNOT_ID(int id, string value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [NOT_ID] = @NOT_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                NOT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNOT_EMISSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [NOT_EMISSAO] = @NOT_EMISSAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                NOT_EMISSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ItenCarga] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteItenCargaQuery(IItenCargaEntity ItenCarga)
        {
            this.Query = $@" DELETE FROM [ItenCarga] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ItenCarga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration