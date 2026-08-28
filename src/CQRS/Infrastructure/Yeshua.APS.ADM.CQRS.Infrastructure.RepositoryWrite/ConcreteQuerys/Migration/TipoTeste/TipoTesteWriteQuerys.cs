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
    public class TipoTesteQueryWrite : QueryBase, ITipoTesteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoTesteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoTesteQuery(ITipoTesteEntity TipoTeste)
        {
            this.Query = $@" INSERT INTO TipoTeste (TT_ESPECIFICACAO, TT_ORIGEM_ESPECIFICACAO, TT_IMPRIME_NO_LAUDO, TenantID, Deleted, Changed, UserId, TT_NOME, TT_DESC, TT_TOL_MAIS, TT_TOL_MENOS, TT_NORMA, TT_INICIO_PROCESSO, TA_ID, UNI_ID, TT_N_AMOSTRAS_P_TESTE, TT_MAX_DEF_CRITICO, TT_MAX_DEF_GRAVE) OUTPUT INSERTED.TT_ID VALUES(@TT_ESPECIFICACAO, @TT_ORIGEM_ESPECIFICACAO, @TT_IMPRIME_NO_LAUDO, @TenantID, @Deleted, @Changed, @UserId, @TT_NOME, @TT_DESC, @TT_TOL_MAIS, @TT_TOL_MENOS, @TT_NORMA, @TT_INICIO_PROCESSO, @TA_ID, @UNI_ID, @TT_N_AMOSTRAS_P_TESTE, @TT_MAX_DEF_CRITICO, @TT_MAX_DEF_GRAVE) ";
            this.Parameters = new
            {
                TT_ESPECIFICACAO = TipoTeste.TT_ESPECIFICACAO,
                TT_ORIGEM_ESPECIFICACAO = TipoTeste.TT_ORIGEM_ESPECIFICACAO,
                TT_IMPRIME_NO_LAUDO = TipoTeste.TT_IMPRIME_NO_LAUDO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                TT_NOME = TipoTeste.TT_NOME,
                TT_DESC = TipoTeste.TT_DESC,
                TT_TOL_MAIS = TipoTeste.TT_TOL_MAIS,
                TT_TOL_MENOS = TipoTeste.TT_TOL_MENOS,
                TT_NORMA = TipoTeste.TT_NORMA,
                TT_INICIO_PROCESSO = TipoTeste.TT_INICIO_PROCESSO,
                TA_ID = TipoTeste.TA_ID,
                UNI_ID = TipoTeste.UNI_ID,
                TT_N_AMOSTRAS_P_TESTE = TipoTeste.TT_N_AMOSTRAS_P_TESTE,
                TT_MAX_DEF_CRITICO = TipoTeste.TT_MAX_DEF_CRITICO,
                TT_MAX_DEF_GRAVE = TipoTeste.TT_MAX_DEF_GRAVE,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoTesteQuery(ITipoTesteEntity TipoTeste)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_ESPECIFICACAO = @TT_ESPECIFICACAO, TT_ORIGEM_ESPECIFICACAO = @TT_ORIGEM_ESPECIFICACAO, TT_IMPRIME_NO_LAUDO = @TT_IMPRIME_NO_LAUDO, Changed = @Changed, UserId = @UserId, TT_NOME = @TT_NOME, TT_DESC = @TT_DESC, TT_TOL_MAIS = @TT_TOL_MAIS, TT_TOL_MENOS = @TT_TOL_MENOS, TT_NORMA = @TT_NORMA, TT_INICIO_PROCESSO = @TT_INICIO_PROCESSO, TA_ID = @TA_ID, UNI_ID = @UNI_ID, TT_N_AMOSTRAS_P_TESTE = @TT_N_AMOSTRAS_P_TESTE, TT_MAX_DEF_CRITICO = @TT_MAX_DEF_CRITICO, TT_MAX_DEF_GRAVE = @TT_MAX_DEF_GRAVE WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_ESPECIFICACAO = TipoTeste.TT_ESPECIFICACAO,
                TT_ORIGEM_ESPECIFICACAO = TipoTeste.TT_ORIGEM_ESPECIFICACAO,
                TT_IMPRIME_NO_LAUDO = TipoTeste.TT_IMPRIME_NO_LAUDO,
                Changed = TipoTeste.Changed,
                UserId = _executionContext.UserId,
                TT_NOME = TipoTeste.TT_NOME,
                TT_DESC = TipoTeste.TT_DESC,
                TT_TOL_MAIS = TipoTeste.TT_TOL_MAIS,
                TT_TOL_MENOS = TipoTeste.TT_TOL_MENOS,
                TT_NORMA = TipoTeste.TT_NORMA,
                TT_INICIO_PROCESSO = TipoTeste.TT_INICIO_PROCESSO,
                TA_ID = TipoTeste.TA_ID,
                UNI_ID = TipoTeste.UNI_ID,
                TT_N_AMOSTRAS_P_TESTE = TipoTeste.TT_N_AMOSTRAS_P_TESTE,
                TT_MAX_DEF_CRITICO = TipoTeste.TT_MAX_DEF_CRITICO,
                TT_MAX_DEF_GRAVE = TipoTeste.TT_MAX_DEF_GRAVE,
                TT_ID = TipoTeste.TT_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_ESPECIFICACAO(int tt_id, Decimal value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_ESPECIFICACAO = @TT_ESPECIFICACAO WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_ESPECIFICACAO = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_ORIGEM_ESPECIFICACAO(int tt_id, string value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_ORIGEM_ESPECIFICACAO = @TT_ORIGEM_ESPECIFICACAO WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_ORIGEM_ESPECIFICACAO = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_IMPRIME_NO_LAUDO(int tt_id, string value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_IMPRIME_NO_LAUDO = @TT_IMPRIME_NO_LAUDO WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_IMPRIME_NO_LAUDO = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int tt_id, int value)
        {
            this.Query = $@" UPDATE TipoTeste SET TenantID = @TenantID WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TenantID = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int tt_id, bool value)
        {
            this.Query = $@" UPDATE TipoTeste SET Deleted = @Deleted WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                Deleted = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int tt_id, DateTime value)
        {
            this.Query = $@" UPDATE TipoTeste SET Changed = @Changed WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                Changed = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int tt_id, int value)
        {
            this.Query = $@" UPDATE TipoTeste SET UserId = @UserId WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                UserId = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_NOME(int tt_id, string value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_NOME = @TT_NOME WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_NOME = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_DESC(int tt_id, string value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_DESC = @TT_DESC WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_DESC = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_TOL_MAIS(int tt_id, Decimal value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_TOL_MAIS = @TT_TOL_MAIS WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_TOL_MAIS = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_TOL_MENOS(int tt_id, Decimal value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_TOL_MENOS = @TT_TOL_MENOS WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_TOL_MENOS = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_NORMA(int tt_id, string value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_NORMA = @TT_NORMA WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_NORMA = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_INICIO_PROCESSO(int tt_id, string value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_INICIO_PROCESSO = @TT_INICIO_PROCESSO WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_INICIO_PROCESSO = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTA_ID(int tt_id, int value)
        {
            this.Query = $@" UPDATE TipoTeste SET TA_ID = @TA_ID WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TA_ID = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_ID(int tt_id, string value)
        {
            this.Query = $@" UPDATE TipoTeste SET UNI_ID = @UNI_ID WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                UNI_ID = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_N_AMOSTRAS_P_TESTE(int tt_id, int value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_N_AMOSTRAS_P_TESTE = @TT_N_AMOSTRAS_P_TESTE WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_N_AMOSTRAS_P_TESTE = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_MAX_DEF_CRITICO(int tt_id, int value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_MAX_DEF_CRITICO = @TT_MAX_DEF_CRITICO WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_MAX_DEF_CRITICO = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTT_MAX_DEF_GRAVE(int tt_id, int value)
        {
            this.Query = $@" UPDATE TipoTeste SET TT_MAX_DEF_GRAVE = @TT_MAX_DEF_GRAVE WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_MAX_DEF_GRAVE = value,
                TT_ID = tt_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoTesteQuery(ITipoTesteEntity TipoTeste)
        {
            this.Query = $@" DELETE FROM TipoTeste WHERE TT_ID = @TT_ID ";
            this.Parameters = new
            {
                TT_ID = TipoTeste.TT_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration