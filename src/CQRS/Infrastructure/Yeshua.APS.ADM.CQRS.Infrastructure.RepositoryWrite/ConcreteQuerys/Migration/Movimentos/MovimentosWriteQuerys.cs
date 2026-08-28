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
    public class MovimentosQueryWrite : QueryBase, IMovimentosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MovimentosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMovimentosQuery(IMovimentosEntity Movimentos)
        {
            this.Query = $@" INSERT INTO Movimentos (MOV_DATA, MOV_VALOR, MOV_PLAID, MOV_UNID, Tr_Unidade_UNI_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.MOV_ID VALUES(@MOV_DATA, @MOV_VALOR, @MOV_PLAID, @MOV_UNID, @Tr_Unidade_UNI_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MOV_DATA = Movimentos.MOV_DATA,
                MOV_VALOR = Movimentos.MOV_VALOR,
                MOV_PLAID = Movimentos.MOV_PLAID,
                MOV_UNID = Movimentos.MOV_UNID,
                Tr_Unidade_UNI_ID = Movimentos.Tr_Unidade_UNI_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMovimentosQuery(IMovimentosEntity Movimentos)
        {
            this.Query = $@" UPDATE Movimentos SET MOV_DATA = @MOV_DATA, MOV_VALOR = @MOV_VALOR, MOV_PLAID = @MOV_PLAID, MOV_UNID = @MOV_UNID, Tr_Unidade_UNI_ID = @Tr_Unidade_UNI_ID, Changed = @Changed, UserId = @UserId WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                MOV_DATA = Movimentos.MOV_DATA,
                MOV_VALOR = Movimentos.MOV_VALOR,
                MOV_PLAID = Movimentos.MOV_PLAID,
                MOV_UNID = Movimentos.MOV_UNID,
                Tr_Unidade_UNI_ID = Movimentos.Tr_Unidade_UNI_ID,
                Changed = Movimentos.Changed,
                UserId = _executionContext.UserId,
                MOV_ID = Movimentos.MOV_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_DATA(int mov_id, string value)
        {
            this.Query = $@" UPDATE Movimentos SET MOV_DATA = @MOV_DATA WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                MOV_DATA = value,
                MOV_ID = mov_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_VALOR(int mov_id, Decimal value)
        {
            this.Query = $@" UPDATE Movimentos SET MOV_VALOR = @MOV_VALOR WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                MOV_VALOR = value,
                MOV_ID = mov_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_PLAID(int mov_id, int value)
        {
            this.Query = $@" UPDATE Movimentos SET MOV_PLAID = @MOV_PLAID WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                MOV_PLAID = value,
                MOV_ID = mov_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_UNID(int mov_id, int value)
        {
            this.Query = $@" UPDATE Movimentos SET MOV_UNID = @MOV_UNID WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                MOV_UNID = value,
                MOV_ID = mov_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTr_Unidade_UNI_ID(int mov_id, int value)
        {
            this.Query = $@" UPDATE Movimentos SET Tr_Unidade_UNI_ID = @Tr_Unidade_UNI_ID WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                Tr_Unidade_UNI_ID = value,
                MOV_ID = mov_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int mov_id, int value)
        {
            this.Query = $@" UPDATE Movimentos SET TenantID = @TenantID WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                TenantID = value,
                MOV_ID = mov_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int mov_id, bool value)
        {
            this.Query = $@" UPDATE Movimentos SET Deleted = @Deleted WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                Deleted = value,
                MOV_ID = mov_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int mov_id, DateTime value)
        {
            this.Query = $@" UPDATE Movimentos SET Changed = @Changed WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                Changed = value,
                MOV_ID = mov_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int mov_id, int value)
        {
            this.Query = $@" UPDATE Movimentos SET UserId = @UserId WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                UserId = value,
                MOV_ID = mov_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMovimentosQuery(IMovimentosEntity Movimentos)
        {
            this.Query = $@" DELETE FROM Movimentos WHERE MOV_ID = @MOV_ID ";
            this.Parameters = new
            {
                MOV_ID = Movimentos.MOV_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration