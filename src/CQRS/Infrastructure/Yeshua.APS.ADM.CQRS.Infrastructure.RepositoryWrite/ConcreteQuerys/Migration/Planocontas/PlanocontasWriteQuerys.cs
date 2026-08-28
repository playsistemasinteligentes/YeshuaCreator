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
    public class PlanocontasQueryWrite : QueryBase, IPlanocontasQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PlanocontasQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPlanocontasQuery(IPlanocontasEntity Planocontas)
        {
            this.Query = $@" INSERT INTO Planocontas (PLA_CODIGO, PLA_DESCRICAO, PLA_TIPO, PLA_NATUREZA, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.PLA_ID VALUES(@PLA_CODIGO, @PLA_DESCRICAO, @PLA_TIPO, @PLA_NATUREZA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PLA_CODIGO = Planocontas.PLA_CODIGO,
                PLA_DESCRICAO = Planocontas.PLA_DESCRICAO,
                PLA_TIPO = Planocontas.PLA_TIPO,
                PLA_NATUREZA = Planocontas.PLA_NATUREZA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlanocontasQuery(IPlanocontasEntity Planocontas)
        {
            this.Query = $@" UPDATE Planocontas SET PLA_CODIGO = @PLA_CODIGO, PLA_DESCRICAO = @PLA_DESCRICAO, PLA_TIPO = @PLA_TIPO, PLA_NATUREZA = @PLA_NATUREZA, Changed = @Changed, UserId = @UserId WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_CODIGO = Planocontas.PLA_CODIGO,
                PLA_DESCRICAO = Planocontas.PLA_DESCRICAO,
                PLA_TIPO = Planocontas.PLA_TIPO,
                PLA_NATUREZA = Planocontas.PLA_NATUREZA,
                Changed = Planocontas.Changed,
                UserId = _executionContext.UserId,
                PLA_ID = Planocontas.PLA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_CODIGO(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planocontas SET PLA_CODIGO = @PLA_CODIGO WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_CODIGO = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_DESCRICAO(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planocontas SET PLA_DESCRICAO = @PLA_DESCRICAO WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_DESCRICAO = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_TIPO(int pla_id, int value)
        {
            this.Query = $@" UPDATE Planocontas SET PLA_TIPO = @PLA_TIPO WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_TIPO = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_NATUREZA(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planocontas SET PLA_NATUREZA = @PLA_NATUREZA WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_NATUREZA = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int pla_id, int value)
        {
            this.Query = $@" UPDATE Planocontas SET TenantID = @TenantID WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                TenantID = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int pla_id, bool value)
        {
            this.Query = $@" UPDATE Planocontas SET Deleted = @Deleted WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                Deleted = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int pla_id, DateTime value)
        {
            this.Query = $@" UPDATE Planocontas SET Changed = @Changed WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                Changed = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int pla_id, int value)
        {
            this.Query = $@" UPDATE Planocontas SET UserId = @UserId WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                UserId = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePlanocontasQuery(IPlanocontasEntity Planocontas)
        {
            this.Query = $@" DELETE FROM Planocontas WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_ID = Planocontas.PLA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration