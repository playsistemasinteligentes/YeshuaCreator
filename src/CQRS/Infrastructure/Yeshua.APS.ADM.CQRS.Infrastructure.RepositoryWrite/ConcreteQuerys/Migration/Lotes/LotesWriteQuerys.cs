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
    public class LotesQueryWrite : QueryBase, ILotesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public LotesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirLotesQuery(ILotesEntity Lotes)
        {
            this.Query = $@" INSERT INTO [Lotes] ([MOV_LOTE], [MOV_SUB_LOTE], [LOT_LARGURA], [LOT_COMPRIMENTO], [LOT_DIAMETRO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@MOV_LOTE, @MOV_SUB_LOTE, @LOT_LARGURA, @LOT_COMPRIMENTO, @LOT_DIAMETRO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MOV_LOTE = Lotes.MOV_LOTE,
                MOV_SUB_LOTE = Lotes.MOV_SUB_LOTE,
                LOT_LARGURA = Lotes.LOT_LARGURA,
                LOT_COMPRIMENTO = Lotes.LOT_COMPRIMENTO,
                LOT_DIAMETRO = Lotes.LOT_DIAMETRO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLotesQuery(ILotesEntity Lotes)
        {
            this.Query = $@" UPDATE [Lotes] SET [MOV_LOTE] = @MOV_LOTE, [MOV_SUB_LOTE] = @MOV_SUB_LOTE, [LOT_LARGURA] = @LOT_LARGURA, [LOT_COMPRIMENTO] = @LOT_COMPRIMENTO, [LOT_DIAMETRO] = @LOT_DIAMETRO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MOV_LOTE = Lotes.MOV_LOTE,
                MOV_SUB_LOTE = Lotes.MOV_SUB_LOTE,
                LOT_LARGURA = Lotes.LOT_LARGURA,
                LOT_COMPRIMENTO = Lotes.LOT_COMPRIMENTO,
                LOT_DIAMETRO = Lotes.LOT_DIAMETRO,
                Changed = Lotes.Changed,
                UserId = _executionContext.UserId,
                Id = Lotes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_LOTE(int id, string value)
        {
            this.Query = $@" UPDATE [Lotes] SET [MOV_LOTE] = @MOV_LOTE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MOV_LOTE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_SUB_LOTE(int id, string value)
        {
            this.Query = $@" UPDATE [Lotes] SET [MOV_SUB_LOTE] = @MOV_SUB_LOTE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MOV_SUB_LOTE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOT_LARGURA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [Lotes] SET [LOT_LARGURA] = @LOT_LARGURA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOT_LARGURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOT_COMPRIMENTO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [Lotes] SET [LOT_COMPRIMENTO] = @LOT_COMPRIMENTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOT_COMPRIMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLOT_DIAMETRO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [Lotes] SET [LOT_DIAMETRO] = @LOT_DIAMETRO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                LOT_DIAMETRO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Lotes] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Lotes] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Lotes] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Lotes] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteLotesQuery(ILotesEntity Lotes)
        {
            this.Query = $@" DELETE FROM [Lotes] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Lotes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration