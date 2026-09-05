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
    public class UsuarioQueryWrite : QueryBase, IUsuarioQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public UsuarioQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirUsuarioQuery(IUsuarioEntity Usuario)
        {
            this.Query = $@" INSERT INTO [Usuario] ([USE_NOME], [USE_EMAIL], [USE_SENHA], [TURM_ID], [USE_ATIVO], [USE_CODERP], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[USE_ID] VALUES(@USE_NOME, @USE_EMAIL, @USE_SENHA, @TURM_ID, @USE_ATIVO, @USE_CODERP, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                USE_NOME = Usuario.USE_NOME,
                USE_EMAIL = Usuario.USE_EMAIL,
                USE_SENHA = Usuario.USE_SENHA,
                TURM_ID = Usuario.TURM_ID,
                USE_ATIVO = Usuario.USE_ATIVO,
                USE_CODERP = Usuario.USE_CODERP,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUsuarioQuery(IUsuarioEntity Usuario)
        {
            this.Query = $@" UPDATE [Usuario] SET [USE_NOME] = @USE_NOME, [USE_EMAIL] = @USE_EMAIL, [USE_SENHA] = @USE_SENHA, [TURM_ID] = @TURM_ID, [USE_ATIVO] = @USE_ATIVO, [USE_CODERP] = @USE_CODERP, [Changed] = @Changed, [UserId] = @UserId WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                USE_NOME = Usuario.USE_NOME,
                USE_EMAIL = Usuario.USE_EMAIL,
                USE_SENHA = Usuario.USE_SENHA,
                TURM_ID = Usuario.TURM_ID,
                USE_ATIVO = Usuario.USE_ATIVO,
                USE_CODERP = Usuario.USE_CODERP,
                Changed = Usuario.Changed,
                UserId = _executionContext.UserId,
                USE_ID = Usuario.USE_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_NOME(int use_id, string value)
        {
            this.Query = $@" UPDATE [Usuario] SET [USE_NOME] = @USE_NOME WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                USE_NOME = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_EMAIL(int use_id, string value)
        {
            this.Query = $@" UPDATE [Usuario] SET [USE_EMAIL] = @USE_EMAIL WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                USE_EMAIL = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_SENHA(int use_id, string value)
        {
            this.Query = $@" UPDATE [Usuario] SET [USE_SENHA] = @USE_SENHA WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                USE_SENHA = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_ID(int use_id, string value)
        {
            this.Query = $@" UPDATE [Usuario] SET [TURM_ID] = @TURM_ID WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                TURM_ID = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ATIVO(int use_id, int value)
        {
            this.Query = $@" UPDATE [Usuario] SET [USE_ATIVO] = @USE_ATIVO WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                USE_ATIVO = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_CODERP(int use_id, string value)
        {
            this.Query = $@" UPDATE [Usuario] SET [USE_CODERP] = @USE_CODERP WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                USE_CODERP = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int use_id, int value)
        {
            this.Query = $@" UPDATE [Usuario] SET [TenantID] = @TenantID WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                TenantID = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int use_id, bool value)
        {
            this.Query = $@" UPDATE [Usuario] SET [Deleted] = @Deleted WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                Deleted = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int use_id, DateTime value)
        {
            this.Query = $@" UPDATE [Usuario] SET [Changed] = @Changed WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                Changed = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int use_id, int value)
        {
            this.Query = $@" UPDATE [Usuario] SET [UserId] = @UserId WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                UserId = value,
                USE_ID = use_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteUsuarioQuery(IUsuarioEntity Usuario)
        {
            this.Query = $@" DELETE FROM [Usuario] WHERE [USE_ID] = @USE_ID ";
            this.Parameters = new
            {
                USE_ID = Usuario.USE_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration