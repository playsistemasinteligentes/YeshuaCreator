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
    public class CTeComplementoIcmsFiscalQueryWrite : QueryBase, ICTeComplementoIcmsFiscalQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CTeComplementoIcmsFiscalQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCTeComplementoIcmsFiscalQuery(ICTeComplementoIcmsFiscalEntity CTeComplementoIcmsFiscal)
        {
            this.Query = $@" INSERT INTO [CTeComplementoIcmsFiscal] ([CTeSolicitacaoFiscalId], [ValorPrestacaoComplementar], [CST], [ValorBaseCalculo], [AliquotaICMS], [ValorICMS], [TenantID], [Deleted], [Changed], [UserId], [OperationalEntityId]) OUTPUT INSERTED.[Id] VALUES(@CTeSolicitacaoFiscalId, @ValorPrestacaoComplementar, @CST, @ValorBaseCalculo, @AliquotaICMS, @ValorICMS, @TenantID, @Deleted, @Changed, @UserId, @OperationalEntityId) ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = CTeComplementoIcmsFiscal.CTeSolicitacaoFiscalId,
                ValorPrestacaoComplementar = CTeComplementoIcmsFiscal.ValorPrestacaoComplementar,
                CST = CTeComplementoIcmsFiscal.CST,
                ValorBaseCalculo = CTeComplementoIcmsFiscal.ValorBaseCalculo,
                AliquotaICMS = CTeComplementoIcmsFiscal.AliquotaICMS,
                ValorICMS = CTeComplementoIcmsFiscal.ValorICMS,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                OperationalEntityId = CTeComplementoIcmsFiscal.OperationalEntityId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeComplementoIcmsFiscalQuery(ICTeComplementoIcmsFiscalEntity CTeComplementoIcmsFiscal)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [CTeSolicitacaoFiscalId] = @CTeSolicitacaoFiscalId, [ValorPrestacaoComplementar] = @ValorPrestacaoComplementar, [CST] = @CST, [ValorBaseCalculo] = @ValorBaseCalculo, [AliquotaICMS] = @AliquotaICMS, [ValorICMS] = @ValorICMS, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = CTeComplementoIcmsFiscal.CTeSolicitacaoFiscalId,
                ValorPrestacaoComplementar = CTeComplementoIcmsFiscal.ValorPrestacaoComplementar,
                CST = CTeComplementoIcmsFiscal.CST,
                ValorBaseCalculo = CTeComplementoIcmsFiscal.ValorBaseCalculo,
                AliquotaICMS = CTeComplementoIcmsFiscal.AliquotaICMS,
                ValorICMS = CTeComplementoIcmsFiscal.ValorICMS,
                Changed = CTeComplementoIcmsFiscal.Changed,
                UserId = _executionContext.UserId,
                Id = CTeComplementoIcmsFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeSolicitacaoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [CTeSolicitacaoFiscalId] = @CTeSolicitacaoFiscalId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorPrestacaoComplementar(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [ValorPrestacaoComplementar] = @ValorPrestacaoComplementar WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorPrestacaoComplementar = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCST(int id, string value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [CST] = @CST WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CST = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorBaseCalculo(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [ValorBaseCalculo] = @ValorBaseCalculo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorBaseCalculo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAliquotaICMS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [AliquotaICMS] = @AliquotaICMS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AliquotaICMS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorICMS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [ValorICMS] = @ValorICMS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorICMS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperationalEntityId(int id, string value)
        {
            this.Query = $@" UPDATE [CTeComplementoIcmsFiscal] SET [OperationalEntityId] = @OperationalEntityId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OperationalEntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCTeComplementoIcmsFiscalQuery(ICTeComplementoIcmsFiscalEntity CTeComplementoIcmsFiscal)
        {
            this.Query = $@" DELETE FROM [CTeComplementoIcmsFiscal] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = CTeComplementoIcmsFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration