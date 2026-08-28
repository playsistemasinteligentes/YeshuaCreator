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
    public class RelatoriosQueryWrite : QueryBase, IRelatoriosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RelatoriosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRelatoriosQuery(IRelatoriosEntity Relatorios)
        {
            this.Query = $@" INSERT INTO Relatorios (REL_NOME_RELATORIO, REL_NOME_CAMPO, REL_TIPO_CAMPO, REL_POS_X, REL_POS_Y, REL_TAMANHO_FONTE, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.REL_ID VALUES(@REL_NOME_RELATORIO, @REL_NOME_CAMPO, @REL_TIPO_CAMPO, @REL_POS_X, @REL_POS_Y, @REL_TAMANHO_FONTE, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                REL_NOME_RELATORIO = Relatorios.REL_NOME_RELATORIO,
                REL_NOME_CAMPO = Relatorios.REL_NOME_CAMPO,
                REL_TIPO_CAMPO = Relatorios.REL_TIPO_CAMPO,
                REL_POS_X = Relatorios.REL_POS_X,
                REL_POS_Y = Relatorios.REL_POS_Y,
                REL_TAMANHO_FONTE = Relatorios.REL_TAMANHO_FONTE,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRelatoriosQuery(IRelatoriosEntity Relatorios)
        {
            this.Query = $@" UPDATE Relatorios SET REL_NOME_RELATORIO = @REL_NOME_RELATORIO, REL_NOME_CAMPO = @REL_NOME_CAMPO, REL_TIPO_CAMPO = @REL_TIPO_CAMPO, REL_POS_X = @REL_POS_X, REL_POS_Y = @REL_POS_Y, REL_TAMANHO_FONTE = @REL_TAMANHO_FONTE, Changed = @Changed, UserId = @UserId WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                REL_NOME_RELATORIO = Relatorios.REL_NOME_RELATORIO,
                REL_NOME_CAMPO = Relatorios.REL_NOME_CAMPO,
                REL_TIPO_CAMPO = Relatorios.REL_TIPO_CAMPO,
                REL_POS_X = Relatorios.REL_POS_X,
                REL_POS_Y = Relatorios.REL_POS_Y,
                REL_TAMANHO_FONTE = Relatorios.REL_TAMANHO_FONTE,
                Changed = Relatorios.Changed,
                UserId = _executionContext.UserId,
                REL_ID = Relatorios.REL_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREL_NOME_RELATORIO(int rel_id, string value)
        {
            this.Query = $@" UPDATE Relatorios SET REL_NOME_RELATORIO = @REL_NOME_RELATORIO WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                REL_NOME_RELATORIO = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREL_NOME_CAMPO(int rel_id, string value)
        {
            this.Query = $@" UPDATE Relatorios SET REL_NOME_CAMPO = @REL_NOME_CAMPO WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                REL_NOME_CAMPO = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREL_TIPO_CAMPO(int rel_id, string value)
        {
            this.Query = $@" UPDATE Relatorios SET REL_TIPO_CAMPO = @REL_TIPO_CAMPO WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                REL_TIPO_CAMPO = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREL_POS_X(int rel_id, int value)
        {
            this.Query = $@" UPDATE Relatorios SET REL_POS_X = @REL_POS_X WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                REL_POS_X = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREL_POS_Y(int rel_id, int value)
        {
            this.Query = $@" UPDATE Relatorios SET REL_POS_Y = @REL_POS_Y WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                REL_POS_Y = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREL_TAMANHO_FONTE(int rel_id, int value)
        {
            this.Query = $@" UPDATE Relatorios SET REL_TAMANHO_FONTE = @REL_TAMANHO_FONTE WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                REL_TAMANHO_FONTE = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int rel_id, int value)
        {
            this.Query = $@" UPDATE Relatorios SET TenantID = @TenantID WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                TenantID = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int rel_id, bool value)
        {
            this.Query = $@" UPDATE Relatorios SET Deleted = @Deleted WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                Deleted = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int rel_id, DateTime value)
        {
            this.Query = $@" UPDATE Relatorios SET Changed = @Changed WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                Changed = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int rel_id, int value)
        {
            this.Query = $@" UPDATE Relatorios SET UserId = @UserId WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                UserId = value,
                REL_ID = rel_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRelatoriosQuery(IRelatoriosEntity Relatorios)
        {
            this.Query = $@" DELETE FROM Relatorios WHERE REL_ID = @REL_ID ";
            this.Parameters = new
            {
                REL_ID = Relatorios.REL_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration