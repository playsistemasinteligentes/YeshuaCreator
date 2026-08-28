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
    public class OperacoesQueryWrite : QueryBase, IOperacoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public OperacoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirOperacoesQuery(IOperacoesEntity Operacoes)
        {
            this.Query = $@" INSERT INTO Operacoes (OPE_TIPO_REGISTRO, OPE_ID, GMA_ID, MAQ_ID, PRO_ID, OPE_EXCECAO, ROT_SEQ_TRANFORMACAO, ORD_ID, FPR_SEQ_REPETICAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@OPE_TIPO_REGISTRO, @OPE_ID, @GMA_ID, @MAQ_ID, @PRO_ID, @OPE_EXCECAO, @ROT_SEQ_TRANFORMACAO, @ORD_ID, @FPR_SEQ_REPETICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                OPE_TIPO_REGISTRO = Operacoes.OPE_TIPO_REGISTRO,
                OPE_ID = Operacoes.OPE_ID,
                GMA_ID = Operacoes.GMA_ID,
                MAQ_ID = Operacoes.MAQ_ID,
                PRO_ID = Operacoes.PRO_ID,
                OPE_EXCECAO = Operacoes.OPE_EXCECAO,
                ROT_SEQ_TRANFORMACAO = Operacoes.ROT_SEQ_TRANFORMACAO,
                ORD_ID = Operacoes.ORD_ID,
                FPR_SEQ_REPETICAO = Operacoes.FPR_SEQ_REPETICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperacoesQuery(IOperacoesEntity Operacoes)
        {
            this.Query = $@" UPDATE Operacoes SET OPE_TIPO_REGISTRO = @OPE_TIPO_REGISTRO, OPE_ID = @OPE_ID, GMA_ID = @GMA_ID, MAQ_ID = @MAQ_ID, PRO_ID = @PRO_ID, OPE_EXCECAO = @OPE_EXCECAO, ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO, ORD_ID = @ORD_ID, FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                OPE_TIPO_REGISTRO = Operacoes.OPE_TIPO_REGISTRO,
                OPE_ID = Operacoes.OPE_ID,
                GMA_ID = Operacoes.GMA_ID,
                MAQ_ID = Operacoes.MAQ_ID,
                PRO_ID = Operacoes.PRO_ID,
                OPE_EXCECAO = Operacoes.OPE_EXCECAO,
                ROT_SEQ_TRANFORMACAO = Operacoes.ROT_SEQ_TRANFORMACAO,
                ORD_ID = Operacoes.ORD_ID,
                FPR_SEQ_REPETICAO = Operacoes.FPR_SEQ_REPETICAO,
                Changed = Operacoes.Changed,
                UserId = _executionContext.UserId,
                Id = Operacoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOPE_TIPO_REGISTRO(int id, string value)
        {
            this.Query = $@" UPDATE Operacoes SET OPE_TIPO_REGISTRO = @OPE_TIPO_REGISTRO WHERE Id = @Id ";
            this.Parameters = new
            {
                OPE_TIPO_REGISTRO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOPE_ID(int id, string value)
        {
            this.Query = $@" UPDATE Operacoes SET OPE_ID = @OPE_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                OPE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGMA_ID(int id, string value)
        {
            this.Query = $@" UPDATE Operacoes SET GMA_ID = @GMA_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                GMA_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int id, string value)
        {
            this.Query = $@" UPDATE Operacoes SET MAQ_ID = @MAQ_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int id, string value)
        {
            this.Query = $@" UPDATE Operacoes SET PRO_ID = @PRO_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOPE_EXCECAO(int id, string value)
        {
            this.Query = $@" UPDATE Operacoes SET OPE_EXCECAO = @OPE_EXCECAO WHERE Id = @Id ";
            this.Parameters = new
            {
                OPE_EXCECAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_SEQ_TRANFORMACAO(int id, int value)
        {
            this.Query = $@" UPDATE Operacoes SET ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_SEQ_TRANFORMACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int id, string value)
        {
            this.Query = $@" UPDATE Operacoes SET ORD_ID = @ORD_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ORD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_REPETICAO(int id, int value)
        {
            this.Query = $@" UPDATE Operacoes SET FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_SEQ_REPETICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Operacoes SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Operacoes SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Operacoes SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Operacoes SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteOperacoesQuery(IOperacoesEntity Operacoes)
        {
            this.Query = $@" DELETE FROM Operacoes WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Operacoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration