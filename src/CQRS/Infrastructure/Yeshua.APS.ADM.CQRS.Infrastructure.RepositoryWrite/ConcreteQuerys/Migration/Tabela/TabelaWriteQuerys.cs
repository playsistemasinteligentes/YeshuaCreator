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
    public class TabelaQueryWrite : QueryBase, ITabelaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TabelaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTabelaQuery(ITabelaEntity Tabela)
        {
            this.Query = $@" INSERT INTO [Tabela] ([CODIGO], [NOME], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[ID_TABELA] VALUES(@CODIGO, @NOME, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CODIGO = Tabela.CODIGO,
                NOME = Tabela.NOME,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTabelaQuery(ITabelaEntity Tabela)
        {
            this.Query = $@" UPDATE [Tabela] SET [CODIGO] = @CODIGO, [NOME] = @NOME, [Changed] = @Changed, [UserId] = @UserId WHERE [ID_TABELA] = @ID_TABELA ";
            this.Parameters = new
            {
                CODIGO = Tabela.CODIGO,
                NOME = Tabela.NOME,
                Changed = Tabela.Changed,
                UserId = _executionContext.UserId,
                ID_TABELA = Tabela.ID_TABELA,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCODIGO(int id_tabela, string value)
        {
            this.Query = $@" UPDATE [Tabela] SET [CODIGO] = @CODIGO WHERE [ID_TABELA] = @ID_TABELA ";
            this.Parameters = new
            {
                CODIGO = value,
                ID_TABELA = id_tabela,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNOME(int id_tabela, string value)
        {
            this.Query = $@" UPDATE [Tabela] SET [NOME] = @NOME WHERE [ID_TABELA] = @ID_TABELA ";
            this.Parameters = new
            {
                NOME = value,
                ID_TABELA = id_tabela,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id_tabela, int value)
        {
            this.Query = $@" UPDATE [Tabela] SET [TenantID] = @TenantID WHERE [ID_TABELA] = @ID_TABELA ";
            this.Parameters = new
            {
                TenantID = value,
                ID_TABELA = id_tabela,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id_tabela, bool value)
        {
            this.Query = $@" UPDATE [Tabela] SET [Deleted] = @Deleted WHERE [ID_TABELA] = @ID_TABELA ";
            this.Parameters = new
            {
                Deleted = value,
                ID_TABELA = id_tabela,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id_tabela, DateTime value)
        {
            this.Query = $@" UPDATE [Tabela] SET [Changed] = @Changed WHERE [ID_TABELA] = @ID_TABELA ";
            this.Parameters = new
            {
                Changed = value,
                ID_TABELA = id_tabela,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id_tabela, int value)
        {
            this.Query = $@" UPDATE [Tabela] SET [UserId] = @UserId WHERE [ID_TABELA] = @ID_TABELA ";
            this.Parameters = new
            {
                UserId = value,
                ID_TABELA = id_tabela,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTabelaQuery(ITabelaEntity Tabela)
        {
            this.Query = $@" DELETE FROM [Tabela] WHERE [ID_TABELA] = @ID_TABELA ";
            this.Parameters = new
            {
                ID_TABELA = Tabela.ID_TABELA,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration