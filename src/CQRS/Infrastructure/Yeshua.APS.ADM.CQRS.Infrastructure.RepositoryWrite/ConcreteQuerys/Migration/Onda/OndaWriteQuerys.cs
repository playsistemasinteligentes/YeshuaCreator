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
    public class OndaQueryWrite : QueryBase, IOndaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public OndaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirOndaQuery(IOndaEntity Onda)
        {
            this.Query = $@" INSERT INTO Onda (OND_ID, OND_ESPESSURA, OND_PESO_COLA, OND_RENDIMENTO_ONDA_1, OND_RENDIMENTO_ONDA_2, OND_PROFUNDIDADE_VINCO, OND_ID_INTEGRACAO, VIN_ID, TenantID, Deleted, Changed, UserId) VALUES(@OND_ID, @OND_ESPESSURA, @OND_PESO_COLA, @OND_RENDIMENTO_ONDA_1, @OND_RENDIMENTO_ONDA_2, @OND_PROFUNDIDADE_VINCO, @OND_ID_INTEGRACAO, @VIN_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                OND_ID = Onda.OND_ID,
                OND_ESPESSURA = Onda.OND_ESPESSURA,
                OND_PESO_COLA = Onda.OND_PESO_COLA,
                OND_RENDIMENTO_ONDA_1 = Onda.OND_RENDIMENTO_ONDA_1,
                OND_RENDIMENTO_ONDA_2 = Onda.OND_RENDIMENTO_ONDA_2,
                OND_PROFUNDIDADE_VINCO = Onda.OND_PROFUNDIDADE_VINCO,
                OND_ID_INTEGRACAO = Onda.OND_ID_INTEGRACAO,
                VIN_ID = Onda.VIN_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOndaQuery(IOndaEntity Onda)
        {
            this.Query = $@" UPDATE Onda SET OND_ESPESSURA = @OND_ESPESSURA, OND_PESO_COLA = @OND_PESO_COLA, OND_RENDIMENTO_ONDA_1 = @OND_RENDIMENTO_ONDA_1, OND_RENDIMENTO_ONDA_2 = @OND_RENDIMENTO_ONDA_2, OND_PROFUNDIDADE_VINCO = @OND_PROFUNDIDADE_VINCO, OND_ID_INTEGRACAO = @OND_ID_INTEGRACAO, VIN_ID = @VIN_ID, Changed = @Changed, UserId = @UserId WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                OND_ESPESSURA = Onda.OND_ESPESSURA,
                OND_PESO_COLA = Onda.OND_PESO_COLA,
                OND_RENDIMENTO_ONDA_1 = Onda.OND_RENDIMENTO_ONDA_1,
                OND_RENDIMENTO_ONDA_2 = Onda.OND_RENDIMENTO_ONDA_2,
                OND_PROFUNDIDADE_VINCO = Onda.OND_PROFUNDIDADE_VINCO,
                OND_ID_INTEGRACAO = Onda.OND_ID_INTEGRACAO,
                VIN_ID = Onda.VIN_ID,
                Changed = Onda.Changed,
                UserId = _executionContext.UserId,
                OND_ID = Onda.OND_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOND_ESPESSURA(string ond_id, Decimal value)
        {
            this.Query = $@" UPDATE Onda SET OND_ESPESSURA = @OND_ESPESSURA WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                OND_ESPESSURA = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOND_PESO_COLA(string ond_id, Decimal value)
        {
            this.Query = $@" UPDATE Onda SET OND_PESO_COLA = @OND_PESO_COLA WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                OND_PESO_COLA = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOND_RENDIMENTO_ONDA_1(string ond_id, Decimal value)
        {
            this.Query = $@" UPDATE Onda SET OND_RENDIMENTO_ONDA_1 = @OND_RENDIMENTO_ONDA_1 WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                OND_RENDIMENTO_ONDA_1 = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOND_RENDIMENTO_ONDA_2(string ond_id, Decimal value)
        {
            this.Query = $@" UPDATE Onda SET OND_RENDIMENTO_ONDA_2 = @OND_RENDIMENTO_ONDA_2 WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                OND_RENDIMENTO_ONDA_2 = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOND_PROFUNDIDADE_VINCO(string ond_id, int value)
        {
            this.Query = $@" UPDATE Onda SET OND_PROFUNDIDADE_VINCO = @OND_PROFUNDIDADE_VINCO WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                OND_PROFUNDIDADE_VINCO = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOND_ID_INTEGRACAO(string ond_id, string value)
        {
            this.Query = $@" UPDATE Onda SET OND_ID_INTEGRACAO = @OND_ID_INTEGRACAO WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                OND_ID_INTEGRACAO = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVIN_ID(string ond_id, int value)
        {
            this.Query = $@" UPDATE Onda SET VIN_ID = @VIN_ID WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                VIN_ID = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string ond_id, int value)
        {
            this.Query = $@" UPDATE Onda SET TenantID = @TenantID WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                TenantID = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string ond_id, bool value)
        {
            this.Query = $@" UPDATE Onda SET Deleted = @Deleted WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                Deleted = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string ond_id, DateTime value)
        {
            this.Query = $@" UPDATE Onda SET Changed = @Changed WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                Changed = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string ond_id, int value)
        {
            this.Query = $@" UPDATE Onda SET UserId = @UserId WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                UserId = value,
                OND_ID = ond_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteOndaQuery(IOndaEntity Onda)
        {
            this.Query = $@" DELETE FROM Onda WHERE OND_ID = @OND_ID ";
            this.Parameters = new
            {
                OND_ID = Onda.OND_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration