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
    public class EstradasQueryWrite : QueryBase, IEstradasQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EstradasQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEstradasQuery(IEstradasEntity Estradas)
        {
            this.Query = $@" INSERT INTO Estradas (EST_ID, EST_DESCRICAO, EST_ID_LIGACAO_PONTO_A, EST_ID_LIGACAO_PONTO_B, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@EST_ID, @EST_DESCRICAO, @EST_ID_LIGACAO_PONTO_A, @EST_ID_LIGACAO_PONTO_B, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                EST_ID = Estradas.EST_ID,
                EST_DESCRICAO = Estradas.EST_DESCRICAO,
                EST_ID_LIGACAO_PONTO_A = Estradas.EST_ID_LIGACAO_PONTO_A,
                EST_ID_LIGACAO_PONTO_B = Estradas.EST_ID_LIGACAO_PONTO_B,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEstradasQuery(IEstradasEntity Estradas)
        {
            this.Query = $@" UPDATE Estradas SET EST_ID = @EST_ID, EST_DESCRICAO = @EST_DESCRICAO, EST_ID_LIGACAO_PONTO_A = @EST_ID_LIGACAO_PONTO_A, EST_ID_LIGACAO_PONTO_B = @EST_ID_LIGACAO_PONTO_B, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_ID = Estradas.EST_ID,
                EST_DESCRICAO = Estradas.EST_DESCRICAO,
                EST_ID_LIGACAO_PONTO_A = Estradas.EST_ID_LIGACAO_PONTO_A,
                EST_ID_LIGACAO_PONTO_B = Estradas.EST_ID_LIGACAO_PONTO_B,
                Changed = Estradas.Changed,
                UserId = _executionContext.UserId,
                Id = Estradas.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_ID(int id, int value)
        {
            this.Query = $@" UPDATE Estradas SET EST_ID = @EST_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE Estradas SET EST_DESCRICAO = @EST_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_ID_LIGACAO_PONTO_A(int id, int value)
        {
            this.Query = $@" UPDATE Estradas SET EST_ID_LIGACAO_PONTO_A = @EST_ID_LIGACAO_PONTO_A WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_ID_LIGACAO_PONTO_A = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_ID_LIGACAO_PONTO_B(int id, int value)
        {
            this.Query = $@" UPDATE Estradas SET EST_ID_LIGACAO_PONTO_B = @EST_ID_LIGACAO_PONTO_B WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_ID_LIGACAO_PONTO_B = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Estradas SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Estradas SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Estradas SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Estradas SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEstradasQuery(IEstradasEntity Estradas)
        {
            this.Query = $@" DELETE FROM Estradas WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Estradas.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration