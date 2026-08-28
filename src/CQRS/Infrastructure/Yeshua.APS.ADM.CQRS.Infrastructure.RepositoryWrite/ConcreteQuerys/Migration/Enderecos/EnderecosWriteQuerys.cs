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
    public class EnderecosQueryWrite : QueryBase, IEnderecosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EnderecosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEnderecosQuery(IEnderecosEntity Enderecos)
        {
            this.Query = $@" INSERT INTO Enderecos (END_ID, END_GRUPO, TenantID, Deleted, Changed, UserId) VALUES(@END_ID, @END_GRUPO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                END_ID = Enderecos.END_ID,
                END_GRUPO = Enderecos.END_GRUPO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEnderecosQuery(IEnderecosEntity Enderecos)
        {
            this.Query = $@" UPDATE Enderecos SET END_GRUPO = @END_GRUPO, Changed = @Changed, UserId = @UserId WHERE END_ID = @END_ID ";
            this.Parameters = new
            {
                END_GRUPO = Enderecos.END_GRUPO,
                Changed = Enderecos.Changed,
                UserId = _executionContext.UserId,
                END_ID = Enderecos.END_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEND_GRUPO(string end_id, string value)
        {
            this.Query = $@" UPDATE Enderecos SET END_GRUPO = @END_GRUPO WHERE END_ID = @END_ID ";
            this.Parameters = new
            {
                END_GRUPO = value,
                END_ID = end_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string end_id, int value)
        {
            this.Query = $@" UPDATE Enderecos SET TenantID = @TenantID WHERE END_ID = @END_ID ";
            this.Parameters = new
            {
                TenantID = value,
                END_ID = end_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string end_id, bool value)
        {
            this.Query = $@" UPDATE Enderecos SET Deleted = @Deleted WHERE END_ID = @END_ID ";
            this.Parameters = new
            {
                Deleted = value,
                END_ID = end_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string end_id, DateTime value)
        {
            this.Query = $@" UPDATE Enderecos SET Changed = @Changed WHERE END_ID = @END_ID ";
            this.Parameters = new
            {
                Changed = value,
                END_ID = end_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string end_id, int value)
        {
            this.Query = $@" UPDATE Enderecos SET UserId = @UserId WHERE END_ID = @END_ID ";
            this.Parameters = new
            {
                UserId = value,
                END_ID = end_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEnderecosQuery(IEnderecosEntity Enderecos)
        {
            this.Query = $@" DELETE FROM Enderecos WHERE END_ID = @END_ID ";
            this.Parameters = new
            {
                END_ID = Enderecos.END_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration