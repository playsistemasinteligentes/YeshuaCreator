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
    public class PlotagemQueryWrite : QueryBase, IPlotagemQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PlotagemQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPlotagemQuery(IPlotagemEntity Plotagem)
        {
            this.Query = $@" INSERT INTO Plotagem (PLO_ID, PLO_NOME, PLO_DIMENSAO, PLO_X, PLO_Y, PLO_Z, PLO_GRAFICO, CON_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PLO_ID, @PLO_NOME, @PLO_DIMENSAO, @PLO_X, @PLO_Y, @PLO_Z, @PLO_GRAFICO, @CON_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PLO_ID = Plotagem.PLO_ID,
                PLO_NOME = Plotagem.PLO_NOME,
                PLO_DIMENSAO = Plotagem.PLO_DIMENSAO,
                PLO_X = Plotagem.PLO_X,
                PLO_Y = Plotagem.PLO_Y,
                PLO_Z = Plotagem.PLO_Z,
                PLO_GRAFICO = Plotagem.PLO_GRAFICO,
                CON_ID = Plotagem.CON_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlotagemQuery(IPlotagemEntity Plotagem)
        {
            this.Query = $@" UPDATE Plotagem SET PLO_ID = @PLO_ID, PLO_NOME = @PLO_NOME, PLO_DIMENSAO = @PLO_DIMENSAO, PLO_X = @PLO_X, PLO_Y = @PLO_Y, PLO_Z = @PLO_Z, PLO_GRAFICO = @PLO_GRAFICO, CON_ID = @CON_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                PLO_ID = Plotagem.PLO_ID,
                PLO_NOME = Plotagem.PLO_NOME,
                PLO_DIMENSAO = Plotagem.PLO_DIMENSAO,
                PLO_X = Plotagem.PLO_X,
                PLO_Y = Plotagem.PLO_Y,
                PLO_Z = Plotagem.PLO_Z,
                PLO_GRAFICO = Plotagem.PLO_GRAFICO,
                CON_ID = Plotagem.CON_ID,
                Changed = Plotagem.Changed,
                UserId = _executionContext.UserId,
                Id = Plotagem.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLO_ID(int id, int value)
        {
            this.Query = $@" UPDATE Plotagem SET PLO_ID = @PLO_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PLO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLO_NOME(int id, string value)
        {
            this.Query = $@" UPDATE Plotagem SET PLO_NOME = @PLO_NOME WHERE Id = @Id ";
            this.Parameters = new
            {
                PLO_NOME = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLO_DIMENSAO(int id, string value)
        {
            this.Query = $@" UPDATE Plotagem SET PLO_DIMENSAO = @PLO_DIMENSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PLO_DIMENSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLO_X(int id, string value)
        {
            this.Query = $@" UPDATE Plotagem SET PLO_X = @PLO_X WHERE Id = @Id ";
            this.Parameters = new
            {
                PLO_X = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLO_Y(int id, string value)
        {
            this.Query = $@" UPDATE Plotagem SET PLO_Y = @PLO_Y WHERE Id = @Id ";
            this.Parameters = new
            {
                PLO_Y = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLO_Z(int id, string value)
        {
            this.Query = $@" UPDATE Plotagem SET PLO_Z = @PLO_Z WHERE Id = @Id ";
            this.Parameters = new
            {
                PLO_Z = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLO_GRAFICO(int id, string value)
        {
            this.Query = $@" UPDATE Plotagem SET PLO_GRAFICO = @PLO_GRAFICO WHERE Id = @Id ";
            this.Parameters = new
            {
                PLO_GRAFICO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCON_ID(int id, int value)
        {
            this.Query = $@" UPDATE Plotagem SET CON_ID = @CON_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CON_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Plotagem SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Plotagem SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Plotagem SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Plotagem SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePlotagemQuery(IPlotagemEntity Plotagem)
        {
            this.Query = $@" DELETE FROM Plotagem WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Plotagem.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration