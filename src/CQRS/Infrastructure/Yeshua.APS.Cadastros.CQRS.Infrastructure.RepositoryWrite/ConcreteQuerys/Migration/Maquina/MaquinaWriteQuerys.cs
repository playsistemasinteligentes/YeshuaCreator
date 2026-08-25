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
    public class MaquinaQueryWrite : QueryBase, IMaquinaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MaquinaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMaquinaQuery(IMaquinaEntity Maquina)
        {
            this.Query = $@" INSERT INTO Maquina (MAQ_ID, MAQ_DESCRICAO, MAQ_STATUS, TenantID, Deleted, Changed, UserId) VALUES(@MAQ_ID, @MAQ_DESCRICAO, @MAQ_STATUS, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MAQ_ID = Maquina.MAQ_ID,
                MAQ_DESCRICAO = Maquina.MAQ_DESCRICAO,
                MAQ_STATUS = Maquina.MAQ_STATUS,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMaquinaQuery(IMaquinaEntity Maquina)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_DESCRICAO = @MAQ_DESCRICAO, MAQ_STATUS = @MAQ_STATUS, Changed = @Changed, UserId = @UserId WHERE MAQ_ID = @MAQ_ID ";
            this.Parameters = new
            {
                MAQ_DESCRICAO = Maquina.MAQ_DESCRICAO,
                MAQ_STATUS = Maquina.MAQ_STATUS,
                Changed = Maquina.Changed,
                UserId = _executionContext.UserId,
                MAQ_ID = Maquina.MAQ_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_DESCRICAO(string maq_id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_DESCRICAO = @MAQ_DESCRICAO WHERE MAQ_ID = @MAQ_ID ";
            this.Parameters = new
            {
                MAQ_DESCRICAO = value,
                MAQ_ID = maq_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_STATUS(string maq_id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_STATUS = @MAQ_STATUS WHERE MAQ_ID = @MAQ_ID ";
            this.Parameters = new
            {
                MAQ_STATUS = value,
                MAQ_ID = maq_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string maq_id, int value)
        {
            this.Query = $@" UPDATE Maquina SET TenantID = @TenantID WHERE MAQ_ID = @MAQ_ID ";
            this.Parameters = new
            {
                TenantID = value,
                MAQ_ID = maq_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string maq_id, bool value)
        {
            this.Query = $@" UPDATE Maquina SET Deleted = @Deleted WHERE MAQ_ID = @MAQ_ID ";
            this.Parameters = new
            {
                Deleted = value,
                MAQ_ID = maq_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string maq_id, DateTime value)
        {
            this.Query = $@" UPDATE Maquina SET Changed = @Changed WHERE MAQ_ID = @MAQ_ID ";
            this.Parameters = new
            {
                Changed = value,
                MAQ_ID = maq_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string maq_id, int value)
        {
            this.Query = $@" UPDATE Maquina SET UserId = @UserId WHERE MAQ_ID = @MAQ_ID ";
            this.Parameters = new
            {
                UserId = value,
                MAQ_ID = maq_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMaquinaQuery(IMaquinaEntity Maquina)
        {
            this.Query = $@" DELETE FROM Maquina WHERE MAQ_ID = @MAQ_ID ";
            this.Parameters = new
            {
                MAQ_ID = Maquina.MAQ_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration