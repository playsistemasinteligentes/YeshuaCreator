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
    public class MemoriaDeCalculoQueryWrite : QueryBase, IMemoriaDeCalculoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MemoriaDeCalculoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMemoriaDeCalculoQuery(IMemoriaDeCalculoEntity MemoriaDeCalculo)
        {
            this.Query = $@" INSERT INTO MemoriaDeCalculo (MEM_ID, ORC_ID, MEM_VALOR, MEM_DESCRICAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@MEM_ID, @ORC_ID, @MEM_VALOR, @MEM_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MEM_ID = MemoriaDeCalculo.MEM_ID,
                ORC_ID = MemoriaDeCalculo.ORC_ID,
                MEM_VALOR = MemoriaDeCalculo.MEM_VALOR,
                MEM_DESCRICAO = MemoriaDeCalculo.MEM_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMemoriaDeCalculoQuery(IMemoriaDeCalculoEntity MemoriaDeCalculo)
        {
            this.Query = $@" UPDATE MemoriaDeCalculo SET MEM_ID = @MEM_ID, ORC_ID = @ORC_ID, MEM_VALOR = @MEM_VALOR, MEM_DESCRICAO = @MEM_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                MEM_ID = MemoriaDeCalculo.MEM_ID,
                ORC_ID = MemoriaDeCalculo.ORC_ID,
                MEM_VALOR = MemoriaDeCalculo.MEM_VALOR,
                MEM_DESCRICAO = MemoriaDeCalculo.MEM_DESCRICAO,
                Changed = MemoriaDeCalculo.Changed,
                UserId = _executionContext.UserId,
                Id = MemoriaDeCalculo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEM_ID(int id, int value)
        {
            this.Query = $@" UPDATE MemoriaDeCalculo SET MEM_ID = @MEM_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                MEM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORC_ID(int id, int value)
        {
            this.Query = $@" UPDATE MemoriaDeCalculo SET ORC_ID = @ORC_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ORC_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEM_VALOR(int id, Decimal value)
        {
            this.Query = $@" UPDATE MemoriaDeCalculo SET MEM_VALOR = @MEM_VALOR WHERE Id = @Id ";
            this.Parameters = new
            {
                MEM_VALOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEM_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE MemoriaDeCalculo SET MEM_DESCRICAO = @MEM_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MEM_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE MemoriaDeCalculo SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE MemoriaDeCalculo SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE MemoriaDeCalculo SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE MemoriaDeCalculo SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMemoriaDeCalculoQuery(IMemoriaDeCalculoEntity MemoriaDeCalculo)
        {
            this.Query = $@" DELETE FROM MemoriaDeCalculo WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = MemoriaDeCalculo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration