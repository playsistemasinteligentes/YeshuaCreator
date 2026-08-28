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
    public class ItensPackedQueryWrite : QueryBase, IItensPackedQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ItensPackedQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirItensPackedQuery(IItensPackedEntity ItensPacked)
        {
            this.Query = $@" INSERT INTO ItensPacked (IPA_ID, CAR_ID, PRO_ID, ORD_ID, IPA_COORDC, IPA_COORDL, IPA_COORDA, IPA_DIMC, IPA_DIML, IPA_DIMA, IPA_QTD_POR_PALETE, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@IPA_ID, @CAR_ID, @PRO_ID, @ORD_ID, @IPA_COORDC, @IPA_COORDL, @IPA_COORDA, @IPA_DIMC, @IPA_DIML, @IPA_DIMA, @IPA_QTD_POR_PALETE, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                IPA_ID = ItensPacked.IPA_ID,
                CAR_ID = ItensPacked.CAR_ID,
                PRO_ID = ItensPacked.PRO_ID,
                ORD_ID = ItensPacked.ORD_ID,
                IPA_COORDC = ItensPacked.IPA_COORDC,
                IPA_COORDL = ItensPacked.IPA_COORDL,
                IPA_COORDA = ItensPacked.IPA_COORDA,
                IPA_DIMC = ItensPacked.IPA_DIMC,
                IPA_DIML = ItensPacked.IPA_DIML,
                IPA_DIMA = ItensPacked.IPA_DIMA,
                IPA_QTD_POR_PALETE = ItensPacked.IPA_QTD_POR_PALETE,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateItensPackedQuery(IItensPackedEntity ItensPacked)
        {
            this.Query = $@" UPDATE ItensPacked SET IPA_ID = @IPA_ID, CAR_ID = @CAR_ID, PRO_ID = @PRO_ID, ORD_ID = @ORD_ID, IPA_COORDC = @IPA_COORDC, IPA_COORDL = @IPA_COORDL, IPA_COORDA = @IPA_COORDA, IPA_DIMC = @IPA_DIMC, IPA_DIML = @IPA_DIML, IPA_DIMA = @IPA_DIMA, IPA_QTD_POR_PALETE = @IPA_QTD_POR_PALETE, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                IPA_ID = ItensPacked.IPA_ID,
                CAR_ID = ItensPacked.CAR_ID,
                PRO_ID = ItensPacked.PRO_ID,
                ORD_ID = ItensPacked.ORD_ID,
                IPA_COORDC = ItensPacked.IPA_COORDC,
                IPA_COORDL = ItensPacked.IPA_COORDL,
                IPA_COORDA = ItensPacked.IPA_COORDA,
                IPA_DIMC = ItensPacked.IPA_DIMC,
                IPA_DIML = ItensPacked.IPA_DIML,
                IPA_DIMA = ItensPacked.IPA_DIMA,
                IPA_QTD_POR_PALETE = ItensPacked.IPA_QTD_POR_PALETE,
                Changed = ItensPacked.Changed,
                UserId = _executionContext.UserId,
                Id = ItensPacked.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPA_ID(int id, int value)
        {
            this.Query = $@" UPDATE ItensPacked SET IPA_ID = @IPA_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                IPA_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID(int id, string value)
        {
            this.Query = $@" UPDATE ItensPacked SET CAR_ID = @CAR_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int id, string value)
        {
            this.Query = $@" UPDATE ItensPacked SET PRO_ID = @PRO_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int id, string value)
        {
            this.Query = $@" UPDATE ItensPacked SET ORD_ID = @ORD_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ORD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPA_COORDC(int id, Decimal value)
        {
            this.Query = $@" UPDATE ItensPacked SET IPA_COORDC = @IPA_COORDC WHERE Id = @Id ";
            this.Parameters = new
            {
                IPA_COORDC = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPA_COORDL(int id, Decimal value)
        {
            this.Query = $@" UPDATE ItensPacked SET IPA_COORDL = @IPA_COORDL WHERE Id = @Id ";
            this.Parameters = new
            {
                IPA_COORDL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPA_COORDA(int id, Decimal value)
        {
            this.Query = $@" UPDATE ItensPacked SET IPA_COORDA = @IPA_COORDA WHERE Id = @Id ";
            this.Parameters = new
            {
                IPA_COORDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPA_DIMC(int id, Decimal value)
        {
            this.Query = $@" UPDATE ItensPacked SET IPA_DIMC = @IPA_DIMC WHERE Id = @Id ";
            this.Parameters = new
            {
                IPA_DIMC = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPA_DIML(int id, Decimal value)
        {
            this.Query = $@" UPDATE ItensPacked SET IPA_DIML = @IPA_DIML WHERE Id = @Id ";
            this.Parameters = new
            {
                IPA_DIML = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPA_DIMA(int id, Decimal value)
        {
            this.Query = $@" UPDATE ItensPacked SET IPA_DIMA = @IPA_DIMA WHERE Id = @Id ";
            this.Parameters = new
            {
                IPA_DIMA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPA_QTD_POR_PALETE(int id, Decimal value)
        {
            this.Query = $@" UPDATE ItensPacked SET IPA_QTD_POR_PALETE = @IPA_QTD_POR_PALETE WHERE Id = @Id ";
            this.Parameters = new
            {
                IPA_QTD_POR_PALETE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE ItensPacked SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE ItensPacked SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE ItensPacked SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE ItensPacked SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteItensPackedQuery(IItensPackedEntity ItensPacked)
        {
            this.Query = $@" DELETE FROM ItensPacked WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = ItensPacked.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration