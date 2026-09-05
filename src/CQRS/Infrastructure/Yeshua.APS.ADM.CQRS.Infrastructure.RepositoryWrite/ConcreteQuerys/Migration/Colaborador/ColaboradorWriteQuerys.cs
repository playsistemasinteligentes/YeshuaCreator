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
    public class ColaboradorQueryWrite : QueryBase, IColaboradorQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ColaboradorQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirColaboradorQuery(IColaboradorEntity Colaborador)
        {
            this.Query = $@" INSERT INTO [Colaborador] ([COL_CPF], [COL_NOME], [COL_NASCIMENTO], [COL_EMAIL], [COL_MATRICULA], [TURM_id], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@COL_CPF, @COL_NOME, @COL_NASCIMENTO, @COL_EMAIL, @COL_MATRICULA, @TURM_id, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                COL_CPF = Colaborador.COL_CPF,
                COL_NOME = Colaborador.COL_NOME,
                COL_NASCIMENTO = Colaborador.COL_NASCIMENTO,
                COL_EMAIL = Colaborador.COL_EMAIL,
                COL_MATRICULA = Colaborador.COL_MATRICULA,
                TURM_id = Colaborador.TURM_id,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateColaboradorQuery(IColaboradorEntity Colaborador)
        {
            this.Query = $@" UPDATE [Colaborador] SET [COL_NOME] = @COL_NOME, [COL_NASCIMENTO] = @COL_NASCIMENTO, [COL_EMAIL] = @COL_EMAIL, [COL_MATRICULA] = @COL_MATRICULA, [TURM_id] = @TURM_id, [Changed] = @Changed, [UserId] = @UserId WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                COL_NOME = Colaborador.COL_NOME,
                COL_NASCIMENTO = Colaborador.COL_NASCIMENTO,
                COL_EMAIL = Colaborador.COL_EMAIL,
                COL_MATRICULA = Colaborador.COL_MATRICULA,
                TURM_id = Colaborador.TURM_id,
                Changed = Colaborador.Changed,
                UserId = _executionContext.UserId,
                COL_CPF = Colaborador.COL_CPF,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOL_NOME(string col_cpf, string value)
        {
            this.Query = $@" UPDATE [Colaborador] SET [COL_NOME] = @COL_NOME WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                COL_NOME = value,
                COL_CPF = col_cpf,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOL_NASCIMENTO(string col_cpf, DateTime value)
        {
            this.Query = $@" UPDATE [Colaborador] SET [COL_NASCIMENTO] = @COL_NASCIMENTO WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                COL_NASCIMENTO = value,
                COL_CPF = col_cpf,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOL_EMAIL(string col_cpf, string value)
        {
            this.Query = $@" UPDATE [Colaborador] SET [COL_EMAIL] = @COL_EMAIL WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                COL_EMAIL = value,
                COL_CPF = col_cpf,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOL_MATRICULA(string col_cpf, string value)
        {
            this.Query = $@" UPDATE [Colaborador] SET [COL_MATRICULA] = @COL_MATRICULA WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                COL_MATRICULA = value,
                COL_CPF = col_cpf,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_id(string col_cpf, string value)
        {
            this.Query = $@" UPDATE [Colaborador] SET [TURM_id] = @TURM_id WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                TURM_id = value,
                COL_CPF = col_cpf,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string col_cpf, int value)
        {
            this.Query = $@" UPDATE [Colaborador] SET [TenantID] = @TenantID WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                TenantID = value,
                COL_CPF = col_cpf,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string col_cpf, bool value)
        {
            this.Query = $@" UPDATE [Colaborador] SET [Deleted] = @Deleted WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                Deleted = value,
                COL_CPF = col_cpf,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string col_cpf, DateTime value)
        {
            this.Query = $@" UPDATE [Colaborador] SET [Changed] = @Changed WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                Changed = value,
                COL_CPF = col_cpf,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string col_cpf, int value)
        {
            this.Query = $@" UPDATE [Colaborador] SET [UserId] = @UserId WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                UserId = value,
                COL_CPF = col_cpf,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteColaboradorQuery(IColaboradorEntity Colaborador)
        {
            this.Query = $@" DELETE FROM [Colaborador] WHERE [COL_CPF] = @COL_CPF ";
            this.Parameters = new
            {
                COL_CPF = Colaborador.COL_CPF,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration