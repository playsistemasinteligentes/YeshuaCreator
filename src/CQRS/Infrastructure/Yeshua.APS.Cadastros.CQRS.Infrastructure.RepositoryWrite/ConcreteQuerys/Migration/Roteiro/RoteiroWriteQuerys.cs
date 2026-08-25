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
    public class RoteiroQueryWrite : QueryBase, IRoteiroQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RoteiroQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRoteiroQuery(IRoteiroEntity Roteiro)
        {
            this.Query = $@" INSERT INTO Roteiro (MAQ_ID, PRO_ID, ROT_SEQ_TRANFORMACAO, GMA_ID, ROT_PECAS_POR_PULSO, ROT_PRIORIDADE_INFORMADA, ROT_ACAO, ROT_PERFORMANCE, ROT_TEMPO_SETUP, ROT_TEMPO_SETUP_AJUSTE, ROT_VA_PARA_SEQ_TRANSFORMACAO, ROT_STATUS, ROT_HIERARQUIA_SEQ_TRANSFORMACAO, ROT_AVALIA_CUSTO, ROT_OPERACOES, ROT_EXCECAO_OPERACOES, ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR, ROT_LINHA_DIRETA, TEM_ID, TenantID, Deleted, Changed, UserId) VALUES(@MAQ_ID, @PRO_ID, @ROT_SEQ_TRANFORMACAO, @GMA_ID, @ROT_PECAS_POR_PULSO, @ROT_PRIORIDADE_INFORMADA, @ROT_ACAO, @ROT_PERFORMANCE, @ROT_TEMPO_SETUP, @ROT_TEMPO_SETUP_AJUSTE, @ROT_VA_PARA_SEQ_TRANSFORMACAO, @ROT_STATUS, @ROT_HIERARQUIA_SEQ_TRANSFORMACAO, @ROT_AVALIA_CUSTO, @ROT_OPERACOES, @ROT_EXCECAO_OPERACOES, @ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR, @ROT_LINHA_DIRETA, @TEM_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MAQ_ID = Roteiro.MAQ_ID,
                PRO_ID = Roteiro.PRO_ID,
                ROT_SEQ_TRANFORMACAO = Roteiro.ROT_SEQ_TRANFORMACAO,
                GMA_ID = Roteiro.GMA_ID,
                ROT_PECAS_POR_PULSO = Roteiro.ROT_PECAS_POR_PULSO,
                ROT_PRIORIDADE_INFORMADA = Roteiro.ROT_PRIORIDADE_INFORMADA,
                ROT_ACAO = Roteiro.ROT_ACAO,
                ROT_PERFORMANCE = Roteiro.ROT_PERFORMANCE,
                ROT_TEMPO_SETUP = Roteiro.ROT_TEMPO_SETUP,
                ROT_TEMPO_SETUP_AJUSTE = Roteiro.ROT_TEMPO_SETUP_AJUSTE,
                ROT_VA_PARA_SEQ_TRANSFORMACAO = Roteiro.ROT_VA_PARA_SEQ_TRANSFORMACAO,
                ROT_STATUS = Roteiro.ROT_STATUS,
                ROT_HIERARQUIA_SEQ_TRANSFORMACAO = Roteiro.ROT_HIERARQUIA_SEQ_TRANSFORMACAO,
                ROT_AVALIA_CUSTO = Roteiro.ROT_AVALIA_CUSTO,
                ROT_OPERACOES = Roteiro.ROT_OPERACOES,
                ROT_EXCECAO_OPERACOES = Roteiro.ROT_EXCECAO_OPERACOES,
                ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR = Roteiro.ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR,
                ROT_LINHA_DIRETA = Roteiro.ROT_LINHA_DIRETA,
                TEM_ID = Roteiro.TEM_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRoteiroQuery(IRoteiroEntity Roteiro)
        {
            this.Query = $@" UPDATE Roteiro SET GMA_ID = @GMA_ID, ROT_PECAS_POR_PULSO = @ROT_PECAS_POR_PULSO, ROT_PRIORIDADE_INFORMADA = @ROT_PRIORIDADE_INFORMADA, ROT_ACAO = @ROT_ACAO, ROT_PERFORMANCE = @ROT_PERFORMANCE, ROT_TEMPO_SETUP = @ROT_TEMPO_SETUP, ROT_TEMPO_SETUP_AJUSTE = @ROT_TEMPO_SETUP_AJUSTE, ROT_VA_PARA_SEQ_TRANSFORMACAO = @ROT_VA_PARA_SEQ_TRANSFORMACAO, ROT_STATUS = @ROT_STATUS, ROT_HIERARQUIA_SEQ_TRANSFORMACAO = @ROT_HIERARQUIA_SEQ_TRANSFORMACAO, ROT_AVALIA_CUSTO = @ROT_AVALIA_CUSTO, ROT_OPERACOES = @ROT_OPERACOES, ROT_EXCECAO_OPERACOES = @ROT_EXCECAO_OPERACOES, ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR = @ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR, ROT_LINHA_DIRETA = @ROT_LINHA_DIRETA, TEM_ID = @TEM_ID, Changed = @Changed, UserId = @UserId WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                GMA_ID = Roteiro.GMA_ID,
                ROT_PECAS_POR_PULSO = Roteiro.ROT_PECAS_POR_PULSO,
                ROT_PRIORIDADE_INFORMADA = Roteiro.ROT_PRIORIDADE_INFORMADA,
                ROT_ACAO = Roteiro.ROT_ACAO,
                ROT_PERFORMANCE = Roteiro.ROT_PERFORMANCE,
                ROT_TEMPO_SETUP = Roteiro.ROT_TEMPO_SETUP,
                ROT_TEMPO_SETUP_AJUSTE = Roteiro.ROT_TEMPO_SETUP_AJUSTE,
                ROT_VA_PARA_SEQ_TRANSFORMACAO = Roteiro.ROT_VA_PARA_SEQ_TRANSFORMACAO,
                ROT_STATUS = Roteiro.ROT_STATUS,
                ROT_HIERARQUIA_SEQ_TRANSFORMACAO = Roteiro.ROT_HIERARQUIA_SEQ_TRANSFORMACAO,
                ROT_AVALIA_CUSTO = Roteiro.ROT_AVALIA_CUSTO,
                ROT_OPERACOES = Roteiro.ROT_OPERACOES,
                ROT_EXCECAO_OPERACOES = Roteiro.ROT_EXCECAO_OPERACOES,
                ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR = Roteiro.ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR,
                ROT_LINHA_DIRETA = Roteiro.ROT_LINHA_DIRETA,
                TEM_ID = Roteiro.TEM_ID,
                Changed = Roteiro.Changed,
                UserId = _executionContext.UserId,
                MAQ_ID = Roteiro.MAQ_ID,
                PRO_ID = Roteiro.PRO_ID,
                ROT_SEQ_TRANFORMACAO = Roteiro.ROT_SEQ_TRANFORMACAO,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGMA_ID(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET GMA_ID = @GMA_ID WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                GMA_ID = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_PECAS_POR_PULSO(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_PECAS_POR_PULSO = @ROT_PECAS_POR_PULSO WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_PECAS_POR_PULSO = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_PRIORIDADE_INFORMADA(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_PRIORIDADE_INFORMADA = @ROT_PRIORIDADE_INFORMADA WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_PRIORIDADE_INFORMADA = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_ACAO(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_ACAO = @ROT_ACAO WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_ACAO = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_PERFORMANCE(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_PERFORMANCE = @ROT_PERFORMANCE WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_PERFORMANCE = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_TEMPO_SETUP(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_TEMPO_SETUP = @ROT_TEMPO_SETUP WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_TEMPO_SETUP = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_TEMPO_SETUP_AJUSTE(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_TEMPO_SETUP_AJUSTE = @ROT_TEMPO_SETUP_AJUSTE WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_TEMPO_SETUP_AJUSTE = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_VA_PARA_SEQ_TRANSFORMACAO(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_VA_PARA_SEQ_TRANSFORMACAO = @ROT_VA_PARA_SEQ_TRANSFORMACAO WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_VA_PARA_SEQ_TRANSFORMACAO = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_STATUS(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_STATUS = @ROT_STATUS WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_STATUS = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_HIERARQUIA_SEQ_TRANSFORMACAO(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_HIERARQUIA_SEQ_TRANSFORMACAO = @ROT_HIERARQUIA_SEQ_TRANSFORMACAO WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_HIERARQUIA_SEQ_TRANSFORMACAO = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_AVALIA_CUSTO(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_AVALIA_CUSTO = @ROT_AVALIA_CUSTO WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_AVALIA_CUSTO = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_OPERACOES(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_OPERACOES = @ROT_OPERACOES WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_OPERACOES = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_EXCECAO_OPERACOES(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_EXCECAO_OPERACOES = @ROT_EXCECAO_OPERACOES WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_EXCECAO_OPERACOES = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR = @ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_LINHA_DIRETA(string maq_id, string pro_id, int rot_seq_tranformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET ROT_LINHA_DIRETA = @ROT_LINHA_DIRETA WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                ROT_LINHA_DIRETA = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_ID(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET TEM_ID = @TEM_ID WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                TEM_ID = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET TenantID = @TenantID WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                TenantID = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string maq_id, string pro_id, int rot_seq_tranformacao, bool value)
        {
            this.Query = $@" UPDATE Roteiro SET Deleted = @Deleted WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                Deleted = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string maq_id, string pro_id, int rot_seq_tranformacao, DateTime value)
        {
            this.Query = $@" UPDATE Roteiro SET Changed = @Changed WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                Changed = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string maq_id, string pro_id, int rot_seq_tranformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET UserId = @UserId WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                UserId = value,
                MAQ_ID = maq_id,
                PRO_ID = pro_id,
                ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRoteiroQuery(IRoteiroEntity Roteiro)
        {
            this.Query = $@" DELETE FROM Roteiro WHERE MAQ_ID = @MAQ_ID AND PRO_ID = @PRO_ID AND ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ";
            this.Parameters = new
            {
                MAQ_ID = Roteiro.MAQ_ID,
                PRO_ID = Roteiro.PRO_ID,
                ROT_SEQ_TRANFORMACAO = Roteiro.ROT_SEQ_TRANFORMACAO,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration